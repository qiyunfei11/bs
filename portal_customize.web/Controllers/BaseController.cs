using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace portal_customize.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class BaseController : ControllerBase
    {
        private StringValues Headers ;
        private string UserInfo => Request.Headers.TryGetValue("UserId", out Headers) ? Headers.ToString() : "";

        public string UserId
        {
            get
            {
                return UserInfo;
            }
        }

        // public string UserToken
        // {
        //     get
        //     {
        //         return UserInfo["Secret"].ToString();
        //     }
        // }
    }
}
