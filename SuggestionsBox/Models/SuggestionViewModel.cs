using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SuggestionsBox.Models
{
    public class SuggestionViewModel
    {
        [Required] public Guid? Id { get; set; }

        [Required(ErrorMessage = "Date Posted is required value")]
        public DateTime DatePosted { get; set; }

        [Required(ErrorMessage = "Suggestion is required value")]
        [MaxLength(2000, ErrorMessage = "Suggestion can not exceed more then 2000 characters.")]
        public string UserPost { get; set; }

        [MaxLength(2000, ErrorMessage = "Suggestion Reply can not exceed more then 2000 characters.")]
        public string ModeratorReply { get; set; }

        [XmlElement(ElementName = "dateReplied")]
        public DateTime DateReplied { get; set; }

        [XmlElement("isVisible")] public bool IsVisible { get; set; }
    }
}