namespace SalesRegisterWebAPI.Domain.DTO
{
    public class SellerDTO
    {
        public SellerDTO()
        {

        }
        public SellerDTO(string Name, string CPF, string Email)
        {
            this.Name = Name;
            this.CPF = CPF;
            this.Email = Email;
        }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
    }
}