using CrudTask1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudTask1.Models.Respository
{
    public class EmployeeServices:IEmployee
    {
        private ApplicationContext context;
        public EmployeeServices(ApplicationContext _context)
        {
            context = _context;
        }

        public bool DeleteEmployee(int id)
        {
            var ems = context.Employees.SingleOrDefault(e => e.id == id);
            if (ems!=null)
            {
                ems.IsActive = false;
                context.Employees.Update(ems);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Address GetAddressById(int id)
        {
            var addr = context.Addresses.SingleOrDefault(e => e.Aid == id);
            return addr;
        }

        public List<Address> GetAddresses()
        {
            return context.Addresses.ToList();
        }

        public List<City> GetCities()
        {
            return context.Cities.ToList();
        }

        public List<Country> GetCountries()
        {
            return context.Countries.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            var dept = context.Departments.SingleOrDefault(e => e.Did == id);
            return dept;
        }

        public List<Department> GetDepartments()
        {
            return context.Departments.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            var emp = context.Employees.SingleOrDefault(e => e.id == id && e.IsActive==true);
            return emp;
        }

        public List<Employee> GetEmployees()
        {
            return context.Employees.Where(e=>e.IsActive==true).ToList();
        }

        public List<EmployeeDeptAddress> GetEmployeeViews()
        {
           
                  
            var emps = from emp in context.Employees
                       join
                       dpt in context.Departments
                       on emp.Department.Did equals dpt.Did
                       join
                       addr in context.Addresses
                       on emp.Address.Aid equals addr.Aid
                       where emp.IsActive==true
                       select new EmployeeDeptAddress() 
                       {
                            Name=emp.Name,
                            Gender=emp.Gender,
                            Salary=emp.Salary,
                            IsActive=emp.IsActive,
                            Title=dpt.Title,
                            FirstAddress=addr.FirstAddress,
                            Pincode=addr.Pincode,
                            CityName=addr.City.CityName,
                           StateName=addr.State.StateName,
                           CountryName=addr.Country.CountryName


                       };


            return emps.ToList();
        }

        public List<State> GetStates()
        {
            return context.States.ToList();
        }
        public EmployeeViewModel PostEmployee(EmployeeViewModel employee)
        {

            //employee.IsActive = true;
            var add = context.Addresses.SingleOrDefault(e => e.Aid == employee.AddressAid);
            var dpt = context.Departments.SingleOrDefault(e => e.Did == employee.DepartmentDid);
            var emp = new Employee()
            {
                id=employee.id,
                Name=employee.Name,
                Gender=employee.Gender,
                Salary=employee.Salary,
                IsActive=employee.IsActive,
                Address=add,
                Department=dpt
            };
            context.Employees.Add(emp);
            context.SaveChanges();
            return employee;
        }
        public AddressViewModel PostAddress(AddressViewModel address)
        {
            var ct = context.Cities.SingleOrDefault(e => e.CtId == address.CityCtId);
            var st = context.States.SingleOrDefault(e => e.Sid == address.StateSid);
            var cyt = context.Countries.SingleOrDefault(e => e.Cnid == address.CountryCnid);
            var adr = new Address()
            {
                FirstAddress=address.FirstAddress,
                SecondAddress=address.SecondAddress,
                Pincode=address.Pincode,
                City=ct,
                State=st,
                Country=cyt,

            };
            context.Addresses.Add(adr);
            context.SaveChanges();
            return address;
        }

        public Department PostDepartment(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return department;
        }

      

        public Address UpdateAddress(Address address)
        {
            context.Addresses.Update(address);
            context.SaveChanges();
            return address;
        }

        public Department UpdateDepartment(Department department)
        {
            context.Departments.Update(department);
            context.SaveChanges();
            return department;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            context.Employees.Update(employee);
            context.SaveChanges();
            return employee;
        }

       public List<Employee> GetEmployeesByDepartment(int id)
        {
            var emps = context.Employees.Where(e => e.Department.Did == id).ToList();
            return emps; 
        }

        public List<Employee> GetEmployeesByCity(int id)
        {
            var emps = context.Employees.Where(e => e.Address.City.CtId == id).ToList();
            return emps;
        }
    }
}
