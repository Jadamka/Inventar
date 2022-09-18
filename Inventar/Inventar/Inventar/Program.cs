using System;

namespace Inventar
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inv = new Inventory(250f);
            Lektvar lk = new Lektvar("Lektvar", 50, "lecivy", 10);
            Zbran zb = new Zbran("Zbran", 100, "utok", 10, Zbran.Type.Jed, 20);
            Zbroj zbj = new Zbroj("Zbroj", 100, "Brneni", true, false, 30, 10);

            Console.ReadKey();
        }
    }
}
