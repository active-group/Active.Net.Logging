namespace Active.Net

module Logging =
    open NLog
    open NLog.Config
    open NLog.Targets


    let makeConfig (loggingPath: string) (level: LogLevel) = 
        let config = new LoggingConfiguration()

        let defaultFileTarget = new FileTarget()

        config.AddTarget("defaultLogging", defaultFileTarget)

        defaultFileTarget.Layout <- new Layouts.SimpleLayout(@"${date:format=yyyy-MM-dd HH\:mm\:ss} ${logger} ${level}: ${message}")
        defaultFileTarget.FileName <- new Layouts.SimpleLayout(loggingPath + "Lokalisierung.log")
                
        // Store the last 7 days, use 1 file per day
        defaultFileTarget.ArchiveFileName <- new Layouts.SimpleLayout(loggingPath + "Lokalisierung.{#}.log")
        defaultFileTarget.ArchiveEvery <- FileArchivePeriod.Day
        defaultFileTarget.ArchiveNumbering <- ArchiveNumberingMode.Date
        defaultFileTarget.ArchiveDateFormat <- "yyyy-MM-dd"
        defaultFileTarget.MaxArchiveFiles <- 7

        let ruleInfo = new LoggingRule("*", level, defaultFileTarget)
        ruleInfo.Final <- true
        config.LoggingRules.Add(ruleInfo)

        config

    // Initializes the logging with our specific configurations
    let initLogging (loggingPath: string) (level: LogLevel) = 
        LogManager.Configuration <- makeConfig loggingPath level
        NLog.LogManager.ReconfigExistingLoggers()

