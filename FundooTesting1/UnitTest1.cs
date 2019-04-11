using FUNDOOAPP.views;
using NUnit.Framework;


namespace Tests
{
    [TestFixture]
    public class Tests

    {
        private readonly Signup signup;

        public Tests()
        {
            signup = new Signup();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var result = this.signup.CheckValidation();
            Assert.IsTrue(result);
        }

    }
}