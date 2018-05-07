using CoreMeetUp.Repositories;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CoreMeetUp.Authentication
{
    public class SimpleAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (var repo = new LoginRepository())
            {
                var user = await repo.GetByEmail(context.UserName);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name does not exist.");
                    return;
                }
                if (user.PasswordHash == null)
                {
                    PasswordManager.SetUserPassword(user, context.Password);
                    await repo.Commit();
                }
                else
                {
                    bool valid = await PasswordManager.ValidatePassword(context.UserName, context.Password);
                    if (!valid)
                    {
                        context.SetError("invalid_grant", "The username and password combination is wrong.");
                        return;
                    }
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Id.ToString()));
                context.Validated(identity);
            }

        }
    }
}