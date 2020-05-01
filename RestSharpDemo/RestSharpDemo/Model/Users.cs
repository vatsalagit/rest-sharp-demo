namespace RestSharpDemo.Model
{
    public class Users
    {
       /* public string Email1
        {
            get => email;
            set => email = value;
        }

        public string Password1
        {
            get => password;
            set => password = value;
        }*/
// check arrow operator
        //public string Email => email;

        //public string Password => password;
//request data
        public string email { get; set; }
        public string password { get; set; }

        //Request payload data
       /* public string email;
        public string password;*/
// response data
       public string id { get; set; }
       public string token { get; set; }

       public string xys { get; set; }
    }
}