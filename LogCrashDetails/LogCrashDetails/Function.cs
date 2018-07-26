using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.Lambda.Core;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Dapper;
using Newtonsoft.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LogCrashDetails
{
    public class Function
    {
        public async Task FunctionHandler(CrashDetail input)
        {
            using (var client = new AmazonS3Client(RegionEndpoint.USWest2))
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = "enigma-dragons-crash-reports",
                    Key = $"{input.ApplicationName.Replace(" ", String.Empty)}-{Guid.NewGuid().ToString()}",
                    ContentBody = JsonConvert.SerializeObject(new
                    {
                        UnixUtcMillis = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds,
                        input.ApplicationName,
                        input.ApplicationVersion,
                        input.ContextJson,
                        input.StackTrace 
                    }) 
                };
                await client.PutObjectAsync(putRequest);
            }
        }
    }
}
