// See https://aka.ms/new-console-template for more information
using System;

namespace dahinhtronglop{
    class Shape{
        protected int height, width;
        public Shape (int a=0, int b=0){
            width=a;
            height=b;
        }
        public virtual int Area(){
            Console.WriteLine("Parent class area:");
            return 0;
        }
    }
    class Retangle: Shape{
        public Retangle (int a=0, int b=0): base(a,b){

        }
        public override int Area()
        {
            Console.WriteLine(" Retangle class area:");
            return (width*height);
        }
    }
    class Triangle: Shape{
         public Triangle (int a=0, int b=0): base(a,b){

        }
        public override int Area()
        {
            Console.WriteLine(" Triangle class area:");
            return (width*height/2);
        }
    }
    class Caller{
        public void callArea(Shape sh){
            int a;
            a=sh.Area();
            Console.WriteLine("Area is {0}",a);
        }
    }
    class Tester{
        static void Main(string[] args){
            Caller c= new Caller();
            Retangle r= new Retangle(10,10);
            Triangle t= new Triangle(10,5);
            c.callArea(r);
            c.callArea(t);
            Console.ReadLine();
        }
    }
}