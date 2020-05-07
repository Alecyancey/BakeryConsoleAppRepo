using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int YearsWithKomodo
        {
            get
            {
                TimeSpan amountOfTime = (DateTime.Now - EnrollmentDate);
                int yearNum = ((amountOfTime.Days) / 365);
                return yearNum;
            }
        }
        public Customer(int customerId, string lastName, int age, DateTime enrollmentDate)
        {
            CustomerId = customerId;
            LastName = lastName;
            Age = age;
            EnrollmentDate = enrollmentDate;
        }
    }
}
