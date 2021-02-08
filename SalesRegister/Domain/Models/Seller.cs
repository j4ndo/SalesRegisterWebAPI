using System.ComponentModel.DataAnnotations;

namespace SalesRegisterWebAPI.Domain.Models
{
    public class Seller
    {
        public Seller(string Name, string CPF, string Email)
        {
            this.Name = Name;
            this.CPF = CPF;
            this.Email = Email;
        }
        [Key]
        public int IdSeller { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Email { get; set; }
    }
}