namespace Tomasos.Domain.DTO
{
    public class CustomerDTO
    {

        public class CustomerLoginDTO
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class GetCustomerDataDTO
        {

            public string Username { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
    }
}
