using CSharpTextRPG_V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTextRPG_V2
{
    public enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }

    internal class Player : Creature
    {
        protected PlayerType type = PlayerType.None;

        public Player() : base(CreatureType.Player)
        {

        }

        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            this.type = type;
        }

        public PlayerType GetPlayerType() { return type; }
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
