using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CleverDolphin;

namespace CleverDolphinTest
{
    [TestClass]
    public class DolphinTest
    {
        [TestMethod]
        public void Rating_Test()
        {
            int corrAns = 13;
            String expectedResult = "Clever";

            Game1 gamePlay = new Game1();

            String result = gamePlay.UpdateRating(corrAns);

            Assert.AreEqual(expectedResult, result, "yee Clever Dolphin");

        }
    }
}
