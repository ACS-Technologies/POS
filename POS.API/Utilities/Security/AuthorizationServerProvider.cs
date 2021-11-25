using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using DBL.Security;

namespace POS.API.Utilities.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private SecurityHelper _securityHelper;

        public AuthorizationServerProvider()
        {
            this._securityHelper = (SecurityHelper)new SecurityHelper();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                APICredentialDBL credentialRepository = new APICredentialDBL();

                string password = this._securityHelper.EncryptString(context.Password, (string)null);
                var apiCredential = credentialRepository.ValidateUser(context.UserName, password);
                if (apiCredential != null)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));//to be checked
                    context.Validated(identity);
                }
                else
                    context.SetError("invalid_grant", "Provided username and password is incorrect");

            }
            catch (Exception ex)
            {
                //this._apiLogBusiness.Save(nameof (AuthorizationServerProvider), ex.ToString(), (object) null);
            }
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
    }
}
