using System.Diagnostics.Tracing;

namespace WeatherForecast
{
    [EventSource(Name = "Sample-EventSource")]
    public class WeatherForecastEventSource : EventSource
    {
        public class Keywords
        {
            public const EventKeywords Application = (EventKeywords)1;
            public const EventKeywords Service = (EventKeywords)2;
            public const EventKeywords Database = (EventKeywords)4;
        }

        public class Tasks
        {
            public const EventTask Page = (EventTask)1;
            public const EventTask DBQuery = (EventTask)2;
        }

        private static WeatherForecastEventSource _log = new WeatherForecastEventSource();
        private WeatherForecastEventSource()
        { }

        public static WeatherForecastEventSource Log
        {
            get
            {
                return _log;
            }
        }

        [Event(101, Keywords = Keywords.Application,
            Level = EventLevel.Critical,
            Message = "Application failure: {0} ")]
        public void Failure(string message)
        {
            if (this.IsEnabled(EventLevel.Critical, Keywords.Application))
            {
                this.WriteEvent(101, message);
            }
        }

        [Event(102, Keywords = Keywords.Application,
            Level = EventLevel.Informational,
            Message = "Information: {0}")]
        public void Information(string message)
        {
            if (this.IsEnabled(EventLevel.Informational, Keywords.Application))
            {
                this.WriteEvent(102, message);
            }
        }
    }
}
