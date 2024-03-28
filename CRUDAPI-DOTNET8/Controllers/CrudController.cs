using CRUDAPI_DOTNET8.Data;
using CRUDAPI_DOTNET8.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI_DOTNET8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly DataContext _context;
        public CrudController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<List<myCrud>>> GetAllEmployees()
        {
            //var employees = new List<myCrud>
            //{

            //    new myCrud
            //    {
            //        Id = 1,
            //        empFname = "Suprabhat",
            //        empLname="Samanta",
            //        Place="Noida",
            //        Sex="Men",
            //        Salary="20000"
            //    }
            //};
            var employees = await _context.myCruds.ToListAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<myCrud>>> GetEmployee(int id)
        {
            var employee=await _context.myCruds.FindAsync(id);
            if (employee == null)
            {
                return BadRequest("Employee not found in the database");
            }
            return Ok(employee);


        }
        [HttpPost]
        public async Task<ActionResult<List<myCrud>>> AddEmployee(myCrud employee)
        {
            _context.myCruds.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(await _context.myCruds.ToListAsync());


        }
        [HttpPut]
        public async Task<ActionResult<List<myCrud>>> UpdateEmployee(myCrud updatedEmployee)
        {
            var dbEmployee = await _context.myCruds.FindAsync(updatedEmployee.Id);
            if (dbEmployee == null)
            {

                return BadRequest("Employee is not found in the database");
            }
            dbEmployee.empFname = updatedEmployee.empFname;
            dbEmployee.empLname= updatedEmployee.empLname;
            dbEmployee.Place= updatedEmployee.Place;
            dbEmployee.Sex= updatedEmployee.Sex;
            dbEmployee.Salary= updatedEmployee.Salary;

            await _context.SaveChangesAsync();
            return Ok(await _context.myCruds.ToListAsync());


        }
        [HttpDelete]
        public async Task<ActionResult<List<myCrud>>> DeleteEmployee(int id)
        {
            var dbEmployee = await _context.myCruds.FindAsync(id);
            if (dbEmployee == null)
            {

                return BadRequest("Employee is not found in the database");
            }



            _context.myCruds.Remove(dbEmployee);

            await _context.SaveChangesAsync();
            return Ok(await _context.myCruds.ToListAsync());
        }
    }
}
