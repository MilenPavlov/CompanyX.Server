﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.CustomModels;
using CompanyX.Data.Models;

namespace CompanyX.Data.Interfaces
{
    public interface IEntityFactory
    {
        EmployeeViewModel CreateEmployee(Employee employee);

        List<EmployeeViewModel> CreateEmployees(List<Employee> employees);

        Employee CreateBaseEmployee(EmployeeViewModel employeeViewModel);

        Employee CreateBaseEmployeePut(EmployeePutModel employeePutModel);
    }
}