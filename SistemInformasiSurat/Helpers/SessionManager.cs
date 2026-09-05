using SistemInformasiSurat.Models;

namespace SistemInformasiSurat.Helpers
{
    public static class SessionManager
    {
        private static User _currentUser;

        public static User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        public static bool IsLoggedIn
        {
            get { return _currentUser != null; }
        }

        public static bool IsAdmin
        {
            get { return _currentUser != null && _currentUser.RoleName == "Admin"; }
        }

        public static bool IsUser
        {
            get { return _currentUser != null && _currentUser.RoleName == "User"; }
        }

        public static void Logout()
        {
            _currentUser = null;
        }

        public static string GetUserInfo()
        {
            if (IsLoggedIn)
            {
                return $"User: {CurrentUser.NamaLengkap} | Role: {CurrentUser.RoleName}";
            }
            return "Not Logged In";
        }
    }
}