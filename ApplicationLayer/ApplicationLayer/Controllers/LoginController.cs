using BLL.DTOS;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("api/auth/login")]
        public HttpResponseMessage Login(UserDTO dto)
        {
            try
            {
                if (dto.Username != null && dto.Password != null)
                {
                    var isAUthenticated = AuthService.Login(dto);
                    if (isAUthenticated != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, isAUthenticated);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = "Provide Username and Password" });
                }
            }
            catch (Exception e)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
