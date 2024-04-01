using System.ComponentModel.DataAnnotations;

namespace AngularApex.Data.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Identificator { get; set; }
    }
}
