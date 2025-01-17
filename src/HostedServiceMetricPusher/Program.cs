using HostedServiceMetricPusher;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prometheus.Client.MetricPusher;
using Prometheus.Client.MetricPusher.HostedService;

var metricPusher = new MetricPusher(new MetricPusherOptions
{
    Endpoint = "http://localhost:9091",
    Job = "pushgateway",
    Instance = "instance"
});

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMetricPusherHostedService(metricPusher);
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
