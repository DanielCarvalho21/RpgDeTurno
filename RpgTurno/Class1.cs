using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTurno
{
    internal class Player
    {
        public float playerHp;
        public int playerAtk;
        public int playerCure;

        public Player(float hp, int playerAtk, int playerCure)
        {
            this.playerHp = hp;
            this.playerAtk = playerAtk;
            this.playerCure = playerCure;
        }
         public float removeHp(int damage)
        {
           float playerDamage = playerHp -= damage;
            return playerDamage;
        }

        public float addHp(float heal)
        {
            float playerAddHp = playerHp += heal;
            return playerAddHp;
        }
    }
}
