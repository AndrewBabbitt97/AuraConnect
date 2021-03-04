using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Razer.Chroma.Broadcast;
using RGBKit.Core;

namespace AuraConnect
{
    /// <summary>
    /// The Aura Connect worker
    /// </summary>
    public class Worker : BackgroundService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<Worker> _logger;

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The RGB Kit service
        /// </summary>
        private readonly IRGBKitService _rgbKit;

        /// <summary>
        /// The Razer Broadcast API
        /// </summary>
        private readonly RzChromaBroadcastAPI _api;

        /// <summary>
        /// If performance metrics are enabled
        /// </summary>
        private readonly bool _performanceMetricsEnabled;

        /// <summary>
        /// The performance metrics stopwatch
        /// </summary>
        private readonly Stopwatch _performanceMetricsStopwatch;

        /// <summary>
        /// The devices to be ignored
        /// </summary>
        private readonly string[] _ignoredDevices;

        /// <summary>
        /// Creates the worker
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="configuration">The configuration</param>
        /// <param name="rgbKit">The RGB Kit service</param>
        public Worker(ILogger<Worker> logger, IConfiguration configuration, IRGBKitService rgbKit)
        {
            _logger = logger;
            _configuration = configuration;
            _rgbKit = rgbKit;
            _api = new RzChromaBroadcastAPI();
            _api.ConnectionChanged += Api_ConnectionChanged;
            _api.ColorChanged += Api_ColorChanged;
            _performanceMetricsEnabled = (bool)_configuration.GetValue(typeof(bool), "PerformanceMetricsEnabled");
            _performanceMetricsStopwatch = new Stopwatch();
            _ignoredDevices = _configuration.GetSection("IgnoredDevices").Get<string[]>();
        }

        /// <summary>
        /// Executes the worker
        /// </summary>
        /// <param name="stoppingToken">The stopping token</param>
        /// <returns>A task</returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000, stoppingToken);

            _logger.LogInformation(new EventId(0, "Logging"), "Initializing Aura Connect...");

            await Task.Delay(1000, stoppingToken);

            _rgbKit.Initialize();

            _api.Init(Guid.Parse("e6bef332-95b8-76ec-a6d0-9f402bad244c"));

            foreach (var deviceProvider in _rgbKit.DeviceProviders)
            {
                foreach (var device in deviceProvider.Devices)
                {
                    if (_ignoredDevices.Contains(device.Name))
                    {
                        _logger.LogInformation(new EventId(0, "Logging"), $"Found Device: {deviceProvider.Name} - {device.Name} - {device.Lights.Count()} Lights - Ignoring Device");
                    }
                    else
                    {
                        _logger.LogInformation(new EventId(0, "Logging"), $"Found Device: {deviceProvider.Name} - {device.Name} - {device.Lights.Count()} Lights");
                    }
                }
            }

            _logger.LogInformation(new EventId(0, "Logging"), "Aura Connect started successfully!");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }

        /// <summary>
        /// Occurs when the connection status to the Razer Chroma Broadcast API changes
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The arguments</param>
        private void Api_ConnectionChanged(object sender, RzChromaBroadcastConnectionChangedEventArgs e)
        {
            _logger.LogInformation(new EventId(0, "Logging"), e.Connected ? "Razer Chroma Broadcast API connected" : "Razer Chroma Broadcast API disconnected");
        }

        /// <summary>
        /// Occurs when the connection status to the Razer Chroma Broadcast API changes
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The arguments</param>
        private void Api_ColorChanged(object sender, RzChromaBroadcastColorChangedEventArgs e)
        {
            var currentColor = 0;

            foreach (var deviceProvider in _rgbKit.DeviceProviders)
            {
                foreach (var device in deviceProvider.Devices)
                {
                    if (_ignoredDevices.Contains(device.Name))
                    {
                        continue;
                    }

                    foreach (var light in device.Lights)
                    {
                        light.Color = e.Colors[currentColor];
                        currentColor++;

                        if (currentColor == e.Colors.Length)
                            currentColor = 0;
                    }

                    if (_performanceMetricsEnabled)
                    {
                        _performanceMetricsStopwatch.Reset();
                        _performanceMetricsStopwatch.Start();
                    }

                    if (device.Lights.Count() > 0)
                    {
                        device.ApplyLights();
                    }

                    if (_performanceMetricsEnabled)
                    {
                        _performanceMetricsStopwatch.Stop();
                        _logger.LogInformation(new EventId(1, "Metrics"), deviceProvider.Name + " - " + device.Name + ": Took " + _performanceMetricsStopwatch.ElapsedMilliseconds + "ms To Update");
                    }
                }
            }
        }
    }
}
