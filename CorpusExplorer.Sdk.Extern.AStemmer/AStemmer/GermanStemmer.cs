using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip german words to the steam
  ///   This class is based on the german stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/german/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class GermanStemmer : AbstractStemmer
  {
    private readonly string[] _endingsStep1A;
    private readonly string[] _endingsStep1B;
    private readonly string[] _endingsStep2;
    private readonly string[] _endingsStep3;
    private readonly char[] _validSEndings;
    private readonly char[] _validStEndings;

    /// <summary>
    ///   Create a new german stemmer with default properties
    /// </summary>
    public GermanStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'y', 'ä', 'ö', 'ü'};
      _validSEndings = new[] {'b', 'd', 'f', 'g', 'h', 'k', 'l', 'm', 'n', 'r', 't'};
      _validStEndings = new[] {'b', 'd', 'f', 'g', 'h', 'k', 'l', 'm', 'n', 't'};
      _endingsStep1A = new[] {"ern", "em", "er"};
      _endingsStep1B = new[] {"es", "en", "e"};
      _endingsStep2 = new[] {"est", "en", "er"};
      _endingsStep3 = new[] {"keit", "heit", "lich", "isch", "ung", "end", "ik", "ig"};
    } // End of the constructor
    // End of the GetSteamWords method

    /// <summary>
    ///   Calculate the R1 and R2 part for a word
    /// </summary>
    /// <param name="characters">An array of characters</param>
    /// <returns>An int array with the r1 and r2 index</returns>
    private int[] CalculateR1R2(char[] characters)
    {
      // Create the int array to return
      var r1 = characters.Length;
      var r2 = characters.Length;

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

      // Adjust R1
      if (r1 < 3)
        r1 = 3;

      // Return the int array
      return new[] {r1, r2};
    } // End of the calculateR1R2 method

    /// <summary>
    ///   Get the steam word from a specific word
    /// </summary>
    /// <param name="word">The word to strip</param>
    /// <returns>The stripped word</returns>
    // ReSharper disable once UnusedMember.Global
    public override string GetSteamWord(string word)
    {
      // Replace ß by ss
      word = word.Replace("ß", "ss");

      // Make sure that the word is in lower case characters
      word = word.ToLowerInvariant();

      // Create a char array that can be used over an over again
      var chars = word.ToCharArray();

      // Put u and y between vowels into upper case
      var charCount = chars.Length - 1;
      for (var i = 1; i < charCount; i++)
        if ((chars[i] == 'u') &&
            IsVowel(chars[i - 1]) &&
            IsVowel(chars[i + 1]))
          chars[i] = 'U';
        else if ((chars[i] == 'y') &&
                 IsVowel(chars[i - 1]) &&
                 IsVowel(chars[i + 1]))
          chars[i] = 'Y';

      // Get indexes for R1 and R2
      var partIndexR = CalculateR1R2(chars);

      // Recreate the word
      word = new string(chars);

      // Create the r1 and r2 string
      var strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      // **********************************************
      // Step 1
      // **********************************************
      var continueStep1 = true;
      foreach (var t in _endingsStep1A.Where(t => strR1.EndsWith(t)))
      {
        // Delete the ending
        word = word.Remove(word.Length - t.Length);
        continueStep1 = false;
        break;
      }

      // Recreate the r1 and r2 string
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      if (continueStep1)
        foreach (var t in _endingsStep1B.Where(t => strR1.EndsWith(t)))
        {
          // Delete the ending
          word = word.Remove(word.Length - t.Length);

          if (word.EndsWith("niss"))
            word = word.Remove(word.Length - 1);
          continueStep1 = false;
          break;
        }

      // Recreate the r1 and r2 string
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      // Delete a s in the end if the s is preceded by a valid s-ending, 
      if (continueStep1 && strR1.EndsWith("s"))
      {
        // Get the preceding char before the s
        var precedingChar = word.Length > 1 ? word[word.Length - 2] : '\0';

        // Check if the preceding char is a valid s-ending
        if (_validSEndings.Any(t => precedingChar == t))
          word = word.Remove(word.Length - 1);
      }
      // **********************************************

      // **********************************************
      // Step 2
      // **********************************************
      // Recreate the r1 and r2 string
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      var checkEndsWithSt = true;
      foreach (var t in _endingsStep2.Where(t => strR1.EndsWith(t)))
      {
        // Delete the ending
        word = word.Remove(word.Length - t.Length);
        checkEndsWithSt = false;
        break;
      }

      // Recreate the r1 and r2 string
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      // Delete st in the end if st is preceded by a valid st-ending, itself preceded by at least 3 letters 
      if (checkEndsWithSt &&
          (word.Length > 5) &&
          strR1.EndsWith("st"))
      {
        // Get the preceding char before the s
        var precedingChar = word[word.Length - 3];

        if (_validStEndings.Any(t => precedingChar == t))
          word = word.Remove(word.Length - 2);
      }
      // **********************************************

      // **********************************************
      // Step 3
      // **********************************************
      // Recreate the r1 and r2 string
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      var strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      foreach (var end in _endingsStep3.Where(end => word.EndsWith(end)))
      {
        switch (end)
        {
          case "end":
          case "ung":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);

              // If preceded by ig, delete if in R2 and not preceded by e
              if (strR2.EndsWith("ig" + end) &&
                  (word.EndsWith("eig") == false))
                word = word.Remove(word.Length - 2);
            }
            break;
          case "ig":
          case "ik":
          case "isch":
            // Delete if in R2 and not preceded by e
            if (strR2.EndsWith(end) &&
                (word.EndsWith("e" + end) == false))
              word = word.Remove(word.Length - end.Length);
            break;
          case "lich":
          case "heit":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);

              // If preceded by er or en, delete if in R1 
              if (strR1.EndsWith("en" + end) ||
                  strR1.EndsWith("er" + end))
                word = word.Remove(word.Length - 2);
            }
            break;
          case "keit":
            // Delete if in R2
            if (strR2.EndsWith(end))
            {
              word = word.Remove(word.Length - end.Length);

              // If preceded by lich or ig, delete if in R2
              if (strR2.EndsWith("lich" + end))
                word = word.Remove(word.Length - 4);
              else if (strR2.EndsWith("ig" + end))
                word = word.Remove(word.Length - 2);
            }
            break;
        }

        // Break out from the loop, the ending has been found
        break;
      }
      // **********************************************

      // Turn the word to lower case
      word = word.ToLowerInvariant();

      // Replace the umlaut accent from a, o and u.
      word = word.Replace('ä', 'a').Replace('ü', 'u').Replace('ö', 'o');

      // Return the word
      return word;
    } // End of the GetSteamWord method
  } // End of the class
} // End of the namespace