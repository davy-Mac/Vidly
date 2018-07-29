using System.Web.Mvc;

namespace Vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new AuthorizeAttribute());

            //filters.Add(new RequireHttpsAttribute());  // this filter will block all "http" unsecured endpoints
        }
    }
}
