using System;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public class ExampleHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        string fileLocation = @"..\OperationLog.txt";
        using (var fs = new FileStream(fileLocation, FileMode.Open))
        {
            if (fs.CanWrite)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("File has writing permissions"));
            }
            return Task.FromResult(
                HealthCheckResult.Unhealthy("File doesn't have writing permissions"));
        }
    }
}