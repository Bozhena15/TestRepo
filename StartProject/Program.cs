//using System.Linq;
//using System.Collections;
using StartProject;
//using System.Text.RegularExpressions;
//using System.ComponentModel.DataAnnotations;

//List<Student> students = new List<Student>
//{
//    new Student { FirstName = "FirstName1", LastName = "LastName1", DateTime = DateTime.Today},
//    new Student { FirstName = "FirstName2", LastName = "LastName2", DateTime = DateTime.Today},
//    new Student { FirstName = "FirstName3", LastName = "LastName3", DateTime = DateTime.Today},
//    new Student { FirstName = "FirstName4", LastName = "LastName4", DateTime = DateTime.Today}
//};

//Teacher teacher = new();

//foreach (Student student in students)
//    teacher.examDelegate += student.Exam;

//teacher.Exam("exam1");

//teacher.examDelegate += delegate (string s)
//{
//    int count = 0;
//    Console.WriteLine(++count);
//};

//teacher.Exam("exam2");

//Calc calc = delegate (int a, int b)
//{
//    int c = a + b;
//    Console.WriteLine(c);
//    return c;
//};

//calc += (int a, int b) =>
//{
//    return a - b;
//};


//calc += delegate (int a, int b)
//{
//    int c = a * b;
//    Console.WriteLine(c);
//    return c;
//};

//calc += delegate (int a, int b)
//{
//    int c = a / b;
//    Console.WriteLine(c);
//    return c;
//};

//calc(2, 1);

//string i = "4";
//int s = i.ToInt();
//s++;
//Console.WriteLine(s);

//bool b = true;
//int m = b.ToInt();
//Console.WriteLine(m);
////File FileInfo
////Directory DirectoryInfo

//DirectoryInfo directory = new DirectoryInfo(@".\Test");

//if(!directory.Exists)
//    directory.Create();

//Console.WriteLine("Full path: " + directory.FullName);
//Console.WriteLine(directory.CreationTime);

//FileInfo[] files = directory.GetFiles();

//foreach (var f in files)
//    Console.WriteLine(f.Name);

//DirectoryInfo[] directorys = directory.GetDirectories();

//foreach (var d in directorys)
//    Console.WriteLine(d.Name);

//DirectoryInfo directory1 = directory.CreateSubdirectory("Test1");


//Console.WriteLine("Full path: " + directory1.FullName);
//Console.WriteLine(directory1.CreationTime);

//FileInfo file = new FileInfo(directory1.FullName + @"\fileTest.txt");

//if(!file.Exists)
//    file.Create();

//string path = directory1.FullName + @"\fileTest1.txt";
//if (!File.Exists(path))
//    File.Create(path);

//FileInfo[] files1 = directory1.GetFiles();

//foreach (var f in files1)
//    Console.WriteLine(f.Name);

//Console.WriteLine("---------------------------------");
//FileInfo[] files12 = directory1.GetFiles();

//foreach (var f in files12)
//    Console.WriteLine(f.Name);

////user.user1@gmail.com
//string emailPattern = @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$";

//string email = "user.user1@gmail.com";
//Regex regex = new Regex(emailPattern);

//Console.WriteLine(regex.IsMatch(email) ? "correct" : "incorrect");

//foreach (var attr in typeof(Employee).CustomAttributes)
//    Console.WriteLine(attr);

//foreach (var info in typeof(Employee).GetMembers())
//{
//    foreach (var attr in info.CustomAttributes)
//        Console.WriteLine(attr);
//}

string? str = Console.ReadLine();
for (int i = 0; i < 4; i++)
    str = "+" + str + "%";

str += "%";
Console.WriteLine(str);

Mas Mas = new Mas();
Mas.Print();