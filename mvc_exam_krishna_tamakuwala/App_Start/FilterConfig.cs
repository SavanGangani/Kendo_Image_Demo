using System.Web;
using System.Web.Mvc;

namespace mvc_exam_krishna_tamakuwala
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
