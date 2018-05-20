using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.ModelBinding;
using SuggestionsBox.Infrastructure;

namespace SuggestionsBox.Models
{
    public static class Utils
    {
        public static string GetErrorMessages(IEnumerable<ModelState> modelState)
        {
            var errors = new StringBuilder();
            foreach (var pair in modelState)
            {
                if (pair.Errors.Count > 0)
                {
                    pair.Errors.ToList().ForEach(error => errors.AppendLine(error.ErrorMessage));
                }
            }
            return errors.ToString();
        }

        public static List<string> GetRoles(string roles)
        {
            List<string> adminRoles;
            if (AppSettings.AdminRole.Contains(';'))
            {
                adminRoles = AppSettings.AdminRole.Split(';').ToList();
            }
            else if (AppSettings.AdminRole.Contains(','))
            {
                adminRoles = AppSettings.AdminRole.Split(',').ToList();
            }
            else
            {
                 adminRoles = new List<string>{AppSettings.AdminRole};
            }
            return adminRoles;
        }
    }
}