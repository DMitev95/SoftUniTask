using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            var result = RemoveTown(dbContext);
            Console.WriteLine(result);
        }

        //Task 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allEmployee = context.Employees.OrderBy(e => e.EmployeeId).ToArray().Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            }).ToArray();

            foreach (var e in allEmployee)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return output.ToString().TrimEnd();
        }

        //Task 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employeesOver50000 = context.Employees.OrderBy(e => e.FirstName).Select(e => new
            {
                e.FirstName,
                e.Salary
            }).Where(e => e.Salary > 50000).ToArray();

            foreach (var e in employeesOver50000)
            {
                output.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return output.ToString().TrimEnd();
        }

        //Task 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var rndEmployees = context.Employees.Where(e => e.Department.Name == "Research and Development").Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            }).OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName).ToArray();

            foreach (var e in rndEmployees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }
            return output.ToString().TrimEnd();
        }

        //Task 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            context.Addresses.Add(newAddress);
            Employee nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = newAddress;
            context.SaveChanges();
            string[] addressText = context.Employees.OrderByDescending(e => e.AddressId).Take(10).Select(e => e.Address.AddressText).ToArray();
            foreach (var e in addressText)
            {
                output.AppendLine(e);
            }

            return output.ToString().TrimEnd();
        }

        //Task 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var emplyeesProjects = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    AllProjects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished",
                    }).ToArray()
                }).ToArray();

            foreach (var e in emplyeesProjects)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.AllProjects)
                {
                    output.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                };
            };

            return output.ToString().TrimEnd();
        }

        //Task 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var adresses = context.Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .Select(a => new
                    {
                        Text = a.AddressText,
                        Town = a.Town.Name,
                        EmployeesCount = a.Employees.Count
                    })
                    .ToList();

            foreach (var ad in adresses)
            {
                output.AppendLine($"{ad.Text}, {ad.Town} - {ad.EmployeesCount} employees");
            }

            return output.ToString().TrimEnd();
        }

        //Task 9 
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    AllProject = e.EmployeesProjects.OrderBy(ep => ep.Project.Name).Select(e => e.Project.Name)
                }).ToArray();
            foreach (var e in employee)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                foreach (var p in e.AllProject)
                {
                    output.AppendLine($"{p}");
                }
            }


            return output.ToString().TrimEnd();
        }

        //Task 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    DName = d.Name,
                    MFName = d.Manager.FirstName,
                    MLName = d.Manager.LastName,
                    AllEmployees = d.Employees
                })
                .ToArray();
            foreach (var d in departments)
            {
                output.AppendLine($"{d.DName} - {d.MFName}  {d.MLName}");
                var employess = d.AllEmployees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName);
                foreach (var p in employess)
                {
                    output.AppendLine($"{p.FirstName} {p.LastName} - {p.JobTitle}");
                }
            }

            return output.ToString().TrimEnd();
        }

        //Task 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var lastProjects = context.Projects
                .OrderByDescending(e => e.StartDate)
                .Take(10)
                .Select(e => new
                {
                    ProjectName = e.Name,
                    ProjectDescription = e.Description,
                    ProjectStartDate = e.StartDate,
                }).OrderBy(e=>e.ProjectName).ToList();
            foreach (var project in lastProjects)
            {
                output.AppendLine(project.ProjectName);
                output.AppendLine(project.ProjectDescription);
                output.AppendLine(project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }
            return output.ToString().TrimEnd();
        }

        //Task 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var salaryIncreases = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToArray();
            foreach (var e in salaryIncreases)
            {
                e.Salary += e.Salary * 0.12m;
                output.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
            context.SaveChanges();
            return output.ToString().TrimEnd();

        }

        //Task 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employees = context.Employees
               .Where(x => x.FirstName.StartsWith("Sa"))
               .Select(x => new Employee
               {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   JobTitle = x.JobTitle,
                   Salary = x.Salary
               }
               )
               .OrderBy(x => x.FirstName)
               .ThenBy(x => x.LastName)
               .ToList();

            foreach (var e in employees)
            {
                output.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return output.ToString().TrimEnd();
        }

        //Task 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var projects = context.EmployeesProjects.Where(e => e.ProjectId == 2).ToArray();
            foreach (var project in projects)
            {
                context.Remove(project);
            }
            context.SaveChanges();

            var projectToDelete = context.Projects.Where(e => e.ProjectId == 2).ToArray();
            foreach (var item in projectToDelete)
            {
                context.Remove(item);
            }
            context.SaveChanges();

            var afterDel = context.Projects.Take(10).ToList();

            foreach (var item in afterDel)
            {
                output.AppendLine(item.Name);
            }

            return output.ToString().TrimEnd();
        }

        //Task 15
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context
                .Towns
                .First(t => t.Name == "Seattle");

            IQueryable<Address> addressesToDelete =
                context
                    .Addresses
                    .Where(a => a.TownId == townToDelete.TownId);

            int addressesCount = addressesToDelete.Count();

            IQueryable<Employee> employeesOnDeletedAddresses =
                context
                    .Employees
                    .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

            foreach (var employee in employeesOnDeletedAddresses)
            {
                employee.AddressId = null;
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Remove(townToDelete);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";
        }
    }
}
