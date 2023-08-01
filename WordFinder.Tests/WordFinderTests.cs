namespace WordFinder.Tests
{
    public class WordFinderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OneWordHorizontal()
        {
            var matrix = new List<string>() {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
            var wordFinder = new Business.WordFinder(matrix);
            var wordStream = new List<string>() {
                "chill"
            };

            var result = wordFinder.Find(wordStream);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.ElementAt(0), Is.EqualTo("chill"));
        }

        [Test]
        public void OneWordVertical()
        {
            var matrix = new List<string>() {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
            var wordFinder = new Business.WordFinder(matrix);
            var wordStream = new List<string>() {
                "cold"
            };

            var result = wordFinder.Find(wordStream);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.ElementAt(0), Is.EqualTo("cold"));
        }

        [Test]
        public void OneWordHorizontalTwoWordsVertical()
        {
            var matrix = new List<string>() {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
            var wordFinder = new Business.WordFinder(matrix);
            var wordStream = new List<string>() {
                "cold",
                "wind",
                "snow",
                "chill"
            };

            var result = wordFinder.Find(wordStream);

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.ElementAt(0), Is.EqualTo("cold"));
            Assert.That(result.ElementAt(1), Is.EqualTo("wind"));
            Assert.That(result.ElementAt(2), Is.EqualTo("chill"));
        }

        [Test]
        public void OneWordHorizontalRepeatedOnStreamTwoWordsVertical()
        {
            var matrix = new List<string>() {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
            var wordFinder = new Business.WordFinder(matrix);
            var wordStream = new List<string>() {
                "cold",
                "wind",
                "snow",
                "chill",
                "chill"
            };

            var result = wordFinder.Find(wordStream);

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.ElementAt(0), Is.EqualTo("cold"));
            Assert.That(result.ElementAt(1), Is.EqualTo("wind"));
            Assert.That(result.ElementAt(2), Is.EqualTo("chill"));
        }

        [Test]
        public void OneWordRepeatedHorizontally()
        {
            var matrix = new List<string>() {
                "abcdcabcdc",
                "fgwiofgwio",
                "chillchill",
                "pqnsdpqnsx",
                "uvdxyuvdxy"
            };
            var wordFinder = new Business.WordFinder(matrix);
            var wordStream = new List<string>() {
                "chill"
            };

            var result = wordFinder.Find(wordStream);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.ElementAt(0), Is.EqualTo("chill"));
        }
    }
}