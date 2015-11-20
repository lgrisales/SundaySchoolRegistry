Imports System.Web.Optimization
Imports NLog

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    ''' <summary>
    ''' logger reference to print information in logs
    ''' </summary>
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()

    ''' <summary>
    ''' Event that is calling when the application is started
    ''' </summary>
    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        logger.Info("Application is started")
    End Sub

    ''' <summary>
    ''' Event that is called when the application is stopped
    ''' </summary>
    Protected Sub Application_End()
        logger.Info("Application is shutdown")
    End Sub


End Class
