namespace EmployeeApp
{
    public class Manager : SalariedEmployee
    {
        protected override int VacationDaysPerYear => 30;
    }
}
