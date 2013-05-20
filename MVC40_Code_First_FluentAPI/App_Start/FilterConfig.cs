using System.Web;
using System.Web.Mvc;

namespace MVC40_Code_First_FluentAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}