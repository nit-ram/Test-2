using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
 public int ID { get; set;} 
 public string Name { get; set;} 
 public string LastName { get; set;} 
 public string RFC { get; set;} 
 public DateTime BornDate{ get; set; }
 public EmployeeStatus Status { get; set; } 
}

public enum EmployeeStatus 
{ 
    NotSet,
    Active,
    Inactive,
    
} 

class EmployeeService
{
    private List<Employee> employees;
    
    public EmployeeService()
    {
        employees = new List<Employee>();
    }
    
    public void AddEmployee(Employee emp)
    {
        if (string.IsNullOrEmpty(emp.RFC) || !IsValidRFC(emp.RFC))
        {
            Console.WriteLine("Invalid RFC format");
            return;
        }
        
        if (employees.Any(e => e.RFC == emp.RFC))
        {
            Console.WriteLine("Employee with this RFC already exists");
            return;
        }
        
        employees.Add(emp);
    }
    
    public List<Employee> GetEmployees(string name = null)
    {
        List<Employee> filteredEmployees = employees;
        
        if (!string.IsNullOrEmpty(name))
        {
            filteredEmployees = filteredEmployees.Where(e => e.Name == name).ToList();
        }
        
        return filteredEmployees.OrderBy(e => e.BornDate).ToList();
    }
    
    private bool IsValidRFC(string rfc)
    {
        // Validate the length of the RFC (e.g. 13 characters)
        if (rfc.Length != 13)
        {
            return false;
        }
        
        // Validate the format of the RFC (e.g. 4 letters followed by 6 numbers followed by 3 letters)
        string pattern = @"^[A-Z]{4}\d{6}[A-Z]{3}$";
        return System.Text.RegularExpressions.Regex.IsMatch(rfc, pattern);
    }
}

class Program
{
  static void Main(string[] args)
  {
    EmployeeService empService = new EmployeeService();
    
    empService.AddEmployee(new Employee { ID = 12345, Name = "Alice", LastName = "Perez", RFC = "APOM849734AAA", BornDate = new DateTime(2013, 2, 08), Status = EmployeeStatus.Active });
    empService.AddEmployee(new Employee { ID = 38567, Name = "Bob", LastName = "Ponce", RFC = "ABCD849735API", BornDate = new DateTime(1997, 10, 23), Status = EmployeeStatus.NotSet });
    empService.AddEmployee(new Employee { ID = 34563, Name = "Joe", LastName = "Smith", RFC = "ABCD459735API", BornDate = new DateTime(2001, 1, 1), Status = EmployeeStatus.Inactive });
    
    var employees = empService.GetEmployees();
    
    foreach (var emp in employees)
    {
       Console.WriteLine("ID: " + emp.ID + "\t Name: " + emp.Name +"\t" + emp.LastName + "\t Born Date: " + emp.BornDate.ToString("dd/MM/yyyy") + "\t Status: " + emp.Status);

    }
  }
}

