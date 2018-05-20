using System.ComponentModel.DataAnnotations;

namespace SuggestionsBox.Models
{
    /// <summary>
    /// Put or Delete by moderator view model
    /// </summary>
  public class ModeratorReplyViewModel
  {
    [Required]
    public string Id { get; set; }

    [MaxLength(2000,ErrorMessage = "Suggestion Reply can not exceed more then 2000 characters.")]
    public string ModeratorReply { get; set; }
  }
}
