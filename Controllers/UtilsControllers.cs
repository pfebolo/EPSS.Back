using Microsoft.AspNetCore.Mvc;

namespace EPSS.Controllers
{
    static public class Utils
    {
        static public JsonResult ResponseConfict(System.Exception ex)
        {
            JsonResult jr409 = new JsonResult(new errorBody(ex));
            jr409.StatusCode = 409;
            return jr409;
        }
    }
}