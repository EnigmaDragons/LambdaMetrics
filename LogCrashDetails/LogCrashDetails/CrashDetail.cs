namespace LogCrashDetails
{
    public class CrashDetail
    {
        public string ApplicationName { get; set; }
        public string ApplicationVersion { get; set; }
        public string ContextJson { get; set; }
        public string StackTrace { get; set; }
    }
}
