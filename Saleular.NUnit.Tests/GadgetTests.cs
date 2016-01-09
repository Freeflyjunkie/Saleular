using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using Saleular.Classes.Repositories;
using Saleular.Models;
using Saleular.NUnit.Tests.TestCaseSources;

namespace Saleular.NUnit.Tests
{
    [TestFixture]
    [Category("Gadgets")]
    public class GadgetTests
    {
        public GadgetRepository SystemToTest { get; set; }

        public GadgetTests()
        {
            //SystemToTest = new GadgetRepository();
        }        

        [OneTimeSetUp]
        public void BeforeTestFixture()
        {
            Console.WriteLine("Beginning Tests");
        }

        [SetUp]
        public void BeforeEachTest()
        {
            SystemToTest = new GadgetRepository();
        }

        [TearDown]
        public void AfterEachTest()
        {
            SystemToTest = null;
        }

        [OneTimeTearDown]
        public void AfterTestFixture()
        {
            Console.WriteLine("Ending Tests");
        }

        //[TestCase("iPhone", "6", "Factory", "64 GB", "Good")]
        //[TestCase("iPhone", "6", "Factory", "64 GB", "Flawless")]
        [TestCaseSource(typeof(GadgetTestCases))]
        [Category("Single Gadget")]
        public void ShouldGetGadget(string type, string model, string carrier, string capacity, string condition)
        {
            var result = SystemToTest.GetGadget(type, model, carrier, capacity, condition);

            Assert.IsNotNull(result);

        }

        [Test]
        [Repeat(5)]
        public void ShouldGetGadgets()
        {
            var result = SystemToTest.GetGadgets().ToList();

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void ShouldAllBeIPhones()
        {
            var result = SystemToTest.GetGadgets().ToList();

            Assert.IsNotNull(result);
            Assert.That(result, Has.All.Matches<Gadget>(g => g.Type == "iPhone"));
        }

        [Test]
        public void ShouldBe270IPhones()
        {
            var result = SystemToTest.GetGadgets().ToList();

            Assert.IsNotNull(result);
            Assert.That(result, Has.Count.EqualTo(270));
        }

        [Test]
        [MaxTime(1000)]
        public void ShouldAllBeUnique()
        {
            var result = SystemToTest.GetGadgets().ToList();

            CollectionAssert.AllItemsAreUnique(result);
            Assert.That(result, Is.Unique);
        }
    }
}
