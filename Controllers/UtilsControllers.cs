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

        static public JsonResult ResponseInternalError(System.Exception ex)
        {
            JsonResult jr500 = new JsonResult(new errorBody(ex));
            jr500.StatusCode = 500;
            return jr500;
        }        
    }
}