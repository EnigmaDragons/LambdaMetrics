using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace RecordMetric
{
    public class Function
    {
        public async Task FunctionHandler(Metric metric)
        {
            using (var client = new AmazonS3Client(RegionEndpoint.USWest2))
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = "enigma-dragons-metrics",
                    Key = $"{metric.ApplicationName.Replace(" ", String.Empty)}-{metric.MetricName.Replace(" ", String.Empty)}-{Guid.NewGuid().ToString()}",
                    ContentBody = JsonConvert.SerializeObject(new
                    {
                        UnixUtcMillis = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds,
                        metric.ApplicationName,
                        metric.ApplicationVersion,
                        metric.PlayerID,
                        metric.MetricName,
                        metric.Value
                    })
                };
                await client.PutObjectAsync(putRequest);
            }
        }
    }
}
