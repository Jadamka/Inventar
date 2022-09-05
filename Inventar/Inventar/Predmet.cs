using System;
using System.Collections.Generic;
using System.Text;

namespace Inventar
{
    abstract class Predmet
    {
        protected string Nazev { get; private set; }
        protected float Vaha { get; private set; }
        protected string Popis { get; private set; }
        public bool Zniceno { get; protected set; }

        public Predmet(string nazev, float vaha, string popis)
        {
            Nazev = nazev;
            Vaha = vaha;
            Popis = popis;
        }

        abstract public int Use();

        abstract public void Info();
    }
}
