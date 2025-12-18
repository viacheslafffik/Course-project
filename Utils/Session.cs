namespace Course_Project.Utils
{
    internal static class Session
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static string FirstName { get; set; }

        public static bool IsAdmin => Role == "admin";

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
            FirstName = null;
        }
    }
}
