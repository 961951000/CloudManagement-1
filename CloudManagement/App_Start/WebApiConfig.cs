using System.Web.Http;
using CloudManagement.Filters.Action;
using CloudManagement.Filters.Authentication;
using CloudManagement.Filters.Handler;

namespace CloudManagement
{
    public static class WebApiConfig
    {
        public static string UrlPrefixRelative => "~/api";

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new IdentityBasicAuthenticationAttribute());
            config.Filters.Add(new ApiExceptionFilterAttribute());
            config.Filters.Add(new ExecutionTimeFilterAttribute());
        }
    }
}
