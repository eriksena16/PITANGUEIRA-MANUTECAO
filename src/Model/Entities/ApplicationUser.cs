
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Pitangueira.Model.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "User Name")]
        public override string UserName { get; set; }

        [Display(Name = "Nome do usuario")]
        public string Name { get; set; }

    }
}
