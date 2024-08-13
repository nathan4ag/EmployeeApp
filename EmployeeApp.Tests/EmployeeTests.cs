using System;
using Xunit;

namespace EmployeeApp.Tests
{
    public class EmployeeTests
    {
        [Fact]
        public void HourlyEmployee_AccumulatesCorrectVacationDays_WhenWorksFullYear()
        {
            // Arrange
            var employee = new HourlyEmployee();
            
            // Act
            employee.Work(260); // full work year
            
            // Assert
            Assert.Equal(10f, employee.VacationDaysAccumulated);
        }

        [Fact]
        public void SalariedEmployee_AccumulatesCorrectVacationDays_WhenWorksFullYear()
        {
            // Arrange
            var employee = new SalariedEmployee();
            
            // Act
            employee.Work(260); // full work year
            
            // Assert
            Assert.Equal(15f, employee.VacationDaysAccumulated, 2);
        }

        [Fact]
        public void Manager_AccumulatesCorrectVacationDays_WhenWorksFullYear()
        {
            // Arrange
            var employee = new Manager();
            
            // Act
            employee.Work(260); // full work year
            
            // Assert
            Assert.Equal(30f, employee.VacationDaysAccumulated, 2);
        }

        [Fact]
        public void HourlyEmployee_AccumulatesCorrectVacationDays_WhenWorksPartialYear()
        {
            // Arrange
            var employee = new HourlyEmployee();
            
            // Act
            employee.Work(130); // half the work year
            
            // Assert
            Assert.Equal(5f, employee.VacationDaysAccumulated, 2);
        }

        [Fact]
        public void SalariedEmployee_AccumulatesCorrectVacationDays_WhenWorksPartialYear()
        {
            // Arrange
            var employee = new SalariedEmployee();
            
            // Act
            employee.Work(130); // half the work year
            
            // Assert
            Assert.Equal(7.5f, employee.VacationDaysAccumulated, 2);
        }

        [Fact]
        public void Manager_AccumulatesCorrectVacationDays_WhenWorksPartialYear()
        {
            // Arrange
            var employee = new Manager();
            
            // Act
            employee.Work(130); // half the work year
            
            // Assert
            Assert.Equal(15f, employee.VacationDaysAccumulated, 2);
        }

        [Fact]
        public void Employee_WorkWithZeroDays_ShouldAccumulateNoVacationDays()
        {
            // Arrange
            var employee = new HourlyEmployee();
            
            // Act
            employee.Work(0);
            
            // Assert
            Assert.Equal(0f, employee.VacationDaysAccumulated);
        }

        [Fact]
        public void Employee_WorkWithNegativeDays_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var employee = new SalariedEmployee();
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => employee.Work(-1));
        }

        [Fact]
        public void Employee_WorkWithMoreThanWorkYearDays_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var employee = new Manager();
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => employee.Work(261));
        }

        [Fact]
        public void Employee_TakeVacationWithNegativeDays_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var employee = new SalariedEmployee();
            employee.Work(260); // fully accumulate vacation days
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => employee.TakeVacation(-1));
        }

        [Fact]
        public void Employee_TakeVacationMoreThanAccumulated_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var employee = new Manager();
            employee.Work(260); // fully accumulate vacation days
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => employee.TakeVacation(31)); // Attempt to take more than accumulated
        }

        [Fact]
        public void Employee_TakeVacationEqualToAccumulated_ShouldResultInZeroVacationDays()
        {
            // Arrange
            var employee = new Manager();
            employee.Work(260); // fully accumulate vacation days
            
            // Act
            employee.TakeVacation(30); // Take exactly the amount accumulated
            
            // Assert
            Assert.Equal(0f, employee.VacationDaysAccumulated);
        }

        [Fact]
        public void Employee_WorkAndTakeVacation_AccumulatesAndReducesCorrectly()
        {
            // Arrange
            var employee = new HourlyEmployee();
            employee.Work(130); // half the work year, should accumulate 5 vacation days
            
            // Act
            employee.TakeVacation(2); // take 2 days
            
            // Assert
            Assert.Equal(3f, employee.VacationDaysAccumulated, 2);
        }

        [Fact]
        public void Employee_WorkMoreDaysAfterTakingVacation_ShouldAccumulateCorrectly()
        {
            // Arrange
            var employee = new SalariedEmployee();
            employee.Work(130); // half the work year, should accumulate 7.5 vacation days
            employee.TakeVacation(2); // take 2 days, 5.5 remaining
            
            // Act
            employee.Work(130); // work another half year, should accumulate another 7.5 days
            
            // Assert
            Assert.Equal(13f, employee.VacationDaysAccumulated, 2); // 13 days should be accumulated
        }
    }
}
