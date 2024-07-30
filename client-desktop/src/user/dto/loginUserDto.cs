namespace client_desktop.User.Dto_s
{
    internal class loginUserDto
    {
        public string email;
        public string password;

        public loginUserDto(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
