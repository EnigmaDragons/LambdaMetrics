using System.Threading.Tasks;
using Xunit;

namespace RecordMetric.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async Task Test()
        {
            await new Function().FunctionHandler(new Metric
            {
                ApplicationName = "RecordMetric",
                ApplicationVersion = "1.0",
                MetricName = "test",
                Value = "test",
                PlayerID = "this is tots unique ;)"
            });
        }
    }
}
