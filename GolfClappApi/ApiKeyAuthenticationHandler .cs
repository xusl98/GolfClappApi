using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ObjectsLibrary.Entities;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace GolfClappApi
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string API_KEY_HEADER = "Api-Key";
        private readonly IAccountService _accountService;


        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IAccountService accountService,
            ISystemClock clock
        ) : base(options, logger, encoder, clock)
        {
            _accountService = accountService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey(API_KEY_HEADER))
            {
                return AuthenticateResult.Fail("Header Not Found.");
            }

            string apiKeyToValidate = Request.Headers[API_KEY_HEADER];

            var isApiKeyValid = _accountService.IsUserApiKeyValid(apiKeyToValidate);

            if (isApiKeyValid == false)
            {
                return AuthenticateResult.Fail("Invalid key.");
            }

            var user = _accountService.GetByUserAPiKey(apiKeyToValidate);

            return AuthenticateResult.Success(CreateTicket(user));
        }

        private AuthenticationTicket CreateTicket(UserEntity user)
        {
            var claims = new[] {
                
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return ticket;
        }
    }
}
