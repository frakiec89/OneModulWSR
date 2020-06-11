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
        [TestMethod()]
        public void CheckVINTest_Count()
        {
            Class1 class1 = new Class1();
            Assert.AreEqual(class1.IsCountSimbol("JHMCM56557C404453"), true);
            Assert.AreEqual(class1.IsCountSimbol("JHMCM56557C40445"), false);
            Assert.AreEqual(class1.IsCountSimbol("JHMCM56557C4044533"), false);
        }



        [TestMethod()]
        public void CheckVINTest_IsBedCount()
        {
            Class1 class1 = new Class1();

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

            Assert.AreEqual(true, class1.IsBebWMI("JAM", out name));

            Assert.AreEqual(class1.IsBebWMI("A09", out name), false);
        }

        [TestMethod()]
        public void CheckVINTest()
        {
            Class1 class1 = new Class1();

            Assert.AreEqual(true, class1.CheckVIN("JHMCM56557C404453"));
            Assert.AreEqual(false, class1.CheckVIN("APMCM56557C404453"));
            Assert.AreEqual(true, class1.CheckVIN("JJMCM56557C404453"));
        }

        [TestMethod()]
        public void CheckVINTest_IsWDS()
        {
            Class1 class1 = new Class1();

            Assert.AreEqual(true, class1.IsWDS("CM5655"));
            Assert.AreEqual(false, class1.IsWDS("CM565А"));
            Assert.AreEqual(true, class1.IsWDS("JJMCMX"));
        }


        [TestMethod()]
        public void CheckVINTest_IsBedVis()
        {
            Class1 class1 = new Class1();

            Assert.AreEqual(true, class1.IsBedVis("7C404453"));
            Assert.AreEqual(false, class1.IsBedVis("ZC404453"));
            Assert.AreEqual(true,  class1.IsBedVis("AC404453"));
            Assert.AreEqual(false, class1.IsBedVis("AC40445A"));
            Assert.AreEqual(false, class1.IsBedVis("AC40445A"));
            Assert.AreEqual(false, class1.IsBedVis("AC4044BA"));
            Assert.AreEqual(false, class1.IsBedVis("AC404XXA"));
        }
    }
}