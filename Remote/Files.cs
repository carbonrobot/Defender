namespace WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    public class Files : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "Secure File A", "Secure File B" };
        }
    }
}