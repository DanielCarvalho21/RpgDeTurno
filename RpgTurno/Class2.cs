using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTurno
{
    internal class Inimigo
    {
        public int inimigoHp;
        public int inimigoAtk;
        public int inimigoCure;
        public int inimigoBigCure;
        public int inimigoCritico;

        public Inimigo(int inimigoHp, int inimigoAtk, int inimigoCure, int inimigoBigCure, int inimigoCritico)
        {
            this.inimigoHp = inimigoHp;
            this.inimigoAtk = inimigoAtk;
            this.inimigoCure = inimigoCure;
            this.inimigoBigCure = inimigoBigCure;
            this.inimigoCritico = inimigoCritico;
        }

        public void removeHp(int damage)
        {
           this.inimigoHp -= damage;
        }

        public int addHp()
        {
            return inimigoHp += inimigoCure;
        }

        public int addCurePlus()
        {
            return inimigoHp += inimigoBigCure;
        }
    }
}
