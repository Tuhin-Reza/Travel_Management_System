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


        //-------------------Role-------------------------
        [HttpPost]
        [Route("api/role/create")]
        public HttpResponseMessage Create(RoleDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = RoleService.Create(dto);
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
        [Route("api/role/{id}")]
        public HttpResponseMessage GetRole(int id)
        {
            try
            {
                var data = RoleService.GetRole(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Role not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/role/list")]
        public HttpResponseMessage GetAllRoles()
        {
            try
            {
                var data = RoleService.GetAll();
                if (data.Count > 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Role not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/role/update")]
        public HttpResponseMessage UpdateRole(RoleDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = RoleService.Update(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Role Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/role/delete/{id}")]
        public HttpResponseMessage DeleteRole(int id)
        {
            try
            {
                var deleteResult = RoleService.Delete(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Role Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }



        //-------------------Employee-------------------------

        [HttpPost]
        [Route("api/employee/create")]
        public HttpResponseMessage Create(EmployeeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = EmployeeService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Email already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/employee/{id}")]
        public HttpResponseMessage GetEmployee(int id)
        {
            try
            {
                var data = EmployeeService.GetEmployee(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/employee/list")]
        public HttpResponseMessage GetAllEmployees()
        {
            try
            {
                var data = EmployeeService.GetAll();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employees not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/employee/update")]
        public HttpResponseMessage UpdateEmployee(EmployeeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = EmployeeService.Update(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Employee Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/employee/delete/{id}")]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                var deleteResult = EmployeeService.DeleteEmployee(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Employee Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/employee/updateStatus")]
        public HttpResponseMessage UpdateStatus(EmployeeStatusDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = EmployeeService.UpdateStatus(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Status Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Employee Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/employee/getByStatus/{status}")]
        public HttpResponseMessage GetAllByStatus(string status)
        {
            try
            {
                var data = EmployeeService.GetAllByStatus(status);
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employees with specified status not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}
