using FF.Contracts.Dto;

namespace FF.Contracts.Service
{
    public interface ILocationService
    {
        GooglePlace GetPlaceDetails(string placeId);
        GoogleNearby GetNearbyPlaces(double latitude, double longitude);
    }
}
