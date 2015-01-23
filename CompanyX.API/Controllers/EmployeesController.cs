using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CompanyX.Data.Context;
using CompanyX.Data.CustomModels;
using CompanyX.Data.Interfaces;
using CompanyX.Data.Models;
using CompanyX.Data.Repositories;
using CompanyX.Data.Services;

namespace CompanyX.API.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly Func<IEntityFactory> _entityFactory;
        private readonly IUnitOfWork _unit;

        public EmployeesController(Func<IEntityFactory> entityFactory, IUnitOfWork unit)
        {
            _entityFactory = entityFactory;
            _unit = unit;
        }

        // GET: api/Employees
        [Authorize]
        public IHttpActionResult GetEmployees()
        {
            var emps = _entityFactory().CreateEmployees( _unit.EmployeeRepository.Get().ToList());
            var response = new EmployeesResponce
            {
                Employees = emps,
                Error = string.Empty
            };
            return Ok(response);
        }


        // GET: api/Employees/5
         [Authorize]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = _unit.EmployeeRepository.GetByID(id);
            if (employee == null)
            {
                return NotFound();
            }

            
            return Ok(_entityFactory().CreateEmployee(employee));
        }

        // PUT: api/Employees/5
        //Update
        [Authorize]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PutEmployee(EmployeePutModel employeePutModel)
        {


            var employee = _entityFactory().CreateBaseEmployeePut(employeePutModel);
            if (!ModelState.IsValid)
            {
                return Ok(string.Format("Error: {0}", ModelState));
            }

            if (employeePutModel.Id != employee.EmployeeId)
            {
                return Ok("Error: could not find Employee");
            }           

            try
            {
                 _unit.EmployeeRepository.Update(employee);
                 _unit.Save();
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employeePutModel.Id))
                {
                    return Ok("Error: DbUpdateConcurrencyException");
                }
                
            }
             return Ok(string.Format("Employee {0} {1} updated successfuly", employee.FirstName, employee.LastName));
             //return Ok("HttpStatusCode.NoContent");
        }

        // POST: api/Employees
        [Authorize]
        [ResponseType(typeof(Employee))]
        [HttpPost]
        public IHttpActionResult PostEmployee(EmployeeViewModel employeeViewModel)
        {
            if (
                _unit.EmployeeRepository.Get(
                    x =>
                        x.FirstName == employeeViewModel.FirstName && x.LastName == employeeViewModel.LastName &&
                        x.DateOfBitrh == employeeViewModel.DateOfBirth).Any())
            {
                return
                    Ok(string.Format("Error: Employee {0} {1} already exists in the database", employeeViewModel.FirstName,
                        employeeViewModel.LastName));
            }
            var employee = _entityFactory().CreateBaseEmployee(employeeViewModel);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
       
             _unit.EmployeeRepository.Insert(employee);
             _unit.Save();

            //return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
            return Ok(string.Format("Employee: {0} {1} created", employee.FirstName, employee.LastName));
        }

        // DELETE: api/Employees/5

        [Authorize]
        [ResponseType(typeof(Employee))]
        public  IHttpActionResult DeleteEmployee(int id)
        {


            Employee employee =  _unit.EmployeeRepository.GetByID(id);
            if (employee == null)
            {
                return NotFound();
            }

            _unit.EmployeeRepository.Delete(id);
            _unit.Save();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unit.Dispose();
            }
            base.Dispose(disposing);
        }

        private  bool EmployeeExists(int id)
        {
            return  _unit.EmployeeRepository.Get().Count(e => e.EmployeeId == id) > 0;
        }
    }
}