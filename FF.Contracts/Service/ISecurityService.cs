namespace FF.Contracts.Service
{
    public interface ISecurityService
    {
        string CurrentUser();

        string UserIpAddress();

        int CurrentUserId();

    }
}
