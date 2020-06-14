using Microsoft.VisualStudio.TestTools.UnitTesting;
using VIN_LIB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIN_LIB.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        List<string> vins = new List<string>
            {
                    "WBAKG7C54DJ746310",
                    "JN1CV6APXCM884333",
                    "2C4RDGCG2FR292116",
                   "2HNYD2H46CH088623",
                    "KNAFU5A29D5373281",
                    "1FTMF1E84AK129978",
                    "WBAKE5C5XCJ498380",
                    "JTHFF2C27F2931205",
                    "WBABW33455P972485",
                     "5FNRL5H2XCB183642",
                    "JTEBU4BF9DK234908",
                    "1G6DM577280903075",
                    "1GYFC43539R480716",
                    "1N6AA0CJ3FN926889",
            };

        [TestMethod()]
        public void CheckVINTest_Count()
        {
            Class1 class1 = new Class1();


            foreach (var v in vins)
            {
                Assert.AreEqual(true, class1.IsCountSimbol(v));
            }

            Assert.AreEqual(class1.IsCountSimbol("JHMCM56557C404453"), true);
            Assert.AreEqual(class1.IsCountSimbol("JHMCM56557C40445"), false);
            Assert.AreEqual(class1.IsCountSimbol("JHMCM56557C4044533"), false);
        }

        [TestMethod()]
        public void CheckVINTest_IsBedCount()
        {
            Class1 class1 = new Class1();

            foreach (var v in vins)
            {
                Assert.AreEqual(true, class1.IsBedCount(v));
            }

            Assert.AreEqual(class1.IsBedCount("JHMCM56557C404453"), true);
            Assert.AreEqual(class1.IsBedCount("IHMCM56557C404453"), false);
            Assert.AreEqual(class1.IsBedCount("OHMCM56557C404453"), false);
            Assert.AreEqual(class1.IsBedCount("QHMCM56557C404453"), false);
            Assert.AreEqual(class1.IsBedCount("бHMCM56557C404453"), false);
        }

        [TestMethod()]
        public void CheckVINTest_IsBebWMI()
        {
            Class1 class1 = new Class1();
            string name;



            foreach (var v in vins)
            {
                Assert.AreEqual(true, class1.IsBebWMI(v.Substring(0, 3), out name));
            }

            Assert.AreEqual(true, class1.IsBebWMI("JAM", out name));

            Assert.AreEqual(class1.IsBebWMI("A09", out name), false);
        }

        [TestMethod()]
        public void CheckVINTest()
        {
            Class1 class1 = new Class1();

            foreach (var v in vins)
            {
                Assert.AreEqual(true, class1.CheckVIN(v));
            }

            Assert.AreEqual(true, class1.CheckVIN("JHMCM56557C404453"));
            Assert.AreEqual(false, class1.CheckVIN("APMCM56557C404453"));

        }

        [TestMethod()]
        public void CheckVINTest_IsWDS()
        {
            Class1 class1 = new Class1();


            foreach (var v in vins)
            {
                Assert.AreEqual(true, class1.IsWDS(v.Substring(3, 6)));
            }

            Assert.AreEqual(true, class1.IsWDS("CM5655"));
            Assert.AreEqual(false, class1.IsWDS("CM565А"));
            Assert.AreEqual(true, class1.IsWDS("JJMCMX"));
        }

        [TestMethod()]
        public void CheckVINTest_IsBedVis()
        {
            Class1 class1 = new Class1();

            foreach (var v in vins)
            {
                Assert.AreEqual(true, class1.IsBedVis(v.Substring(9)));
            }

            Assert.AreEqual(true, class1.IsBedVis("7C404453"));
            Assert.AreEqual(false, class1.IsBedVis("ZC404453"));
            Assert.AreEqual(true, class1.IsBedVis("AC404453"));
            Assert.AreEqual(false, class1.IsBedVis("AC40445A"));
            Assert.AreEqual(false, class1.IsBedVis("AC40445A"));
            Assert.AreEqual(false, class1.IsBedVis("AC4044BA"));
            Assert.AreEqual(false, class1.IsBedVis("AC404XXA"));
        }

        [TestMethod()]
        public void CheckVINTest_ControllSum()
        {
            Class1 class1 = new Class1();

            /*             
              foreach (var v in vins)
              {
                  Assert.AreEqual(true, class1.ControllSum(v));
              }*/

            Assert.AreEqual(true, class1.ControllSum("JHMCM56557C404453"));

            Assert.AreEqual(false, class1.ControllSum("JHMCM56557C404452"));
            //Assert.AreEqual(false, class1.ControllSum("JHMCM56557C404454"));
        }

        [TestMethod()]
        public void GetVINCountryTest()
        {
            Class1 class1 = new Class1();

            Assert.AreEqual("Япония", class1.GetVINCountry("JHMCM56557C404453"));
        }

        [TestMethod()]
        public void GetTransportYearTest()
        {
            Class1 class1 = new Class1();

            Assert.AreEqual(2007,  class1.GetTransportYear ("JHMCM56557C404453"));
        }
    }
}