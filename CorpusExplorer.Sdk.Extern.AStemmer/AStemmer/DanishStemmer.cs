using System.Linq;
using CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer
{
  /// <summary>
  ///   This class is used to strip danish words to the steam
  ///   This class is based on the danish stemming algorithm from Snowball
  ///   http://snowball.tartarus.org/algorithms/danish/stemmer.html
  /// </summary>
  // ReSharper disable once UnusedMember.Global
  public class DanishStemmer : AbstractStemmer
  {
    private readonly string[] _endingsStep1;
    private readonly string[] _endingsStep2;
    private readonly string[] _endingsStep3;
    private readonly char[] _validSEndings;

    /// <summary>
    ///   Create a new danish stemmer with default properties
    /// </summary>
    public DanishStemmer()
    {
      // Set values for instance variables
      Vowels = new[] {'a', 'e', 'i', 'o', 'u', 'y', 'æ', 'å', 'ø'};
      _validSEndings = new[]
      {
        'a',
        'b',
        'c',
        'd',
        'f',
        'g',
        'h',
        'j',
        'k',
        'l',
        'm',
        'n',
        'o',
        'p',
        'r',
        't',
        'v',
        'y',
        'z',
        'å'
      };
      _endingsStep1 = new[]
      {
        "erendes",
        "hedens",
        "erende",
        "erede",
        "ethed",
        "heden",
        "erens",
        "heder",
        "endes",
        "ernes",
        "erets",
        "eret",
        "eren",
        "erer",
        "ered",
        "ende",
        "heds",
        "erne",
        "eres",
        "enes",
        "ens",
        "ets",
        "ere",
        "hed",
        "ene",
        "ers",
        "et",
        "er",
        "en",
        "es",
        "e"
      };
      _endingsStep2 = new[] {"gd", "dt", "gt", "kt"};
      _endingsStep3 = new[] {"elig", "els", "lig", "ig"};
    } // End of the constructor
    // End of the GetSteamWords method

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
    // ReSharper disable once UnusedMember.Global
    public override string GetSteamWord(string word)
    {
      // Turn the word into lower case letters
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

      // Delete a s in the end if the s is preceded by a valid s-ending
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
      if (part2.EndsWith("igst"))
        part2 = part2.Remove(part2.Length - 2);

      var repeatStep2 = false;
      foreach (var t in _endingsStep3.Where(t => part2.EndsWith(t)))
      {
        // Delete the ending
        part2 = part2.Remove(part2.Length - t.Length);
        repeatStep2 = true;
        break;
      }

      if (repeatStep2)
      {
        if (_endingsStep2.Any(t => part2.EndsWith(t)))
          part2 = part2.Remove(part2.Length - 1);
      }
      else if (part2.EndsWith("løst"))
      {
        // Delete the last letter in part2
        part2 = part2.Remove(part2.Length - 1);
      }
      // **********************************************
      // Step 4
      // **********************************************
      // If the word ends with double consonant in R1, remove one of the consonants.
      word = part1 + part2;
      if ((word.Length > 1) &&
          (part2.Length > 0) &&
          (word[word.Length - 2] == word[word.Length - 1])
          &&
          (IsVowel(part2[part2.Length - 1]) == false))
        part2 = part2.Remove(part2.Length - 1);
      // **********************************************

      // Return the stripped word
      return part1 + part2;
    } // End of the GetSteamWord method
  } // End of the class
} // End of the namespace