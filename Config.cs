using Rocket.API;

namespace Tortellio.DeathMessenger
{
    public class Config : IRocketPluginConfiguration
    {
        public string DeathIconURL;
        public string DeathColor;
        public string LocationIconURL;
        public string LocationColor;
        public bool LocationMessage;
        public bool BleedingMessage;
        public bool BonesMessage;
        public bool FreezingMessage;
        public bool BurningMessage;
        public bool FoodMessage;
        public bool WaterMessage;
        public bool GunMessage;
        public bool MeleeMessage;
        public bool ZombieMessage;
        public bool AnimalMessage;
        public bool SuicideMessage;
        public bool KillMessage;
        public bool InfectionMessage;
        public bool PunchMessage;
        public bool BreathMessage;
        public bool RoadkillMessage;
        public bool VehicleMessage;
        public bool GrenadeMessage;
        public bool ShredMessage;
        public bool LandmineMessage;
        public bool ArenaMessage;
        public bool MissileMessage;
        public bool ChargeMessage;
        public bool SplashMessage;
        public bool SentryMessage;
        public bool AcidMessage;
        public bool BoulderMessage;
        public bool BurnerMessage;
        public bool SpitMessage;
        public bool SparkMessage;
        public void LoadDefaults()
        {
            DeathIconURL = "https://i.imgur.com/RwNhu8v.png";
            DeathColor = "Red";
            LocationIconURL = "https://i.imgur.com/AlIq6xx.png";
            LocationColor = "Yellow";
            LocationMessage = true;
            AcidMessage = true;
            AnimalMessage = true;
            ArenaMessage = true;
            BleedingMessage = true;
            BonesMessage = true;
            BoulderMessage = true;
            BreathMessage = true;
            BurnerMessage = true;
            BurningMessage = true;
            ChargeMessage = true;
            FoodMessage = true;
            FreezingMessage = true;
            GrenadeMessage = true;
            GunMessage = true;
            InfectionMessage = true;
            KillMessage = true;
            LandmineMessage = true;
            MeleeMessage = true;
            MissileMessage = true;
            PunchMessage = true;
            RoadkillMessage = true;
            SentryMessage = true;
            ShredMessage = true;
            SparkMessage = true;
            SpitMessage = true;
            SplashMessage = true;
            SuicideMessage = true;
            VehicleMessage = true;
            WaterMessage = true;
            ZombieMessage = true;
        }
    }
}