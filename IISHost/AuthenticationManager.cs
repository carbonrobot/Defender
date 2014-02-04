namespace IISHost
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    internal static class AuthenticationManager
    {
        internal static IEnumerable<Claim> CreateFakeClaims()
        {
            return new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, "Id"),
                    new Claim(ClaimTypes.Name, "Bob"),
                    new Claim(ClaimTypes.Role, "Policy"),
                    new Claim(ClaimTypes.Role, "Admin")
                };
        }

        internal static Task<IEnumerable<Claim>> ValidateKey(string key)
        {
            if (key == "123456789")
                return Task.FromResult<IEnumerable<Claim>>(CreateFakeClaims());

            return Task.FromResult<IEnumerable<Claim>>(null);
        }

        internal static Task<IEnumerable<Claim>> ValidateUser(string id, string secret)
        {
            if (id == secret)
                return Task.FromResult<IEnumerable<Claim>>(CreateFakeClaims());

            return Task.FromResult<IEnumerable<Claim>>(null);
        }
    }
}