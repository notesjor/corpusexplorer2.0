using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip french words to the steam
  ///   This class is based on the french stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/french/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class FrenchStemmer : AbstractStemmer
  {
    private readonly string[] _endingsStep1;
    private readonly string[] _endingsStep2A;
    private readonly string[] _endingsStep2B;

    /// <summary>
    ///   Create a new french stemmer with default properties
    /// </summary>
    public FrenchStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'y', 'â', 'à', 'ë', 'é', 'ê', 'è', 'ï', 'î', 'ô', 'û', 'ù'};
      _endingsStep1 = new[]
      {
        "issements",
        "issement",
        "atrices",
        "atrice",
        "ateurs",
        "ations",
        "logies",
        "usions",
        "utions",
        "ements",
        "amment",
        "emment",
        "ances",
        "iqUes",
        "ismes",
        "ables",
        "istes",
        "ateur",
        "ation",
        "logie",
        "usion",
        "ution",
        "ences",
        "ement",
        "euses",
        "ments",
        "ance",
        "iqUe",
        "isme",
        "able",
        "iste",
        "ence",
        "ités",
        "ives",
        "eaux",
        "euse",
        "ment",
        "eux",
        "ité",
        "ive",
        "ifs",
        "aux",
        "if"
      };
      _endingsStep2A = new[]
      {
        "issantes",
        "issaIent",
        "issante",
        "issions",
        "issants",
        "iraIent",
        "issant",
        "irions",
        "issiez",
        "issons",
        "issais",
        "issait",
        "issent",
        "iriez",
        "isses",
        "irais",
        "iront",
        "irait",
        "issez",
        "irons",
        "irent",
        "irez",
        "iras",
        "îmes",
        "îtes",
        "isse",
        "irai",
        "ira",
        "ies",
        "ît",
        "is",
        "ir",
        "ie",
        "it",
        "i"
      };
      _endingsStep2B = new[]
      {
        "eraIent",
        "assions",
        "assiez",
        "erions",
        "assent",
        "erait",
        "èrent",
        "erons",
        "antes",
        "eriez",
        "asses",
        "eront",
        "erais",
        "aIent",
        "asse",
        "ants",
        "ante",
        "erai",
        "eras",
        "âtes",
        "erez",
        "âmes",
        "ions",
        "ait",
        "ant",
        "era",
        "iez",
        "ées",
        "ais",
        "ez",
        "ât",
        "ai",
        "er",
        "as",
        "és",
        "ée",
        "é",
        "a"
      };
    } // End of the constructor
    // End of the GetSteamWords method

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

      // Create a word from the characters array
      var word = new string(characters);

      // Calculate RV
      if ((characters.Length > 3) &&
          ((IsVowel(characters[0]) && IsVowel(characters[1]))
           || word.StartsWith("par") || word.StartsWith("col") || word.StartsWith("tap")))
        rV = 3;
      else
        for (var i = 1; i < characters.Length; i++)
        {
          if (!IsVowel(characters[i]))
            continue;
          // Set the rV index
          rV = i + 1;
          break;
        }

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
    // ReSharper disable once UnusedMember.Global
    public override string GetSteamWord(string word)
    {
      // Make sure that the word is in lower case characters
      word = word.ToLowerInvariant();

      // Create a char array that can be used over an over again
      var chars = word.ToCharArray();

      // Put into upper case u or i preceded and followed by a vowel, and y preceded or followed by a vowel. u after q is also put into upper case.
      var charCount = chars.Length - 1;
      for (var i = 0; i < chars.Length; i++)
        if (i == 0)
        {
          if ((chars.Length > 1) &&
              (chars[i] == 'y') &&
              IsVowel(chars[i + 1]))
            chars[i] = 'Y';
        }
        else if (i == charCount)
        {
          if ((chars[i] == 'u') &&
              (chars[i - 1] == 'q'))
            chars[i] = 'U';
        }
        else if ((chars[i] == 'y') &&
                 (IsVowel(chars[i - 1]) || IsVowel(chars[i + 1])))
          chars[i] = 'Y';
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
      var strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      var strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";
      var strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // A boolean that indicates if the word has been altered
      var wordIsAltered = false;

      // **********************************************
      // Step 1
      // **********************************************
      var doStep2 = true;
      foreach (var end in _endingsStep1.Where(end => word.EndsWith(end)))
      {
        switch (end)
        {
          case "ance":
          case "iqUe":
          case "isme":
          case "able":
          case "iste":
          case "eux":
          case "ances":
          case "iqUes":
          case "ismes":
          case "ables":
          case "istes":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "atrice":
          case "ateur":
          case "ation":
          case "atrices":
          case "ateurs":
          case "ations":
            // Delete if in R2
            // If preceded by ic, delete if in R2, else replace by iqU
            if (strR2.EndsWith(end))
            {
              // Remove the ending
              word = word.Remove(word.Length - end.Length);

              // Do further processing
              if (strR2.EndsWith("ic" + end))
                word = word.Remove(word.Length - 2);
              else if (word.EndsWith("ic"))
              {
                word = word.Remove(word.Length - 2);
                word += "iqU";
              }

              // Break out from the loop and indicate that step 2 not should be done
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "logie":
          case "logies":
            // Replace with log if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "log";
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "usion":
          case "ution":
          case "usions":
          case "utions":
            // Replace with u if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "u";
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "ences":
          case "ence":
            // Replace with ent if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "ent";
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "ements":
          case "ement":
            // Delete if in RV
            if (strRv.EndsWith(end))
            {
              // Delete if in RV
              word = word.Remove(word.Length - end.Length);

              if (strR2.EndsWith("iv" + end))
                // If preceded by iv, delete if in R2 (and if further preceded by at, delete if in R2)
              {
                word = word.Remove(word.Length - 2);

                if (strR2.EndsWith("ativ" + end))
                  word = word.Remove(word.Length - 2);
              }
              else if (word.EndsWith("eus")) // If preceded by eus, delete if in R2, else replace by eux if in R1
              {
                if (strR2.EndsWith("eus" + end))
                  word = word.Remove(word.Length - 3);
                else if (strR1.EndsWith("eus" + end))
                {
                  word = word.Remove(word.Length - 3);
                  word += "eux";
                }
              }
              else if (strR2.EndsWith("abl" + end) ||
                       strR2.EndsWith("iqU" + end))
                // If preceded by abl or iqU, delete if in R2
                word = word.Remove(word.Length - 3);
              else if (strRv.EndsWith("ièr" + end) ||
                       strRv.EndsWith("Ièr" + end))
                // If preceded by ièr or Ièr, replace by i if in RV
              {
                word = word.Remove(word.Length - 3);
                word += "i";
              }

              // Break out from the loop and indicate that step 2 not should be done
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "ités":
          case "ité":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);

              if (word.EndsWith("abil")) // If preceded by abil, delete if in R2, else replace by abl
              {
                word = word.Remove(word.Length - 4);

                if (strR2.EndsWith("abil" + end) == false)
                  word += "abl";
              }
              else if (word.EndsWith("ic")) // If preceded by ic, delete if in R2, else replace by iqU
              {
                word = word.Remove(word.Length - 2);

                if (strR2.EndsWith("ic" + end) == false)
                  word += "iqU";
              }
              else if (strR2.EndsWith("iv" + end)) // If preceded by iv, delete if in R2   
                word = word.Remove(word.Length - 2);

              // Break out from the loop and indicate that step 2 not should be done
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "ives":
          case "ifs":
          case "ive":
          case "if":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);

              if (word.EndsWith("at"))
                // If preceded by at, delete if in R2 (and if further preceded by ic, delete if in R2, else replace by iqU)
              {
                if (strR2.EndsWith("at" + end))
                  word = word.Remove(word.Length - 2);

                if (word.EndsWith("ic"))
                {
                  word = word.Remove(word.Length - 2);

                  if (strR2.EndsWith("icat" + end) == false)
                    word += "iqU";
                }
              }

              // Break out from the loop and indicate that step 2 not should be done
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "eaux":
            // Replace with eau
            word = word.Remove(word.Length - 1);
            doStep2 = false;
            wordIsAltered = true;
            break;
          case "aux":
            // Replace with al if in R1
            if (strR1.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "al";
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "euses":
          case "euse":
            // Delete if in R2, else replace by eux if in R1
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              doStep2 = false;
              wordIsAltered = true;
            }
            else if (strR1.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "eux";
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "issements":
          case "issement":
            // Delete if in R1 and preceded by a non-vowel
            if ((word.Length > end.Length) &&
                strR1.EndsWith(end) &&
                (IsVowel(word[word.Length - end.Length - 1]) == false))
            {
              word = word.Remove(word.Length - end.Length);
              doStep2 = false;
              wordIsAltered = true;
            }
            break;
          case "amment":
            // Replace with ant if in RV
            if (strRv.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "ant";
              wordIsAltered = true;
            }
            break;
          case "emment":
            // Replace with ent if in RV
            if (strRv.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "ent";
              wordIsAltered = true;
            }
            break;
          case "ments":
          case "ment":
            // Delete if preceded by a vowel in RV
            if ((strRv.Length > end.Length) &&
                strRv.EndsWith(end) &&
                IsVowel(strRv[strRv.Length - end.Length - 1]))
            {
              word = word.Remove(word.Length - end.Length);
              wordIsAltered = true;
            }
            break;
        }

        // Break out from the loop (the ending has been found)
        break;
      }
      // **********************************************

      // **********************************************
      // Step 2
      // **********************************************

      // Recreate strings
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      if (doStep2)
      {
        // Reset the word is altered boolean
        wordIsAltered = false;

        foreach (
          var end in
          _endingsStep2A.Where(
            end =>
              (strRv.Length > end.Length) && strRv.EndsWith(end) &&
              (IsVowel(strRv[strRv.Length - end.Length - 1]) == false)))
        {
          word = word.Remove(word.Length - end.Length);
          doStep2 = false;
          wordIsAltered = true;
          break;
        }
      }

      if (doStep2)
        foreach (var end in _endingsStep2B.Where(end => strRv.EndsWith(end)))
        {
          switch (end)
          {
            case "ions":
              if (strR2.EndsWith(end))
              {
                word = word.Remove(word.Length - end.Length);
                wordIsAltered = true;
              }
              break;
            case "é":
            case "ée":
            case "ées":
            case "és":
            case "èrent":
            case "er":
            case "era":
            case "erai":
            case "eraIent":
            case "erais":
            case "erait":
            case "eras":
            case "erez":
            case "eriez":
            case "erions":
            case "erons":
            case "eront":
            case "ez":
            case "iez":
              word = word.Remove(word.Length - end.Length);
              wordIsAltered = true;
              break;
            case "âmes":
            case "ât":
            case "âtes":
            case "a":
            case "ai":
            case "aIent":
            case "ais":
            case "ait":
            case "ant":
            case "ante":
            case "antes":
            case "ants":
            case "as":
            case "asse":
            case "assent":
            case "asses":
            case "assiez":
            case "assions":
              // Delete
              word = word.Remove(word.Length - end.Length);

              // Delete the preceding e
              if ((strRv.Length > end.Length) &&
                  (strRv[strRv.Length - end.Length - 1] == 'e'))
                word = word.Remove(word.Length - 1);

              // The word has been altered
              wordIsAltered = true;
              break;
          }

          // Break out from the loop (the ending has been found)
          break;
        }
      // **********************************************

      // **********************************************
      // Step 3
      // **********************************************

      // Recreate strings
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      if (wordIsAltered)
      {
        // Get the final character
        var finalChar = word.Length > 0 ? word[word.Length - 1] : '\0';

        switch (finalChar)
        {
          case 'Y':
            word = word.Remove(word.Length - 1);
            word += "i";
            break;
          case 'ç':
            word = word.Remove(word.Length - 1);
            word += "c";
            break;
        }
      }
      // **********************************************

      // **********************************************
      // Step 4
      // **********************************************
      if (wordIsAltered == false)
      {
        // Get the final character
        var finalChar = word.Length > 0 ? word[word.Length - 1] : '\0';
        var precedingChar = word.Length > 1 ? word[word.Length - 2] : '\0';

        // If the word ends s, not preceded by a, i, o, u, è or s, delete it. 
        if ((finalChar == 's') &&
            (precedingChar != 'a') &&
            (precedingChar != 'i') &&
            (precedingChar != 'o')
            &&
            (precedingChar != 'u') &&
            (precedingChar != 'è') &&
            (precedingChar != 's') &&
            (precedingChar != '\0'))
          word = word.Remove(word.Length - 1);

        // Recreate strings
        strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";
        strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

        if (strRv.EndsWith("Ière") ||
            strRv.EndsWith("ière"))
        {
          // Replace with i
          word = word.Remove(word.Length - 4);
          word += "i";
        }
        else if (strRv.EndsWith("Ier") ||
                 strRv.EndsWith("ier"))
        {
          // Replace with i
          word = word.Remove(word.Length - 3);
          word += "i";
        }
        else if ((strRv.EndsWith("sion") || strRv.EndsWith("tion")) &&
                 strR2.EndsWith("ion"))
        {
          // Delete ion
          word = word.Remove(word.Length - 3);
        }
        else if (strRv.EndsWith("e"))
          word = word.Remove(word.Length - 1);
        else if (strRv.EndsWith("ë") &&
                 word.EndsWith("guë"))
          word = word.Remove(word.Length - 1);
      }
      // **********************************************

      // **********************************************
      // Step 5
      // **********************************************
      // If the word ends enn, onn, ett, ell or eill, delete the last letter
      if (word.EndsWith("eill") ||
          word.EndsWith("ell") ||
          word.EndsWith("ett") ||
          word.EndsWith("onn") ||
          word.EndsWith("enn"))
        word = word.Remove(word.Length - 1);

      // **********************************************

      // **********************************************
      // Step 6
      // **********************************************
      // If the words ends é or è followed by at least one non-vowel, remove the accent from the e.
      chars = word.ToCharArray();
      var startIndex = chars.Length - 1;
      var numberOfNonVowels = 0;
      var steps = 0;
      for (var i = startIndex; i >= 0; i--)
      {
        if (((chars[i] == 'é') || (chars[i] == 'è')) &&
            (numberOfNonVowels > 0) &&
            (numberOfNonVowels == steps))
        {
          chars[i] = 'e';
          word = new string(chars);
          break;
        }

        if (IsVowel(chars[i]) == false)
          numberOfNonVowels += 1;

        steps++;
      }
      // **********************************************

      // Return the word
      return word.ToLowerInvariant();
    } // End of the GetSteamWord method
  } // End of the class
} // End of the namespace