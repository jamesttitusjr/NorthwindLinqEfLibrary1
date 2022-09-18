using Microsoft.EntityFrameworkCore.Query;
using NorthwindLinqEfLibrary1.Controllers;
using NorthwindLinqEfLibrary1.Models;
using System.Reflection;

Console.WriteLine("Northwind LINQ EF Library1");

AppDbContext _context = new();

EmployeesController emplCtrl = new(_context);

var empls = emplCtrl.GetByLastNamePartial("D")
//var empls = emplCtrl.GetByLastNamePartial("d"); Not case sensitive, can use either.

foreach (Employee emp in empls)
{
    Print(emp);
}

void Print(object obj)
{
    if (obj is null)
        obj = "(NULL)";
    //Console.WriteLine(obj);
    System.Diagnostics.Debug.WriteLine(obj.ToString());
}

//emplCtrl.Delete(10);

//Employee? empl1 = emplCtrl.GetByPK(1);
/*
Employee? newempl = new()
{
    EmployeeId = 0, LastName = "Phence", FirstName = "Noah",
    Title = "Joker", TitleOfCourtesy = "Mr.", BirthDate = new DateTime(2022, 9, 12),
    //HireDate = new DateTime(2010, 1, 1),
};

emplCtrl.Insert(newEmpl);

Print(newempl);
*/
//empl1.TitleOfCourtesy = "Ms.";

//emplCtrl.Update(empl1.EmployeeId, empl1);

//Print(empl1);

//List<Employee> empls = emplCtrl.GetAll().ToList();

/*foreach(Employee empl in empls)
{
    Print(empl);
}

void Print(object obj)
{
    if(obj is null)
        obj = "(NULL)";
    Console.WriteLine(obj);
    System.Diagnostics.Debug.WriteLine(obj.ToString());
}
*/