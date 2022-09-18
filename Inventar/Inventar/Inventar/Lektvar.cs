using System;
using System.Collections.Generic;
using System.Text;

namespace Inventar
{
    class Lektvar : Predmet
    {
        public int Ucinnost { get; private set; }

        public Lektvar(string nazev, float vaha, string popis, int ucinnost) : base(nazev, vaha, popis)
        {
            Ucinnost = ucinnost;
            Zniceno = false;
        }

        public override int Use()
        {
            Zniceno = true;
            return Ucinnost;
        }

        public override string Info()
        {
            return $"Název: {Nazev}\nVáha: {Vaha}\nPopis: {Popis}\nZniceno: {Zniceno}\nÚčinnost: {Ucinnost}";
        }
    }
}
