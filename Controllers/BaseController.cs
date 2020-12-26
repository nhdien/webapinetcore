using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebAPINetCore.Entities;

namespace WebAPINetCore.Controllers
{
    [Controller]
    public abstract class BaseController : Controller
    {
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}
