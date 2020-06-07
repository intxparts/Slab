using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slab.Tools;

namespace Tests
{
    [TestClass]
    public class SwatchVMTests
    {
        [TestMethod]
        public void RGB_are_zero_prior_to_initialization()
        {
            var swatchVM = new SwatchViewModel();
            Assert.AreEqual(swatchVM.Red, 0);
            Assert.AreEqual(swatchVM.Green, 0);
            Assert.AreEqual(swatchVM.Blue, 0);
        }

        [TestMethod]
        public void RGB_match_GLDataContextBackgroundColor_after_initialization()
        {
            //var swatchVM = new SwatchViewModel();
            //var glDataContext = new Slab.GLDataContext() { BackgroundColor = new Slab.Color() { Red = 2, Blue = 4, Green = 6 } };
            //swatchVM.Initialize(glDataContext, new Slab.DataModel(), new Slab.LicenseData());

            //Assert.AreEqual(swatchVM.Red, glDataContext.BackgroundColor.Red);
            //Assert.AreEqual(swatchVM.Green, glDataContext.BackgroundColor.Green);
            //Assert.AreEqual(swatchVM.Blue, glDataContext.BackgroundColor.Blue);
        }

        [TestMethod]
        public void Updates_GLDataContextBackgroundColor_after_apply()
        {
            //var swatchVM = new SwatchViewModel();
            //var glDataContext = new Slab.GLDataContext() { BackgroundColor = new Slab.Color() { Red = 2, Blue = 4, Green = 6 } };
            //swatchVM.Initialize(glDataContext, new Slab.DataModel(), new Slab.LicenseData());

            //swatchVM.Red = 10;
            //swatchVM.Blue = 17;

            //swatchVM.ApplyBtn_OnClick.Execute(null);

            //Assert.AreEqual(10, glDataContext.BackgroundColor.Red);
            //Assert.AreEqual(6, glDataContext.BackgroundColor.Green);
            //Assert.AreEqual(17, glDataContext.BackgroundColor.Blue);
        }
    }

    [TestClass]
    public class SwatchToolTests
    {
        [TestMethod]
        public void NotVisible_with_no_licenseData()
        {
            var swatchTool = new SwatchTool();
            Assert.IsFalse(swatchTool.IsVisible);
        }

        [TestMethod]
        public void IsVisible_for_experimental_licenses()
        {
            //var swatchTool = new SwatchTool();
            //swatchTool.Initialize(new Slab.DataModel(), new Slab.LicenseData() { LicenseType = Slab.LicenseType.Experimental });
            //Assert.IsTrue(swatchTool.IsVisible);
        }

        [TestMethod]
        public void NotVisible_for_basic_license()
        {
            //var swatchTool = new SwatchTool();
            //swatchTool.Initialize(new Slab.DataModel(), new Slab.LicenseData() { LicenseType = Slab.LicenseType.Basic });
            //Assert.IsFalse(swatchTool.IsVisible);
        }
    }
}
