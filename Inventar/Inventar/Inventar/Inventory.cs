using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Inventar
{
    class Inventory
    {
        private List<Predmet> inventar;
        private float kapacita;

        public Inventory(float kapacita)
        {
            inventar = new List<Predmet>();
            this.kapacita = kapacita;
        }

        public void Vlozit(Predmet predmet)
        {
            Console.Clear();
            if(kapacita - predmet.Vaha >= 0)
            {
                kapacita -= predmet.Vaha;
                inventar.Add(predmet);
                Console.WriteLine("Předmět byl úspěšně přidán");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Není místo");
            Console.ReadKey();
        }

        public void Info()
        {
            Console.Clear();
            foreach(Predmet predmet in inventar)
            {
                Console.WriteLine(predmet.Info());
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public void UseLektvar()
        {
            Console.Clear();
            int index = 1;
            foreach (Predmet predmet in inventar)
            {
                if(predmet is Lektvar)
                {
                    Console.WriteLine($"{index}. ");
                    Console.WriteLine(predmet.Info());
                    index++;
                }
            }

            Console.Write("\nVolba: ");
            int volba = int.Parse(Console.ReadLine()) - 1;

            Console.Clear();

            index = 1;
            foreach(Predmet predmet in inventar)
            {
                if(predmet is Lektvar)
                {
                    if(volba == index - 1)
                    {
                        if (!predmet.Zniceno)
                            ((Lektvar)predmet).Use();
                        else
                            Console.WriteLine("Předmět je zničen");
                    }
                    index++;
                }
            }

            Console.ReadKey();
        }

        public void UseZbran()
        {
            int index = 1;
            foreach (Predmet predmet in inventar)
            {
                if (predmet is Zbran)
                {
                    Console.WriteLine($"{index}. ");
                    Console.WriteLine(predmet.Info());
                    index++;
                }
            }

            Console.Write("\nVolba: ");
            int volba = int.Parse(Console.ReadLine()) - 1;

            Console.Clear();

            index = 1;
            foreach (Predmet predmet in inventar)
            {
                if (predmet is Zbran)
                {
                    if (volba == index - 1)
                    {
                        if(!predmet.Zniceno)
                            ((Zbran)predmet).Use();
                        else
                            Console.WriteLine("Předmět je zničen");
                    }
                    index++;
                }
            }

            Console.ReadKey();
        }

        public void UseZbroj()
        {
            int index = 1;
            foreach (Predmet predmet in inventar)
            {
                if (predmet is Zbroj)
                {
                    Console.WriteLine($"{index}. ");
                    Console.WriteLine(predmet.Info());
                    index++;
                }
            }

            Console.Write("\nVolba: ");
            int volba = int.Parse(Console.ReadLine()) - 1;

            Console.Clear();

            index = 1;
            foreach (Predmet predmet in inventar)
            {
                if (predmet is Zbroj)
                {
                    if (volba == index - 1)
                    {
                        if (!predmet.Zniceno)
                            ((Zbroj)predmet).Use();
                        else
                            Console.WriteLine("Předmět je zničen");
                    }
                    index++;
                }
            }

            Console.ReadKey();
        }

        public void Vyhodit()
        {
            Console.Clear();
            for(int i = 0; i < inventar.Count; i++)
            {
                Console.Write(i + 1);
                Console.WriteLine(inventar[i].Info());
            }

            Console.Write("\nVolba: ");
            int volba = int.Parse(Console.ReadLine()) - 1;

            if(volba < 0 || volba > inventar.Count - 1)
            {
                Console.WriteLine("Špatná volba");
                Console.ReadKey();
                return;
            }

            inventar.RemoveAt(volba);
            Console.WriteLine("Předmět byl úspěšně smazán");
            Console.ReadKey();
        }

        public void VyhoditZnicene()
        {
            Console.Clear();
            foreach(Predmet predmet in inventar)
            {
                if (predmet.Zniceno)
                {
                    Console.WriteLine(predmet.Info());
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Chcete odebrat všechny zničené věci? a/n");
            char volba = Console.ReadLine()[0];

            Console.Clear();
            switch (volba)
            {
                case 'a':
                    for(int i = inventar.Count-1; i >= 0; i--)
                    {
                        if (inventar[i].Zniceno)
                        {
                            inventar.RemoveAt(i);
                        }
                    }
                    Console.WriteLine("Předměty byli úspěšně vyhozeny");
                    break;
                case 'n':
                    Console.WriteLine("Rozhodl ses nic nevyhodit");
                    break;
                default:
                    Console.WriteLine("Špatná volba");
                    break;
            }

            Console.ReadKey();
        }

        public void Export()
        {
            StreamWriter zapis = new StreamWriter("Evidence.txt", false);
            foreach(Predmet predmet in inventar)
            {
                string info = predmet.Info().Replace('\n', ';');
                zapis.WriteLine(info);
            }
            zapis.Close();
        }

        public void Import()
        {
            Zbran.Type typ;
            StreamReader cteni = new StreamReader("Evidence.txt");
            string line = "";
            while((line = cteni.ReadLine()) != null)
            {
                string[] hodnota = line.Split(';');
                if(hodnota.Length == 5)
                {
                    Vlozit(new Lektvar(hodnota[0].Remove(0, hodnota[0].IndexOf(' ') + 1), float.Parse(hodnota[1].Remove(0, hodnota[1].IndexOf(' ') + 1)), hodnota[2].Remove(0, hodnota[2].IndexOf(' ') + 1), int.Parse(hodnota[4].Remove(0, hodnota[4].IndexOf(' ') + 1))));
                }
                else if(hodnota.Length == 7)
                {
                    if (hodnota[5] == "Ohen")
                        typ = Zbran.Type.Ohen;
                    else if (hodnota[5] == "Jed")
                        typ = Zbran.Type.Jed;
                    else
                        typ = Zbran.Type.Normal;
                    Vlozit(new Zbran(hodnota[0].Remove(0, hodnota[0].IndexOf(' ') + 1), float.Parse(hodnota[1].Remove(0, hodnota[1].IndexOf(' ') + 1)), hodnota[2].Remove(0, hodnota[2].IndexOf(' ') + 1), int.Parse(hodnota[4].Remove(0, hodnota[4].IndexOf(' ') + 1)), typ, int.Parse(hodnota[6].Remove(0, hodnota[6].IndexOf(' ') + 1))));
                }
                else
                {
                    Vlozit(new Zbroj(hodnota[0].Remove(0, hodnota[0].IndexOf(' ') + 1), float.Parse(hodnota[1].Remove(0, hodnota[1].IndexOf(' ') + 1)), hodnota[2].Remove(0, hodnota[2].IndexOf(' ') + 1), bool.Parse(hodnota[4].Remove(0, hodnota[4].IndexOf(':') + 2)), bool.Parse(hodnota[5].Remove(0, hodnota[5].IndexOf(':') + 2)), int.Parse(hodnota[6].Remove(0, hodnota[6].IndexOf(' ') + 1)), int.Parse(hodnota[7].Remove(0, hodnota[7].IndexOf(' ') + 1))));
                }
            }

            cteni.Close();
        }
    }
}
