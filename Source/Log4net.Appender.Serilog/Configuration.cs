namespace log4net.Appender.Serilog
{
    public static class Configuration
    {
        /// <summary>
        /// Configures log4net to log to Serilog.
        /// </summary>
        /// <param name="logger">The serilog logger (if left null Log.Logger will be used).</param>
        public static void Configure(global::Serilog.ILogger logger = null, bool useParameterExtraction = false)
        {
            var loggerRepository = (log4net.Repository.Hierarchy.Hierarchy)log4net.LogManager.GetRepository();
            Configure(loggerRepository, logger, useParameterExtraction);            
        }

        public static void Configure(log4net.Repository.ILoggerRepository repository, global::Serilog.ILogger logger = null, bool useParameterExtraction = false)
        {
            var loggerRepository = (log4net.Repository.Hierarchy.Hierarchy)repository;
            Configure(loggerRepository.Root);            
            loggerRepository.Configured = true;
        }

        public static void Configure(log4net.Repository.Hierarchy.Logger root, global::Serilog.ILogger logger = null, bool useParameterExtraction = false)
        {
            var serilogAppender = new log4net.Appender.Serilog.SerilogAppender(logger)
            {
                UseParameterExtraction = useParameterExtraction
            };
            serilogAppender.ActivateOptions();
            
            root.AddAppender(serilogAppender);
        }
    }
}
