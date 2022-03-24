using System;
using System.Linq;
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
        [TestCase(" Space prefixed", 2)]
        [TestCase("Space suffixed ", 2)]
        [TestCase(" Space prefix and suffix ", 4)]
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

        [Test]
        public async Task GivenMassiveInput_WhenRun_ThenStatsCorrect()
        {
            //Arrange
            int wordCount = 100000000;  //pc can cope with 100 million megatrons, but if we stick another zero on there to make it
                                        //a billion, we get an out of memory exception before even hitting the string processor.
                                        //at 100 million, test takes approx 13 seconds on this box
            string repeatWord = "Megatron ";
            var testSubject = string.Concat(Enumerable.Repeat(repeatWord, wordCount));

            //Act
            var stats = await _stringStatsProcessor.Run(testSubject);

            //Assert
            Assert.AreEqual(wordCount, stats.NumberOfWords);
        }



    }
}