namespace SeleniumRecorder.Models
{
    public class Register
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
    public class Login
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class LoginRegisterViewModel
    {
        public Login? login { get; set; }
        public Register? register { get; set; }
    }
}
