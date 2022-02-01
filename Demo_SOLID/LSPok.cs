using System;
using System.Collections.Generic;

namespace Demo_SOLID.LSPOk
{

    public class LSPOkDemo {
        public static void MainOk()
        {
            List<IWork> lstWork = new List<IWork>();

            lstWork.Add(new Manager());
            // lstWork.Add(new SalesPerson());

            foreach (var emp in lstWork)
            {
                Console.WriteLine(emp.GetWorkDetails(1234));
            }

            List<IEmployee> lstEmployee = new List<IEmployee>();

            lstEmployee.Add(new Manager());
            lstEmployee.Add(new SalesPerson());

            foreach (var emp in lstEmployee)
            {
                Console.WriteLine(emp.GetEmployeeDetails(1234));
            }
        }

    }

    public interface IEmployee
    {
        string GetEmployeeDetails(int Id);
    }

    public interface IWork
    {
        string GetWorkDetails(int Id);
    }

    public class Employee : IEmployee, IWork
    {
        public string GetWorkDetails(int id)
        {
            return "Base Work";
        }

        public string GetEmployeeDetails(int id)
        {
            return "Base Employee";
        }
    }
    public class Manager : IEmployee, IWork
    {
        public string GetWorkDetails(int id)
        {
            return "Manager Work";
        }

        public string GetEmployeeDetails(int id)
        {
            return "Manager Employee";
        }
    }

    public class SalesPerson : IEmployee
    {
        public string GetEmployeeDetails(int id)
        {
            return "SalesPerson Employee";
        }
    }
}
