using PrintCareThirdTry.GUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for JobControlPanelTest and is intended
    ///to contain all JobControlPanelTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JobControlPanelTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for btnPredictInkValveValues_Click
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PrintCareThirdTry.exe")]
        public void btnPredictInkValveValues_ClickTest()
        {
            JobControlPanel_Accessor target = new JobControlPanel_Accessor(); // TODO: Initialize to an appropriate value
            object sender = null; // TODO: Initialize to an appropriate value
            RoutedEventArgs e = null; // TODO: Initialize to an appropriate value
            target.btnPredictInkValveValues_Click(sender, e);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
