using FF.Contracts.Service;

namespace FF.Service
{
    /// <summary>
    /// Warning, bad code ahead!
    /// </summary>
    public class SecurityService : ISecurityService
    {
        private static ISecurityService _service;

        private SecurityService()
        {
        }

        public static ISecurityService Instance
        {
            get
            {
                if (_service == null)
                {
                    _service = new SecurityService();
                }
                return _service;
            }
        }

        public string CurrentUser()
        {
            return "Test user";
        }

        public int CurrentUserId()
        {
            return 1;
        }

        public string UserIpAddress()
        {
            return "127.0.0.1";
        }
    }
}
