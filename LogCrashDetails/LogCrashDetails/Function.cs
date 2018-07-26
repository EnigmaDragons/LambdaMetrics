using System;
using System.Data.SqlClient;
using Amazon.Lambda.Core;
using Dapper;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace LogCrashDetails
{
    public class Function
    {
        public void FunctionHandler(CrashDetail input)
        {
            using (var db = new SqlConnection("nope"))
            {
                db.Execute("INSERT INTO Metrics.CrashReports (ReceivedTimeUtc, ApplicationName, ApplicationVersion, ContextJson, StackTrace) " +
                           "Values (@UnixUtcMillis, @ApplicationName, @ApplicationVersion, @ContextJson, @StackTrace);", 
                           new
                            {
                                UnixUtcMillis = (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds,
                                input.ApplicationName,
                                input.ApplicationVersion,
                                input.ContextJson,
                                input.StackTrace 
                            });
            }
        }
    }
}
