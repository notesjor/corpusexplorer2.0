using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorpusExplorer.Sdk.Extern.AStemmer.AStemmer.Abstract
{
  /// <summary>
  ///   This is the base class for a stemmer
  /// </summary>
  public abstract class AbstractStemmer
  {
    /// <summary>
    ///   Create a new Stemmer
    /// </summary>
    protected AbstractStemmer()
    {
      // Set values for instance variables
      Vowels = new char[0];
    } // End of the constructor
    protected char[] Vowels { get; set; }

    /// <summary>
    ///   Get the steam word from a specific word
    /// </summary>
    /// <param name="word">The word to strip</param>
    /// <returns>The stripped word</returns>
    // ReSharper disable once MemberCanBeProtected.Global
    public abstract string GetSteamWord(string word);

    /// <summary>
    ///   Gets the steam words.
    /// </summary>
    /// <param name="words">The words.</param>
    /// <returns>System.String[].</returns>
    public IEnumerable<string> GetSteamWords(IEnumerable<string> words)
    {
      if (words == null)
        return null;
      var arr = words.ToArray();
      if (arr.Length == 0)
        return null;

      var results = new string[arr.Length];

      Parallel.For(0, results.Length, i => results[i] = GetSteamWord(arr[i]));

      return results;
    }

    /// <summary>
    ///   Check if a character is a short syllable
    /// </summary>
    /// <param name="characters">The character to check</param>
    /// <param name="index"></param>
    /// <returns>A boolean that indicates if the character is a short syllable</returns>
    protected bool IsShortSyllable(char[] characters, int index)
    {
      // Create the boolean to return
      var isShortSyllable = false;

      // Indexes
      var plusOneIndex = index + 1;
      var minusOneIndex = index - 1;

      if ((index == 0) &&
          (characters.Length > 1))
      {
        if ((index == 0) &&
            IsVowel(characters[index]) &&
            (IsVowel(characters[plusOneIndex]) == false))
          isShortSyllable = true;
      }
      else if ((minusOneIndex > -1) &&
               (plusOneIndex < characters.Length))
      {
        if (IsVowel(characters[index]) &&
            (IsVowel(characters[plusOneIndex]) == false) &&
            (characters[plusOneIndex] != 'w') &&
            (characters[plusOneIndex] != 'x')
            &&
            (characters[plusOneIndex] != 'Y') &&
            (IsVowel(characters[minusOneIndex]) == false))
          isShortSyllable = true;
      }

      // Return the boolean
      return isShortSyllable;
    } // End of the IsShortSyllable method

    /// <summary>
    ///   Check if a word is a short word
    /// </summary>
    /// <param name="word">The word to check</param>
    /// <param name="strR1">The r1 string</param>
    /// <returns>A boolean that indicates if the word is a short word</returns>
    protected bool IsShortWord(string word, string strR1)
    {
      return (strR1 == "") && IsShortSyllable(word.ToCharArray(), word.Length - 2);
    } // End of the IsShortWord method

    /// <summary>
    ///   Check if a character is a vowel
    /// </summary>
    /// <param name="character">The character to check</param>
    /// <returns>A boolean that indicates if the character is a vowel</returns>
    protected bool IsVowel(char character)
    {
      // Loop the vowel array
      return Vowels.Any(t => character == t);
    } // End of the isVowel method
  } // End of the class
} // End of the namespace