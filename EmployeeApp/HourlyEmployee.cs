namespace EmployeeApp
{
    public class HourlyEmployee : Employee
    {
        protected override int VacationDaysPerYear => 10;
    }
}
