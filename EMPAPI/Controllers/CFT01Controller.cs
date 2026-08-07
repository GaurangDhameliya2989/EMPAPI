using Asp.Versioning;
using EMPBAL;
using EMPMAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMPAPI
{
    [Route("api/empapi")]
    [ControllerName("CFT01")]
    [ApiController]
    public class CFT01Controller : ControllerBase
    {
        [Authorize]
        [HttpGet("GetEmployeeDepartment")]
        public IActionResult GetDepartment()
        {
            Response objResponse = new Response();
            objResponse = new BLCFT01Handler().GetDepartment();
            return Ok(objResponse);
        }

        [HttpGet("GetDesignation")]
        public IActionResult GetDesignation()
        {
            Response objResponse = new Response();
            objResponse = new BLCFT02Handler().GetDesignation();
            return Ok(objResponse);
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee()
        {
            Response objResponse = new Response();
            objResponse = new BLCFT03Handler().GetEmployee();
            return Ok(objResponse);
        }

        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment([FromBody]DTOT01 objDTOT01)
        {
            Response objResponse = new Response();
            BLCFT01Handler objT01Handler = new BLCFT01Handler();
            objT01Handler.PreSave(objDTOT01);
            objResponse = objT01Handler.InsertUpdate();
            return Ok(objResponse);
        }

        [HttpPost("AddDesignation")]
        public IActionResult AddDesignation([FromBody]DTOT02 objDTOT02)
        {
            Response objresponse = new Response();
            BLCFT02Handler objTo2Handler = new BLCFT02Handler();
            objTo2Handler.Presave(objDTOT02);
            objresponse = objTo2Handler.Insert();
            return Ok(objresponse);
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody]DTOT03 objDTOT03)
        {
            Response objResponse = new Response();
            BLCFT03Handler objCFT03Handler = new BLCFT03Handler();
            objCFT03Handler.PreSave(objDTOT03);
            objResponse = objCFT03Handler.Insert();
            return Ok(objResponse);
        }

        [HttpPut("UpdateDepartment")]
        public IActionResult UpdateDepartment([FromBody]DTOT01 objDTOT01)
        {
            Response objResponse = new Response();
            BLCFT01Handler objBLT01Handler = new BLCFT01Handler();
            objBLT01Handler.PreSave(objDTOT01);
            objResponse = objBLT01Handler.Update();
            return Ok(objResponse);
        }

        [HttpPut("UpdateDesignation")]
        public IActionResult UpdateDesignation([FromBody]DTOT02 objDTOT02)
        {
            Response objResponse = new Response();
            BLCFT02Handler objBLT02Handler = new BLCFT02Handler();
            objBLT02Handler.Presave(objDTOT02);
            objResponse = objBLT02Handler.Update();
            return Ok(objResponse);
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody]DTOT03 objDTOT03)
        {
            Response objResponse = new Response();
            BLCFT03Handler objBLT03Handler = new BLCFT03Handler();
            objBLT03Handler.PreSave(objDTOT03);
            objResponse = objBLT03Handler.Update();
            return Ok(objResponse);
        }

        [HttpDelete("DeleteDepartment")]
        public IActionResult DeleteDepartment(int DepartmentId)
        {
            Response objResponse = new Response();
            BLCFT01Handler objBLT01Handler = new BLCFT01Handler();
            objResponse = objBLT01Handler.DeleteDepartment(DepartmentId);
            return Ok(objResponse);
        }

        [HttpDelete("DeleteDesignation")]
        public IActionResult DeleteDesignation(int DesignationId)
        {
            Response objResponse = new Response();
            BLCFT02Handler objBLT02Handler = new BLCFT02Handler();
            objResponse = objBLT02Handler.Dlete(DesignationId);
            return Ok(objResponse);
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int EmployeeId)
        {
            Response objResponse = new Response();
            BLCFT03Handler objBLT03Handler = new BLCFT03Handler();
            objResponse = objBLT03Handler.Delete(EmployeeId);
            return Ok(objResponse);
        }
    }
}
