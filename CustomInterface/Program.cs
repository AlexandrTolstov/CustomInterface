using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("***** Fun with Intefaces *****\n");
            //Hexagon hex = new Hexagon();
            //Console.WriteLine("Points: {0}", hex.Points);
            //Console.ReadLine();

            //Circle c = new Circle("Lisa");
            //IPointy itfPt = null;
            //try
            //{
            //    itfPt = (IPointy)c;
            //    Console.WriteLine(itfPt.Points);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //Hexagon hex2 = new Hexagon("Peter");
            //itfPt = hex2 as IPointy;
            //if(itfPt != null)
            //    Console.WriteLine("Points: {0}", itfPt.Points);
            //else
            //    Console.WriteLine("OOPS! Not pointy...");

            Shape[] myShapes = { new Hexagon(), new Circle(), new Triangle("Joe"), new Circle("Jojo") };
            for (int i = 0; i < myShapes.Length; i++)
            {
                myShapes[i].Draw();

                if(myShapes[i] is IPointy ip)
                    Console.WriteLine("-> Points: {0}", ip.Points);
                else
                    Console.WriteLine("-> {0}\'s not pointy!", myShapes[i].PetName);

                if (myShapes[i] is IDraw3D)
                    DrawIn3D((IDraw3D)myShapes[i]);
                Console.WriteLine();
            }
            IPointy firstPointItem = FindFirstPointyShape(myShapes);
            Console.WriteLine("The item has {0} points", firstPointItem.Points);
            Console.ReadLine();
        }
        static void DrawIn3D(IDraw3D itf3d)
        {
            Console.WriteLine("-> Drawing IDraw3D compatible type");
            itf3d.Draw3D();
        }
        static IPointy FindFirstPointyShape(Shape[] shapes)
        {
            foreach(Shape s in shapes)
            {
                if (s is IPointy ip)
                    return ip;
            }
            return null;
        }
    }
}
