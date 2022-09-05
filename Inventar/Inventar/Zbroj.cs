using System;
using System.Collections.Generic;
using System.Text;

namespace Inventar
{
    class Zbroj : Predmet
    {
        public bool OdolnostOhen { get; private set; }
        public bool OdolnostJed { get; private set; }
        public int Ochrana { get; private set; }
        private int stav;
        public int Stav
        {
            get
            {
                return stav;
            }
            set
            {
                stav = value;
                if (stav <= 10)
                    Zniceno = true;
                else
                    Zniceno = false;
            }
        }

        public Zbroj(string nazev, float vaha, string popis, bool odolnostOhen, bool odolnostJed, int ochrana, int stav) : base(nazev, vaha, popis)
        {
            OdolnostOhen = odolnostOhen;
            OdolnostJed = odolnostJed;
            Ochrana = ochrana;
            Stav = stav;
        }

        public override int Use()
        {
            return 0;
        }

        public override void Info()
        {
            Console.WriteLine($"Název: {Nazev}\nVáha: {Vaha}\nPopis: {Popis}\nZniceno: {Zniceno}\nOdolnost Ohně: {OdolnostOhen}\nOdolnost Jedu: {OdolnostJed}\nOchrana: {Ochrana}\nStav: {this.stav}");
        }
    }
}
