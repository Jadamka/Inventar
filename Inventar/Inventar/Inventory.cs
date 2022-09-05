using System;
using System.Collections.Generic;
using System.Text;

namespace Inventar
{
    class Inventory
    {
        private List<Predmet> inventar;
        private int kapacita;

        public Inventory(int kapacita)
        {
            inventar = new List<Predmet>();
            this.kapacita = kapacita;
        }

        public void Vlozit(Predmet predmet)
        {
            if(inventar.Count <= kapacita)
            {
                inventar.Add(predmet);
            }
        }

        public void Info()
        {
            foreach(Predmet predmet in inventar)
            {
                predmet.Info();
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public void UseLektvar()
        {
            int index = 1;
            foreach (Predmet predmet in inventar)
            {
                if(predmet is Lektvar)
                {
                    Console.WriteLine($"{index}. ");
                    predmet.Info();
                    index++;
                }
            }

            Console.Write("\nVolba: ");
            int volba = int.Parse(Console.ReadLine()) - 1;

            index = 1;
            foreach(Predmet predmet in inventar)
            {
                if(predmet is Lektvar)
                {
                    if(volba == index - 1)
                    {
                        ((Lektvar)predmet).Use();
                    }
                    index++;
                }
            }
        }

        public void UseZbran()
        {
            int index = 1;
            foreach (Predmet predmet in inventar)
            {
                if (predmet is Zbran)
                {
                    Console.WriteLine($"{index}. ");
                    predmet.Info();
                    index++;
                }
            }

            Console.Write("\nVolba: ");
            int volba = int.Parse(Console.ReadLine()) - 1;

            index = 1;
            foreach (Predmet predmet in inventar)
            {
                if (predmet is Zbran)
                {
                    if (volba == index - 1)
                    {
                        ((Zbran)predmet).Use();
                    }
                    index++;
                }
            }
        }

        public void UseZbroj()
        {
            int index = 1;
            foreach (Predmet predmet in inventar)
            {
                if (predmet is Zbroj)
                {
                    Console.WriteLine($"{index}. ");
                    predmet.Info();
                    index++;
                }
            }

            Console.Write("\nVolba: ");
            int volba = int.Parse(Console.ReadLine()) - 1;

            index = 1;
            foreach (Predmet predmet in inventar)
            {
                if (predmet is Zbroj)
                {
                    if (volba == index - 1)
                    {
                        ((Zbroj)predmet).Use();
                    }
                    index++;
                }
            }
        }

        public void Vyhodit()
        {
            for(int i = 0; i < inventar.Count; i++)
            {
                Console.Write(i + 1);
                inventar[i].Info();
            }

            Console.Write("\nVolba: ");
            int volba = int.Parse(Console.ReadLine()) - 1;

            inventar.RemoveAt(volba);
        }

        public void VyhoditZnicene()
        {
            foreach(Predmet predmet in inventar)
            {
                if (predmet.Zniceno)
                {
                    predmet.Info();
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Chcete odebrat všechny zničené věci? a/n");
            char volba = Console.ReadLine()[0];

            switch (volba)
            {
                case 'a':
                    foreach (Predmet predmet in inventar)
                    {
                        if (predmet.Zniceno)
                        {
                            inventar.Remove(predmet);
                        }
                    }
                    break;
                case 'n':
                    break;
                default:
                    Console.WriteLine("Špatná volba");
                    break;
            }
        }
    }
}
