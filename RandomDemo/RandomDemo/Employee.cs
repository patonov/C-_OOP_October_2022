using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private int? age;

        public Employee(string name, decimal salary, string position, string department) 
        { 
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;        
        }

        public Employee(string name, decimal salary, string position, string department, string email)
            : this(name, salary, position, department)
        {
            this.Email = email;
        }

        public Employee(string name, decimal salary, string position, string department, int? age)
            : this(name, salary, position, department)
        {
            this.Age = age;
        }

        public Employee(string name, decimal salary, string position, string department, string email, int? age)
            : this(name, salary, position, department)
        {
            this.Email = email;
            this.Age = age;
        }

        [DefaultValue("Muncho")]
        public string Name { get { return name; } set { name = value; } }

        [DefaultValue(1077.00)]
        public decimal Salary { get { return salary; } set { salary = value; } }

        [DefaultValue("Junior expert")]
        public string Position { get { return position; } set { position = value; } }

        [DefaultValue("Development")]
        public string Department { get { return department; } set { department = value; } }

        [DefaultValue("hr@swu.bg")]
        public string Email { get { return email; } set { email = value; } }

        [DefaultValue(18)]
        public int? Age { get { return age; } set { age = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Name);
            sb.Append(" ");
            sb.Append($"{this.Salary:f2}");
            sb.Append(" ");
            sb.Append((this.Email == null ? "n/a" : this.Email));
            sb.Append(" ");
            sb.Append((this.Age == null ? "-1" : this.Age));

            return sb.ToString();
        }
    }
}
