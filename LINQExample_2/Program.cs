using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace LINQExample_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // GetOrderBy();
            //GroupingOperator();
            //QuantifierOperator();
            //FilterOperator();
            ElementOperation();


        }

        static void ElementOperation()
        {
            ////ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single and SingleOrDefault Element Operators
            ////ElementAt, ElementAtOrDefault Operators
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            // Single and SingleOrDefault Element Operators

            //var emp = employeeList.Single(e => e.Id > 1);
            var emp = employeeList.SingleOrDefault(e => e.Id == 11);
            if (emp != null)
                Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
            else Console.WriteLine("This employee does not exist within the collection");


            ////First, FirstOrDefault, Last, LastOrDefault Operators
            //First
            //List<int> integerList = new List<int> {3,13,23,17,27,89};
            //int result = integerList.First(i => i % 2 == 0);
            //Console.WriteLine(result);

            //FirstOrDefault
            // List<int> integerList = new List<int> { 3, 13, 23, 17, 25, 87 };
            //int result = integerList.FirstOrDefault(i => i % 2 == 0);
            //int result = integerList.Last();
            //int result = integerList.Last(i => i % 2 == 0);
            //int result = integerList.LastOrDefault(i => i % 2 == 0);
            //if (result != 0)
            //{
            //    Console.WriteLine(result);
            //}
            //else
            //{
            //    Console.WriteLine("There are no even number in the collection");
            //}

            ////int result = integerList.First(i => i % 2 == 0);
            //// int result = integerList.FirstOrDefault(i => i % 2 == 0);
            //int result = integerList.LastOrDefault(i => i % 2 == 0);

            //if (result != 0)
            //{
            //    Console.WriteLine(result);
            //}
            //else
            //{
            //    Console.WriteLine("There are no even numbers in the collection");
            //}

            //ELEMENTATORDEFAULT
            //var emp = employeeList.ElementAtOrDefault(12);

            //if (emp != null)
            //    Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
            //else Console.WriteLine("This employee record does not exist within the collection");


            //var emp = employeeList.ElementAtOrDefault(12);

            //if (emp != null)
            //{
            //    Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
            //}
            //else
            //{
            //    Console.WriteLine("This employee record does not exist within the collection");
            //}

        }

        static void FilterOperator()
        {
            ArrayList mixedCollection = Data.GetHeterogeneousDataCollectio();
            //var stringResult = from s in mixedCollection.OfType<string>()
            //                   select s;

            //query all integerArray
            //var intResult = from i in mixedCollection.OfType<int>()
            //                   select i;
            //foreach (var item in employeeResults)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();

            //query all integerArray
            //var employeeResults = from e in mixedCollection.OfType<Employee>()
            //                select e;
            //foreach ( var emp in employeeResults)
            //{
            //    Console.WriteLine($"{emp.Id, -5} {emp.FirstName, -10} {emp.LastName, -10}");
            //}
            //Console.ReadKey();

            var departmentResults = from d in mixedCollection.OfType<Department>()
                                    select d;

            foreach (var dept in departmentResults)
                Console.WriteLine($"{dept.Id,-5} {dept.LongName,-30} {dept.ShortName,-10}");

        }


        static void QuantifierOperator()
        {
            List<Employee> employeesList = Data.GetEmployees();
            List<Department> departmentsList = Data.GetDepartments();

            //All Or  Any
            //var annualSalaryCompare = 40000;
            //bool isTrueAll = employeesList.All(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAll )
            //{
            //    Console.WriteLine($"All employee annual salaries are above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"Not All employee annual salaries are a above {annualSalaryCompare}");
            //}
            //bool isTrueAny = employeesList.Any(e => e.AnnualSalary > annualSalaryCompare );
            //if (isTrueAny )
            //{
            //    Console.WriteLine($"At least one employee has an annual salary above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"No employees have an annual salary above {annualSalaryCompare}");
            //}

           

            //CONTAINS OPERATOR
            var searchEmployee = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 1
            };


            bool containsEmployee = employeesList.Contains(searchEmployee, new EmployeeComparer());

            if (containsEmployee)
            {
                Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was found");
            }
            else
            {
                Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was not found");
            }

            Console.ReadKey();
            
        }


        static void GroupingOperator()
        {
            List<Employee> employeesList = Data.GetEmployees();
            List<Department> departmentsList = Data.GetDepartments();

            //GroupBy
            //var groupResult = employeesList.GroupBy(e => e.DepartmentId);
            //var groupResult = from emp in employeesList
            //                  orderby emp.DepartmentId
            //                  group emp by emp.DepartmentId;
            //foreach (var empGroup in groupResult)
            //{
            //    Console.WriteLine($"Department Id: {empGroup.Key}");

            //    foreach (var emp in empGroup)
            //    {
            //        Console.WriteLine($"\tEmployee FullName: {emp.FirstName} {emp.LastName}");
            //    }
            //}

            //ToLookUpOperator

            var groupResult = employeesList.OrderByDescending(o => o.DepartmentId).ToLookup(e => e.DepartmentId);
            foreach (var empGroup in groupResult)
            {
                Console.WriteLine($"Department Id: {empGroup.Key}");

                foreach (var emp in empGroup)
                {
                    Console.WriteLine($"\tEmployee FullName: {emp.FirstName} {emp.LastName}");
                }
            }



        }
       

        //Sorting Operator
        static void GetOrderBy()
        {
            List<Employee> employeesList = Data.GetEmployees();
            List<Department> departmentsList = Data.GetDepartments();

            //Method Syntax
            //var results = employeesList.Join(departmentsList, e => e.DepartmentId, d => d.Id,
            //    (emp, dept) => new
            //    {
            //        Id = emp.Id,
            //        FirstName = emp.FirstName,
            //        LastName = emp.LastName,
            //        AnnualSalary = emp.AnnualSalary,
            //        DepartmentId = emp.DepartmentId,
            //        DepartmentName = dept.LongName
            //    }).OrderBy(o => o.DepartmentId).ThenBy(O => O.AnnualSalary);
            //foreach (var item  in results)
            //    Console.WriteLine($"First Name: {item.FirstName, -10} Last Name: {item.LastName,-10} Annual Salary: {item.AnnualSalary, 5}\tDepartment Name: {item.DepartmentName}" );


            var results = from emp in employeesList
                          join dept in departmentsList
                          on emp.DepartmentId equals dept.Id
                          orderby emp.DepartmentId, emp.AnnualSalary descending
                          select new
                          {
                              Id = emp.Id,
                              FirstName = emp.FirstName,
                              LastName = emp.LastName,
                              AnnualSalary = emp.AnnualSalary,
                              DepartmentId = emp.DepartmentId,
                              DepartmentName = dept.LongName
                          };

            foreach (var item in results)
                 Console.WriteLine($"First Name: {item.FirstName, -10} Last Name: {item.LastName,-10} Annual Salary: {item.AnnualSalary, 5}\tDepartment Name: {item.DepartmentName}" );

                Console.ReadKey();
        }

    }
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            if (x.Id == y.Id && x.FirstName.ToLower() == y.FirstName.ToLower() && x.LastName.ToLower() == x.FirstName.ToLower())
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }



    public class Employee
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }

    }

    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }

    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();


            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jameson",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 3
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Stevens",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 3
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 5,
                FirstName = "David",
                LastName = "Ukpoju",
                AnnualSalary = 35000.5m,
                IsManager = true,
                DepartmentId = 4,

            };
            employees.Add(employee);

            return employees;

        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);

            return departments;
        }

        public static ArrayList GetHeterogeneousDataCollectio()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(100);
            arrayList.Add("Bob Jones");
            arrayList.Add(2000);
            arrayList.Add(3000);
            arrayList.Add("Bill Henderson");
            arrayList.Add(new Employee {Id =6,FirstName="Jennifer", LastName="Dale",AnnualSalary =90000, IsManager = true, DepartmentId =1 });
            arrayList.Add(new Employee { Id = 7, FirstName = "Dane", LastName = "Hughes", AnnualSalary = 60000, IsManager = false, DepartmentId = 2 });
            arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" });
            arrayList.Add(new Department { Id = 5, ShortName = "R&D", LongName = "Research and Development" });
            arrayList.Add(new Department { Id = 6, ShortName = "PRD", LongName = "Production" });

            return arrayList;
        }

    }
    
}