using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        private bool sonarMode = false;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SonarMode => sonarMode;

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSonarMode()
        {
            switch (SonarMode)
            {
                case false:
                    sonarMode = true;
                    MainWeaponCaliber += 40;
                    Speed -= 5;
                    break;
                case true:
                    sonarMode = false;
                    MainWeaponCaliber -= 40;
                    Speed += 5;
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *SonarMode: {(SonarMode == true ? "ON" : "OFF")}");
            return sb.ToString().TrimEnd();
        }
             
    }
}
