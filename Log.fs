namespace Active.Net

module Log =

    let getLogger (id: string): NLog.Logger = NLog.LogManager.GetLogger(id)

    let logTrace (logger: NLog.Logger) (msg: string) = logger.Trace msg
    let logDebug (logger:NLog.Logger) (msg:string) = logger.Debug msg 
    let logInfo (logger:NLog.Logger) (msg:string) = logger.Info msg 
    let logWarn (logger:NLog.Logger) (msg:string) = logger.Warn msg
    let logError (logger:NLog.Logger) (msg:string) = logger.Error msg
    let logFatal (logger:NLog.Logger) (msg:string) = logger.Fatal msg



