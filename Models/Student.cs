namespace Models;
using System.Text.RegularExpressions;
using System.Globalization;

public class Student: Person, IStudy
{
    public DateTime DateOfBirth { get;  }
    public string StudentId { get;  }
    public int Course { get;  }

    public Student(string name, string lastName, string DateOfBirth, string studentId, string Course)
        : base(name, lastName)
    {
        if (!DateTime.TryParseExact(DateOfBirth, "dd.MM.yyyy", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthdayDate))
        {
            throw new ArgumentException("Invalid birthday date, expected format: dd.MM.yyyy");
        }
        this.DateOfBirth = birthdayDate;

        int ParseCourse;
        bool check  = int.TryParse(Course,  out ParseCourse);

        if (!check)
        {
            throw new ArgumentException("Invalid course, course must be a number!");
        }
        
        this.Course = ParseCourse;
        
        if (!Regex.IsMatch(studentId, "^[A-Z]{2}[0-9]{8}$"))
        {
            throw new ArgumentException("Student ID must contains 2 letters and 8 digit numbers.");
        }
        StudentId = studentId;
    }

    public Student(List<KeyValue> args)
        :base(GetValue(args, "firstname"), GetValue(args, "lastname"))
    {
        if (!DateTime.TryParseExact(GetValue(args, "dateofbirth"), "dd.MM.yyyy", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthdayDate))
        {
            throw new ArgumentException("Invalid birthday date, expected format: dd.MM.yyyy");
        }
        DateOfBirth = birthdayDate;
        
        if (!Regex.IsMatch(GetValue(args, "studentId"), "^[A-Z]{2}[0-9]{8}$"))
        {
            throw new ArgumentException("Student ID must contains 2 letters and 8 digit numbers.");
        }
        StudentId = GetValue(args, "studentId");
        
        int ParseCourse;
        bool check  = int.TryParse(GetValue(args, "course"),  out ParseCourse);

        if (!check)
        {
            throw new ArgumentException("Invalid course, course must be a number!");
        }
        
        Course = ParseCourse;
    }

    public string Study()
    {
        return "I study at university.";
    }

    public override string ToString()
    {
        return $"Student {Name} {LastName}, {DateOfBirth.ToString("dd.MM.yyyy")}, {Course}, {StudentId}. Other: {Study()}";
    }

    public override string ToBlock()
    {
        return $"Student {Name}{LastName}\n" +
               $"{{ \"firstname\": {Name},\n" +
               $"\"lastname\": \"{LastName}\",\n" +
               $"\"dateofbirth\": {DateOfBirth.ToString("dd.MM.yyyy")},\n" +
               $"\"studentId\": {StudentId},\n" +
               $"\"course\": {Course}}};";
    }
}