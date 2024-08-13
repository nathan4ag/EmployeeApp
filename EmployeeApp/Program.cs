using System;

namespace EmployeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IEmployee hourlyEmployee = new HourlyEmployee();
            hourlyEmployee.Work(100);
            Console.WriteLine($"Hourly Employee Vacation Days: {hourlyEmployee.VacationDaysAccumulated}");

            IEmployee salariedEmployee = new SalariedEmployee();
            salariedEmployee.Work(260);
            Console.WriteLine($"Salaried Employee Vacation Days: {salariedEmployee.VacationDaysAccumulated}");

            IEmployee manager = new Manager();
            manager.Work(260);
            manager.TakeVacation(10);
            Console.WriteLine($"Manager Vacation Days after taking 10 days: {manager.VacationDaysAccumulated}");
        }
    }
}
