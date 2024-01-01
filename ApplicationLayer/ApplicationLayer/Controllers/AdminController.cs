using BLL.DTOS;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/getTest")]
        public HttpResponseMessage GetTest()
        {

            ////string senderEmail = "vivop672@gmail.com";
            ////string senderPassword = "xjfd bqaz dhhs rrxl";
            //string senderEmail = WebConfigurationManager.AppSettings["SenderEmail"];
            //string senderPassword = WebConfigurationManager.AppSettings["SenderPassword"];

            //// Recipient's email
            //string recipientEmail = "tuhinreza984@gmail.com";

            //// Subject and body of the email
            //string subject = "Check";
            //string body = "Hello";

            //try
            //{
            //    // Create an instance of SmtpClient
            //    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            //    {
            //        Port = 587,
            //        Credentials = new NetworkCredential(senderEmail, senderPassword),
            //        EnableSsl = true,
            //    };

            //    // Create a MailMessage
            //    MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail, subject, body);

            //    // Send the email
            //    smtpClient.Send(mailMessage);
            //    return Request.CreateResponse(HttpStatusCode.OK, "Mail Send");


            //}
            //catch (Exception ex)
            //{
            //    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            //}

            var check = "Travel Management System";
            //var name = new string[] { "Tuhin", "Reza" };
            return Request.CreateResponse(HttpStatusCode.OK, check);
        }


        [HttpPost]
        [Route("api/emplType/create")]
        public HttpResponseMessage Create(EmployeeTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = EmployeeTypeService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Entity already exists");
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        [HttpGet]
        [Route("api/emplType/{id}")]
        public HttpResponseMessage GetDepartment(int id)
        {
            try
            {
                var data = EmployeeTypeService.GetEmployeeType(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "EmployeeType not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/emplType/list")]
        public HttpResponseMessage GetAllEmplType()
        {
            try
            {
                var data = EmployeeTypeService.GetAll();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Type not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/emplType/update")]
        public HttpResponseMessage UpdateEmployeeType(EmployeeTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = EmployeeTypeService.Update(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Update failed");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/emplType/delete/{id}")]
        public HttpResponseMessage DeleteEmployeeType(int id)
        {
            try
            {
                var deleteResult = EmployeeTypeService.Delete(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Delete failed");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
