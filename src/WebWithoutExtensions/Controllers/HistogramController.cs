﻿using Microsoft.AspNetCore.Mvc;
using Prometheus.Client;

namespace WebWithoutExtensions.Controllers;

[Route("[controller]")]
public class HistogramController : Controller
{
    private readonly IMetricFamily<IHistogram> _histogram;

    public HistogramController(IMetricFactory metricFactory)
    {
        _histogram = metricFactory.CreateHistogram("test_hist", "help_text", "params1", "params2");
    }

    [HttpGet]
    public IActionResult Get()
    {
        _histogram.WithLabels("test1", "value1").Observe(1);
        _histogram.WithLabels("test2", "value2").Observe(2);
        return Ok();
    }
}