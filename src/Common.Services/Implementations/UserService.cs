using Common.Services.Interfaces;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Common.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetUserUniqueNameFromContext()
        {
            var userKey = string.Empty;

            if (httpContextAccessor.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues vs))
            {
                var token = vs.FirstOrDefault();

                if (!string.IsNullOrEmpty(token))
                {
                    var decodedToken = JwtBuilder.Create().Decode<IDictionary<string, object>>(token);

                    var uniqueName = decodedToken[Constants.Constants.UNIQUENAME_TOKEN_PROPERTYNAME].ToString();
                    var familyName = decodedToken[Constants.Constants.FAMILYNAME_TOKEN_PROPERTYNAME].ToString();
                    var givenName = decodedToken[Constants.Constants.GIVENNAME_TOKEN_PROPERTYNAME].ToString();

                    if (!string.IsNullOrEmpty(familyName) && !string.IsNullOrEmpty(givenName) && !string.IsNullOrEmpty(uniqueName))
                        userKey = $"{familyName} {givenName} - {uniqueName}";
                    else if (!string.IsNullOrEmpty(uniqueName))
                        userKey = $"{uniqueName}";
                    else throw new Exception("Uniquename is not present in Authorization token");
                }
            }

            return await Task.FromResult(userKey);
        }
    }
}
