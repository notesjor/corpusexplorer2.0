using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip italian words to the steam
  ///   This class is based on the italian stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/italian/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class ItalianStemmer : AbstractStemmer
  {
    private readonly char[] _acuteAccents;
    private readonly string[] _endingsStep0;
    private readonly string[] _endingsStep1;
    private readonly string[] _endingsStep2;
    private readonly string[] _endingsStep3A;
    private readonly char[] _graveAccents;

    /// <summary>
    ///   Create a new italian stemmer with default properties
    /// </summary>
    public ItalianStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'à', 'è', 'ì', 'ò', 'ù'};
      _acuteAccents = new[] {'á', 'é', 'í', 'ó', 'ú'};
      _graveAccents = new[] {'à', 'è', 'ì', 'ò', 'ù'};
      _endingsStep0 = new[]
      {
        "gliela",
        "gliele",
        "glieli",
        "glielo",
        "gliene",
        "mele",
        "celo",
        "celi",
        "cele",
        "cela",
        "tene",
        "telo",
        "teli",
        "tele",
        "tela",
        "mene",
        "melo",
        "meli",
        "vene",
        "mela",
        "cene",
        "vela",
        "vele",
        "veli",
        "velo",
        "sene",
        "gli",
        "vi",
        "ti",
        "si",
        "ne",
        "la",
        "lo",
        "li",
        "le",
        "ci",
        "mi"
      };
      _endingsStep1 = new[]
      {
        "atrice",
        "usione",
        "uzioni",
        "uzione",
        "azione",
        "amente",
        "imenti",
        "imento",
        "amenti",
        "amento",
        "azioni",
        "atrici",
        "usioni",
        "abile",
        "abili",
        "ibile",
        "ibili",
        "logie",
        "logia",
        "atori",
        "atore",
        "mente",
        "anti",
        "ante",
        "enza",
        "anze",
        "enze",
        "ichi",
        "iche",
        "anza",
        "ismi",
        "istì",
        "istè",
        "istà",
        "isti",
        "iste",
        "ista",
        "ismo",
        "ose",
        "osa",
        "osi",
        "oso",
        "ità",
        "ivo",
        "ico",
        "iva",
        "ice",
        "ica",
        "ici",
        "ive",
        "ivi"
      };
      _endingsStep2 = new[]
      {
        "irebbero",
        "erebbero",
        "eresti",
        "assimo",
        "iscono",
        "iranno",
        "iresti",
        "eranno",
        "erebbe",
        "essero",
        "iscano",
        "ireste",
        "assero",
        "eremmo",
        "irebbe",
        "ereste",
        "iremmo",
        "issero",
        "avamo",
        "avano",
        "avate",
        "ivate",
        "ivano",
        "ivamo",
        "eremo",
        "iremo",
        "erete",
        "erono",
        "evamo",
        "irono",
        "evano",
        "irete",
        "evate",
        "arono",
        "endi",
        "irei",
        "irai",
        "ende",
        "immo",
        "iamo",
        "Yamo",
        "erei",
        "enda",
        "ando",
        "emmo",
        "isca",
        "ammo",
        "asse",
        "isce",
        "isci",
        "erai",
        "isco",
        "assi",
        "endo",
        "erà",
        "irà",
        "evo",
        "evi",
        "irò",
        "eva",
        "ete",
        "erò",
        "ita",
        "ite",
        "iti",
        "ito",
        "iva",
        "ivi",
        "ere",
        "ivo",
        "ano",
        "avo",
        "avi",
        "ono",
        "uta",
        "ute",
        "ava",
        "ato",
        "ati",
        "ate",
        "ata",
        "uti",
        "uto",
        "ire",
        "are",
        "ar",
        "ir"
      };
      _endingsStep3A = new[] {"a", "e", "i", "o", "à", "è", "ì", "ò"};
    } // End of the constructor

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
        else if ((IsVowel(characters[0]) == false) &&
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

      // Replace all acute accents by grave accents
      for (var i = 0; i < chars.Length; i++)
        for (var j = 0; j < _acuteAccents.Length; j++)
          if (chars[i] == _acuteAccents[j])
            chars[i] = _graveAccents[j];

      // Put u after q, and u, i between vowels into upper case
      var charCount = chars.Length - 1;
      for (var i = 1; i < chars.Length; i++)
        if (i == charCount)
        {
          if ((chars[i] == 'u') &&
              (chars[i - 1] == 'q'))
            chars[i] = 'U';
        }
        else if ((chars[i] == 'u') &&
                 ((IsVowel(chars[i - 1]) && IsVowel(chars[i + 1])) || (chars[i - 1] == 'q')))
          chars[i] = 'U';
        else if ((chars[i] == 'i') &&
                 IsVowel(chars[i - 1]) &&
                 IsVowel(chars[i + 1]))
          chars[i] = 'I';

      // Get indexes for R1, R2 and RV
      var partIndexR = CalculateR1R2Rv(chars);

      // Recreate the word
      word = new string(chars);

      // Create strings
      var strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // **********************************************
      // Step 0
      // **********************************************
      foreach (var end in _endingsStep0.Where(end => word.EndsWith(end)))
      {
        if (strRv.EndsWith("ando" + end) ||
            strRv.EndsWith("endo" + end))
        {
          // (a) Delete the suffix
          word = word.Remove(word.Length - end.Length);
        }
        else if (strRv.EndsWith("ar" + end) ||
                 strRv.EndsWith("er" + end) ||
                 strRv.EndsWith("ir" + end))
        {
          // (b) Replace the suffix with e
          word = word.Remove(word.Length - end.Length);
          word += "e";
        }

        // Break out from the loop (the ending has been found)
        break;
      }
      // **********************************************

      // **********************************************
      // Step 1
      // **********************************************
      var strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      var strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      var endingRemovedStep1 = false;
      foreach (var end in _endingsStep1.Where(end => word.EndsWith(end)))
      {
        switch (end)
        {
          case "azione":
          case "azioni":
          case "atore":
          case "atori":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemovedStep1 = true;

              // If preceded by ic, delete if in R2
              if (strR2.EndsWith("ic" + end))
                word = word.Remove(word.Length - 2);
            }
            break;
          case "logia":
          case "logie":
            // Replace with log if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "log";
              endingRemovedStep1 = true;
            }
            break;
          case "uzione":
          case "uzioni":
          case "usione":
          case "usioni":
            // Replace with u if in R2 
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "u";
              endingRemovedStep1 = true;
            }
            break;
          case "enza":
          case "enze":
            // Replace with ente if in R2 
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "ente";
              endingRemovedStep1 = true;
            }
            break;
          case "amento":
          case "amenti":
          case "imento":
          case "imenti":
            // Delete if in RV
            if (strRv.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemovedStep1 = true;
            }
            break;
          case "amente":
            // Delete if in R1
            if (strR1.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemovedStep1 = true;

              // If preceded by iv, delete if in R2 (and if further preceded by at, delete if in R2)
              // If preceded by os, ic or abil, delete if in R2 
              if (strR2.EndsWith("iv" + end) ||
                  strR2.EndsWith("os" + end) ||
                  strR2.EndsWith("ic" + end))
              {
                word = word.Remove(word.Length - 2);

                if (strR2.EndsWith("ativ" + end))
                  word = word.Remove(word.Length - 2);
              }
              else if (strR2.EndsWith("abil" + end))
                word = word.Remove(word.Length - 2);
            }
            break;
          case "ità":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemovedStep1 = true;

              // If preceded by abil, ic or iv, delete if in R2
              if (strR2.EndsWith("abil" + end))
                word = word.Remove(word.Length - 4);
              else if (strR2.EndsWith("ic" + end) ||
                       strR2.EndsWith("iv" + end))
                word = word.Remove(word.Length - 2);
            }
            break;
          case "ivo":
          case "ivi":
          case "iva":
          case "ive":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemovedStep1 = true;

              // If preceded by at, delete if in R2 (and if further preceded by ic, delete if in R2)
              if (strR2.EndsWith("at" + end))
              {
                word = word.Remove(word.Length - 2);

                if (strR2.EndsWith("icat" + end))
                  word = word.Remove(word.Length - 2);
              }
            }
            break;
          default:
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemovedStep1 = true;
            }
            break;
        }

        // Break out from the loop
        break;
      }
      // **********************************************

      // **********************************************
      // Step 2
      // **********************************************
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      if (endingRemovedStep1 == false)
        foreach (var end in _endingsStep2.Where(end => strRv.EndsWith(end)))
        {
          word = word.Remove(word.Length - end.Length);
          break;
        }
      // **********************************************

      // **********************************************
      // Step 3
      // **********************************************
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // (a)
      foreach (var end in _endingsStep3A.Where(end => strRv.EndsWith(end)))
      {
        word = word.Remove(word.Length - end.Length);

        // Delete a preceding i if it is in RV
        if (strRv.EndsWith("i" + end))
          word = word.Remove(word.Length - 1);

        break;
      }

      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // (b)
      if (strRv.EndsWith("ch") ||
          strRv.EndsWith("gh"))
        word = word.Remove(word.Length - 1);
      // **********************************************

      // Return the word
      return word.ToLowerInvariant();
    } // End of the GetSteamWord method
  } // End of the class
} // End of the namespace