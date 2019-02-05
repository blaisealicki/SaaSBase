using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SaaSBase.Controllers
{
    public class BaseController : Controller
    {
        protected string tenet;

        public BaseController()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            tenet = GetCompanyFromHost(Request.Host.Host);
            base.OnActionExecuting(context);
        }

        private string GetCompanyFromHost(string host)
        {
            var splitHost = host.Split('.');
            if (splitHost.Length == 3)
            {
                return splitHost[0];
            }
            return "";
        }
    }
}
