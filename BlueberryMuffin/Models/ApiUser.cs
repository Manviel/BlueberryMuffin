using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueberryMuffin.Models
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [InverseProperty(nameof(Survey.CreatedBy))]
        public virtual ICollection<Survey> CreatedSurveys { get; set; } = new HashSet<Survey>();

        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
        public virtual ICollection<SurveyAccess> SurveyAccesses { get; set; }
    }
}
