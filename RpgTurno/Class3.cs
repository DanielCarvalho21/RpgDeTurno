using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RpgTurno.Player;

namespace RpgTurno
{
    internal class Arma
    {
        public int ArmaDamage;
        private float armaHablidade;

        public Arma(int ArmaDamage)
        {
            this.ArmaDamage = ArmaDamage;
        }
        public int Critico()
        {
            int danoCritico = 12;
            Random random = new Random();
            int criticoChance = random.Next(1,4);
            if (criticoChance == 3)
            {
                return danoCritico;

            }
            else
            {
                return 0;
            }

        }
        

    }
}