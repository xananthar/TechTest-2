using System;

namespace TechTest.Models
{
    /// <summary>
    /// Contains statistics about a string.
    /// </summary>
    public class StringStatsModel
    {
        /// <summary>
        /// The total number of characters contained within a string - including punctuation, symbols and whitespace.
        /// </summary>
        public long NumberOfCharacters { get; set; }

        /// <summary>
        /// The total number of words contained within a string. A word is any unbroken sequence non-whitespace
        /// characters. Some examples: "Hello" is a word and so is "@,;'". "I'm here." is two words.
        /// </summary>
        public long NumberOfWords { get; set; }

        /// <summary>
        /// The number of characters of the longest word contained within the string. A word is any non-whitespace
        /// character and symbols or punctuation also count. Eg "Hello" is 5 characters long. The longest word in:
        /// "Hello there." is 'there.' and is 6 characters long. 
        /// </summary>
        public long LongestWordNumberOfCharacters { get; set; }
    }
}
