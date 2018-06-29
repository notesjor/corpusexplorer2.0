using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip finnish words to the steam
  ///   This class is based on the finnish stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/finnish/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class FinnishStemmer : AbstractStemmer
  {
    private readonly string[] _endingsStep1;
    private readonly string[] _endingsStep2;
    private readonly string[] _endingsStep3;
    private readonly string[] _endingsStep4;
    private readonly string[] _longVowels;
    private readonly char[] _restrictedVowels;

    /// <summary>
    ///   Create a new finnish stemmer with default properties
    /// </summary>
    public FinnishStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'y', 'ä', 'ö'};
      _endingsStep1 = new[] {"kään", "kaan", "hän", "han", "kin", "pä", "pa", "kö", "ko"};
      _endingsStep2 = new[] {"nsa", "nsä", "mme", "nne", "si", "ni", "an", "än", "en"};
      _endingsStep3 = new[]
      {
        "seen",
        "siin",
        "tten",
        "han",
        "hon",
        "lle",
        "ltä",
        "lta",
        "llä",
        "lla",
        "stä",
        "hin",
        "ssä",
        "ssa",
        "hen",
        "hän",
        "ttä",
        "tta",
        "hön",
        "ksi",
        "ine",
        "den",
        "sta",
        "nä",
        "tä",
        "ta",
        "na",
        "a",
        "ä",
        "n"
      };
      _endingsStep4 = new[]
      {
        "impi",
        "impä",
        "immi",
        "imma",
        "immä",
        "impa",
        "mpi",
        "eja",
        "mpa",
        "mpä",
        "mmi",
        "mma",
        "mmä",
        "ejä"
      };
      _restrictedVowels = new[] {'a', 'e', 'i', 'o', 'u', 'ä', 'ö'};
      _longVowels = new[] {"aa", "ee", "ii", "oo", "uu", "ää", "öö"};
    } // End of the constructor

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

      // Get indexes for R1 and R2
      var partIndexR = CalculateR1R2(word.ToCharArray());

      // Create strings
      var strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      // **********************************************
      // Step 1
      // **********************************************
      // (a)
      var continueStep1 = true;
      foreach (var end in _endingsStep1)
      {
        // Check if word ends with some of the predefined step 1 endings
        if (word.EndsWith(end) != true)
          continue;
        // Get the preceding character
        var precedingChar = word.Length > end.Length ? word[word.Length - end.Length - 1] : '\0';

        // Delete if in R1 and preceded by n, t or a vowel
        if (strR1.EndsWith(end) &&
            (precedingChar == 'n' || precedingChar == 't' || IsVowel(precedingChar)))
        {
          word = word.Remove(word.Length - end.Length);
          continueStep1 = false;
        }

        // Break out from the loop (the ending has been found)
        break;
      }

      // Recreate strings
      var strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      // (b)
      if (continueStep1 && strR2.EndsWith("sti"))
        word = word.Remove(word.Length - 3);
      // **********************************************

      // **********************************************
      // Step 2
      // **********************************************
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      foreach (var end in _endingsStep2.Where(end => strR1.EndsWith(end)))
      {
        switch (end)
        {
          case "nsa":
          case "nsä":
          case "mme":
          case "nne":
            // Delete
            word = word.Remove(word.Length - end.Length);
            break;
          case "si":
            // Delete if not preceded by k
            if (word.EndsWith("ksi") == false)
              word = word.Remove(word.Length - end.Length);
            break;
          case "ni":
            // Delete
            word = word.Remove(word.Length - end.Length);

            // If preceded by kse, replace with ksi
            if (word.EndsWith("kse"))
            {
              word = word.Remove(word.Length - 1);
              word += "i";
            }

            break;
          case "an":
            // Delete if preceded by one of:   ta   ssa   sta   lla   lta   na
            if (word.EndsWith("taan") ||
                word.EndsWith("ssaan") ||
                word.EndsWith("staan") ||
                word.EndsWith("llaan")
                ||
                word.EndsWith("ltaan") ||
                word.EndsWith("naan"))
              word = word.Remove(word.Length - end.Length);
            break;
          case "än":
            // Delete if preceded by one of:   tä   ssä   stä   llä   ltä   nä
            if (word.EndsWith("tään") ||
                word.EndsWith("ssään") ||
                word.EndsWith("stään") ||
                word.EndsWith("llään")
                ||
                word.EndsWith("ltään") ||
                word.EndsWith("nään"))
              word = word.Remove(word.Length - end.Length);
            break;
          case "en":
            // Delete if preceded by one of:   lle   ine
            if (word.EndsWith("lleen") ||
                word.EndsWith("ineen"))
              word = word.Remove(word.Length - end.Length);
            break;
        }

        // Break out from the loop
        break;
      }
      // **********************************************

      // **********************************************
      // Step 3
      // **********************************************
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      var endingRemovedStep3 = false;
      foreach (var end in _endingsStep3)
      {
        // Check if R1 ends with some of the predefined step 3 endings
        if (strR1.EndsWith(end))
        {
          string precedingString;
          switch (end)
          {
            case "han":
            case "hen":
            case "hin":
            case "hon":
            case "hän":
            case "hön":
              endingRemovedStep3 = true;

              // Get the middle character
              var middleCharacter = end.Substring(1, 1);

              // Delete if preceded by X, where X is a V other than u (a/han, e/hen etc)
              if (word.EndsWith(middleCharacter + end))
                word = word.Remove(word.Length - end.Length);
              break;
            case "siin":
            case "tten":
            case "den":
              // Get the preceding two letters
              precedingString = word.Length > end.Length + 1 ? word.Substring(word.Length - end.Length - 2, 2) : "";

              // Delete if preceded by Vi
              if (_restrictedVowels.Any(t => precedingString == t.ToString() + "i"))
              {
                word = word.Remove(word.Length - end.Length);
                endingRemovedStep3 = true;
              }

              break;
            default:
              switch (end)
              {
                case "seen":
                  // Get the preceding two letters
                  precedingString = word.Length > end.Length + 1
                    ? word.Substring(word.Length - end.Length - 2, 2)
                    : "";

                  // Delete if preceded by LV
                  if (_longVowels.Any(t => precedingString == t))
                  {
                    word = word.Remove(word.Length - end.Length);
                    endingRemovedStep3 = true;
                  }

                  break;
                case "a":
                case "ä":
                  // Get the preciding two letters
                  var before1 = word.Length > 1 ? word[word.Length - 2] : '\0';
                  var before2 = word.Length > 2 ? word[word.Length - 3] : '\0';

                  // Delete if preceded by cv
                  if (word.Length > 2 &&
                      IsVowel(before2) == false &&
                      IsVowel(before1))
                  {
                    word = word.Remove(word.Length - end.Length);
                    endingRemovedStep3 = true;
                  }

                  break;
                case "tta":
                case "ttä":
                  // Delete if preceded by e
                  if (word.EndsWith("e" + end))
                  {
                    word = word.Remove(word.Length - end.Length);
                    endingRemovedStep3 = true;
                  }

                  break;
                case "ta":
                case "tä":
                case "ssa":
                case "ssä":
                case "sta":
                case "stä":
                case "lla":
                case "llä":
                case "lta":
                case "ltä":
                case "lle":
                case "na":
                case "nä":
                case "ksi":
                case "ine":
                  // Delete
                  word = word.Remove(word.Length - end.Length);
                  endingRemovedStep3 = true;
                  break;
                case "n":
                  // Delete
                  word = word.Remove(word.Length - end.Length);
                  endingRemovedStep3 = true;

                  // If preceded by LV or ie, delete the last vowel
                  if (word.EndsWith("ie"))
                  {
                    word = word.Remove(word.Length - 1);
                  }
                  else
                  {
                    // Get the preceding two letters
                    var lastTwoLetters = word.Length > 1 ? word.Substring(word.Length - 2, 2) : "";

                    if (_longVowels.Any(t => lastTwoLetters == t))
                      word = word.Remove(word.Length - 1);
                  }

                  break;
              }

              break;
          }
        }

        // Break out from the loop if a ending has been removed
        if (endingRemovedStep3)
          break;
      }
      // **********************************************

      // **********************************************
      // Step 4
      // **********************************************
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      foreach (var end in _endingsStep4.Where(end => strR2.EndsWith(end)))
      {
        switch (end)
        {
          case "mpi":
          case "mpa":
          case "mpä":
          case "mmi":
          case "mma":
          case "mmä":
            // Delete if not preceded by po
            if (word.EndsWith("po" + end) == false)
              word = word.Remove(word.Length - end.Length);
            break;
          case "impi":
          case "impa":
          case "impä":
          case "immi":
          case "imma":
          case "immä":
          case "eja":
          case "ejä":
            // Delete
            word = word.Remove(word.Length - end.Length);
            break;
        }

        // Break out from the loop
        break;
      }
      // **********************************************

      // **********************************************
      // Step 5
      // **********************************************
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      if (endingRemovedStep3)
      {
        // If an ending was removed in step 3, delete a final i or j if in R1
        if (strR1.EndsWith("i") ||
            strR1.EndsWith("j"))
          word = word.Remove(word.Length - 1);
      }
      else
      {
        // Delete a final t in R1 if it follows a vowel
        if (strR1.EndsWith("t"))
        {
          // Get the preceding char
          var before = word.Length > 1 ? word[word.Length - 2] : '\0';

          if (IsVowel(before))
          {
            word = word.Remove(word.Length - 1);

            strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
            strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

            // If a t is removed, delete a final mma or imma in R2, unless the mma is preceded by po
            if (strR2.EndsWith("imma"))
              word = word.Remove(word.Length - 4);
            else if (strR2.EndsWith("mma") &&
                     word.EndsWith("poma") == false)
              word = word.Remove(word.Length - 3);
          }
        }
      }
      // **********************************************

      // **********************************************
      // Step 6
      // **********************************************
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      // a) If R1 ends LV delete the last letter
      if (_longVowels.Any(t => strR1.EndsWith(t)))
        word = word.Remove(word.Length - 1);

      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      // b) If R1 ends cX, c a consonant and X one of: a   ä   e   i, delete the last letter
      var c = strR1.Length > 1 ? strR1[strR1.Length - 2] : '\0';
      if (c != '\0' &&
          IsVowel(c) == false &&
          (strR1.EndsWith("a") || strR1.EndsWith("ä") || strR1.EndsWith("e") || strR1.EndsWith("i")))
        word = word.Remove(word.Length - 1);

      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      // c) If R1 ends oj or uj delete the last letter
      if (strR1.EndsWith("oj") ||
          strR1.EndsWith("uj"))
        word = word.Remove(word.Length - 1);

      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      // d) If R1 ends jo delete the last letter
      if (strR1.EndsWith("jo"))
        word = word.Remove(word.Length - 1);

      // e) If the word ends with a double consonant followed by zero or more vowels, remove the last consonant (so eläkk -> eläk, aatonaatto -> aatonaato)
      var startIndex = word.Length - 1;
      for (var i = startIndex; i > -1; i--)
      {
        // Try to find a double consonant
        if (i <= 0 ||
            word[i] != word[i - 1] ||
            IsVowel(word[i]) ||
            IsVowel(word[i - 1]))
          continue;
        // Get the count of characters that follows the double consonant
        var count = startIndex - i;
        var vowelCount = 0;

        // Count the number of vowels
        for (var j = i; j < word.Length; j++)
          if (IsVowel(word[j]))
            vowelCount += 1;

        // Remove the last consonant
        if (count == vowelCount)
          word = word.Remove(i, 1);

        // Break out from the loop
        break;
      }
      // **********************************************

      // Return the word
      return word.ToLowerInvariant();
    } // End of the GetSteamWord method
    // End of the GetSteamWords method

    /// <summary>
    ///   Calculate indexes for R1 and R2
    /// </summary>
    /// <param name="characters">The char array to calculate indexes for</param>
    /// <returns>An int array with the r1 and r2 index</returns>
    private int[] CalculateR1R2(char[] characters)
    {
      // Create ints
      var r1 = characters.Length;
      var r2 = characters.Length;

      // Calculate R1
      for (var i = 1; i < characters.Length; i++)
      {
        if (IsVowel(characters[i]) ||
            IsVowel(characters[i - 1]) != true)
          continue;
        // Set the r1 index
        r1 = i + 1;
        break;
      }

      // Calculate R2
      for (var i = r1; i < characters.Length; ++i)
      {
        if (IsVowel(characters[i]) ||
            IsVowel(characters[i - 1]) != true)
          continue;
        // Set the r2 index
        r2 = i + 1;
        break;
      }

      // Return the int array
      return new[] {r1, r2};
    } // End of the CalculateR1R2 method
  } // End of the class
} // End of the namespace