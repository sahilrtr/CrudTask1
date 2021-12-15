using CrudTask1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models.Respository
{
   public interface IEmployee
    {
        List<Employee> GetEmployees();
        List<Address> GetAddresses();
        List<Department> GetDepartments();
        List<City> GetCities();
        List<State> GetStates();
        List<Country> GetCountries();
        EmployeeViewModel PostEmployee(EmployeeViewModel employee);
        Employee GetEmployeeById(int id);
        bool DeleteEmployee(int id);
        Employee UpdateEmployee(Employee employee);
        Department PostDepartment(Department department);
        Department GetDepartmentById(int id);
        Department UpdateDepartment(Department department);
        AddressViewModel PostAddress(AddressViewModel address);
        Address GetAddressById(int id);
        Address UpdateAddress(Address address);
        List<EmployeeDeptAddress> GetEmployeeViews();

        List<Employee> GetEmployeesByDepartment(int id);
        List<Employee> GetEmployeesByCity(int id);

    }
}
