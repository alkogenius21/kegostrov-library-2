using Microsoft.AspNetCore.Identity;

namespace backend.Database {

    public class AppUser : IdentityUser {
        public string? FirstName { get; set; }
        public string? SecondNane {get; set; }
        public string? LastName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public bool IsActivated { get; set; }
    } 
}