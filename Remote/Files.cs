namespace WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    [Authorize]
    public class FilesController : ApiController
    {

        public IEnumerable<string> Get()
        {
            return Data.Files.GetNames();
        }

        public string Get(int id)
        {
            
        }
    }
}