using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using SuggestionsBox.Models;

namespace SuggestionsBox.Infrastructure
{
    public class SuggestionsBoxData
    {
        private const string XML_ROOT = "suggestion";
        private const string XML_ID = "id";
        private const string XML_DATE_POSTED = "datePosted";
        private const string XML_DATE_REPLIED = "dateReplied";
        private const string XML_USER_POST = "userPost";
        private const string XML_MODERATOR_REPLY = "moderatorReply";
        private const string XML_IS_VISIBLE = "isVisible";
        private readonly string _fullPath;

        public SuggestionsBoxData()
        {
            _fullPath = AppSettings.FilePath;
            var fi = new FileInfo(_fullPath);
            if (!fi.Exists) throw new FileNotFoundException("Suggestions Data file is missing.");
            ArchiveData();
        }

        private void ArchiveData()
        {
            try
            {
                var backUpDirectory = Path.GetDirectoryName(AppSettings.FilePath) + @"\Backup\";
                if (!Directory.Exists(backUpDirectory))
                {
                    Directory.CreateDirectory(backUpDirectory);
                }

                var backUpFiles = Directory.GetFiles(backUpDirectory);

                var fileDate = $"{DateTime.Now:yy-MM-dd}";
                if (!backUpFiles.Any() || !Directory.GetFiles(backUpDirectory).Any(x => Path.GetFileNameWithoutExtension(x).StartsWith(fileDate)))
                {
                    File.Copy(_fullPath, $"{backUpDirectory}{fileDate}-{Path.GetFileName(AppSettings.FilePath)}");
                }
                if (backUpFiles.Any())
                {
                    foreach (var file in backUpFiles.Where(x => !Path.GetFileNameWithoutExtension(x).StartsWith(fileDate)))
                    {
                        File.Delete(file);
                    } 
                }
            }
            catch (Exception e)
            {
               LogWrapper.Log(e);
            }
        }

        public async Task<IEnumerable<Suggestion>> GetData()
        {
            IEnumerable<Suggestion> suggestions = null;
            await Task.Run(() =>
            {
                var serializer = new XmlSerializer(typeof(List<Suggestion>), new XmlRootAttribute("suggestions"));
                using (var fs = new FileStream(_fullPath, FileMode.Open, FileAccess.Read))
                {
                    var xmlSettings = new XmlReaderSettings
                    {
                        Async = true,
                        IgnoreWhitespace = true
                    };

                    var reader = XmlReader.Create(fs, xmlSettings);
                    suggestions = (List<Suggestion>) serializer.Deserialize(reader);
                    fs.Close();
                }
            });
            return suggestions;
        }

        public void InsertData(Suggestion suggestion)
        {
            var doc = XDocument.Load(_fullPath);
            var newSuggestion = new XElement(XML_ROOT,
                new XElement(XML_ID, suggestion.Id),
                new XElement(XML_DATE_POSTED, suggestion.DatePosted),
                new XElement(XML_USER_POST, suggestion.UserPost),
                new XElement(XML_IS_VISIBLE, suggestion.IsVisible),
                new XElement(XML_DATE_REPLIED, suggestion.DateReplied),
                new XElement(XML_MODERATOR_REPLY, suggestion.ModeratorReply ?? "")
            );
            doc.Root.Add(newSuggestion);
            doc.Save(_fullPath);
            Task.FromResult(suggestion);
        }

        public void UpdateData(Suggestion suggestion)
        {
            var allSuggestions = XDocument.Load(_fullPath);
            var suggestionXml = allSuggestions.Descendants(XML_ROOT)
                .FirstOrDefault(x => x.Element(XML_ID).Value.Equals(suggestion.Id));

            suggestionXml.Element(XML_MODERATOR_REPLY).Value = suggestion.ModeratorReply;
            suggestionXml.Element(XML_DATE_REPLIED).Value = suggestion.DateReplied;
            suggestionXml.Element(XML_IS_VISIBLE).Value = suggestion.IsVisible.ToString().ToLower();
            allSuggestions.Save(_fullPath);
            Task.FromResult(suggestion);    
        }
    }

}
