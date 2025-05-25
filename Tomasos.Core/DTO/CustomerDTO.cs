namespace Tomasos.Domain.DTO
{
    public class CustomerDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public object Address { get; set; }
        public string Password { get; set; }
        public int BonusPoints { get; set; }
        public CustomerDTO() { }



        public CustomerDTO(string username, string email, string phoneNumber, string fullName, object address, string password, int bonusPoints)
        {
            Username = username;
            Email = email;
            PhoneNumber = phoneNumber;
            FullName = fullName;
            Address = address;
            Password = password;
            BonusPoints = bonusPoints;
        }
    }
}
