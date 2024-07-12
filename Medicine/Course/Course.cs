
namespace Course
{

    internal class Course
    {
        public List<Group> groups = new List<Group>();

        public object Groups { get; internal set; }

        public void AddGroup(Group group)
        {
            if (groups.Any(g => g.Name == group.Name))
            {
                Console.WriteLine($"A group with name {group.Name} already exists.");
            }
            else
            {
                groups.Add(group);
                Console.WriteLine($"Group {group.Name} added to the course.");
            }
        }

        public void DisplayGroups()
        {
            Console.WriteLine("Groups in the course:");
            foreach (var group in groups)
            {
                Console.WriteLine($"Group ID: {group.Id}, Name: {group.Name}, Limit: {group.Limit}");
            }
        }

        public void DisplayStudentsInAllGroups()
        {
            foreach (var group in groups)
            {
                group.DisplayStudents();
            }
        }

        public void AddStudentToGroup(string groupName, Student student)
        {
            Group foundGroup = null;
            foreach (var group in groups)
            {
                if (group.Name == groupName)
                {
                    foundGroup = group;
                    break;
                }
            }
            if (foundGroup != null)
            {
                foundGroup.AddStudent(student);
                Console.WriteLine($"Student {student.Name} added to group {groupName}.");
            }
            else
            {
                Console.WriteLine($"Group {groupName} not found.");
            }
        }

        public void RemoveStudentFromGroup(string groupName, int studentId)
        {
            Group group = groups.FirstOrDefault(g => g.Name == groupName);
            if (group != null)
            {
                group.RemoveStudent(studentId);
            }
            else
            {
                Console.WriteLine($"Group {groupName} not found.");
            }
        }

        public void EditStudentInGroup(string groupName, int studentId)
        {
            Group foundGroup = null;
            foreach (var group in groups)
            {
                if (group.Name == groupName)
                {
                    foundGroup = group;
                    break;
                }
            }
            if (foundGroup != null)
            {
                Student foundStudent = null;
                foreach (var student in foundGroup.Students)
                {
                    if (student.Id == studentId)
                    {
                        foundStudent = student;
                        break;
                    }
                }
                if (foundStudent != null)
                {
                    Console.WriteLine("Enter new details for the student:");
                    Console.Write("Name: ");
                    foundStudent.Name = Console.ReadLine();
                    Console.Write("Surname: ");
                    foundStudent.Surname = Console.ReadLine();
                    Console.Write("Age: ");
                    foundStudent.Age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Grade: ");
                    foundStudent.Grade = Console.ReadLine();
                    Console.WriteLine("Student details updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Student with ID {studentId} not found in group {groupName}.");
                }
            }
            else
            {
                Console.WriteLine($"Group {groupName} not found.");
            }
        }


        public void SearchStudents(string searchTerm)
        {
            Console.WriteLine($"Search results for '{searchTerm}':");
            foreach (var group in groups)
            {
                foreach (var student in group.Students)
                {
                    if (student.Name.Contains(searchTerm))
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Group: {group.Name}");
                    }
                }
            }
        }

        public void RemoveStudentById(int studentId)
        {
            foreach (var group in groups)
            {
                Student student = group.Students.FirstOrDefault(s => s.Id == studentId);
                if (student != null)
                {
                    group.Students.Remove(student);
                    Console.WriteLine($"Student {student.Name} removed from group {group.Name}");
                    return;
                }
            }
            Console.WriteLine($"Student with ID {studentId} not found in any group.");
        }

        public void DisplayStudentsInGroup(string groupName)
        {
            Group group = groups.FirstOrDefault(g => g.Name == groupName);
            if (group != null)
            {
                group.DisplayStudents();
            }
            else
            {
                Console.WriteLine($"Group {groupName} not found.");
            }
        }
    }
}
