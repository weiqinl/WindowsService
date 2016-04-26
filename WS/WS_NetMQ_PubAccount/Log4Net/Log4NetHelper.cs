using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

/// <summary>
///Log4NetHelper 的摘要说明
/// </summary>
public class Log4NetHelper
{
    public Log4NetHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    private readonly ILog _logger;
    internal Log4NetHelper(string loggerName)
    {
        _logger = LogManager.GetLogger(loggerName);
    }
    /// <summary>
    /// 记日志，默认为 INFO 级别
    /// </summary>
    /// <param name="message">日志消息</param>
    public void Log(object message)
    {
        Log(message, LogLevelEnum.Info);
    }

    /// <summary>
    /// 记日志
    /// </summary>
    /// <param name="message">日志消息</param>
    /// <param name="logLevelEnum">日志级别</param>
    public void Log(object message, LogLevelEnum logLevelEnum)
    {
        if (_logger != null)
        {
            switch (logLevelEnum)
            {
                case LogLevelEnum.Debug:
                    _logger.Debug(message);
                    break;
                case LogLevelEnum.Info:
                    _logger.Info(message);
                    break;
                case LogLevelEnum.Warn:
                    _logger.Warn(message);
                    break;
                case LogLevelEnum.Error:
                    _logger.Error(message);
                    break;
                case LogLevelEnum.Fatal:
                    _logger.Fatal(message);
                    break;
                default:
                    break;
            }
        }
    }
}