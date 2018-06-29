using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip romanian words to the steam
  ///   This class is based on the romanian stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/romanian/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class RomanianStemmer : AbstractStemmer
  {
    private readonly string[] _endingsStep0;
    private readonly string[] _endingsStep1;
    private readonly string[] _endingsStep2;
    private readonly string[] _endingsStep3;
    private readonly string[] _endingsStep4;

    /// <summary>
    ///   Create a new romanian stemmer with default properties
    /// </summary>
    public RomanianStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'ă', 'â', 'e', 'i', 'î', 'o', 'u'};
      _endingsStep0 = new[]
      {
        "iilor",
        "aţia",
        "aţie",
        "atei",
        "elor",
        "ilor",
        "iile",
        "ului",
        "iua",
        "aua",
        "ile",
        "ele",
        "iei",
        "ii",
        "ea",
        "ul"
      };
      _endingsStep1 = new[]
      {
        "abilitate",
        "abilităţi",
        "ibilitate",
        "abilitati",
        "abilităi",
        "ivităţi",
        "icităţi",
        "ivitate",
        "ivitati",
        "icitati",
        "icatori",
        "icitate",
        "itoare",
        "iţiune",
        "ivităi",
        "icator",
        "ătoare",
        "icităi",
        "atoare",
        "aţiune",
        "itori",
        "icală",
        "ativa",
        "icale",
        "icala",
        "itiva",
        "icivă",
        "icivi",
        "icive",
        "iciva",
        "itive",
        "ative",
        "ativi",
        "ativă",
        "itivi",
        "atori",
        "itivă",
        "ători",
        "icali",
        "ativ",
        "ical",
        "iciv",
        "ator",
        "ător",
        "itiv",
        "itor"
      };
      _endingsStep2 = new[]
      {
        "ibile",
        "abila",
        "abile",
        "abili",
        "abilă",
        "ibila",
        "itati",
        "ibili",
        "ibilă",
        "atori",
        "itate",
        "ităţi",
        "oasă",
        "oasa",
        "iuni",
        "abil",
        "ităi",
        "isme",
        "işti",
        "iune",
        "ator",
        "antă",
        "anti",
        "ante",
        "anta",
        "ibil",
        "ista",
        "iste",
        "isti",
        "oase",
        "istă",
        "ica",
        "uta",
        "ive",
        "ivi",
        "ivă",
        "ant",
        "oşi",
        "osi",
        "iva",
        "ata",
        "ism",
        "ist",
        "ică",
        "ici",
        "ice",
        "ată",
        "ate",
        "ite",
        "iti",
        "ită",
        "ita",
        "ati",
        "ute",
        "uti",
        "ută",
        "iv",
        "os",
        "ic",
        "it",
        "ut",
        "at"
      };
      _endingsStep3 = new[]
      {
        "seserăţi",
        "âserăţi",
        "seserăm",
        "userăţi",
        "iserăţi",
        "aserăţi",
        "iserăm",
        "seseşi",
        "userăm",
        "serăţi",
        "âserăm",
        "seseră",
        "aserăm",
        "urăţi",
        "irăţi",
        "serăm",
        "ârăţi",
        "aseşi",
        "âseră",
        "useşi",
        "aseră",
        "iseşi",
        "iseră",
        "useră",
        "ească",
        "âseşi",
        "arăţi",
        "sesem",
        "usem",
        "iaţi",
        "indu",
        "âsem",
        "seră",
        "irăm",
        "ăşte",
        "ăşti",
        "sese",
        "isem",
        "urăm",
        "eaţi",
        "eşte",
        "eşti",
        "arăm",
        "asem",
        "ârăm",
        "seşi",
        "ează",
        "ându",
        "âse",
        "use",
        "ând",
        "aţi",
        "ind",
        "ise",
        "eţi",
        "âre",
        "iţi",
        "ăsc",
        "ase",
        "âţi",
        "âră",
        "ere",
        "âşi",
        "esc",
        "iră",
        "işi",
        "ură",
        "sei",
        "uşi",
        "ară",
        "ire",
        "aşi",
        "ezi",
        "iau",
        "are",
        "iai",
        "iam",
        "eau",
        "eze",
        "eai",
        "eam",
        "ăm",
        "em",
        "im",
        "âm",
        "âi",
        "ui",
        "ez",
        "ea",
        "au",
        "ai",
        "am",
        "se",
        "ia"
      };
      _endingsStep4 = new[] {"ie", "a", "e", "i", "ă"};
    } // End of the constructor

    /// <summary>
    ///   Get the steam word from a specific word
    /// </summary>
    /// <param name="word">The word to strip</param>
    /// <returns>The stripped word</returns>
    // ReSharper disable once MemberCanBeProtected.Global
    public override string GetSteamWord(string word)
    {
      // Make sure that the word is in lower case characters
      word = word.ToLowerInvariant();

      // Create a char array
      var chars = word.ToCharArray();

      // First, i and u between vowels are put into upper case (so that they are treated as consonants)
      var charCount = chars.Length - 1;
      for (var i = 1; i < charCount; i++)
        if (chars[i] == 'i' &&
            IsVowel(chars[i - 1]) &&
            IsVowel(chars[i + 1]))
          chars[i] = 'I';
        else if (chars[i] == 'u' &&
                 IsVowel(chars[i - 1]) &&
                 IsVowel(chars[i + 1]))
          chars[i] = 'U';

      // Get indexes for R1, R2 and RV
      var partIndexR = CalculateR1R2Rv(chars);

      // Recreate the word
      word = new string(chars);

      // Create strings
      var strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      // **********************************************
      // Step 0
      // **********************************************
      foreach (var end in _endingsStep0.Where(end => word.EndsWith(end)))
      {
        switch (end)
        {
          case "ul":
          case "ului":
            if (strR1.EndsWith(end))
              word = word.Remove(word.Length - end.Length);
            break;
          case "aua":
            if (strR1.EndsWith(end))
            {
              // Replace with a
              word = word.Remove(word.Length - end.Length);
              word += "a";
            }

            break;
          case "ea":
          case "ele":
          case "elor":
            if (strR1.EndsWith(end))
            {
              // Replace with e
              word = word.Remove(word.Length - end.Length);
              word += "e";
            }

            break;
          case "ile":
            if (strR1.EndsWith(end) &&
                word.EndsWith("ab" + end) == false)
            {
              // Replace with i if not preceded by ab
              word = word.Remove(word.Length - end.Length);
              word += "i";
            }

            break;
          case "atei":
            if (strR1.EndsWith(end))
            {
              // Replace with at
              word = word.Remove(word.Length - end.Length);
              word += "at";
            }

            break;
          case "aţie":
          case "aţia":
            if (strR1.EndsWith(end))
            {
              // Replace with aţi
              word = word.Remove(word.Length - end.Length);
              word += "aţi";
            }

            break;
          default:
            if (strR1.EndsWith(end))
            {
              // Replace with i
              word = word.Remove(word.Length - end.Length);
              word += "i";
            }

            break;
        }

        // Break out from the loop (the ending has been found)
        break;
      }
      // **********************************************

      // **********************************************
      // Step 1
      // **********************************************
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      var endingRemoved = false;
      for (var i = 0; i < _endingsStep1.Length; i++)
      {
        // A boolean that indicates if the loop should be restarted
        var restartLoop = false;

        // Get the ending
        var end = _endingsStep1[i];

        // Check if word ends with some of the predefined step 1 endings
        if (!word.EndsWith(end))
          continue;
        switch (end)
        {
          case "abilitate":
          case "abilitati":
          case "abilităi":
          case "abilităţi":
            if (strR1.EndsWith(end))
            {
              // Replace with abil
              word = word.Remove(word.Length - end.Length);
              word += "abil";
              endingRemoved = true;
              restartLoop = true;
            }

            break;
          case "ibilitate":
            if (strR1.EndsWith(end))
            {
              // Replace with ibil
              word = word.Remove(word.Length - end.Length);
              word += "ibil";
              endingRemoved = true;
              restartLoop = true;
            }

            break;
          case "ivitate":
          case "ivitati":
          case "ivităi":
          case "ivităţi":
            if (strR1.EndsWith(end))
            {
              // Replace with iv
              word = word.Remove(word.Length - end.Length);
              word += "iv";
              endingRemoved = true;
              restartLoop = true;
            }

            break;
          case "ativ":
          case "ativa":
          case "ative":
          case "ativi":
          case "ativă":
          case "aţiune":
          case "atoare":
          case "ator":
          case "atori":
          case "ătoare":
          case "ător":
          case "ători":
            if (strR1.EndsWith(end))
            {
              // Replace with at
              word = word.Remove(word.Length - end.Length);
              word += "at";
              endingRemoved = true;
              restartLoop = true;
            }

            break;
          case "itiv":
          case "itiva":
          case "itive":
          case "itivi":
          case "itivă":
          case "iţiune":
          case "itoare":
          case "itor":
          case "itori":
            if (strR1.EndsWith(end))
            {
              // Replace with it
              word = word.Remove(word.Length - end.Length);
              word += "it";
              endingRemoved = true;
              restartLoop = true;
            }

            break;
          default:
            if (strR1.EndsWith(end))
            {
              // Replace with ic
              word = word.Remove(word.Length - end.Length);
              word += "ic";
              endingRemoved = true;
              restartLoop = true;
            }

            break;
        }

        // Check if we should restart the loop
        if (!restartLoop)
          continue;
        // Restart the loop
        strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
        i = 0;
      }
      // **********************************************

      // **********************************************
      // Step 2
      // **********************************************
      var strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      foreach (var end in _endingsStep2.Where(end => word.EndsWith(end)))
      {
        switch (end)
        {
          case "iune":
          case "iuni":
            // Delete if in R2 and preceded by ţ, and replace the ţ by t.
            if (strR2.EndsWith(end) &&
                word.EndsWith("ţ" + end))
            {
              word = word.Remove(word.Length - 5);
              word += "t";
              endingRemoved = true;
            }

            break;
          case "ism":
          case "isme":
          case "ist":
          case "ista":
          case "iste":
          case "isti":
          case "istă":
          case "işti":
            if (strR2.EndsWith(end))
            {
              // Replace with ist
              word = word.Remove(word.Length - end.Length);
              word += "ist";
              endingRemoved = true;
            }

            break;
          default:
            if (strR2.EndsWith(end))
            {
              // Delete
              word = word.Remove(word.Length - end.Length);
              endingRemoved = true;
            }

            break;
        }

        // Break out from the loop
        break;
      }
      // **********************************************

      // **********************************************
      // Step 3
      // **********************************************
      var strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // Do step 3 if no suffix was removed either by step 1 or step 2
      if (endingRemoved == false)
        foreach (var end in _endingsStep3.Where(end => word.EndsWith(end)))
        {
          if (end == "ăm" ||
              end == "aţi" ||
              end == "em" ||
              end == "eţi" ||
              end == "im" ||
              end == "iţi" ||
              end == "âm" ||
              end == "âţi" ||
              end == "seşi" ||
              end == "serăm" ||
              end == "serăţi" ||
              end == "seră" ||
              end == "sei" ||
              end == "se" ||
              end == "sesem" ||
              end == "seseşi" ||
              end == "sese" ||
              end == "seserăm" ||
              end == "seserăţi" ||
              end == "seseră")
          {
            // Delete if in RV
            if (!strRv.EndsWith(end))
              continue;
            word = word.Remove(word.Length - end.Length);
            break;
          }

          // Delete if preceded in RV by a consonant or u
          if (!strRv.EndsWith(end))
            continue;
          var before = strRv.Length > end.Length ? strRv[strRv.Length - end.Length - 1] : 'a';
          if (IsVowel(before) == false ||
              before == 'u')
            word = word.Remove(word.Length - end.Length);

          // Break out from the loop
          break;
        }
      // **********************************************

      // **********************************************
      // Step 4
      // **********************************************
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      foreach (var end in _endingsStep4.Where(end => word.EndsWith(end)))
      {
        // Delete if in RV
        if (strRv.EndsWith(end))
          word = word.Remove(word.Length - end.Length);

        // Break out from the loop
        break;
      }
      // **********************************************

      // Return the word
      return word.ToLowerInvariant();
    } // End of the GetSteamWord method

    /// <summary>
    ///   Calculate the R1, R2 and RV part for a word
    /// </summary>
    /// <param name="characters">The char array to calculate indexes for</param>
    /// <returns>An int array with the r1, r2 and rV index</returns>
    private int[] CalculateR1R2Rv(char[] characters)
    {
      // Create ints
      var r1 = characters.Length;
      var r2 = characters.Length;
      var rV = characters.Length;

      // Calculate RV
      // If the second letter is a consonant, RV is the region after the next following vowel, or if the first two letters are vowels, 
      // RV is the region after the next consonant, and otherwise (consonant-vowel case) RV is the region after the third letter. 
      // But RV is the end of the word if these positions cannot be found.
      if (characters.Length > 3)
        if (IsVowel(characters[1]) == false)
          for (var i = 2; i < characters.Length; i++)
          {
            if (!IsVowel(characters[i]))
              continue;
            rV = i + 1;
            break;
          }
        else if (IsVowel(characters[0]) &&
                 IsVowel(characters[1]))
          for (var i = 2; i < characters.Length; i++)
          {
            if (IsVowel(characters[i]))
              continue;
            rV = i + 1;
            break;
          }
        else if (IsVowel(characters[0]) == false &&
                 IsVowel(characters[1]))
          rV = 3;

      // Calculate R1
      for (var i = 1; i < characters.Length; i++)
      {
        if (IsVowel(characters[i]) ||
            !IsVowel(characters[i - 1]))
          continue;
        // Set the r1 index
        r1 = i + 1;
        break;
      }

      // Calculate R2
      for (var i = r1; i < characters.Length; ++i)
      {
        if (IsVowel(characters[i]) ||
            !IsVowel(characters[i - 1]))
          continue;
        // Set the r2 index
        r2 = i + 1;
        break;
      }

      // Return the int array
      return new[] {r1, r2, rV};
    } // End of the CalculateR1R2RV method
  } // End of the class
} // End of the namespace