using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var caprain = captains.FirstOrDefault(capt => capt.FullName == selectedCaptainName);
            if (caprain == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName.ToString());
            }

            var vessel = vessels.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            if (vessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }
            captains.Add(caprain);
            vessel.Captain = caprain;
            caprain.AddVessel(vessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);

        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackVessel = vessels.FindByName(attackingVesselName);
            var defVessel = vessels.FindByName(defendingVesselName);

            if (attackVessel == null || defVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if (attackVessel.ArmorThickness == 0 || defVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            attackVessel.Attack(defVessel);
            attackVessel.Captain.IncreaseCombatExperience();
            defVessel.Captain.IncreaseCombatExperience();

            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var capRep = captains.Find(c => c.FullName == captainFullName);
            return capRep.Report();
        }

        public string HireCaptain(string fullName)
        {

            if (captains.Any(c => c.FullName == fullName))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            Captain captin = new Captain(fullName);
            captains.Add(captin);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vesselType == "Submarine")
            {
                vessels.Add(new Submarine(name, mainWeaponCaliber, speed));
            }
            else if (vesselType == "Battleship")
            {
                vessels.Add(new Battleship(name, mainWeaponCaliber, speed));
            }
            else
            {
                return String.Format(OutputMessages.InvalidVesselType);
            }
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            var vesselToRepair = vessels.FindByName(vesselName);
            if (vesselToRepair == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }
            vesselToRepair.RepairVessel();
            return String.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vesselToToggle = vessels.FindByName(vesselName);

            if (vesselToToggle == null)
            {
                return String.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vesselToToggle.GetType().Name == nameof(Battleship))
            {
                Battleship battleship = (Battleship)vesselToToggle;
                battleship.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, battleship.Name);
            }
            else
            {
                Submarine submarine = (Submarine)vesselToToggle;
                submarine.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, submarine.Name);
            }

        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            return vessel.ToString();
        }
    }
}
