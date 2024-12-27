namespace foodordering
{
    public class UserSession
    {
        private static UserSession instance;

        public static UserSession Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserSession();
                return instance;
            }
        }

        public string LoggedInUsername { get; set; }
        public string AvatarPath { get; set; }

        private UserSession() { }
    }



}
