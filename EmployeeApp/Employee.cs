namespace EmployeeApp
{
    public abstract class Employee : IEmployee
    {
        private float vacationDaysAccumulated;
        private const int WorkYearDays = 260;

        public float VacationDaysAccumulated => vacationDaysAccumulated;

        // Vacation accrual rate per day worked assuming each employee type's total vacationdays per year is earned proportionatly to worked days.
        protected float VacationAccrualRate => VacationDaysPerYear / (float)WorkYearDays;

        protected abstract int VacationDaysPerYear { get; }

        public void Work(int daysWorked)
        {
            if (daysWorked < 0 || daysWorked > WorkYearDays)
            {
                throw new ArgumentOutOfRangeException(nameof(daysWorked), "Days worked must be between 0 and 260.");
            }

            // Accumulate vacation days based on the number of days worked
            vacationDaysAccumulated += daysWorked * VacationAccrualRate;
        }

        public void TakeVacation(float daysTaken)
        {
            if (daysTaken < 0 || daysTaken > vacationDaysAccumulated)
            {
                throw new ArgumentOutOfRangeException(nameof(daysTaken), "Cannot take more vacation than accumulated.");
            }

            vacationDaysAccumulated -= daysTaken;
        }
    }
}
