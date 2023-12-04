namespace EmployeeAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Designation { get; set; }
        public DateTime Doj { get; set; }
        public string Gender { get; set; }
        public int IsMarried { get; set; }
        public int IsActive { get; set; }

    }
}

