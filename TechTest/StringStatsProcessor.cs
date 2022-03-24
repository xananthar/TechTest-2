using System;
using System.Linq;
using System.Threading.Tasks;
using TechTest.Core;
using TechTest.Models;

namespace TechTest
{
    /// <summary>
    /// Extracts statistics from the supplied string.
    /// </summary>
    public class StringStatsProcessor : IStringStatsProcessor
    {
        /// <summary>
        /// Extracts statistics from the supplied string.
        /// </summary>
        /// <param name="subject">Must not be null.</param>
        /// <returns>A model containing statistics for the supplied string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the supplied input is null or empty.</exception>
        public async Task<StringStatsModel> Run(string subject)
        {
            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentNullException("subject");
            }

            //split on space on the trimmed version of the string so we ensure we dont get any empty elements in the words list
            var words = subject.Trim().Split(' ').ToList();

            return new StringStatsModel
            {
                NumberOfCharacters = subject.Length,
                NumberOfWords = words.Count(),
                LongestWordNumberOfCharacters = words.Select(w => w.Length).Max()
            };
        }
    }
}