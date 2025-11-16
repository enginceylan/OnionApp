using Microsoft.AspNetCore.Identity;

namespace OnionApp.Domain.Entities.Identity
{
    public class AppRole:IdentityRole<int>
    {
        // AUDIT DATA
        public string? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
    }
}
