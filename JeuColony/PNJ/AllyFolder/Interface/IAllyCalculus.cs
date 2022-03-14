using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuColony.PNJ.AllyFolder
{
    interface IAllyCalculus
    {
        void GenerateAllStat();
        int GenerateHealthPointMax();
        int GenerateHealthPoint();
        int GenerateAttackPower();
        int GenerateLoggingPower();
        int GenerateDiggerPower();
        int GenerateVisionRange();
        int MoveTo();
    }
}
