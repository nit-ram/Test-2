using System;
using System.Linq;
using System.Collections.Generic;

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


class Program
{
  static void Main(string[] args)
  {
    List<Employee> employees = new List<Employee>()
        {
            new Employee{ID = 34563, Name = "Joe", LastName = "Lopez", RFC = "APOM849734",BornDate= new DateTime(2019, 1, 23), Status= EmployeeStatus.Inactive},
            new Employee{ ID = 12345,Name = "Alice",LastName = "Perez", RFC = "APOM849734", BornDate= new DateTime(2013, 2, 08) , Status= EmployeeStatus.Active},
            new Employee{ ID = 38567,Name = "Alice",LastName = "Ponce", RFC = "APOM849734", BornDate= new DateTime(2022, 10, 23) , Status= EmployeeStatus.NotSet},
        };
        
        //sorted by born date
        var result = employees.OrderByDescending(sal => sal.BornDate);

        
        Console.WriteLine("ID \t Name \t LastName \tRFC\t\t  BornDate\t\t\t Status");
        Console.WriteLine("==================================================================== \n");
        foreach (Employee emp in result)
        {
            Console.WriteLine($"{emp.ID}\t {emp.Name}\t {emp.LastName}  \t{emp.RFC} \t{emp.BornDate} \t{emp.Status}");
        }
        Console.WriteLine("====================================================================");
  }
}
