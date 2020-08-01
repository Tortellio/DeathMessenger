using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Permissions;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;
using Math = System.Math;

namespace Tortellio.DeathMessenger
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;
		public static string PluginName = "DeathMessenger";
        public static string PluginVersion = "1.0.0";
        public Color DeathMsgColor;
        public Color LocationMsgColor;
        public Config Config;

        protected override void Load()
        {
            Instance = this;
            Config = Configuration.Instance;
            DeathMsgColor = UnturnedChat.GetColorFromName(Configuration.Instance.DeathColor, Color.green);
            LocationMsgColor = UnturnedChat.GetColorFromName(Configuration.Instance.LocationColor, Color.green);
            Logger.Log("DeathMessenger has been loaded!", ConsoleColor.Yellow);
			Logger.Log(PluginName + " v" + PluginVersion, ConsoleColor.Yellow);
            Logger.Log("Made by Tortellio", ConsoleColor.Yellow);
            Logger.Log("Visit Tortellio Discord for more! https://discord.gg/pzQwsew", ConsoleColor.Yellow);

            PlayerLife.onPlayerDied += OnPlayerDied;
        }

        protected override void Unload()
        {
            Instance = null;

            Logger.Log("DeathMessenger has been unloaded!", ConsoleColor.Yellow);
			Logger.Log("Visit Tortellio Discord for more! https://discord.gg/pzQwsew", ConsoleColor.Yellow);

            PlayerLife.onPlayerDied -= OnPlayerDied;
        }

        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "CAUSE_ACID", "{0} was blown up by a zombie!" },
            { "CAUSE_BLEEDING", "{0} bled to death!" },
            { "CAUSE_BONES", "{0} fractured to death!" },
            { "CAUSE_FREEZING", "{0} froze to death!" },
            { "CAUSE_BURNING", "{0} burned to death!" },
            { "CAUSE_FOOD", "{0} starved to death!" },
            { "CAUSE_WATER", "{0} dehydrated to death!" },
            { "CAUSE_GUN", "{0} [HP: {1}] shot and killed {2} in the {3} with {4}! [{5}m away]" },
            { "CAUSE_MELEE", "{0} [HP: {1}] chopped and killed {2} in the {3} with {4}!" },
            { "CAUSE_ZOMBIE", "{0} was mauled by a zombie!" },
            { "CAUSE_ANIMAL", "{0} was mauled by an animal!" },
            { "CAUSE_SUICIDE", "{0} commited suicide. Everyone is disappointed." },
            { "CAUSE_KILL", "{0} was killed by a server admin." },
            { "CAUSE_INFECTION", "{0} was infected to death!" },
            { "CAUSE_PUNCH", "{0} [HP: {1}] launched a Falcon Punch and killed {2} in the {3}!" },
            { "CAUSE_BREATH", "{0} suffocated to death!" },
            { "CAUSE_ROADKILL", "{0} was roadkilled by {1} [HP: {2}]!" },
            { "CAUSE_VEHICLE", "{0} was blown up by a vehicle!" },
            { "CAUSE_GRENADE", "{0} was blown up by {1} [HP: {2}] with a grenade! [{3}m away]" },
            { "CAUSE_SHRED", "{0} was shredded to bits!" },
            { "CAUSE_LANDMINE", "{0} was blown up by a landmine!" },
            { "CAUSE_ARENA", "{0} was eliminated by the arena!" },
            { "CAUSE_MISSILE", "{0} was blown up by {1} [HP: {2}] with a missile! [{3}m away]" },
            { "CAUSE_CHARGE", "{0} was blown up by {1} [HP: {2}] with a remote detonator! [{3}m away]" },
            { "CAUSE_SPLASH", "{0} was blown up by {1} [HP: {2}] with an explosive bullet! [{3}m away]" },
            { "CAUSE_SENTRY", "{0} was shot by a sentry gun!" },
            { "CAUSE_BOULDER", "{0} was crushed by a zombie!" },
            { "CAUSE_BURNER", "{0} was burned by a zombie!" },
            { "CAUSE_SPIT", "{0} was dissolved by a zombie!" },
            { "CAUSE_SPARK", "{0} was electrocuted by a zombie!" },
            { "LOCATION", "Death Detector: {0} nearest location is {1}!" },
        };
        public void OnPlayerDied(PlayerLife victim, EDeathCause cause, ELimb limb, CSteamID killer)
        {
            switch (cause)
            {
                case EDeathCause.ACID:
                    if (Config.AcidMessage) Say(Translate("CAUSE_ACID", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.ANIMAL:
                    if (Config.AnimalMessage) Say(Translate("CAUSE_ANIMAL", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.ARENA:
                    if (Config.ArenaMessage) Say(Translate("CAUSE_ARENA", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BLEEDING:
                    if (Config.BleedingMessage) Say(Translate("CAUSE_BLEEDING", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BONES:
                    if (Config.BonesMessage) Say(Translate("CAUSE_BONES", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BOULDER:
                    if (Config.BoulderMessage) Say(Translate("CAUSE_BOULDER", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BREATH:
                    if (Config.BreathMessage) Say(Translate("CAUSE_BREATH", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BURNER:
                    if (Config.BurnerMessage) Say(Translate("CAUSE_BURNER", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BURNING:
                    if (Config.BurningMessage) Say(Translate("CAUSE_BURNING", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.CHARGE:
                    if (Config.ChargeMessage) Say(Translate("CAUSE_CHARGE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.FOOD:
                    if (Config.FoodMessage) Say(Translate("CAUSE_FOOD", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.FREEZING:
                    if (Config.FreezingMessage) Say(Translate("CAUSE_FREEZING", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.GRENADE:
                    if (Config.GrenadeMessage) Say(Translate("CAUSE_GRENADE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.GUN:
                    if (Config.GunMessage) Say(Translate("CAUSE_GUN", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb), KillerEquip(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.INFECTION:
                    if (Config.InfectionMessage) Say(Translate("CAUSE_INFECTION", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.KILL:
                    if (Config.KillMessage) Say(Translate("CAUSE_KILL", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.LANDMINE:
                    if (Config.LandmineMessage) Say(Translate("CAUSE_LANDMINE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.MELEE:
                    if (Config.MeleeMessage) Say(Translate("CAUSE_MELEE", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb), KillerEquip(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.MISSILE:
                    if (Config.MissileMessage) Say(Translate("CAUSE_MISSILE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.PUNCH:
                    if (Config.PunchMessage) Say(Translate("CAUSE_PUNCH", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.ROADKILL:
                    if (Config.RoadkillMessage) Say(Translate("CAUSE_ROADKILL", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SENTRY:
                    if (Config.SentryMessage) Say(Translate("CAUSE_SENTRY", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SHRED:
                    if (Config.ShredMessage) Say(Translate("CAUSE_SHRED", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SPARK:
                    if (Config.SparkMessage) Say(Translate("CAUSE_SPARK", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SPIT:
                    if (Config.SpitMessage) Say(Translate("CAUSE_SPIT", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SPLASH:
                    if (Config.SplashMessage) Say(Translate("CAUSE_SPLASH", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SUICIDE:
                    if (Config.SuicideMessage) Say(Translate("CAUSE_SUICIDE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.VEHICLE:
                    if (Config.VehicleMessage) Say(Translate("CAUSE_VEHICLE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.WATER:
                    if (Config.WaterMessage) Say(Translate("CAUSE_WATER", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.ZOMBIE:
                    if (Config.ZombieMessage) Say(Translate("CAUSE_ZOMBIE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(Translate("LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                default:
                    Logger.LogError("Error. Please contact nelson!");
                    break;
            }
        }
        public string KillerDistance(Player victim, CSteamID killer)
        {
            return Math.Round(Vector3.Distance(victim.transform.position, PlayerTool.getPlayer(killer).transform.position)).ToString();
        }
        public string KillerHealth(CSteamID killer)
        {
            return PlayerTool.getPlayer(killer).life.health.ToString();
        }
        public string KillerEquip(CSteamID killer)
        {
            return PlayerTool.getPlayer(killer).equipment.asset.itemName;
        }
        public string KillerName(CSteamID killer)
        {
            return PlayerTool.getPlayer(killer).channel.owner.playerID.characterName;
        }
        public string VictimLimb(ELimb limb)
        {
            switch (limb)
            {
                case ELimb.LEFT_ARM:
                    return "left arm";
                case ELimb.LEFT_BACK:
                    return "torso";
                case ELimb.LEFT_FOOT:
                    return "left foot";
                case ELimb.LEFT_FRONT:
                    return "torso";
                case ELimb.LEFT_HAND:
                    return "left hand";
                case ELimb.LEFT_LEG:
                    return "left leg";
                case ELimb.RIGHT_ARM:
                    return "right arm";
                case ELimb.RIGHT_BACK:
                    return "torso";
                case ELimb.RIGHT_FOOT:
                    return "right foot";
                case ELimb.RIGHT_FRONT:
                    return "torso";
                case ELimb.RIGHT_HAND:
                    return "right hand";
                case ELimb.RIGHT_LEG:
                    return "right leg";
                case ELimb.SKULL:
                    return "head";
                case ELimb.SPINE:
                    return "torso";
                default:
                    return "";
            }
        }
        public string VictimLocation(Player victim)
        {
            var location = "Unknown";
            //Vector3 tempLocation = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            float tempDistance = float.MaxValue;
            LevelInfo info = Level.info;
            Local local = info?.getLocalization();
            for (int i = 0; i < LevelNodes.nodes.Count; i++)
            {
                Node node = LevelNodes.nodes[i];
                if (node.type == ENodeType.LOCATION)
                {
                    LocationNode locationNode = node as LocationNode;
                    var distance = Vector3.Distance(locationNode.point, victim.transform.position);
                    if (distance < tempDistance)
                    {
                        //tempLocation = locationNode.point;
                        tempDistance = distance;
                        string text = locationNode?.name;
                        if (!string.IsNullOrEmpty(text))
                        {
                            string key = text.Replace(' ', '_');
                            if (local != null && local.has(key))
                            {
                                text = local.format(key);
                                location = text;
                            }
                        }
                    }
                }
            }
            return location;
        }
        public List<string> WrapMessage(string text)
        {
            if (text.Length == 0) return new List<string>();
            string[] words = text.Split(' ');
            List<string> lines = new List<string>();
            string currentLine = "";
            int maxLength = 250;
            foreach (var currentWord in words)
            {

                if ((currentLine.Length > maxLength) ||
                    ((currentLine.Length + currentWord.Length) > maxLength))
                {
                    lines.Add(currentLine);
                    currentLine = "";
                }

                if (currentLine.Length > 0)
                    currentLine += " " + currentWord;
                else
                    currentLine += currentWord;

            }

            if (currentLine.Length > 0)
            {
                lines.Add(currentLine);
            }
            return lines;
        }
        public void Say(CSteamID CSteamID, string message, Color color, string imageURL)
        {
            SteamPlayer toPlayer = PlayerTool.getSteamPlayer(CSteamID);
            foreach (string m in WrapMessage(message))
            {
                ChatManager.serverSendMessage(m, color, fromPlayer: null, toPlayer: toPlayer, mode: EChatMode.SAY, iconURL: imageURL, useRichTextFormatting: true);
            }
        }
        public void Say(IRocketPlayer player, string message, Color color, string imageURL)
        {
            Say(new CSteamID(ulong.Parse(player.Id)), message, color, imageURL);
        }
        public void Say(Player player, string message, Color color, string imageURL)
        {
            Say(player.channel.owner.playerID.steamID, message, color, imageURL);
        }
        public void Say(string message, Color color, string imageURL)
        {
            foreach (string m in WrapMessage(message))
            {
                ChatManager.serverSendMessage(m, color, fromPlayer: null, toPlayer: null, mode: EChatMode.GLOBAL, iconURL: imageURL, useRichTextFormatting: true);
            }
        }
    }
}