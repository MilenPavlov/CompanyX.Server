using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CompanyX.Data.CustomModels;
using CompanyX.Data.Interfaces;
using CompanyX.Data.Models;
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
        public async Task<IHttpActionResult> GetEmployees()
        {
            var emps = await _entityFactory().CreateEmployees( await _unit.EmployeeRepository.GetAsync());
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
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            var employee = await _unit.EmployeeRepository.GetByIdAsync(id);
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
        public async Task<IHttpActionResult> PutEmployee(EmployeePutModel employeePutModel)
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
                 await _unit.EmployeeRepository.UpdateAsync(employee);
                 _unit.Save();
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employeePutModel.Id))
                {
                    return Ok("Error: DbUpdateConcurrencyException");
                }
                
            }
             return Ok(string.Format("Employee {0} {1} updated successfully", employee.FirstName, employee.LastName));
        }

        // POST: api/Employees
        [Authorize]
        [ResponseType(typeof(Employee))]
        [HttpPost]
        public async Task<IHttpActionResult> PostEmployee(EmployeeViewModel employeeViewModel)
        {
            var emps = await
                _unit.EmployeeRepository.GetAsync(
                    x =>
                        x.FirstName == employeeViewModel.FirstName && x.LastName == employeeViewModel.LastName &&
                        x.DateOfBitrh == employeeViewModel.DateOfBirth);
            if (emps.Any())
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
       
             await _unit.EmployeeRepository.InsertAsync(employee);
             _unit.Save();

            return Ok(string.Format("Employee: {0} {1} created", employee.FirstName, employee.LastName));
        }

        // DELETE: api/Employees/5

        [Authorize]
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            var employee =  await _unit.EmployeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _unit.EmployeeRepository.DeleteAsync(id);
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
        private bool EmployeeExists(int id)
        {
            return  _unit.EmployeeRepository.Get().Count(e => e.EmployeeId == id) > 0;          
        }
    }
}