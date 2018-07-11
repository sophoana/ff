using FF.Contracts.Service;
using FF.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using NLog;
using Telerik.JustMock;

namespace FF.UnitTests.Service
{
    [TestClass]
    public class LocationServiceTests
    {

        public class LocationServiceBuilder
        {
            IHttpService _httpService = Mock.Create<IHttpService>();
            IFileService _fileService = Mock.CreateLike<IFileService>(
                fs => fs.ReadAllLines(Arg.AnyString) == new string[] { "key" });

            private ILogger _log = Mock.Create<ILogger>();

            public LocationServiceBuilder WithHttpService(IHttpService httpService)
            {
                _httpService = httpService;
                return this;
            }

            public LocationServiceBuilder WithFileService(IFileService fileService)
            {
                _fileService = fileService;
                return this;
            }

            public LocationService Build()
            {
                return new LocationService(_httpService, _fileService, _log);
            }

            public string GetPlaceDetailsTestResults(string placeId)
            {
                #region results
                var results =
                    @"{
   ""html_attributions"" : [],
   ""result"" : {
      ""address_components"" : [
         {
            ""long_name"" : ""5440"",
            ""short_name"" : ""5440"",
            ""types"" : [ ""street_number"" ]
         },
         {
            ""long_name"" : ""S. 56th Street"",
            ""short_name"" : ""S. 56th Street"",
            ""types"" : [ ""route"" ]
         },
         {
            ""long_name"" : ""Colonial Hills"",
            ""short_name"" : ""Colonial Hills"",
            ""types"" : [ ""neighborhood"", ""political"" ]
         },
         {
            ""long_name"" : ""Lincoln"",
            ""short_name"" : ""Lincoln"",
            ""types"" : [ ""locality"", ""political"" ]
         },
         {
            ""long_name"" : ""Lancaster County"",
            ""short_name"" : ""Lancaster County"",
            ""types"" : [ ""administrative_area_level_2"", ""political"" ]
         },
         {
            ""long_name"" : ""Nebraska"",
            ""short_name"" : ""NE"",
            ""types"" : [ ""administrative_area_level_1"", ""political"" ]
         },
         {
            ""long_name"" : ""United States"",
            ""short_name"" : ""US"",
            ""types"" : [ ""country"", ""political"" ]
         },
         {
            ""long_name"" : ""68516"",
            ""short_name"" : ""68516"",
            ""types"" : [ ""postal_code"" ]
         }
      ],
      ""adr_address"" : ""\u003cspan class=\""street-address\""\u003e5440 S. 56th Street\u003c/span\u003e, \u003cspan class=\""locality\""\u003eLincoln\u003c/span\u003e, \u003cspan class=\""region\""\u003eNE\u003c/span\u003e \u003cspan class=\""postal-code\""\u003e68516\u003c/span\u003e, \u003cspan class=\""country-name\""\u003eUSA\u003c/span\u003e"",
      ""formatted_address"" : ""5440 S. 56th Street, Lincoln, NE 68516, USA"",
      ""formatted_phone_number"" : ""(402) 423-7181"",
      ""geometry"" : {
         ""location"" : {
            ""lat"" : 40.75802789999999,
            ""lng"" : -96.6398406
         }
      },
      ""icon"" : ""https://maps.gstatic.com/mapfiles/place_api/icons/shopping-71.png"",
      ""id"" : ""f3ce7b6236acf44e3dca0eb86d1453cf60838edc"",
      ""international_phone_number"" : ""+1 402-423-7181"",
      ""name"" : ""Super Saver"",
      ""opening_hours"" : {
         ""open_now"" : true,
         ""periods"" : [
            {
               ""open"" : {
                  ""day"" : 0,
                  ""time"" : ""0000""
               }
            }
         ],
         ""weekday_text"" : [
            ""Monday: Open 24 hours"",
            ""Tuesday: Open 24 hours"",
            ""Wednesday: Open 24 hours"",
            ""Thursday: Open 24 hours"",
            ""Friday: Open 24 hours"",
            ""Saturday: Open 24 hours"",
            ""Sunday: Open 24 hours""
         ]
      },
      ""photos"" : [
         {
            ""height"" : 3024,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/113460033458276629987/photos\""\u003eMatt McCoy\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAANX3b96IOm-FYwKIfF-5EgJXyvDGzwtMj3EUilzLlTtH7ESL32xiigMusux4VFDDoO_XA4PWSDQ6YhzpDEG94G4OGRK64GESyE0GnREHfz_129eikJk5qSjbrdkTY0DxmJvhvNlZcIZSFYaUrQJn5I9Xc3RMCGLu7W_HMfCkg5rlEhCF0mIFkEQfIA7GPGkVfY65GhQvjcpfJRHRzcpSQq5-d887S-cLgQ"",
            ""width"" : 4032
         },
         {
            ""height"" : 2448,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/108154670478057011366/photos\""\u003eMarty Jarvis\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAANHV0TtJAKAaxjq-X6nP9dl-btoWBugVul7BcfEwJw8iJJabqBcJJGUbW7K8pYTpkXeGairJbjXkF-ODoYHdoPHFpk9rIlaDMRqhtpTF4azt9l0maXBLQqSco4U48J0VZJFRtRiowKwPh6jHqC7_OZdCAwMv6Uk4HgczYne2ikuREhD5XlIxSF9vxdI4s5uDFXMgGhTQGWmMRXNIQEdWumhusKVkCcvzjg"",
            ""width"" : 3264
         },
         {
            ""height"" : 1200,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/114984212475113670487/photos\""\u003eSuper Saver\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAADTKl5UuCXaKiljtPdXR2xZFdfd6RoxukY-MYzl_ghsQDQzNhq0IMKV2Mii6cZxc52eDP_1V8u4BEaEUmDwna_c2JCzuZ0jVtOy8GoZ9HiKsSl_YN-rQMRqf_MX1Oq9Q1uEnjiPU50wZX2g6-Uvs0xRpJyPsE1WnEekCCuMbeilPEhDq_Qa_MJGoqy0Nc-8pFwhlGhRPYJkrU6A7sm2xUGMMq-a5HnzOjA"",
            ""width"" : 1800
         },
         {
            ""height"" : 2736,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/114984212475113670487/photos\""\u003eSuper Saver\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAAJlieQsaD2TUINRZDEkbjPIHq4Xa2IwsYHFJ15aM69S5tVxuYi3HND-jus4r0x85nj46ImOQVzBBTeSfPyEHdB0RS9YuV6TSWAc3lN95EWPD1vjAtohriWZbSMMTFHLDXiohAZy_zpmJD5E_eFROU1kw2Ml8CnT4xRPk3RxXAGqwEhCgQ5nhlxa771aOWxqTfZCCGhTVzzJkd2UpuhXv8V4WvQefyf6o-g"",
            ""width"" : 3648
         },
         {
            ""height"" : 2736,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/114984212475113670487/photos\""\u003eSuper Saver\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAALx6PKDNdJMvwIchYV6FKrb1hC35_KywYryww0mWIS--r6XVFALOQ-aEYGTn8rzqMzUi1xgte5Qo5hYh_3jfHhup5TVBur7ww2vjyctdXlATzNFnLwLX_avyeUY4Wq0a9K5FnZqIb4P61pK6LBxjOW5Q6_v2NsqBQ9lvMx-s-6eVEhBRj5pXyksdJjyTDk8ayREnGhQ8LbCLIXMAjlSjMvjjjwwpneuVdg"",
            ""width"" : 3648
         },
         {
            ""height"" : 2736,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/114984212475113670487/photos\""\u003eSuper Saver\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAAHVPTLms-ebT9u3I7cMSUNpnyR0nuH_QeuoopJ89NTa9lvNoO1LVzgVHnY6pNVsbDtcLAW7aei9dWcxUBGsjAL4xHhMqEstQE1U28Y9XkH8fKT1GC5wJ5gWMO1KJE_w9omdGn83_1cxYqIEBsUDemUevo6NTSERVZakiOi18zmzuEhAgPQ2MZHntcmqTiIZvmzZhGhQs-0BixLdHAX61TREAqy5-IhMyFA"",
            ""width"" : 3648
         },
         {
            ""height"" : 402,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/114984212475113670487/photos\""\u003eSuper Saver\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAAPJkcwx98cLPlMieqQPhLXUclP97Uzex9TNh-8Vzyk_Rg6IhVjkdsIhgKtl8pqWQpV_TAVNRvjsYzhrz2Dx6J-I3nDpVh7unktoQVi2WUeiWu3uoYYvREGVDbU9GcmsXDtANQ-YibQWIZ4y14Ym_4SHeEhBQVzQ2sHXWBcScFhTVEhBkJACh-JchXBpWND8l9nY9GhTGYd-eXUX0qzhV3R2ouD7rqhwajA"",
            ""width"" : 465
         },
         {
            ""height"" : 3648,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/114984212475113670487/photos\""\u003eSuper Saver\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAAMbWlL1BbrEIz_V30l-x7lbTIWPvM-kegboBolT68XR4nXblnFk5W8rEHM3bORojMiLPXCc-ReLSvdNKGf3EgXT-lgxehdTEA-FepkvTVQGHkWJpcwhNk_RCPI62PBabVvDx-3nonmBAZF1staNaweb_Fzky7NKUriwiWj9cNjSEEhC9DtQVdkqaDbiTokvEFlwLGhS8B2zIuCZWzj0kkxbYJJNtEWy1Aw"",
            ""width"" : 2736
         },
         {
            ""height"" : 3648,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/114984212475113670487/photos\""\u003eSuper Saver\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAABYCaFUnORzQbPwbDuVINcjblIcFbP_ovnNqkZbTbEAIlIladcW0uNE549iIl3SeU_XadIfHIrcn6Z28Mg3_aGq9_KnJr4T5rJExel_AhPyhpYzac4p6A_skyt4WifnBhuMU2_L8m-_k7Yp0DDCgtbOMKQLY_wsXwWJ4YIfej3X7EhDLoFjQjIic-TezteTq38HqGhQFeTXjUuhALbKwlnik5KaooSkysw"",
            ""width"" : 2736
         },
         {
            ""height"" : 2736,
            ""html_attributions"" : [
               ""\u003ca href=\""https://maps.google.com/maps/contrib/114984212475113670487/photos\""\u003eSuper Saver\u003c/a\u003e""
            ],
            ""photo_reference"" : ""CoQBdwAAAEIdRNchEwer5lYWX40svxqCoNprwkUFSnUSq_IA3_ynEWpMaLF3kc5Tx1XHl7Jmui8Zr5nm68W6AlxDEVLpFcOZvqWADLEX4Miqt8zffBii8hIY8C5TigcVvRbk0z__45htzzTvThX1yL_T72oPR4uvCW-Or1olypOSk0xEjI2KEhAPoiESUfLulvmnlwnMUrLAGhQ_Ll-N-lAfuapIsT8sCuok9F7HSw"",
            ""width"" : 3648
         }
      ],
      ""place_id"" : """ + placeId + @""",
      ""rating"" : 4.3,
      ""reference"" : ""CmReAAAAUMAMonmnJN4n2dMK4B580pVTv0IjR_qQKQt799kCgoGbn5G75PytDb5bCTG0xOkFh5SvwoIuF3iUZAqY1BB6KbbL7o1Ai_D0SUuVqeQDRscrY1ekDOS0hT2xDZFVhgSTEhBvtTxHuVfVHLF-HD385ZQAGhQAMOni4DUd-sEjh2lvA6BvjXlsrg"",
      ""reviews"" : [
         {
            ""aspects"" : [
               {
                  ""rating"" : 3,
                  ""type"" : ""overall""
               }
            ],
            ""author_name"" : ""Jerry Brasuell"",
            ""author_url"" : ""https://plus.google.com/113610583708157496655"",
            ""language"" : ""en"",
            ""profile_photo_url"" : ""//lh5.googleusercontent.com/-xQfPlEjtcy4/AAAAAAAAAAI/AAAAAAAAEsg/qbLwJ34Hfbk/photo.jpg"",
            ""rating"" : 5,
            ""text"" : ""I have lived in Lincoln for 26 years and this is my go-to store for groceries and misc items I need. I dont have to go far for help if i need it. All the managers and employees are pleasant and I have gotten to know a few well enough that they wave hello to me and smile when they see me.\n The store layout is nice and I have never had a problem finding what I need. Prices and quality is great. \nWould recommend this store before any of the others. "",
            ""time"" : 1468019906
         },
         {
            ""aspects"" : [
               {
                  ""rating"" : 1,
                  ""type"" : ""overall""
               }
            ],
            ""author_name"" : ""Gary Walter"",
            ""author_url"" : ""https://plus.google.com/114189646695253941480"",
            ""language"" : ""en"",
            ""profile_photo_url"" : ""//lh6.googleusercontent.com/-rRfYGZX2RgM/AAAAAAAAAAI/AAAAAAAAqJY/-uQpq4Ue75o/photo.jpg"",
            ""rating"" : 3,
            ""text"" : ""Good prices, good selection. Employees could me more helpful."",
            ""time"" : 1463835992
         },
         {
            ""aspects"" : [
               {
                  ""rating"" : 2,
                  ""type"" : ""overall""
               }
            ],
            ""author_name"" : ""jon harring"",
            ""author_url"" : ""https://plus.google.com/110411008975317112395"",
            ""language"" : ""en"",
            ""profile_photo_url"" : ""//lh5.googleusercontent.com/-A35YRIMd71I/AAAAAAAAAAI/AAAAAAAAKQQ/KfHEg-umHcU/photo.jpg"",
            ""rating"" : 4,
            ""text"" : ""Good- the employees are usually friendly and helpful, a couple have had sour attitudes, but everybody can have a bad day now and then.  The Produce section has very good stuff."",
            ""time"" : 1438238121
         },
         {
            ""aspects"" : [
               {
                  ""rating"" : 3,
                  ""type"" : ""overall""
               }
            ],
            ""author_name"" : ""jo ma"",
            ""author_url"" : ""https://plus.google.com/111133793872329161241"",
            ""language"" : ""en"",
            ""profile_photo_url"" : ""//lh4.googleusercontent.com/-T8vZFBYglVg/AAAAAAAAAAI/AAAAAAAAAHQ/JoQ_GoYVDk4/photo.jpg"",
            ""rating"" : 5,
            ""text"" : ""Things are much better now."",
            ""time"" : 1449242563
         },
         {
            ""aspects"" : [
               {
                  ""rating"" : 3,
                  ""type"" : ""overall""
               }
            ],
            ""author_name"" : ""Kylee Jones"",
            ""author_url"" : ""https://plus.google.com/117101254948877883666"",
            ""language"" : ""en"",
            ""profile_photo_url"" : ""//lh3.googleusercontent.com/-YiDwiz4u46A/AAAAAAAAAAI/AAAAAAAAA-Y/JxCEdw1AdbQ/photo.jpg"",
            ""rating"" : 5,
            ""text"" : ""very kush"",
            ""time"" : 1415723737
         }
      ],
      ""scope"" : ""GOOGLE"",
      ""types"" : [
         ""grocery_or_supermarket"",
         ""pharmacy"",
         ""bakery"",
         ""florist"",
         ""health"",
         ""restaurant"",
         ""food"",
         ""store"",
         ""point_of_interest"",
         ""establishment""
      ],
      ""url"" : ""https://maps.google.com/?cid=8963553868234341464"",
      ""utc_offset"" : -300,
      ""vicinity"" : ""5440 S. 56th Street, Lincoln"",
      ""website"" : ""http://www.super-saver.com/""
   },
   ""status"" : ""OK""
}";
                #endregion
                return results;
            }

        }

        private LocationService MakeLocationService()
        {
            var httpService = Mock.Create<IHttpService>();
            var fileService = Mock.Create<IFileService>();
            var log = Mock.Create<ILogger>();
            var service = new LocationService(httpService, fileService, log);

            return service;
        }

        [TestMethod]
        public void GetPlaceDetails_WithAPlaceId_ReturnsTheGooglePlace()
        {
            //Arrange
            var serviceBuilder = new LocationServiceBuilder();
            var placeId = "10302";
            var httpService = Mock.Create<IHttpService>();
            Mock.Arrange(() => httpService.GetResponse(Arg.AnyString))
                .Returns(serviceBuilder.GetPlaceDetailsTestResults(placeId));
            var service = serviceBuilder.WithHttpService(httpService).Build();


            //Act
            var result = service.GetPlaceDetails(placeId).result;

            //Assert
            Assert.AreEqual(placeId, result.place_id
                , "the place id returned should match what was passed in");

            result.place_id.Should().Be(placeId,
                "because the place id returned should match what was passed in");

        }

        [TestMethod]
        public void GetPlaceDetails_WithNoPlaceId_RaisesArgumentException()
        {
            //Arrange


            //Act


            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetPlaceDetails_WithInvalidPlaceId_RaisesApplicationException()
        {
            //Arrange


            //Act


            //Assert
            throw new ApplicationException("example");
        }

        [TestMethod]
        public void GetNearbyPlaces_WithInvalidLatLong_RaisesArugmentException()
        {
            //Arrange


            //Act


            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void GetNearbyPlaces_WhenCallReturnsErrorCode_RaisesApplicationException()
        {
            //Arrange


            //Act


            //Assert
            throw new ApplicationException("example");
        }

        [TestMethod]
        public void GetNearbyPlaces_WhenEverythingWorks_ReturnsMyData()
        {
            //Arrange


            //Act


            //Assert

        }

    }
}
