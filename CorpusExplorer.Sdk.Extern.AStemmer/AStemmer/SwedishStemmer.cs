using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip swedish words to the steam
  ///   This class is based on the swedish stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/swedish/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class SwedishStemmer : AbstractStemmer
  {
    private readonly string[] _endingsStep1;
    private readonly string[] _endingsStep2;
    private readonly string[] _endingsStep3;
    private readonly char[] _validSEndings;

    /// <summary>
    ///   Create a new swedish stemmer with default properties
    /// </summary>
    public SwedishStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'y', 'ä', 'å', 'ö'};
      _validSEndings = new[] {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'r', 't', 'v', 'y'};
      _endingsStep1 = new[]
      {
        "heterna",
        "hetens",
        "arens",
        "andes",
        "andet",
        "ornas",
        "ernas",
        "arnas",
        "heter",
        "heten",
        "anden",
        "erns",
        "ades",
        "aren",
        "aste",
        "arne",
        "ande",
        "orna",
        "erna",
        "arna",
        "ast",
        "het",
        "ens",
        "ern",
        "are",
        "ade",
        "at",
        "es",
        "as",
        "or",
        "er",
        "ar",
        "en",
        "ad",
        "e",
        "a"
      };
      _endingsStep2 = new[] {"dd", "gd", "nn", "dt", "gt", "kt", "tt"};
      _endingsStep3 = new[] {"lig", "els", "ig"};
    } // End of the constructor

    /// <summary>
    ///   Get the steam word from a specific word
    /// </summary>
    /// <param name="word">The word to strip</param>
    /// <returns>The stripped word</returns>
    public override string GetSteamWord(string word)
    {
      // Turn the word into lower case
      word = word.ToLowerInvariant();

      // Get a char array of each letter in the word
      var characters = word.ToCharArray();

      // Create two parts for the word
      string part1;
      var part2 = "";

      // Get the index of the first non-vowel after the first vowel (R1)
      var firstNonVowel = CalculateR1(characters);

      // Split the word in two parts if a non-vowel was found
      if (firstNonVowel < characters.Length)
      {
        // Get first and the second part of the word
        part1 = word.Substring(0, firstNonVowel);
        part2 = word.Substring(firstNonVowel);
      }
      else
      {
        part1 = word;
      }

      // **********************************************
      // Step 1
      // **********************************************
      // Replace endings in part 2
      var continueStep1 = true;
      foreach (var t in _endingsStep1.Where(t => part2.EndsWith(t)))
      {
        // Delete the ending in part 2
        part2 = part2.Remove(part2.Length - t.Length);
        continueStep1 = false;
        break;
      }

      // Delete a s in the end if the s is preceded by a valid s-ending, 
      if (continueStep1 && part2.EndsWith("s"))
      {
        // Create a full string of part1 and part2
        word = part1 + part2;

        // Get the preceding char before the s
        var precedingChar = word.Length > 1 ? word[word.Length - 2] : '\0';

        if (_validSEndings.Any(t => precedingChar == t))
          part2 = part2.Remove(part2.Length - 1);
      }
      // **********************************************

      // **********************************************
      // Step 2
      // **********************************************
      if (_endingsStep2.Any(t => part2.EndsWith(t)))
        part2 = part2.Remove(part2.Length - 1);
      // **********************************************

      // **********************************************
      // Step 3
      // **********************************************
      if (part2.EndsWith("fullt") ||
          part2.EndsWith("löst"))
        part2 = part2.Remove(part2.Length - 1);
      else
        foreach (var t in _endingsStep3.Where(t => part2.EndsWith(t)))
        {
          // Delete the ending
          part2 = part2.Remove(part2.Length - t.Length);
          break;
        }

      // Return the stripped word
      return part1 + part2;
    } // End of the GetSteamWord method

    /// <summary>
    ///   Calculate the R1 part for a word
    /// </summary>
    /// <param name="characters">An array of characters</param>
    /// <returns>An int with the r1 index</returns>
    private int CalculateR1(char[] characters)
    {
      // Create the int array to return
      var r1 = characters.Length;

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

      // Adjust R1
      if (r1 < 3)
        r1 = 3;

      // Return the int array
      return r1;
    } // End of the calculateR1 method
  } // End of the class
} // End of the namespace