using BlueberryMuffin.Models;
using Microsoft.AspNetCore.Identity;

namespace BlueberryMuffin.Data
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Survey> CreatedSurveys { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
        public virtual ICollection<SurveyAccess> SurveyAccesses { get; set; }
    }
}
