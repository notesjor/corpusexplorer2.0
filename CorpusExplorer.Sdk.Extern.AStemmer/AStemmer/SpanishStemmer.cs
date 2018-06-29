using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip spanish words to the steam
  ///   This class is based on the spanish stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/spanish/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class SpanishStemmer : AbstractStemmer
  {
    private readonly string[] _acuteAccents;
    private readonly string[] _acuteAccentsReplacements;
    private readonly string[] _endingsStep0;
    private readonly string[] _endingsStep1;
    private readonly string[] _endingsStep2A;
    private readonly string[] _endingsStep2B;
    private readonly string[] _endingsStep3;

    /// <summary>
    ///   Create a new spanish stemmer with default properties
    /// </summary>
    public SpanishStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'á', 'é', 'í', 'ó', 'ú', 'ü'};
      _endingsStep0 = new[]
        {"selas", "selos", "sela", "selo", "nos", "los", "les", "las", "se", "le", "lo", "me", "la"};
      _endingsStep1 = new[]
      {
        "amientos",
        "imientos",
        "imiento",
        "amiento",
        "uciones",
        "aciones",
        "adoras",
        "adores",
        "idades",
        "amente",
        "encias",
        "ancias",
        "logías",
        "ución",
        "encia",
        "ancia",
        "antes",
        "mente",
        "istas",
        "ibles",
        "ables",
        "ación",
        "anzas",
        "adora",
        "ismos",
        "logía",
        "ivos",
        "ante",
        "osas",
        "osos",
        "ismo",
        "icas",
        "idad",
        "ista",
        "icos",
        "ible",
        "anza",
        "able",
        "ivas",
        "ador",
        "osa",
        "oso",
        "iva",
        "ivo",
        "ica",
        "ico"
      };
      _endingsStep2A = new[] {"yamos", "yendo", "yeron", "yais", "yes", "yas", "yan", "yen", "ye", "yó", "ya", "yo"};
      _endingsStep2B = new[]
      {
        "iésemos",
        "iéramos",
        "iríamos",
        "eríamos",
        "aríamos",
        "aremos",
        "ábamos",
        "iríais",
        "aríais",
        "ásemos",
        "isteis",
        "asteis",
        "ieseis",
        "eremos",
        "ierais",
        "áramos",
        "iremos",
        "eríais",
        "arías",
        "aréis",
        "aseis",
        "arais",
        "íamos",
        "abais",
        "iesen",
        "erían",
        "ieses",
        "ieran",
        "ieras",
        "eréis",
        "arían",
        "irían",
        "irías",
        "iréis",
        "iendo",
        "ieron",
        "erías",
        "irás",
        "aron",
        "irán",
        "asen",
        "ando",
        "aran",
        "aría",
        "aban",
        "abas",
        "iste",
        "idos",
        "iese",
        "arás",
        "adas",
        "idas",
        "arán",
        "iera",
        "ería",
        "aras",
        "erás",
        "erán",
        "ases",
        "amos",
        "imos",
        "emos",
        "aste",
        "íais",
        "iría",
        "ados",
        "iré",
        "ido",
        "ían",
        "ado",
        "aré",
        "ase",
        "ará",
        "áis",
        "eré",
        "ara",
        "erá",
        "ida",
        "ada",
        "aba",
        "éis",
        "irá",
        "ías",
        "an",
        "es",
        "id",
        "ed",
        "ad",
        "ía",
        "ís",
        "ar",
        "er",
        "ir",
        "as",
        "en",
        "ió"
      };
      _endingsStep3 = new[] {"os", "a", "o", "á", "í", "ó", "e", "é"};
      _acuteAccents = new[] {"á", "é", "í", "ó", "ú"};
      _acuteAccentsReplacements = new[] {"a", "e", "i", "o", "u"};
    } // End of the constructor

    /// <summary>
    ///   Get the steam word from a specific word
    /// </summary>
    /// <param name="word">The word to strip</param>
    /// <returns>The stripped word</returns>
    public override string GetSteamWord(string word)
    {
      // Make sure that the word is in lower case characters
      word = word.ToLowerInvariant();

      // Get indexes for R1, R2 and RV
      var partIndexR = CalculateR1R2RV(word.ToCharArray());

      // Create strings
      // ReSharper disable InconsistentNaming
      var strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";
      // ReSharper restore InconsistentNaming

      // **********************************************
      // Step 0
      // **********************************************
      foreach (var end in _endingsStep0.Where(end => word.EndsWith(end)))
      {
        if (strRv.EndsWith("iéndo" + end))
        {
          // Deletion is followed by removing the acute accent (for example, haciéndola -> haciendo)
          word = word.Remove(word.Length - end.Length - 5);
          word += "iendo";
        }
        else if (strRv.EndsWith("ándo" + end))
        {
          // Deletion is followed by removing the acute accent (for example, haciéndola -> haciendo)
          word = word.Remove(word.Length - end.Length - 4);
          word += "ando";
        }
        else if (strRv.EndsWith("ár" + end))
        {
          // Deletion is followed by removing the acute accent (for example, haciéndola -> haciendo)
          word = word.Remove(word.Length - end.Length - 2);
          word += "ar";
        }
        else if (strRv.EndsWith("ér" + end))
        {
          // Deletion is followed by removing the acute accent (for example, haciéndola -> haciendo)
          word = word.Remove(word.Length - end.Length - 2);
          word += "er";
        }
        else if (strRv.EndsWith("ír" + end))
        {
          // Deletion is followed by removing the acute accent (for example, haciéndola -> haciendo)
          word = word.Remove(word.Length - end.Length - 2);
          word += "ir";
        }
        else if (strRv.EndsWith("iendo" + end) ||
                 strRv.EndsWith("ando" + end) ||
                 strRv.EndsWith("ar" + end) ||
                 strRv.EndsWith("er" + end) ||
                 strRv.EndsWith("ir" + end))
        {
          // Delete the ending
          word = word.Remove(word.Length - end.Length);
        }
        else if (strRv.EndsWith("yendo" + end) &&
                 word.EndsWith("uyendo" + end))
        {
          // Delete the ending
          word = word.Remove(word.Length - end.Length);
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

      var endingRemovedStep1 = false;
      foreach (var end in _endingsStep1.Where(end => word.EndsWith(end)))
      {
        switch (end)
        {
          case "anza":
          case "anzas":
          case "ico":
          case "ica":
          case "icos":
          case "icas":
          case "ismo":
          case "ismos":
          case "able":
          case "ables":
          case "ible":
          case "ibles":
          case "ista":
          case "istas":
          case "oso":
          case "osa":
          case "osos":
          case "osas":
          case "amiento":
          case "amientos":
          case "imiento":
          case "imientos":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemovedStep1 = true;
            }

            break;
          case "adora":
          case "ador":
          case "ación":
          case "adoras":
          case "adores":
          case "aciones":
          case "ante":
          case "antes":
          case "ancia":
          case "ancias":
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
          case "logía":
          case "logías":
            // Replace with log if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "log";
              endingRemovedStep1 = true;
            }

            break;
          case "ución":
          case "uciones":
            // Replace with u if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "u";
              endingRemovedStep1 = true;
            }

            break;
          case "encia":
          case "encias":
            // Replace with ente if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              word += "ente";
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
              endingRemovedStep1 = true;

              // If preceded by ante, able or ible, delete if in R2
              if (strR2.EndsWith("ante" + end) ||
                  strR2.EndsWith("able" + end) ||
                  strR2.EndsWith("ible" + end))
                word = word.Remove(word.Length - 4);
            }

            break;
          case "idades":
          case "idad":
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
          case "ivos":
          case "ivas":
          case "iva":
          case "ivo":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);
              endingRemovedStep1 = true;

              // If preceded by at, delete if in R2
              if (strR2.EndsWith("at" + end))
                word = word.Remove(word.Length - 2);
            }

            break;
        }

        // Break out from the loop if a ending has been removed
        if (endingRemovedStep1)
          break;
      }
      // **********************************************

      // **********************************************
      // Step 2
      // **********************************************
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      // (a)
      var doStep_2B = true;
      if (endingRemovedStep1 == false)
        foreach (
          var end in
          _endingsStep2A.Where(end => word.EndsWith(end))
            .Where(end => strRv.EndsWith(end) && word.EndsWith("u" + end)))
        {
          word = word.Remove(word.Length - end.Length);
          doStep_2B = false;
          break;
        }

      // (b)
      if (endingRemovedStep1 == false && doStep_2B)
        foreach (var end in _endingsStep2B.Where(end => word.EndsWith(end)))
        {
          if (end == "en" ||
              end == "es" ||
              end == "éis" ||
              end == "emos")
          {
            // Delete, and if preceded by gu delete the u (the gu need not be in RV)
            if (!strRv.EndsWith(end))
              continue;
            word = word.Remove(word.Length - end.Length);

            // If preceded by gu delete the u (the gu need not be in RV)
            if (word.EndsWith("gu"))
              word = word.Remove(word.Length - 1);

            break;
          }

          // Delete if in RV
          if (!strRv.EndsWith(end))
            continue;
          word = word.Remove(word.Length - end.Length);
          break;
        }
      // **********************************************

      // **********************************************
      // Step 3
      // **********************************************
      strRv = partIndexR[2] < word.Length ? word.Substring(partIndexR[2]) : "";

      foreach (var end in _endingsStep3.Where(end => word.EndsWith(end)))
      {
        if (end == "é" ||
            end == "e")
        {
          // Delete if in RV
          if (!strRv.EndsWith(end))
            continue;
          word = word.Remove(word.Length - end.Length);

          // If preceded by gu with the u in RV delete the u
          if (strRv.EndsWith("u" + end) &&
              word.EndsWith("gu"))
            word = word.Remove(word.Length - 1);

          break;
        }

        // Delete if in RV
        if (!strRv.EndsWith(end))
          continue;
        word = word.Remove(word.Length - end.Length);
        break;
      }
      // **********************************************

      // **********************************************
      // Step 4
      // **********************************************
      // Remove acute accents
      for (var i = 0; i < _acuteAccents.Length; i++)
        word = word.Replace(_acuteAccents[i], _acuteAccentsReplacements[i]);

      // Return the word
      return word.ToLowerInvariant();
    } // End of the GetSteamWord method

    /// <summary>
    ///   Calculate the R1, R2 and RV part for a word
    /// </summary>
    /// <param name="characters">The char array to calculate indexes for</param>
    /// <returns>An int array with the r1, r2 and rV index</returns>
    private int[] CalculateR1R2RV(char[] characters)
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