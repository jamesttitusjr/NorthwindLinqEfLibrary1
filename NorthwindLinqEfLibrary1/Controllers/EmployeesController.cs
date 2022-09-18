using NorthwindLinqEfLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindLinqEfLibrary1.Controllers
{
    public class EmployeesController
    {
        private readonly AppDbContext _context = null!;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.OrderBy(e => e.LastName);
        }

        public Employee? GetByPK(int employeeId)
        {
            //Employee? empl = _context.Employees.SingleOrDefault(e => e.EmployeeId == employeeId);
            return _context.Employees.Find(employeeId);
        }

        public IEnumerable<Employee> GetByLastNamePartial(string startsWithString)
        {
            IEnumerable<Employee> employees = from e in _context.Employees
                                              where e.LastName.StartsWith(startsWithString)
                                              orderby e.LastName
                                              select e;
            return employees;
        }

        //public bool Update(int employeeId, Employee employee)
        
        public void Update(int employeeId, Employee employee)
        {
            if(employeeId != employee.EmployeeId)
            {
                throw new ArgumentException("Employee id doesn't match employee instance!");
            }
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return;
            //return true;

            public Employee Insert(Employee employee)
            {
                if (employee.EmployeeId ! = 0)
                {
                    throw new ArgumentException("Inserting a new employee requires the employeeId be set to 0!");
                }
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee;

            }
            public void Delete(int employeeId)
            {
                Employee? empl = GetByPK(int employeeId);
                if(empl is null)
                {
                    throw new Exception("Employee not found");
                }
                _context.Remove(empl);
                _context.SaveChanges();
            }
        }
}
