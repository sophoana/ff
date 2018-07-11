using FF.Contracts.Dto;
using FF.Contracts.Service;
using Newtonsoft.Json;
using NLog;
using System;
using System.Linq;


namespace FF.Service
{
    public class LocationService : ILocationService
    {
        private IHttpService _httpService;
        private IFileService _fileService;
        private ILogger _log;
        private const string _statusOK = "OK";

        /// <summary>
        /// Google's Place Nearby API https://developers.google.com/places/web-service/search
        /// </summary>
        private string _urlNearBy = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=500&types=grocery_or_supermarket&key={2}";

        /// <summary>
        /// Google's Place Details API https://developers.google.com/places/web-service/details
        /// </summary>
        private string _urlDetails = "https://maps.googleapis.com/maps/api/place/details/json?placeid={0}&key={1}";

        public LocationService(IHttpService httpService, IFileService fileService, ILogger log)
        {
            _httpService = httpService;
            _fileService = fileService;
            _log = log;
        }

        private string Key()
        {
            return _fileService.ReadAllLines("C:/Key/google.txt").First<string>();
        }

        public GooglePlace GetPlaceDetails(string placeId)
        {
            if (string.IsNullOrWhiteSpace(placeId))
            {
                throw new ArgumentException("PlaceId is required");
            }

            var url = string.Format(_urlDetails, placeId, Key());
            string result = _httpService.GetResponse(url);
            _log.Debug(string.Format("GetPlaceDetails({0}) returned {1}", placeId, result.Count()));

            var place = (GooglePlace) JsonConvert.DeserializeObject<GooglePlace>(result);

            if (place.status != _statusOK)
            {
                _log.Error(string.Format("GetPlaceDetails for placeId {0} returned status {1}. Result: {2}",
                    placeId,
                    place.status,
                    result));
                throw new ApplicationException("Call to Google Place API failed");
            }

            return place;
        }

        public GoogleNearby GetNearbyPlaces(double latitude, double longitude)
        {
            if(!ValidCoordinates(latitude, longitude))
            {
                throw new ArgumentException($"Invalid Latitude {latitude} or Longitude {longitude}.");
            }
            var url = string.Format(_urlNearBy, latitude, longitude, Key());
            string result = _httpService.GetResponse(url);
            _log.Debug("GetNearbyPlaces({0},{1}) returned {2}", latitude, longitude, result);

            var nearby = (GoogleNearby)JsonConvert.DeserializeObject<GoogleNearby>(result);

            if (nearby.status != _statusOK)
            {
                _log.Error("GetNearbyPlaces for lat {0} and long {1} returned status {2}. Result: {3}",
                    latitude,
                    longitude,
                    nearby.status,
                    result);
                throw new ApplicationException("Call to Google Nearby API failed");
            }

            return nearby;
        }

        private bool ValidCoordinates(double latitude, double longitude)
        {
            return Math.Abs(latitude) <= 90 && Math.Abs(longitude) <= 180;
        }
    }
}
