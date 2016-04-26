using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.IO;

/// <summary>
///LogHelper 的摘要说明
/// </summary>
public class LogHelper
{
    public LogHelper()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }
    #region LogHelper


    /// <summary>
    /// 记日志，默认为INFO级别
    /// </summary>
    /// <param name="message">日志消息</param>
    /// <param name="psncode">人员编码</param>
    /// <param name="port">平台号</param>
    /// <param name="absoluteuri">绝对路径</param>
    /// <param name="requestmethod">请求方法</param>
    /// <param name="apiversion">版本号</param>
    /// <param name="stringType">请求/响应-头/内容</param>
    public static void Log(object message, string psncode, string port, string absoluteuri, string requestmethod, string apiversion, string stringType)
    {
        var path = AppDomain.CurrentDomain.BaseDirectory + @"\log4net.config";
        log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
        log4net.ThreadContext.Properties["RequestUID"] = psncode;
        log4net.ThreadContext.Properties["RequestPort"] = port;
        log4net.ThreadContext.Properties["RequestUri"] = absoluteuri;
        log4net.ThreadContext.Properties["RequestMethod"] = requestmethod;
        log4net.ThreadContext.Properties["ApiVersion"] = apiversion;
        log4net.ThreadContext.Properties["StringType"] = stringType;
        Log(message, LogLevelEnum.Info);
    }
    public static void Log(object message)
    {
        var path = AppDomain.CurrentDomain.BaseDirectory + @"\log4net.config";
        log4net.Config.XmlConfigurator.Configure(new FileInfo(path));
        Log(message, LogLevelEnum.Info);
    }
    /// <summary>
    /// 记日志
    /// </summary>
    /// <param name="message">日志消息</param>
    /// <param name="logLevelEnum">日志级别</param>
    private static void Log(object message, LogLevelEnum logLevelEnum)
    {
        try
        {
            //ILog log = GetLogger(message);
            Log4NetHelper logger = new Log4NetHelper(message.GetType().FullName);
            logger.Log(message, logLevelEnum);
        }
        catch (Exception ex)
        {
            log4net.LogManager.GetLogger("LogAPILogger").Error("Log组件记录日志时出现异常，异常信息：" + ex.Message);
        }
    }

    private static ILog GetLogger(object message)
    {
        var loggerName = message.GetType().FullName;
        return LogManager.GetLogger(loggerName);
    }


    #endregion
}