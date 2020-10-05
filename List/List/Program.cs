using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();
            list.Add(10);
            list.Add(20);
            list.Add(78);
            list.Add(199);
            list.Add(200);

            list.Clear();
            Console.WriteLine(list[0]);



            //list.Insert(1, 555);


            //for (int i = 0; i < list.count; i++)
            //{

            //    Console.WriteLine(list[i]);
            //}


            //list.Remove(20);

            //for (int i = 0; i < list.count; i++)
            //{

            //    Console.WriteLine(list[i]);
               
            //}

            //bool c = list.Remove(1);
            //new List<int>().Con
            //list.Clear();

            //for (int i = 0; i < list.count; i++)
            //{

            //    Console.WriteLine(list[i]);
            //}






        }
    }
}
