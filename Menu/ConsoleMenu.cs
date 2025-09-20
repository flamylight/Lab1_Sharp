using Models;

namespace Menu;

public class ConsoleMenu
{
    private bool isActive = true;

    private string MainMessage = "Choose one option: \n" +
                                 "1. Deserialization\n" +
                                 "2. Serialization\n" +
                                 "3. Print list\n" +
                                 "4. Calculate the task\n" +
                                 "5. Exit";

    public void Start()
    {
        PersonList newList = new PersonList();
        
        
        while (isActive)
        {
            
            Console.WriteLine(MainMessage);
            
            Console.Write("Choose one option: ");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    try
                    {
                        newList.Deserialization();
                        Console.WriteLine("Done!");
                        break;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        break;
                    }
                    
                case "3":
                    if (newList.Count != 0)
                    {
                        for (int i = 0; i < newList.Count; i++)
                        {
                            Console.WriteLine($"{i+1}. {newList.people[i]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Empty list!");
                    }
                    
                    break;
                
                case "2":
                    Console.Write("Please enter the type: ");
                    string type = Console.ReadLine();

                    if (type == "Student")
                    {
                        Console.Write("Please enter the name: ");
                        string name = Console.ReadLine();
                        Console.Write("Please enter the last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Please enter the date of birth: ");
                        string date = Console.ReadLine();
                        Console.Write("Please enter the student ID: ");
                        string studentID = Console.ReadLine();
                        Console.Write("Please enter the course: ");
                        string course = Console.ReadLine();
                        
                        try
                        {
                            Student newStudent = new Student(name, lastName, date, studentID, course);
                            newList.Serialization(newStudent);

                            Console.WriteLine("Done!\n");
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            
                        }
                    }
                    else if (type == "Painter")
                    {
                        Console.Write("Please enter the name: ");
                        string name = Console.ReadLine();
                        Console.Write("Please enter the last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Please enter the style: ");
                        string style = Console.ReadLine();
                        
                        try
                        {
                            Painter newPainter = new Painter(name, lastName, style);
                            newList.Serialization(newPainter);

                            Console.WriteLine("Done!\n");
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something is entered incorrectly!");
                            
                        }
                    }
                    
                    else if (type == "Farmer")
                    {
                        Console.Write("Please enter the name: ");
                        string name = Console.ReadLine();
                        Console.Write("Please enter the last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Please enter the age: ");
                        string age = Console.ReadLine();
                        
                        try
                        {
                            Farmer newFarmer = new Farmer(name, lastName, age);
                            newList.Serialization(newFarmer);

                            Console.WriteLine("Done!\n");
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Something is entered incorrectly!");
                            
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Unknown type: " + type);
                    }

                    break;

                    
                
                case "5":
                    isActive = false;
                    break;
                
                case "4":
                    if (newList.Count != 0)
                    {
                        Console.WriteLine("2nd year students and birth winter: ");
                        foreach (Person person in newList.people)
                        {
                            if (person is Student student)
                            {
                                if (student.Course == 2 &&
                                    student.DateOfBirth.Month == 12 ||
                                    student.DateOfBirth.Month == 1 || student.DateOfBirth.Month == 2)
                                {
                                    Console.WriteLine(student);
                                }
                            }
                            
                        }
                    }

                    break;
            }
        }
    }
}