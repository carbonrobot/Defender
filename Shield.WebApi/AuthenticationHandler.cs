﻿namespace Shield.WebApi
 {
     using System.Collections.Generic;
     using System.Net.Http;
     using System.Security.Claims;
     using System.Security.Principal;
     using System.Threading;
     using System.Threading.Tasks;

     /// <summary>
     /// Validates HTTP Requests using a preshared key
     /// </summary>
     public abstract class AuthenticationHandler<T> : DelegatingHandler where T : AuthenticationOptions
     {
         protected T Options;

         protected AuthenticationHandler(T options)
         {
             this.Options = options;
         }

         protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
         {
             var claims = await AuthenticateCoreAsync(request);
             if (claims != null)
             {
                 var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
                 var principal = new ClaimsPrincipal(identity);
                 SetPrincipal(request, principal);
             }

             return await base.SendAsync(request, cancellationToken);
         }

         protected abstract Task<IEnumerable<Claim>> AuthenticateCoreAsync(HttpRequestMessage request);

         private void SetPrincipal(HttpRequestMessage request, IPrincipal principal)
         {
             request.GetRequestContext().Principal = principal;
         }
     }
 }