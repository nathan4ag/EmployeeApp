namespace EmployeeApp
{
    public class SalariedEmployee : Employee
    {
        protected override int VacationDaysPerYear => 15;
    }
}
