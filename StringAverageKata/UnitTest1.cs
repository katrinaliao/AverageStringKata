using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace StringAverageKata
{
    [TestClass]
    public class StringAverageTest
    {
        [TestMethod]
        public void InputEmpty_should_return_NA()
        {
            var input = "";
            var expected = StringAverage.Average(input);
            Assert.AreEqual("n/a", expected);
        }

        [TestMethod]
        public void Average_Should_EqualTo()
        {
            Assert.AreEqual("four", StringAverage.Average("zero nine five two"));
            Assert.AreEqual("three", StringAverage.Average("four six two three"));
            Assert.AreEqual("three", StringAverage.Average("one two three four five"));
            Assert.AreEqual("four", StringAverage.Average("five four"));
            Assert.AreEqual("zero", StringAverage.Average("zero zero zero zero zero"));
            Assert.AreEqual("two", StringAverage.Average("one one eight one"));
        }
    }

    public class StringAverage
    {
        public static string Average(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "n/a";
            }

            Dictionary<string, int> comparison = new Dictionary<string, int>() { 
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9},
                {"zero", 0}
            };

            string[] splitString = input.Split();
            int sum = 0;

            foreach (string i in splitString)
            {
                sum = sum + comparison[i];
            }

            var average = sum / splitString.Length;
            return comparison.FirstOrDefault(x => x.Value == average).Key;      
        }
    }
}
