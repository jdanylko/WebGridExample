using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebGridExample
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("API Default", 
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            // Remove the xml so we get back JSON
            var appXmlType = configuration.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            // Remove the k__backingfield issue in the names.
            JsonSerializerSettings jSettings = new JsonSerializerSettings();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = jSettings;
        
        }
    }
}