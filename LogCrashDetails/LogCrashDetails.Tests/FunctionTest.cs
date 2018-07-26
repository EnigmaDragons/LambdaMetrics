using Xunit;

namespace LogCrashDetails.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void Test()
        {
            new Function().FunctionHandler(new CrashDetail
            {
                ApplicationName = "LogCrashDetails",
                ApplicationVersion = "1.0",
                ContextJson = "{ TestProperty = \"test\"}",
                StackTrace = "Test"
            });
        }
    }
}
