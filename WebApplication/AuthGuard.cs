using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication
{
    public class AuthGuard : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;

            // Verificar si el ítem "login" existe en la sesión
            if (string.IsNullOrEmpty(session.GetString("login")))
            {
                // Redirigir al login si no hay usuario en la sesión
                context.Result = new RedirectToActionResult("Login", "Usuario", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
