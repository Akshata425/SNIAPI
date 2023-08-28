
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Configuration;
using System.Text;
using System.Web.Http;

[assembly: OwinStartup(typeof(SNIAPI.Startup))]

namespace SNIAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //change this configuration as you want.


            //Signal any messages to client application
            //app.Map("/signalr", map =>
            //{
            //    map.UseCors(CorsOptions.AllowAll);
            //    var hubConfiguration = new HubConfiguration { };
            //    map.RunSignalR(hubConfiguration);
            //});
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //Validate JWT Token

            var securityKey = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["SecretKey"]);
            string issuer = ConfigurationManager.AppSettings["Issuer"];
            string audience = ConfigurationManager.AppSettings["Audience"];

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer, //some string, normally web url,  
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(securityKey)
                    }
                });

            var config = new HttpConfiguration();
            //WebApiConfig.Register(config);

            //SwaggerConfig.Register(config);
         
            app.UseWebApi(config);
           // app.useM
        }
    }
}
