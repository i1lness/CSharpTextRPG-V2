using CSharpTextRPG_V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextRPG_V2
{
    enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }
    
    class Player
    {
        protected PlayerType type = PlayerType.None;
        protected int hp = 0;
        protected int power = 0;

        protected Player(PlayerType type)
        {
            this.type = type;
        }

        public void SetInfo(int hp, int power)
        {
            this.hp = hp;
            this.power = power;
        }

        public PlayerType GetPlayerType() { return type; }
        public int GetHp() { return hp; }   
        public int GetPower() { return power; }

        public bool IsDead() { return hp <= 0; }

        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0) hp = 0;
        }

        
    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo(100, 10);
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(75, 12);
        }
    }

    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(50, 15);
        }
    }
}
