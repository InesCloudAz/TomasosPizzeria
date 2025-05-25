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

        public class CustomerLoginDTO
        {
            public string Username { get; set; }
            public string Password { get; set; } 
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string FullName { get; set; }
            public string Address { get; set; }


        }





    }
}
