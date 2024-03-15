namespace client_desktop.User.Dto_s
{
    internal class createUserDto
    {
        public string email;
        public string name;
        public string password;
        public string adress;
        public float money;

        public createUserDto(string email, string name, string password, string adress)
        {
            this.email = email;
            this.name = name;
            this.password = password;
            this.adress = adress;
            this.money = 1000;
        }
    }
}
