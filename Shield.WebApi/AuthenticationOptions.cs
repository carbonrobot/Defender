namespace Shield.WebApi
{
    public abstract class AuthenticationOptions
    {
        public string AuthenticationType { get; set; }

        protected AuthenticationOptions(string type)
        {
            this.AuthenticationType = type;
        }
    }
}