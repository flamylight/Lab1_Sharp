namespace Models;
using System.Text.RegularExpressions;

public class PersonList
{
    private string _path = "test.txt";
    public List<Person> people = new List<Person>();

    public int Count => people.Count;
    
    
    //Deserialization
    public void Deserialization()
    {
        using (StreamReader sr = new StreamReader(_path))
        {
            string line = sr.ReadLine();

            while (!sr.EndOfStream)
            {
                
                if (!string.IsNullOrWhiteSpace(line))
                {
                    if (!line.Contains(":"))
                    {
                        string type;
                
                        List<KeyValue> args = new List<KeyValue>();
                        
                        string[] currentType = line.Split(" ");
                        type = currentType[0];

                        line = sr.ReadLine();

                        while (line != null && line.Contains(":"))
                        {

                            string strArgs = Regex.Replace(line, @"[{:,""};]", "");
                            string[] argsArray = strArgs.Trim().Split(" ");

                            KeyValue currArg = new KeyValue(argsArray[0], argsArray[1]);
                            
                            args.Add(currArg);
                            
                            line = sr.ReadLine();

                        }

                        switch (type)
                        {
                            case "Student":
                                Student newStudent = new Student(args);
                                people.Add(newStudent);
                                break;
                            case "Painter":
                                Painter newPainter = new Painter(args);
                                people.Add(newPainter);
                                break;
                            case "Farmer":
                                Farmer newFarmer = new Farmer(args);
                                people.Add(newFarmer);
                                break;
                        }
                        

                    }

                    if ((line = sr.ReadLine()) == null)
                    {
                        break;
                    }
                }
                else
                {
                    line = sr.ReadLine();
                }
            }
        }
    }

    //Serialization
    public void Serialization(Person person)
    {
        people.Add(person);
        using (StreamWriter sw = new StreamWriter(_path, append: true))
        {
            sw.WriteLine();
            sw.WriteLine(person.ToBlock());
        }
    }
    
}