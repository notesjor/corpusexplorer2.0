using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip dutch words to the steam
  ///   This class is based on the dutch stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/dutch/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class DutchStemmer : AbstractStemmer
  {
    private readonly char[] _accentReplacements;
    private readonly char[] _acuteUmlautAccents;

    /// <summary>
    ///   Create a new dutch stemmer with default properties
    /// </summary>
    public DutchStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'y', 'è'};
      _acuteUmlautAccents = new[] {'ä', 'ë', 'ï', 'ö', 'ü', 'á', 'é', 'í', 'ó', 'ú'};
      _accentReplacements = new[] {'a', 'e', 'i', 'o', 'u', 'a', 'e', 'i', 'o', 'u'};
    } // End of the constructor

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
      // Turn the word into lower case characters
      word = word.ToLowerInvariant();

      // Create a char array
      var chars = word.ToCharArray();

      // Replace all acute and umlaut accents
      for (var i = 0; i < chars.Length; i++)
        for (var j = 0; j < _acuteUmlautAccents.Length; j++)
          if (chars[i] == _acuteUmlautAccents[j])
            chars[i] = _accentReplacements[j];

      // Put initial y, y after a vowel, and i between vowels into upper case
      var charCount = chars.Length - 1;
      for (var i = 0; i < chars.Length; i++)
        if (i == 0)
        {
          if (chars[i] == 'y')
            chars[i] = 'Y';
        }
        else if (i == charCount)
        {
          if ((chars[i] == 'y') &&
              IsVowel(chars[i - 1]))
            chars[i] = 'Y';
        }
        else if ((chars[i] == 'i') &&
                 IsVowel(chars[i - 1]) &&
                 IsVowel(chars[i + 1]))
          chars[i] = 'I';
        else if ((chars[i] == 'y') &&
                 IsVowel(chars[i - 1]))
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
      if (word.EndsWith("heden"))
      {
        // Replace with heid if in R1
        if (strR1.EndsWith("heden"))
        {
          // Replace with heid if in R1
          word = word.Remove(word.Length - 5);
          word += "heid";
        }
      }
      else if (word.EndsWith("ene"))
      {
        // Delete if in R1 and preceded by a valid en-ending, and then undouble the ending
        if (strR1.EndsWith("ene") &&
            (word.Length > 3) &&
            (word.EndsWith("gemene") == false) &&
            (IsVowel(word[word.Length - 4]) == false))
        {
          word = word.Remove(word.Length - 3);

          // Undouble the ending
          word = UndoubleEnding(word);
        }
      }
      else if (word.EndsWith("en"))
      {
        // Delete if in R1 and preceded by a valid en-ending, and then undouble the ending
        if (strR1.EndsWith("en") &&
            (word.Length > 2) &&
            (word.EndsWith("gemene") == false) &&
            (IsVowel(word[word.Length - 3]) == false))
        {
          word = word.Remove(word.Length - 2);

          // Undouble the ending
          word = UndoubleEnding(word);
        }
      }
      else if (word.EndsWith("se"))
      {
        // Delete if in R1 and preceded by a valid s-ending
        if (strR1.EndsWith("se") &&
            (word.Length > 2) &&
            (word[word.Length - 3] != 'j') &&
            (IsVowel(word[word.Length - 3]) == false))
          word = word.Remove(word.Length - 2);
      }
      else if (word.EndsWith("s"))
      {
        // Delete if in R1 and preceded by a valid s-ending
        if (strR1.EndsWith("s") &&
            (word.Length > 1) &&
            (word[word.Length - 2] != 'j') &&
            (IsVowel(word[word.Length - 2]) == false))
          word = word.Remove(word.Length - 1);
      }
      // **********************************************

      // **********************************************
      // Step 2
      // **********************************************
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      // Delete suffix e if in R1 and preceded by a non-vowel, and then undouble the ending
      var endingRemovedStep2 = false;
      if (strR1.EndsWith("e") &&
          (word.Length > 1) &&
          (IsVowel(word[word.Length - 2]) == false))
      {
        word = word.Remove(word.Length - 1);
        endingRemovedStep2 = true;

        // Undouble the ending
        word = UndoubleEnding(word);
      }
      // **********************************************

      // **********************************************
      // Step 3
      // **********************************************
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      var strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      // (a) Delete heid if in R2 and not preceded by c, and treat a preceding en as in step 1(b)
      if (strR2.EndsWith("heid") &&
          (word.Length > 4) &&
          (word[word.Length - 5] != 'c'))
      {
        word = word.Remove(word.Length - 4);

        // Delete en if in R1 and preceded by a valid en-ending, and then undouble the ending
        if (strR1.EndsWith("enheid") &&
            (word.Length > 2) &&
            (word.EndsWith("gemene") == false) &&
            (IsVowel(word[word.Length - 3]) == false))
        {
          word = word.Remove(word.Length - 2);

          // Undouble the ending
          word = UndoubleEnding(word);
        }
      }

      // (b)
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      if (strR2.EndsWith("baar"))
      {
        // Delete if in R2
        word = word.Remove(word.Length - 4);
      }
      else if (strR2.EndsWith("lijk"))
      {
        // Delete if in R2, and then repeat step 2
        word = word.Remove(word.Length - 4);

        // Delete suffix e if in R1 and preceded by a non-vowel, and then undouble the ending
        if (strR1.EndsWith("elijk") &&
            (word.Length > 1) &&
            (IsVowel(word[word.Length - 2]) == false))
        {
          word = word.Remove(word.Length - 1);

          // Undouble the ending
          word = UndoubleEnding(word);
        }
      }
      else if (strR2.EndsWith("bar"))
      {
        // Delete if in R2 and if step 2 actually removed an e
        if (endingRemovedStep2)
          word = word.Remove(word.Length - 3);
      }
      else if (strR2.EndsWith("end") ||
               strR2.EndsWith("ing"))
      {
        // Delete if in R2
        word = word.Remove(word.Length - 3);
        strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

        // If preceded by ig, delete if in R2 and not preceded by e, otherwise undouble the ending
        if (strR2.EndsWith("ig") &&
            (word.EndsWith("eig") == false))
          word = word.Remove(word.Length - 2);
        else
          word = UndoubleEnding(word);
      }
      else if (strR2.EndsWith("ig"))
      {
        // Delete if in R2 and not preceded by e
        if (word.EndsWith("eig") == false)
          word = word.Remove(word.Length - 2);
      }
      // **********************************************

      // **********************************************
      // Step 4
      // **********************************************

      // If the words ends CVD, where C is a non-vowel, D is a non-vowel other than I, and V is double a, e, o or u, 
      // remove one of the vowels from V (for example, maan -> man, brood -> brod).
      if (word.Length <= 3)
        return word.ToLowerInvariant();
      // Get CVD

      var v = word.Substring(word.Length - 3, 2);
      var d = word[word.Length - 1];

      if ((d != 'I') &&
          (IsVowel(word[word.Length - 4]) == false) &&
          (IsVowel(d) == false) &&
          ((v == "aa") || (v == "ee") || (v == "oo") || (v == "uu")))
        word = word.Remove(word.Length - 2, 1);
      // **********************************************

      // Return the word
      return word.ToLowerInvariant();
    } // End of the GetSteamWord method
    // End of the GetSteamWords method

    /// <summary>
    ///   Undouble the ending
    /// </summary>
    /// <param name="word">A reference to the word</param>
    /// <returns>The word</returns>
    private static string UndoubleEnding(string word)
    {
      // Undouble the ending
      if (word.EndsWith("kk") ||
          word.EndsWith("dd") ||
          word.EndsWith("tt"))
        word = word.Remove(word.Length - 1);

      // Return the word
      return word;
    } // End of the UndoubleEnding method
  } // End of the class
} // End of the namespace