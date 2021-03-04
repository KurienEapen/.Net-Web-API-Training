using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace FirstWebApplication
{
    public class CustomAuthorizationAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization != null)
            {
                var auth = actionContext.Request.Headers.Authorization.Parameter;
                var token = Encoding.UTF8.GetString(Convert.FromBase64String(auth));
                var cred = token.Split(':');
                var userName = cred[0];
                var password = cred[1];
                if ((userName == "kurien" || userName=="rahul") && password == "lol" && Users.Split(',').Contains(userName))
                {

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}