using System;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using CompanyX.Data.Repositories;

namespace CompanyX.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;
        ////todo add DI here??
        public AccountController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        //disabled for now :)
        //[AllowAnonymous]
        //[Route("Register")]
        //public async Task<IHttpActionResult> Register(User userModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await _repo.RegisterUser(userModel);

        //    IHttpActionResult errorResult = GetErrorResult(result);

        //    if (errorResult != null)
        //    {
        //        return errorResult;
        //    }

        //    return Ok();
        //}

        [AllowAnonymous]
        [Route("ping")]
        [HttpGet]
        public  IHttpActionResult Test()
        {
            return  Ok(new {ServerTime = DateTime.Now, GreetingsMesasge = "Server secured :)"});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        //private string GetToken(IOwinContext context, User user)
        //{

        //    var claims = new List<Claim> 
        //    {
        //        new Claim(ClaimTypes.Name, user.UserName) 
        //        //add more claims here
        //    };
        //    //set context to authenticated
        //    var cookiesIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);
        //    context.Authentication.SignIn(cookiesIdentity);

        //    //generate access token
        //    //create oAuth identity and add claims to it
        //    var oAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthServerOptions.AuthenticationType);

        //    var props = new AuthenticationProperties(new Dictionary<string, string>
        //        {
        //            { 
        //                "userName", user.UserName
        //            }
        //        });

        //    var ticket = new AuthenticationTicket(oAuthIdentity, props);
        //    ticket.Properties.IssuedUtc = DateTime.UtcNow;
        //    ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddMinutes(60);

        //    var token = Startup.OAuthServerOptions.AccessTokenFormat.Protect(ticket);

        //    return token;
        //}
    }
}
