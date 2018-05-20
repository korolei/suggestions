using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuggestionsBox.Models;

namespace SuggestionsBox.Infrastructure
{
public class SuggestionsBoxEngine: AutoMapperConfiguration
{
        private readonly SuggestionsBoxData _suggestionBoxRepository;

        public SuggestionsBoxEngine()
        {
            _suggestionBoxRepository = new SuggestionsBoxData();
        }
        public async Task<List<SuggestionViewModel>> GetSuggestionsAsync(bool isAdmin)
        {
            var suggestions = await _suggestionBoxRepository.GetData();
            if (!isAdmin)
            {
                suggestions = suggestions.Where(x => x.IsVisible);
            }
            var list = _mapper.Map<List<SuggestionViewModel>>(suggestions);
            return list.OrderByDescending(x => x.DatePosted).ToList();
        }

        public void AddSuggestionAsync(UserPostViewModel userPost)
        {
            var suggestion = _mapper.Map<Suggestion>(userPost);
            _suggestionBoxRepository.InsertData(suggestion);
            //SendNotificationEmail();
        }

        public void UpdateSuggestionAsync(ModeratorReplyViewModel moderatorReply)
        {
            var suggestion = _mapper.Map<Suggestion>(moderatorReply);
            _suggestionBoxRepository.UpdateData(suggestion);
        }

    }
}
    
