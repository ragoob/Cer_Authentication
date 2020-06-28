using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace my_secured_app.MiddleWare
{
    public class CertAuthorizationAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        public CertAuthorizationAttribute() : base()
        {

        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var clientCert = await context.HttpContext.Connection.GetClientCertificateAsync();
            
        }

       
      
    }
}
