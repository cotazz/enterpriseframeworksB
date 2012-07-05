using CavanGaelsCarRentals.Ingestion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using CavanGaelsCarRentals.Models;
using System.Collections.Generic;
using System.IO;


namespace Tests
{
     /// <summary>
     ///This is a test class for CSVParserTest and is intended
     ///to contain all CSVParserTest Unit Tests
     ///</summary>

     
     [TestClass]
     public class CSVParserTest
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


          /// <summary>
          ///A test for CSVParser Constructor
          ///</summary>
          // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
          // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
          // whether you are testing a page, web service, or a WCF service.
          [TestMethod()]
          [HostType("ASP.NET")]
          [AspNetDevelopmentServerHost("", "/")]
          [UrlToTest("http://localhost:56662/")]
          public void CSVParserConstructorTest()
          {
               CSVParser target = new CSVParser();
               Assert.Inconclusive("TODO: Implement code to verify target");
          }

          /// <summary>
          ///A test for DemoApplication.ingestion.IDataparser.parseExchangerates
          ///</summary>
          // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
          // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
          // whether you are testing a page, web service, or a WCF service.
          [TestMethod()]
          [HostType("ASP.NET")]
          [AspNetDevelopmentServerHost("C:\\Users\\Jim\\Desktop\\DemoApp\\DemoApplication\\DemoApplication", "/")]
          [UrlToTest("http://localhost:56662/")]
          [DeploymentItem("DemoApplication.dll")]
          public void parseExchangeratesTest()
          {
               IDataparser target = new CSVParser(); // TODO: Initialize to an appropriate value
               List<Car> expected = null; // TODO: Initialize to an appropriate value
               List<Car> actual;
               actual = target.();
               Assert.AreEqual(expected, actual);
               Assert.Inconclusive("Verify the correctness of this test method.");
          }

          /// <summary>
          ///A test for DemoApplication.ingestion.IDataparser.setStreamSource
          ///</summary>
          // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
          // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
          // whether you are testing a page, web service, or a WCF service.
          [TestMethod()]
          [HostType("ASP.NET")]
          [AspNetDevelopmentServerHost("C:\\Users\\Jim\\Desktop\\DemoApp\\DemoApplication\\DemoApplication", "/")]
          [UrlToTest("http://localhost:56662/")]
          [DeploymentItem("DemoApplication.dll")]
          public void setStreamSourceTest()
          {
               IDataparser target = new CSVParser(); // TODO: Initialize to an appropriate value
               StreamReader reader = null; // TODO: Initialize to an appropriate value
               target.setStreamSource(reader);
               Assert.Inconclusive("A method that does not return a value cannot be verified.");
          }

          /// <summary>
          ///A test for DemoApplication.ingestion.IDataparser.supportsType
          ///</summary>
          // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
          // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
          // whether you are testing a page, web service, or a WCF service.
          [TestMethod()]
          [HostType("ASP.NET")]
          [AspNetDevelopmentServerHost("C:\\Users\\Jim\\Desktop\\DemoApp\\DemoApplication\\DemoApplication", "/")]
          [UrlToTest("http://localhost:56662/")]
          [DeploymentItem("DemoApplication.dll")]
          public void supportsTypeTest()
          {
               IDataparser target = new CSVParser(); // TODO: Initialize to an appropriate value
               string format = string.Empty; // TODO: Initialize to an appropriate value
               bool expected = false; // TODO: Initialize to an appropriate value
               bool actual;
               actual = target.supportsType(format);
               Assert.AreEqual(expected, actual);
               Assert.Inconclusive("Verify the correctness of this test method.");
          }




          //[TestMethod]
          //public void TestMethod1()
          //{
          //}
     }
}
