using System;
using System.Collections.Generic;

namespace Demo_SOLID.LSPbad
{
    public class LSPbadDemo {
        public static void MainBad()
        {
            List<Employee> list = new List<Employee>();

            list.Add(new Manager());
            list.Add(new SalesPerson());

            foreach (Employee emp in list)
            {
                emp.GetWorkDetails(1234);
            }
        }

    }


    public class Employee
    {
        public virtual string GetWorkDetails(int id)
        {
            return "Base Work";
        }

        public virtual string GetEmployeeDetails(int id)
        {
            return "Base Employee";
        }
    }
    public class Manager : Employee
    {
        public override string GetWorkDetails(int id)
        {
            return "Manager Work";
        }

        public override string GetEmployeeDetails(int id)
        {
            return "Manager Employee";
        }
    }

    public class SalesPerson : Employee
    {
        public override string GetWorkDetails(int id)
        {
            throw new NotImplementedException();
        }

        public override string GetEmployeeDetails(int id)
        {
            return "SalesPerson Employee";
        }
    }
}
