using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip english words to the steam
  ///   This class is based on the Porter2 english stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/english/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class EnglishStemmer : AbstractStemmer
  {
    private readonly string[] _doubles;
    private readonly string[,] _exceptions;
    private readonly string[] _exceptions2;
    private readonly string[,] _step1Replacements;
    private readonly string[,] _step2Replacements;
    private readonly string[,] _step3Replacements;
    private readonly string[] _step4Replacements;
    private readonly string[] _validLiEndings;

    /// <summary>
    ///   Create a new swedish stemmer with default properties
    /// </summary>
    public EnglishStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'y'};
      _validLiEndings = new[] {"c", "d", "e", "g", "h", "k", "m", "n", "r", "t"};
      _doubles = new[] {"bb", "dd", "ff", "gg", "mm", "nn", "pp", "rr", "tt"};
      _step1Replacements = new[,]
        {{"eedly", "ee"}, {"ingly", ""}, {"edly", ""}, {"eed", "ee"}, {"ing", ""}, {"ed", ""}};
      _step2Replacements = new[,]
      {
        {"ization", "ize"},
        {"iveness", "ive"},
        {"fulness", "ful"},
        {"ational", "ate"},
        {"ousness", "ous"},
        {"biliti", "ble"},
        {"tional", "tion"},
        {"lessli", "less"},
        {"fulli", "ful"},
        {"entli", "ent"},
        {"ation", "ate"},
        {"aliti", "al"},
        {"iviti", "ive"},
        {"ousli", "ous"},
        {"alism", "al"},
        {"abli", "able"},
        {"anci", "ance"},
        {"alli", "al"},
        {"izer", "ize"},
        {"enci", "ence"},
        {"ator", "ate"},
        {"bli", "ble"},
        {"ogi", "og"},
        {"li", ""}
      };
      _step3Replacements = new[,]
      {
        {"ational", "ate"},
        {"tional", "tion"},
        {"alize", "al"},
        {"icate", "ic"},
        {"iciti", "ic"},
        {"ative", ""},
        {"ical", "ic"},
        {"ness", ""},
        {"ful", ""}
      };
      _step4Replacements = new[]
      {
        "ement",
        "ment",
        "ence",
        "able",
        "ible",
        "ance",
        "ism",
        "ent",
        "ate",
        "iti",
        "ant",
        "ous",
        "ive",
        "ize",
        "ion",
        "ic",
        "er",
        "al"
      };
      _exceptions = new[,]
      {
        {"skis", "ski"},
        {"skies", "sky"},
        {"dying", "die"},
        {"lying", "lie"},
        {"tying", "tie"},
        {"idly", "idl"},
        {"gently", "gentl"},
        {"ugly", "ugly"},
        {"early", "early"},
        {"only", "only"},
        {"singly", "singl"},
        {"sky", "sky"},
        {"news", "news"},
        {"howe", "howe"},
        {"atlas", "atlas"},
        {"cosmos", "cosmos"},
        {"bias", "bias"},
        {"andes", "andes"}
      };
      _exceptions2 = new[] {"inning", "outing", "canning", "herring", "earring", "proceed", "exceed", "succeed"};
    } // End of the constructor

    /// <summary>
    ///   Get the englist steam word from a specific word
    /// </summary>
    /// <param name="word">The word to strip</param>
    /// <returns>The stripped word</returns>
    // ReSharper disable once UnusedMember.Global
    public override string GetSteamWord(string word)
    {
      // Just return the word if it is 2 letters or less
      if (word.Length < 3)
        return word;

      // Set all characters to lower in the word
      word = word.ToLowerInvariant();

      // Remove a initial apostroph if it is present
      if (word.StartsWith("'"))
        word = word.Substring(1);

      // Check for first part exceptions
      for (var i = 0; i < 18; ++i)
        if (word == _exceptions[i, 0])
          return _exceptions[i, 1];

      // Get a char array of each letter in the word
      var chars = word.ToCharArray();

      // Set initial y to Y
      if (chars.Length > 0 &&
          chars[0] == 'y')
        chars[0] = 'Y';

      // Set y after a vowel to Y
      if (chars.Length > 1)
        for (var i = 1; i < chars.Length; i++)
          foreach (var v in Vowels)
            if (chars[i] == 'y' &&
                chars[i - 1] == v)
              chars[i] = 'Y';

      // Get the modified word from the char array
      word = new string(chars);

      // Calculate indexes for r1 and r2
      var partIndexR = CalculateR1R2(word);

      // ********************************************************
      // Step 0 - Remove endings
      // ********************************************************
      if (word.Length >= 3 &&
          word.EndsWith("'s'"))
        word = word.Remove(word.Length - 3, 3);
      else if (word.Length >= 2 &&
               word.EndsWith("'s"))
        word = word.Remove(word.Length - 2, 2);
      else if (word.Length >= 1 &&
               word.EndsWith("'"))
        word = word.Remove(word.Length - 1, 1);
      // ********************************************************

      // ********************************************************
      // Step 1a - Remove endings
      // ********************************************************
      if (word.EndsWith("sses"))
      {
        word = word.Remove(word.Length - 2);
      }
      else if (word.EndsWith("ied") ||
               word.EndsWith("ies"))
      {
        word = word.Length > 4 ? word.Remove(word.Length - 2) : word.Remove(word.Length - 1);
      }
      else if (word.EndsWith("us") ||
               word.EndsWith("ss"))
      {
        // Do nothing
      }
      else if (word.EndsWith("s"))
      {
        // Convert the word to a character array
        chars = word.ToCharArray();

        // Make sure that the word is long enough
        if (chars.Length >= 2)
          for (var i = 0; i < chars.Length - 2; i++)
          {
            if (!IsVowel(chars[i]))
              continue;
            word = word.Remove(word.Length - 1, 1);
            break;
          }
      }
      // ********************************************************

      // Check for second part exceptions
      foreach (var t in _exceptions2.Where(t => word == t))
        return t;

      // Create the r1 and r2 string
      var strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      // ********************************************************
      // Step 1b - Remove endings
      // ********************************************************
      for (var i = 0; i < 6; i++)
      {
        if (_step1Replacements[i, 0] == "eedly" &&
            strR1.EndsWith("eedly"))
        {
          word = word.Length >= 2 ? word.Remove(word.Length - 2, 2) : word;
          break;
        }

        if (_step1Replacements[i, 0] == "eed" &&
            strR1.EndsWith("eed"))
        {
          word = word.Length >= 1 ? word.Remove(word.Length - 1, 1) : word;
          break;
        }

        if (!word.EndsWith(_step1Replacements[i, 0]))
          continue;
        // Create a character array
        chars = word.ToCharArray();

        var vowelIsFound = false;

        // Check if we can find a vowel in the preceding word part
        if (chars.Length > _step1Replacements[i, 0].Length)
          for (var j = 0; j < chars.Length - _step1Replacements[i, 0].Length; j++)
          {
            if (!IsVowel(chars[j]))
              continue;
            word = word.Remove(word.Length - _step1Replacements[i, 0].Length);
            vowelIsFound = true;
            break;
          }

        if (vowelIsFound)
        {
          // Recreate the r1 and r2 string
          strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

          // Check if further processing should be done
          var continueProcessing = true;

          // Check if the word ends with at, bl or iz
          if (word.EndsWith("at") ||
              word.EndsWith("bl") ||
              word.EndsWith("iz"))
          {
            word += "e";
            continueProcessing = false;
          }

          // Check if the word ends with a double
          if (continueProcessing)
            if (_doubles.Any(t => word.EndsWith(t)))
            {
              word = word.Remove(word.Length - 1, 1);
              continueProcessing = false;
            }

          // Check if the word is short
          if (continueProcessing && IsShortWord(word, strR1))
            word += "e";
        }

        // Break out from the loop
        break;
      }

      // ********************************************************
      // Step 1c - Replace ending
      // ********************************************************
      if (word.Length > 2 &&
          (word.EndsWith("y") || word.EndsWith("Y")) &&
          IsVowel(word[word.Length - 2]) == false)
      {
        word = word.Remove(word.Length - 1);
        word += "i";
      }
      // ********************************************************

      // Recreate the r1 and r2 string
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";

      // ********************************************************
      // Step 2 - Remove endings
      // ********************************************************
      for (var i = 0; i < 24; ++i)
      {
        // Check if we can find the ending
        if (!word.EndsWith(_step2Replacements[i, 0]))
          continue;
        // Make sure that the ending can be found in R1
        if (strR1.EndsWith(_step2Replacements[i, 0]))
          switch (_step2Replacements[i, 0])
          {
            case "ogi":
              if (word.EndsWith("logi"))
                word = word.Remove(word.Length - 1);
              break;
            case "li":
              if (word.Length >= 3)
              {
                var liEnding = word.Substring(word.Length - 3, 1);
                if (_validLiEndings.Any(t => liEnding == t))
                  word = word.Remove(word.Length - 2);
              }

              break;
            default:
              if (word.Length >= _step2Replacements[i, 0].Length)
              {
                word = word.Remove(word.Length - _step2Replacements[i, 0].Length);
                word += _step2Replacements[i, 1];
              }

              break;
          }

        // Break out from the loop
        break;
      }
      // ********************************************************

      // Recreate the r1 and r2 string
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      var strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      // ********************************************************
      // Step 3 - Remove endings
      // ********************************************************
      for (var i = 0; i < 9; ++i)
      {
        if (!strR1.EndsWith(_step3Replacements[i, 0]))
          continue;
        if (_step3Replacements[i, 0] == "ative")
        {
          if (strR2.EndsWith("ative"))
            word = word.Remove(word.Length - _step3Replacements[i, 0].Length);
        }
        else
        {
          word = word.Remove(word.Length - _step3Replacements[i, 0].Length);
          word += _step3Replacements[i, 1];
        }

        // Break out from the loop
        break;
      }
      // ********************************************************

      // Recreate the r1 and r2 string
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      // ********************************************************
      // Step 4 - Remove endings
      // ********************************************************
      foreach (var t in _step4Replacements)
      {
        // Get the end
        var end = t;

        // Check if the word ends with the ending
        if (!word.EndsWith(end))
          continue;
        if (strR2.EndsWith(end))
          if (end == "ion")
          {
            var preChar = word.Length > 4 ? word[word.Length - 4] : '\0';

            if (preChar == 's' ||
                preChar == 't')
              word = word.Remove(word.Length - t.Length);
          }
          else
          {
            word = word.Remove(word.Length - t.Length);
          }

        // Break out from the loop
        break;
      }
      // ********************************************************

      // Recreate the r1 and r2 string
      strR1 = partIndexR[0] < word.Length ? word.Substring(partIndexR[0]) : "";
      strR2 = partIndexR[1] < word.Length ? word.Substring(partIndexR[1]) : "";

      // ********************************************************
      // Step 5 - Remove endings
      // ********************************************************
      if (strR2.EndsWith("e") ||
          strR1.EndsWith("e") && IsShortSyllable(word.ToCharArray(), word.Length - 3) == false)
        word = word.Remove(word.Length - 1);
      else if (strR2.EndsWith("l") &&
               word.EndsWith("ll"))
        word = word.Remove(word.Length - 1);
      // ********************************************************

      // Return the stripped word
      return word.ToLowerInvariant();
    } // End of the GetSteamWord method

    /// <summary>
    ///   Calculate the R1 and R2 part for a word
    /// </summary>
    /// <param name="word">The word to calculate R1 and R2 for</param>
    /// <returns>An int array with the r1 and r2 index</returns>
    private int[] CalculateR1R2(string word)
    {
      // Create the int array to return
      var r1 = word.Length;
      var r2 = word.Length;

      // Convert the word to a char array
      var characters = word.ToCharArray();

      // Calculate R1
      if (word.StartsWith("gener") ||
          word.StartsWith("arsen"))
        r1 = 5;
      else if (word.StartsWith("commun"))
        r1 = 6;
      else
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
      return new[] {r1, r2};
    } // End of the calculateR1R2 method
  } // End of the class
} // End of the namespace