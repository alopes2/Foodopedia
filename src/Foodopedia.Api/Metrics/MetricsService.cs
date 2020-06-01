using Prometheus;

namespace Foodopedia.Api.Metrics
{
    public class MetricsService: IMetricsService
    {
        private const string ApplicationPrefix = "Foodopedia";

        /// <summary>
        /// Total number of exceptions.
        /// </summary>
        public Counter UnhandledExceptionsCounter { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceMetrics"/> class.
        /// </summary>
        public MetricsService()
        {
            UnhandledExceptionsCounter = Prometheus.Metrics.CreateCounter(
                name: $"{ApplicationPrefix}_unhandled_exceptions_total",
                help: "Total count of unhandled exceptions");
        }   
    }
}