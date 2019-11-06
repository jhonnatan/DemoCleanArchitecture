using System.Collections.Generic;
using System.Security.Claims;

namespace DemoCleanArchitecture.Tests.Builders
{
    public class ClaimBuilder
    {
        public List<Claim> Claims { get; set; }

        public static ClaimBuilder New()
        {
            return new ClaimBuilder
            {
                Claims = new List<Claim>()
                {
                    new Claim("CompanyName", "CompanyNamTest"),
                    new Claim("IsImported", "false"),
                    new Claim("Empty", "false"),
                    new Claim("Name", "NameTeste"),
                    new Claim("FirstName", "FirstNameTest"),
                    new Claim("LastName", "LastNameTest"),
                    new Claim("Email", "email"),
                    new Claim("LoginName", "LoginTest"),
                    new Claim("RoleName", "RoleNameTest"),
                    new Claim("RoleId", "1"),
                    new Claim("CompanyId", "1"),
                    new Claim("Imported", "false"),
                }
            };
        }

        public ClaimsPrincipal Build()
        {
            return new ClaimsPrincipal(new ClaimsIdentity(Claims, "TestAuthType"));
        }
    }
}
