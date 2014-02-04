namespace WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Controllers;

    /// <summary>
    /// Secure file storage API
    /// </summary>
    [Authorize]
    public class FilesController : ApiController
    {
        /// <summary>
        /// Returns a list of all secure files within the system
        /// </summary>
        public IEnumerable<string> Get()
        {
            return Data.Files.GetNames();
        }

        /// <summary>
        /// Uploads a new file to secure document storage
        /// </summary>
        public async Task<IHttpActionResult> Post()
        {
            return Ok();
        }
    }
}