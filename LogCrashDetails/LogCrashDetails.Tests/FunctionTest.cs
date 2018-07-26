using System.Threading.Tasks;
using Xunit;

namespace LogCrashDetails.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async Task Test()
        {
            await new Function().FunctionHandler(new CrashDetail
            {
                ApplicationName = "LogCrashDetails",
                ApplicationVersion = "1.0",
                ContextJson = "{ TestProperty = \"test\"}",
                StackTrace = "Test"
            });
        }
    }
}
