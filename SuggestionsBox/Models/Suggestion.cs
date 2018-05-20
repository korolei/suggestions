using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SuggestionsBox.Models
{
    [XmlType("suggestion")]
    [XmlRoot("suggestions")]
    [Serializable]
    public class Suggestion
    {
        [Required] [XmlElement("id")] public string Id { get; set; }

        [Required(ErrorMessage = "Date Posted is required value")]
        [XmlElement(ElementName = "datePosted")]
        public string DatePosted { get; set; }

        [Required(ErrorMessage = "Suggestion is required value")]
        [MaxLength(2000, ErrorMessage = "Suggestion can not exceed more then 2000 characters.")]
        [MinLength(20, ErrorMessage = "Suggestion can not be less then 20 characters.")]
        [XmlElement("userPost")]
        public string UserPost { get; set; }

        [MaxLength(2000, ErrorMessage = "Suggestion Reply can not exceed more then 2000 characters.")]
        [MinLength(20, ErrorMessage = "Suggestion Reply can not be less then 20 characters.")]
        [XmlElement("moderatorReply")]
        public string ModeratorReply { get; set; }

        [XmlElement(ElementName = "dateReplied")]
        public string DateReplied { get; set; }

        [XmlElement("isVisible")] public bool IsVisible { get; set; }
    }
}