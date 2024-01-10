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


        //-------------------Property Type-------------------------
        [HttpPost]
        [Route("api/propertyType/create")]
        public HttpResponseMessage Create(PropertyTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = PropertyTypeService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Type name already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/propertyType/{id}")]
        public HttpResponseMessage GetPropertyType(int id)
        {
            try
            {
                var data = PropertyTypeService.GetPropertyType(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Property type not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/propertyType/list")]
        public HttpResponseMessage GetAllPropertyTypes()
        {
            try
            {
                var data = PropertyTypeService.GetAll();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Property types not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/propertyType/update")]
        public HttpResponseMessage UpdatePropertyType(PropertyTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = PropertyTypeService.Update(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Property type Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/propertyType/delete/{id}")]
        public HttpResponseMessage DeletePropertyType(int id)
        {
            try
            {
                var deleteResult = PropertyTypeService.Delete(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Property type Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //-------------------Property Category-------------------------
        [HttpPost]
        [Route("api/propertyCategory/create")]
        public HttpResponseMessage Create(PropertyCategoryDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = PropertyCategoryService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Category name already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/propertyCategory/{id}")]
        public HttpResponseMessage GetPropertyCategory(int id)
        {
            try
            {
                var data = PropertyCategoryService.GetPropertyCategory(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Property category not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/propertyCategory/list")]
        public HttpResponseMessage GetAllPropertyCategories()
        {
            try
            {
                var data = PropertyCategoryService.GetAllPropertyCategories();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Property categories not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/propertyCategory/update")]
        public HttpResponseMessage UpdatePropertyCategory(PropertyCategoryDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = PropertyCategoryService.Update(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Property category Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/propertyCategory/delete/{id}")]
        public HttpResponseMessage DeletePropertyCategory(int id)
        {
            try
            {
                var deleteResult = PropertyCategoryService.DeletePropertyCategory(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Property category Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------Facility Type-------------------------
        [HttpPost]
        [Route("api/facilityType/create")]
        public HttpResponseMessage Create(FacilityTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = FacilityTypeService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Type name already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/facilityType/{id}")]
        public HttpResponseMessage GetFacilityType(int id)
        {
            try
            {
                var data = FacilityTypeService.GetFacilityType(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Facility type not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/facilityType/list")]
        public HttpResponseMessage GetAllFacilityTypes()
        {
            try
            {
                var data = FacilityTypeService.GetAll();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Facility types not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/facilityType/update")]
        public HttpResponseMessage UpdateFacilityType(FacilityTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = FacilityTypeService.Update(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Facility type Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/facilityType/delete/{id}")]
        public HttpResponseMessage DeleteFacilityType(int id)
        {
            try
            {
                var deleteResult = FacilityTypeService.Delete(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Facility type Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------Destination Country-------------------------
        [HttpPost]
        [Route("api/destinationCountry/create")]
        public HttpResponseMessage Create(DestinationCountryDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = DestinationCountryService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Country name already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/destinationCountry/{id}")]
        public HttpResponseMessage GetDestinationCountry(int id)
        {
            try
            {
                var data = DestinationCountryService.GetDestinationCountry(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Destination country not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/destinationCountry/list")]
        public HttpResponseMessage GetAllDestinationCountries()
        {
            try
            {
                var data = DestinationCountryService.GetAll();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Destination countries not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/destinationCountry/update")]
        public HttpResponseMessage UpdateDestinationCountry(DestinationCountryDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = DestinationCountryService.Update(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Destination country Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/destinationCountry/delete/{id}")]
        public HttpResponseMessage DeleteDestinationCountry(int id)
        {
            try
            {
                var deleteResult = DestinationCountryService.Delete(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Destination country Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------Destination Country City-------------------------
        [HttpPost]
        [Route("api/destinationCountryCity/create")]
        public HttpResponseMessage Create(DestinationCountryCityDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = DestinationCountryCityService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "City name already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/destinationCountryCity/{id}")]
        public HttpResponseMessage GetDestinationCountryCity(int id)
        {
            try
            {
                var data = DestinationCountryCityService.GetDestinationCountryCity(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Destination country city not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/destinationCountryCity/list")]
        public HttpResponseMessage GetAllDestinationCountryCities()
        {
            try
            {
                var data = DestinationCountryCityService.GetAll();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Destination country cities not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/destinationCountryCity/update")]
        public HttpResponseMessage UpdateDestinationCountryCity(DestinationCountryCityDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = DestinationCountryCityService.Update(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Destination country city Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/destinationCountryCity/delete/{id}")]
        public HttpResponseMessage DeleteDestinationCountryCity(int id)
        {
            try
            {
                var deleteResult = DestinationCountryCityService.Delete(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Destination country city Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //-------------------DestinationCountryCityPlace-------------------------

        [HttpPost]
        [Route("api/destinationCountryCityPlace/create")]
        public HttpResponseMessage Create(DestinationCountryCityPlaceDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = DestinationCountryCityPlaceService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Place name already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/destinationCountryCityPlace/{id}")]
        public HttpResponseMessage GetDestinationCountryCityPlace(int id)
        {
            try
            {
                var data = DestinationCountryCityPlaceService.GetDestinationCountryCityPlace(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Place not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/destinationCountryCityPlace/list")]
        public HttpResponseMessage GetAllDestinationCountryCityPlaces()
        {
            try
            {
                var data = DestinationCountryCityPlaceService.GetAllDestinationCountryCityPlaces();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Places not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/destinationCountryCityPlace/update")]
        public HttpResponseMessage UpdateDestinationCountryCityPlace(DestinationCountryCityPlaceDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = DestinationCountryCityPlaceService.Update(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Place Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/destinationCountryCityPlace/delete/{id}")]
        public HttpResponseMessage DeleteDestinationCountryCityPlace(int id)
        {
            try
            {
                var deleteResult = DestinationCountryCityPlaceService.DeleteDestinationCountryCityPlace(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Place Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //-------------------Room Type-------------------------
        [HttpPost]
        [Route("api/roomType/create")]
        public HttpResponseMessage Create(RoomTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = RoomTypeService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Room type name already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/roomType/{id}")]
        public HttpResponseMessage GetRoomType(int id)
        {
            try
            {
                var data = RoomTypeService.GetRoomType(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Room type not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/roomType/list")]
        public HttpResponseMessage GetAllRoomTypes()
        {
            try
            {
                var data = RoomTypeService.GetAllRoomTypes();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Room types not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/roomType/update")]
        public HttpResponseMessage UpdateRoomType(RoomTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = RoomTypeService.UpdateRoomType(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Room type Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/roomType/delete/{id}")]
        public HttpResponseMessage DeleteRoomType(int id)
        {
            try
            {
                var deleteResult = RoomTypeService.DeleteRoomType(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Room type Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //-------------------Hotel-------------------------
        [HttpPost]
        [Route("api/hotel/create")]
        public HttpResponseMessage CreateHotel(HotelDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = HotelService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Hotel name already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/hotel/{id}")]
        public HttpResponseMessage GetHotelDetails(int id)
        {
            try
            {
                var data = HotelService.GetHotel(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Hotel not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/hotel/list")]
        public HttpResponseMessage GetAllHotels()
        {
            try
            {
                var data = HotelService.GetAllHotels();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Hotels not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/hotel/update")]
        public HttpResponseMessage UpdateHotelDetails(HotelDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = HotelService.UpdateHotel(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/hotel/delete/{id}")]
        public HttpResponseMessage DeleteHotel(int id)
        {
            try
            {
                var deleteResult = HotelService.DeleteHotel(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Hotel Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //-------------------Leave Type-------------------------
        [HttpPost]
        [Route("api/leaveType/create")]
        public HttpResponseMessage Create(LeaveTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var duplCheck = LeaveTypeService.Create(dto);
                    if (duplCheck != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Successfully Inserted");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.Conflict, "Leave type name already exists");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/leaveType/{id}")]
        public HttpResponseMessage GetLeaveType(int id)
        {
            try
            {
                var data = LeaveTypeService.GetLeaveType(id);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Leave type not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/leaveType/list")]
        public HttpResponseMessage GetAllLeaveTypes()
        {
            try
            {
                var data = LeaveTypeService.GetAllLeaveTypes();
                if (data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Leave types not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/leaveType/update")]
        public HttpResponseMessage UpdateLeaveType(LeaveTypeDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var updateResult = LeaveTypeService.UpdateLeaveType(dto);
                    if (updateResult)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "Updated");
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Leave type Not Found");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/leaveType/delete/{id}")]
        public HttpResponseMessage DeleteLeaveType(int id)
        {
            try
            {
                var deleteResult = LeaveTypeService.DeleteLeaveType(id);

                if (deleteResult)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Successfully Deleted");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Leave type Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }










    }
}
