using System.ComponentModel.DataAnnotations;

namespace SuggestionsBox.Models
{
    /// <summary>
    /// Post only view model
    /// </summary>
  public class UserPostViewModel
  {
    [Required(ErrorMessage = "Suggestion is required value")]
    [MaxLength(2000,ErrorMessage = "Suggestion can not exceed more then 2000 characters.")]
    public string UserPost { get; set; }
  }
}
