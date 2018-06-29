using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip portuguese words to the steam
  ///   This class is based on the portuguese stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/portuguese/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class PortugueseStemmer : AbstractStemmer
  {
    private readonly string[] _endingsStep1;
    private readonly string[] _endingsStep2;
    private readonly string[] _endingsStep4;

    /// <summary>
    ///   Create a new portuguese stemmer with default properties
    /// </summary>
    public PortugueseStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú', 'â', 'ê', 'ô'};
      _endingsStep1 = new[]
      {
        "imentos",
        "uciones",
        "amentos",
        "idades",
        "amento",
        "imento",
        "aço~es",
        "adores",
        "ância",
        "amente",
        "ências",
        "adoras",
        "logías",
        "aça~o",
        "ución",
        "logía",
        "mente",
        "antes",
        "idade",
        "istas",
        "ismos",
        "adora",
        "ência",
        "ador",
        "ezas",
        "ante",
        "iras",
        "ismo",
        "ivas",
        "osas",
        "osos",
        "icas",
        "icos",
        "ivos",
        "ista",
        "ível",
        "ável",
        "iva",
        "ivo",
        "osa",
        "oso",
        "ira",
        "ica",
        "ico",
        "eza"
      };

      _endingsStep2 = new[]
      {
        "íssemos",
        "iríamos",
        "ássemos",
        "êssemos",
        "eríamos",
        "aríamos",
        "ísseis",
        "ésseis",
        "ásseis",
        "éramos",
        "iríeis",
        "eríeis",
        "iremos",
        "eremos",
        "aremos",
        "aríeis",
        "ávamos",
        "íramos",
        "áramos",
        "era~o",
        "issem",
        "essem",
        "armos",
        "íamos",
        "ara~o",
        "asses",
        "ira~o",
        "arias",
        "áveis",
        "ermos",
        "irmos",
        "assem",
        "ireis",
        "íreis",
        "ereis",
        "éreis",
        "areis",
        "áreis",
        "iriam",
        "eriam",
        "ariam",
        "erias",
        "irias",
        "ardes",
        "erdes",
        "istes",
        "estes",
        "astes",
        "isses",
        "esses",
        "irdes",
        "irás",
        "eres",
        "ares",
        "ires",
        "aram",
        "esse",
        "asse",
        "avas",
        "aria",
        "eras",
        "erás",
        "aras",
        "arás",
        "iras",
        "íeis",
        "ados",
        "iria",
        "idas",
        "adas",
        "irei",
        "erei",
        "arei",
        "eria",
        "idos",
        "ámos",
        "amos",
        "indo",
        "endo",
        "ando",
        "iste",
        "este",
        "emos",
        "imos",
        "aste",
        "irem",
        "erem",
        "arem",
        "isse",
        "avam",
        "iram",
        "eram",
        "ada",
        "ais",
        "ará",
        "ida",
        "eis",
        "ias",
        "ara",
        "iam",
        "era",
        "irá",
        "ido",
        "ado",
        "ava",
        "ira",
        "erá",
        "ou",
        "iu",
        "ia",
        "am",
        "ei",
        "eu",
        "ar",
        "er",
        "ir",
        "as",
        "es",
        "is",
        "em"
      };

      _endingsStep4 = new[] {"os", "a", "i", "o", "á", "í", "ó"};
    } // End of the constructor

    /// <summary>
    ///   Get the steam word from a specific word
    /// </summary>
    /// <param name="word">The word to strip</param>
    /// <returns>The stripped word</returns>
    // ReSharper disable once MemberCanBeProtected.Global
    public override string GetSteamWord(string word)
    {
      // Make sure that the word is in lower case letters
      word = word.ToLowerInvariant();

      // Replace ã and õ by a~ and o~ in the word
      word = word.Replace("ã", "a~");
      word = word.Replace("õ", "o~");

      // Get indexes for R1, R2 and RV
      var partIndexR = CalculateR1R2Rv(word.ToCharArray());

      // Create strings
      var strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      var strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";
      var strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // **********************************************
      // Step 1
      // **********************************************
      var endingRemoved = false;
      foreach (var end in _endingsStep1.Where(end => word.EndsWith(end)))
      {
        switch (end)
        {
          case "logías":
          case "logía":
            // Replace with log if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "log";
              endingRemoved = true;
            }

            break;
          case "uciones":
          case "ución":
            // Replace with u if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "u";
              endingRemoved = true;
            }

            break;
          case "ências":
          case "ência":
            // Replace with ente if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "ente";
              endingRemoved = true;
            }

            break;
          case "amente":
            // Delete if in R1
            if (strR1.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemoved = true;

              // If preceded by iv, delete if in R2 (and if further preceded by at, delete if in R2)
              // If preceded by os, ic or ad, delete if in R2
              if (strR2.EndsWith("iv" + end) ||
                  strR2.EndsWith("os" + end) ||
                  strR2.EndsWith("ic" + end) ||
                  strR2.EndsWith("ad" + end))
              {
                word = word.Remove(word.Length - 2);

                if (strR2.EndsWith("ativ" + end))
                  word = word.Remove(word.Length - 2);
              }
            }

            break;
          case "mente":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemoved = true;

              // If preceded by ante, avel or ível, delete if in R2
              if (strR2.EndsWith("ante" + end) ||
                  strR2.EndsWith("avel" + end) ||
                  strR2.EndsWith("ível" + end))
                word = word.Remove(word.Length - 4);
            }

            break;
          case "idades":
          case "idade":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemoved = true;

              // If preceded by abil, ic or iv, delete if in R2
              if (strR2.EndsWith("abil" + end))
                word = word.Remove(word.Length - 4);
              else if (strR2.EndsWith("ic" + end) ||
                       strR2.EndsWith("iv" + end))
                word = word.Remove(word.Length - 2);
            }

            break;
          case "ivos":
          case "ivas":
          case "ivo":
          case "iva":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemoved = true;

              // If preceded by at, delete if in R2
              if (strR2.EndsWith("at" + end))
                word = word.Remove(word.Length - 2);
            }

            break;
          case "iras":
          case "ira":
            // Replace with ir if in RV and preceded by e
            if (strRv.EndsWith(end) &&
                word.EndsWith("e" + end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "ir";
              endingRemoved = true;
            }

            break;
          default:
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemoved = true;
            }

            break;
        }

        // Break out from the loop if a ending has been removed
        if (endingRemoved)
          break;
      }
      // **********************************************

      // **********************************************
      // Step 2
      // **********************************************
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // Do step 2 if no ending was removed in step 1
      if (endingRemoved == false)
        foreach (var end in _endingsStep2.Where(end => word.EndsWith(end)).Where(end => strRv.EndsWith(end)))
        {
          word = word.Remove(word.Length - end.Length);
          endingRemoved = true;
          break;
        }
      // **********************************************

      // **********************************************
      // Step 3
      // **********************************************
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // Do step 3 if an ending was removed in step 1 or 2
      if (endingRemoved)
        if (strRv.EndsWith("i") &&
            word.EndsWith("ci"))
          word = word.Remove(word.Length - 1);
      // **********************************************

      // **********************************************
      // Step 4
      // **********************************************
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // Do step 4 if an ending not was removed in step 1 and 2
      if (endingRemoved == false)
        foreach (var end in _endingsStep4.Where(end => word.EndsWith(end)).Where(end => strRv.EndsWith(end)))
        {
          word = word.Remove(word.Length - end.Length);
          break;
        }
      // **********************************************

      // **********************************************
      // Step 4
      // **********************************************
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // If the word ends with one of e, é, ê in RV, delete it
      if (strRv.EndsWith("e") ||
          strRv.EndsWith("é") ||
          strRv.EndsWith("ê"))
      {
        word = word = word.Remove(word.Length - 1);
        strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

        // If preceded by gu (or ci) with the u (or i) in RV, delete the u (or i)
        if (word.EndsWith("gu") && strRv.EndsWith("u") ||
            word.EndsWith("ci") && strRv.EndsWith("i"))
          word = word = word.Remove(word.Length - 1);
      }
      else if (word.EndsWith("ç"))
      {
        word = word = word.Remove(word.Length - 1);
        word += "c";
      }
      // **********************************************

      // Turn a~, o~ back into ã, õ
      word = word.Replace("a~", "ã");
      word = word.Replace("o~", "õ");

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