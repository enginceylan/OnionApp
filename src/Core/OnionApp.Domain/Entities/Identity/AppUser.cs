using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionApp.Domain.Entities.Identity
{
    public class AppUser:IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //public string? FullName
        //{
        //    get
        //    {
        //        return $"{FirstName} {LastName}";
        //    }
        //}

        // Yukarıdaki prop. aş gibi de yazılabilir : 

        [NotMapped]
        public string? FullName  => $"{FirstName} {LastName}";

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }

        // AUDIT DATA
        public string? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }

    }
}
