using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokedex_databaze
{
    public class Pokemon
    {
        public static int TotalPokemon = 0;
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public bool Discovered { get; set; }

        public Pokemon(string Name, string Type, int HP, int Attack, int Defense, int Speed)
        {
            this.ID = TotalPokemon + 1;
            this.Name = Name;
            this.Type = Type;
            this.HP = HP;
            this.Attack = Attack;
            this.Defense = Defense;
            this.Speed = Speed;
            Discovered = false;
            TotalPokemon++;
        }
    }
}
