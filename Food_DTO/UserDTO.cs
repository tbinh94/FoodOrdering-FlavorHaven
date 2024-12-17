namespace Food_DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        // Constructor cơ bản
        public UserDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }

        // Constructor đầy đủ
        public UserDTO(string username, string password, string email, string phoneNumber, string address)
        {
            Username = username;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
        }
    }

}
