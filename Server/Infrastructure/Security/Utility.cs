namespace Infrastructure.Security
{
	public static class Utility
	{
		static Utility()
		{
		}

		//public const string AuthenticationScheme = "Cookies";

		public const string AuthenticationScheme =
			Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;

		public static string? FindFirstValue(this System.Security.Claims.ClaimsIdentity identity, string claimType)
		{
			string? result = 
				identity?.FindFirst(type: claimType)?.Value;

			return result;
		}

		public static string? GetUserClaimValue(this System.Security.Principal.IIdentity identity, string claimType)
		{
			var identityInstance = 
				identity as System.Security.Claims.ClaimsIdentity;

			var result = identityInstance?.FindFirstValue(claimType);

			return result;
		}
	}
}
