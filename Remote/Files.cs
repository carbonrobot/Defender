namespace WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Principal;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    [Authorize]
    public class FilesController : ApiController
    {

        public IEnumerable<string> Get()
        {
            return Data.Files.GetNames();
        }

    }
}