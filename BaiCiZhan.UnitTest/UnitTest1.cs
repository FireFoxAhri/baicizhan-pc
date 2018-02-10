using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaiCiZhan.Helper;

namespace BaiCiZhan.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetWord()
        {
            string word = "abandon";
            var a = CET4Helper.GetInstance().GetWord(word);
            Assert.IsTrue(word == a.word);
        }

        [TestMethod]
        public void TestIHistoryHelper()
        {
            IHistoryHelper hisHelper = new HistoryHelper();
            hisHelper.Add("test");
            var a = hisHelper.GetAll();
        }
    }
}
