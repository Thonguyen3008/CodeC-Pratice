// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;
using System.Security.Permissions;
using System.Xml;
using MainData;

namespace MainData{
    public class Student{
        private string name ="Not Assigned";
         private string code="Not Assigned";
          private int age =0;
          public Student(string name="", string code="", int age=0){
            this.name=name;
            this.code=code;
            this.age=age;
          }
          public void DisplayInfo(){
            Console.WriteLine("Code= {0}, name={1}, Age={2}", code, name, age);
          }
        public override string ToString()
        {
            return "Code = " + code + ",Name = "+ name +", Age = "+ age ;
            
       }
       public class NegativeNumException:Exception{
        public NegativeNumException(){}
        public NegativeNumException(string message): base(message){}
       }
        public void InputInfo(){
            Console.WriteLine("Input Student Name:");
            name= Console.ReadLine();
            Console.WriteLine("Input Student Code:");
            code= Console.ReadLine();
            Console.WriteLine("Input Student Age:");
            string str= Console.ReadLine();
            try{
                 age= int.Parse(str);
                 if(age<=0){
                    throw new NegativeNumException();
                 }
            }
            catch(FormatException){
                Console.WriteLine("Not input a Numver. Please reinput a number:");
                str = Console.ReadLine();
                age= int.Parse(str);
            }
            catch(NegativeNumException){
                Console.WriteLine("Negative Age is not accepted. Please Reinput a number:");
                str=Console.ReadLine();
                age=int.Parse(str);
            }
           
        }
}
    public class Lecturer{
        private string name= "Not Assignment";
        private string code=" Not Assignment";
        private int age= 0;
        public Lecturer(string name="", string code= "", int age=0){
            this.name=name;
            this.code=code;
            this.age= age;
        }
        public void DisplayInfo(){
            Console.WriteLine("Code= {0}, name={1}, Age={2}", code, name, age);
        }
        public override string ToString()
        {
            return "Code = " + code + ",Name = "+ name +", Age = "+ age ;
        }
        public class NegativeNumException:Exception{
        public NegativeNumException(){}
        public NegativeNumException(string message): base(message){}
       }
        public void InputInfo(){
            Console.Write("Input Teacher name:");
            name= Console.ReadLine();
            Console.Write("Input Teacher code");
            code=Console.ReadLine();
            Console.Write("Input teacher age:");
            string str= Console.ReadLine();;
            try{
                 age= int.Parse(str);
                 if(age<=0){
                    throw new NegativeNumException();
                 }
            }
            catch(FormatException){
                Console.WriteLine("Not input a Numver. Please reinput a number:");
                str = Console.ReadLine();
                age= int.Parse(str);
            }
            catch(NegativeNumException){
                Console.WriteLine("Negative Age is not accepted. Please Reinput a number:");
                str=Console.ReadLine();
                age=int.Parse(str);
            }
           

        }
 }
 }
 namespace StudentListManagement{
    class Program{
        static void Main(String[] args){
            Student sv= new Student("Nguyen van", "0123456789", 23);

            sv.DisplayInfo();
            sv.InputInfo();

            
            Console.WriteLine(sv.ToString());

            Lecturer gv= new Lecturer("Anh tuan", "Khoa toan-tin",33);
            gv.DisplayInfo();
            gv.InputInfo();
            Console.WriteLine(gv.ToString());

            Console.ReadLine();
        }
    }
}

    

