namespace WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Data;
    using Shield.WebApi.Authorization;

    /// <summary>
    /// Policy Administration API
    /// </summary>
    [Authorize]
    public class PolicyController : ApiController
    {
        /// <summary>
        /// Gets a policy by id
        /// </summary>
        /// <param name="id">The policy id</param>
        public Policy Get(int id)
        {
            return new Policy();
        }

        /// <summary>
        /// Creates a new policy
        /// </summary>
        /// <param name="policy">The policy information</param>
        [HttpPost]
        public Policy Post(Policy policy)
        {
            return policy;
        }

        /// <summary>
        /// Cancels the specified policy
        /// </summary>
        /// <param name="id">The policy id number</param>
        [HttpPost]
        [ClaimsAuthorize("Policy", "Admin")]
        public async Task<IHttpActionResult> Cancel(int id)
        {
            return Ok();
        }
    }
}
