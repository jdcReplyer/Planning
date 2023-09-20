using Common.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Planning.API.Controllers
{
    public class BaseController : ControllerBase
    {
      
        readonly IUserService _userService;
        public BaseController(IUserService userService)
        {
            _userService = userService;
        }
        protected IEnumerable<ModelError> GetModelStateErrors()
        {
            return  ModelState.Values.SelectMany(v => v.Errors);
        }

        protected async Task<string> GetUserFormToken()
        {
            return await _userService.GetUserUniqueNameFromContext();
        }
    }
}
