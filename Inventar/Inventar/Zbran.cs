using System;
using System.Collections.Generic;
using System.Text;

namespace Inventar
{
    class Zbran : Predmet
    {
        public int Damage { get; private set; }
        public enum Type { Ohen, Jed, Normal};
        public Type Typ { get; private set; }
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

        public Zbran(string nazev, float vaha, string popis, int damage, Type typ, int stav) : base(nazev, vaha, popis)
        {
            Damage = damage;
            Typ = typ;
            Stav = stav;
        }

        public override int Use()
        {
            Stav -= 10;
            return Damage;
        }

        public override void Info()
        {
            Console.WriteLine($"Název: {Nazev}\nVáha: {Vaha}\nPopis: {Popis}\nZniceno: {Zniceno}\nDamage: {Damage}\nTyp: {Typ}\nStav: {this.stav}");
        }
    }
}
