using System;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTest.Core;

namespace TechTest.Tests
{
    /// <summary>
    /// Unit tests for StringStatsProcessor.
    /// </summary>
    [TestFixture]
    public class StringStatsProcessorTests
    {
        private IStringStatsProcessor _stringStatsProcessor;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _stringStatsProcessor = new StringStatsProcessor();
        }

        [Test]
        public void GivenInvalidInput_WhenRun_ThenExceptionThrown()
        {
            //Arrange
            var test = string.Empty;

            //Act
            var ex = Assert.ThrowsAsync<ArgumentNullException>(async () => await _stringStatsProcessor.Run(test));

            //Assert
            Assert.AreEqual("Value cannot be null. (Parameter 'subject')", ex.Message);
            Assert.AreEqual("subject", ex.ParamName);
        }

        [TestCase("This is a 37 character length string.", 37)]
        [TestCase("Thisonehasonly16", 16)]
        public async Task GivenValidInput_WhenRun_ThenNumberOfCharsCorrect(string testSubject, int expectedCharacterCount)
        {
            //Arrange

            //Act
            var stats = await _stringStatsProcessor.Run(testSubject);

            //Assert
            Assert.AreEqual(expectedCharacterCount, stats.NumberOfCharacters);
        }

        [TestCase("This string has fourteen words in it but some arent real words! $%%^^¬ .!3sdfsdf", 14)]
        [TestCase("Oneword", 1)]
        public async Task GivenValidInput_WhenRun_ThenNumberOfWordsCorrect(string testSubject, int expectedWordCount)
        {
            //Arrange

            //Act
            var stats = await _stringStatsProcessor.Run(testSubject);

            //Assert
            Assert.AreEqual(expectedWordCount, stats.NumberOfWords);
        }

        [TestCase("My favourite long word is Floccinaucinihilipilification you know!", 29)]
        [TestCase("Transformers are clearly the best toy ever created.", 12)]
        [TestCase("Chris likes pizza", 5)]
        public async Task GivenValidInput_WhenRun_ThenLongestWordCountCorrect(string testSubject, int expectedLongestWordCharacterCount)
        {
            //Arrange

            //Act
            var stats = await _stringStatsProcessor.Run(testSubject);

            //Assert
            Assert.AreEqual(expectedLongestWordCharacterCount, stats.LongestWordNumberOfCharacters);
        }

    }
}