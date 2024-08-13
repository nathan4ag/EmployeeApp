namespace EmployeeApp
{
    public interface IEmployee
    {
        float VacationDaysAccumulated { get; }
        void Work(int daysWorked);
        void TakeVacation(float daysTaken);
    }
}
