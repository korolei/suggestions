

namespace SuggestionsBox.Infrastructure
{
    public static class AppSettings
    {
        private const string FILE_PATH = "FilePath";
        private const string ADMIN_ROLE = "AdminRole";
        private const string APPLICATION_NAME = "Application Name";
        private const string EMAIL_REDIRECT = "EmailRedirect";
        private const string EXCEPTION_POLICY = "ExceptionPolicy";
        private const string IS_TESTING = "IsTesting";
        private const string SUGGESTIONS_BOX_URL = "SuggestionBoxUrl";

        public static string EventLogRecipients => EMAIL_REDIRECT;
        public static string ApplicationName => APPLICATION_NAME;
        public static string ExceptionPolicy => EXCEPTION_POLICY;
        public static string AdminRole => ADMIN_ROLE;
        public static bool IsTesting => bool.Parse(IS_TESTING);
        public static string SuggestionBoxUrl => SUGGESTIONS_BOX_URL;
        public static string FilePath => FILE_PATH;
    }
}