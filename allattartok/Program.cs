using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using word = Microsoft.Office.Interop.Word;

namespace allattartok
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler handler = new Handler();
            handler.setter();
            handler.ownersAgeListASC();
            Console.WriteLine("\n");
            handler.ownersAgeListDESC();
            Console.WriteLine("\n");
            handler.ownerOlderThanPet();
            Console.WriteLine("\n");
            handler.searchByPetName("pet");
            Console.WriteLine("\n");
            handler.searchByPetName("owner");
            Console.WriteLine("\n");
            handler.ownerPetsMax();
            Console.WriteLine("\n");
            handler.oldest();
            Console.WriteLine("\n");
            handler.youngest();
            Console.WriteLine("\n");
            Console.WriteLine("popularfirsletter: " + handler.getPopularFirstLetter());



            //handler.writeowner();
            //Console.WriteLine("\n");
            //handler.writePets();
            //Console.WriteLine("\n");
            Console.ReadKey();
        }

    }
}
