using System;
using System.Collections.Generic;
using FF.Contracts.Dto;
using FF.Contracts.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FF.Service;
using Newtonsoft.Json;
using NLog;
using Telerik.JustMock;

namespace FF.UnitTests.OldTests
{
    /// <summary>
    /// These are examples of tests that have problems and could be better.
    /// </summary>
    [TestClass()]
    public class LocationServiceTests
    {
        [TestMethod()]
        public void LocationServiceTest()
        {
            var log = Mock.Create<ILogger>();
            var http = Mock.Create<IHttpService>();
            var file = Mock.Create<IFileService>();

            var sut = new LocationService(http, file, log);

            Assert.IsNotNull(sut);
        }

        [TestMethod()]
        public void KeyTest()
        {
            var log = Mock.Create<ILogger>();
            var http = Mock.Create<IHttpService>();
            var file = Mock.Create<IFileService>();
            Mock.Arrange(() => file.ReadAllLines(Arg.AnyString))
                .Returns(new string[] { "key" })
                .OccursOnce();

            var target = new PrivateAccessor(new LocationService(http, file, log));

            var result = target.CallMethod("Key");

            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual("key", result);
        }

        [TestMethod()]
        public void GetPlaceDetailsTestResultName()
        {
            var place = Mock.Create<GooglePlace>();
            var placeResult = Mock.Create<GooglePlace.Result>();
            place.result = placeResult;
            place.status = "OK";
            place.result.name = "Super Saver";
            
            var log = Mock.Create<ILogger>();
            Mock.Arrange(() => log.Debug(Arg.AnyString))
                .OccursOnce();

            var http = Mock.Create<IHttpService>();
            Mock.Arrange(() => http.GetResponse(Arg.AnyString))
                .Returns(JsonConvert.SerializeObject(place))
                .OccursOnce();

            var file = Mock.Create<IFileService>();
            Mock.Arrange(() => file.ReadAllLines(Arg.AnyString))
                .Returns(new string[] {"key"})
                .OccursOnce();

            var sut = new LocationService(http, file, log);


            var result = sut.GetPlaceDetails("ChIJMya5ZceVlocR7j6awgpuImw");

            Mock.Assert(log);
            Mock.Assert(http);
            Mock.Assert(file);
            Assert.IsNotNull(result);
            Assert.AreEqual("OK", result.status);
            Assert.AreEqual("Super Saver", result.result.name);
        }

        [TestMethod()]
        public void GetPlaceDetailsTestHtmlAttributions()
        {
            var place = Mock.Create<GooglePlace>();
            var html = new List<object> {"one", "two"};
            place.status = "OK";
            place.html_attributions = html;

            var log = Mock.Create<ILogger>();
            Mock.Arrange(() => log.Debug(Arg.AnyString))
                .OccursOnce();

            var http = Mock.Create<IHttpService>();
            Mock.Arrange(() => http.GetResponse(Arg.AnyString))
                .Returns(JsonConvert.SerializeObject(place))
                .OccursOnce();

            var file = Mock.Create<IFileService>();
            Mock.Arrange(() => file.ReadAllLines(Arg.AnyString))
                .Returns(new string[] { "key" })
                .OccursOnce();

            var sut = new LocationService(http, file, log);


            var result = sut.GetPlaceDetails("DKvhe9sleedocR7j6awgpuImw");

            Mock.Assert(log);
            Mock.Assert(http);
            Mock.Assert(file);
            Assert.IsNotNull(result);
            Assert.AreEqual("OK", result.status);
            Assert.AreEqual("one", result.html_attributions[0].ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void GetPlaceDetailsTestFails()
        {
            var place = Mock.Create<GooglePlace>();
            var placeResult = Mock.Create<GooglePlace.Result>();
            place.result = placeResult;
            place.status = "Error";
            
            var log = Mock.Create<ILogger>();
            Mock.Arrange(() => log.Debug(Arg.AnyString))
                .OccursOnce();
            Mock.Arrange(() => log.Error(Arg.AnyString))
                .OccursOnce();

            var http = Mock.Create<IHttpService>();
            Mock.Arrange(() => http.GetResponse(Arg.AnyString))
                .Returns(JsonConvert.SerializeObject(place))
                .OccursOnce();

            var file = Mock.Create<IFileService>();
            Mock.Arrange(() => file.ReadAllLines(Arg.AnyString))
                .Returns(new string[] { "key" })
                .OccursOnce();

            var sut = new LocationService(http, file, log);

            var result = sut.GetPlaceDetails("ChIJMya5ZceVlocR7j6awgpuImw");    

            Mock.Assert(log);
            Mock.Assert(http);
            Mock.Assert(file);
            Assert.IsNotNull(result);
            Assert.AreEqual("Error", result.status);
        }

        [TestMethod()]
        public void GetNearbyPlacesTest()
        {
            
        }

        [TestMethod()]
        public void GetNearbyPlacesTestFails()
        {

        }

        [TestMethod()]
        public void ValidCoordinatesTest()
        {
            var log = Mock.Create<ILogger>();
            var http = Mock.Create<IHttpService>();
            var file = Mock.Create<IFileService>();
            Mock.Arrange(() => file.ReadAllLines(Arg.AnyString))
                .Returns(new string[] { "key" })
                .OccursOnce();

            var target = new PrivateAccessor(new LocationService(http, file, log));

            var result = target.CallMethod("ValidCoordinates", 90, 90);

            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);
        }

        [TestMethod()]
        public void InvalidCoordinatesTest()
        {
            var log = Mock.Create<ILogger>();
            var http = Mock.Create<IHttpService>();
            var file = Mock.Create<IFileService>();
            Mock.Arrange(() => file.ReadAllLines(Arg.AnyString))
                .Returns(new string[] { "key" })
                .OccursOnce();

            var target = new PrivateAccessor(new LocationService(http, file, log));

            var result = target.CallMethod("ValidCoordinates", 200, 200);

            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsFalse((bool)result);
        }
    }
}


