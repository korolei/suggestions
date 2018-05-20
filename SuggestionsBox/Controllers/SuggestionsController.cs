using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using SuggestionsBox.Infrastructure;
using SuggestionsBox.Models;

namespace SuggestionsBox.Controllers
{
    [Authorize]
    [Route("api/suggestionsbox")]
    [EsbExceptionFilter]
    public class SuggestionsController : ApiController
    {
        private readonly bool _isAdmin;
        private readonly SuggestionsBoxEngine _engine;

        public SuggestionsController()
        {
            _engine = new SuggestionsBoxEngine();
            var userRoles = Utils.GetRoles(AppSettings.AdminRole);
            _isAdmin = userRoles.Any(adminRole => RequestContext.Principal.IsInRole(adminRole));
        }

        [HttpGet]
        [Route("api/suggestionsbox/isadmin")]
        public IHttpActionResult IsAdmin()
        {
            return Ok(_isAdmin);
        }

        [HttpGet]
        public async Task<List<SuggestionViewModel>> Get()
        {
            return await _engine.GetSuggestionsAsync(_isAdmin);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]UserPostViewModel userPost)
        {
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResponseModel
                {
                    Success = false,
                    Message = Utils.GetErrorMessages(ModelState.Values)
                });
            }
            _engine.AddSuggestionAsync(userPost);
            return Ok(new ApiResponseModel
            {
                Success = true,
                Message = "Thank you! Your suggestion has been accepted and became visible, once dedicated person will reply to it within 3 business days."
            });
        }

        [HttpPut]
        public IHttpActionResult Put([FromBody]ModeratorReplyViewModel moderatorReply)
        {
            if (!_isAdmin)
            {
                ModelState.AddModelError("Post Denied","User must be in admin role.");
            }
            if (!ModelState.IsValid)
            {
                return Ok(new ApiResponseModel
                {
                    Success = false,
                    Message = Utils.GetErrorMessages(ModelState.Values)
                });
            }

            _engine.UpdateSuggestionAsync(moderatorReply);
            return Ok(new ApiResponseModel
            {
                Success = true,
                Message = "Suggestion Reply has been added successfully"
            });
        }
    }
}