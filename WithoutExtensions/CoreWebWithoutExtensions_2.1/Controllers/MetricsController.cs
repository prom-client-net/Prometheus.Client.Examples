﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prometheus.Client;

namespace CoreWebWithoutExtensions.Controllers
{
    [Route("[controller]")]
    public class MetricsController : Controller
    {
        [HttpGet]
        public async Task Get()
        {
            Response.StatusCode = 200;
            using (var outputStream = Response.Body)
            {
                await ScrapeHandler.ProcessAsync(Metrics.DefaultCollectorRegistry, outputStream);
            }
        }
    }
}
