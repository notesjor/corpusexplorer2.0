using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip norwegian words to the steam
  ///   This class is based on the norwegian stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/norwegian/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class NorwegianStemmer : AbstractStemmer
  {
    private readonly string[] _endingsStep1;
    private readonly string[] _endingsStep2;
    private readonly string[] _endingsStep3;
    private readonly char[] _validSEndings;

    /// <summary>
    ///   Create a new norwegian stemmer with default properties
    /// </summary>
    public NorwegianStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'y', 'æ', 'å', 'ø'};
      _validSEndings = new[] {'b', 'c', 'd', 'f', 'g', 'h', 'j', 'l', 'm', 'n', 'o', 'p', 'r', 't', 'v', 'y', 'z'};
      // or k not preceded by a vowel
      _endingsStep1 = new[]
      {
        "hetenes",
        "hetens",
        "hetene",
        "heter",
        "heten",
        "endes",
        "edes",
        "enes",
        "ande",
        "ende",
        "ane",
        "ene",
        "ens",
        "ers",
        "ets",
        "het",
        "ast",
        "ede",
        "en",
        "ar",
        "er",
        "et",
        "as",
        "es",
        "a",
        "e"
      };
      _endingsStep2 = new[] {"dt", "vt"};
      _endingsStep3 = new[] {"hetslov", "eleg", "elov", "slov", "elig", "lig", "els", "leg", "eig", "lov", "ig"};
    } // End of the constructor

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
    } // End of the calculateR1R2 method

    /// <summary>
    ///   Get the steam word from a specific word
    /// </summary>
    /// <param name="word">The word to strip</param>
    /// <returns>The stripped word</returns>
    // ReSharper disable once MemberCanBeProtected.Global
    public override string GetSteamWord(string word)
    {
      // Adjust the word to lower case
      word = word.ToLowerInvariant();

      // Get a char array of each letter in the word
      var characters = word.ToCharArray();

      // Create two parts for the word
      string part1;
      var part2 = "";

      // Get the index of the first non-vowel after the first vowel (R1)
      var firstNonVowel = CalculateR1(characters);

      // Split the word in two parts if a non-vowel not was found
      if (firstNonVowel < characters.Length)
      {
        // Get the first and the second part of the word
        part1 = word.Substring(0, firstNonVowel);
        part2 = word.Substring(firstNonVowel);
      }
      else
        part1 = word;

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

        foreach (var t in _validSEndings)
        {
          // Check if the preceding char is a valid s-ending
          if (precedingChar == t)
          {
            // Delete the s
            part2 = part2.Remove(part2.Length - 1);
            continueStep1 = false;
            break;
          }

          // Check if the preceding char is k
          if (precedingChar != 'k')
            continue;
          var charBeforeK = word.Length > 2 ? word[word.Length - 3] : '\0';

          // Make sure that the char before k not is a vowel
          if (IsVowel(charBeforeK))
            continue;
          // Delete the s
          part2 = part2.Remove(part2.Length - 1);
          continueStep1 = false;
          break;
        }
      }
      else
        continueStep1 = true;

      // Check for an erte or an ert ending
      if (continueStep1)
        if (part2.EndsWith("erte"))
          part2 = part2.Remove(part2.Length - 2);
        else if (part2.EndsWith("ert"))
          part2 = part2.Remove(part2.Length - 1);
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
      foreach (var t in _endingsStep3.Where(t => part2.EndsWith(t)))
      {
        // Delete the ending
        part2 = part2.Remove(part2.Length - t.Length);
        break;
      }

      // Return the stripped word
      return part1 + part2;
    } // End of the GetSteamWord method
  } // End of the class
} // End of the namespace