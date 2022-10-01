using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextRPG_V2
{

    public enum CreatureType
    {
        None = 0,
        Player = 1,
        Monster = 2
    }

    internal class Creature
    {
        CreatureType type = CreatureType.None;

        protected Creature(CreatureType type)
        {
            this.type = type;
        }

        protected int hp = 0;
        protected int power = 0;

        public int GetHp() { return hp; }
        public int GetPower() { return power; }

        public bool IsDead() { return hp <= 0; }

        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0) hp = 0;
        }

        public void SetInfo(int hp, int power)
        {
            this.hp = hp;
            this.power = power;
        }
    }
}
