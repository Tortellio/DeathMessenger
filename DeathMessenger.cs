using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Plugins;
using OpenMod.API.Plugins;
using SDG.Unturned;
using UnityEngine;
using Steamworks;
using System.Collections.Generic;
using OpenMod.API.Users;

[assembly: PluginMetadata("Tortellio.DeathMessenger", Author = "Tortellio", DisplayName = "DeathMessenger", 
    Website = "https://github.com/Tortellio/DeathMessenger/")]
namespace DeathMessenger
{
    public class DeathMessenger : OpenModUnturnedPlugin
    {
        private readonly IConfiguration m_Configuration;
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly ILogger<DeathMessenger> m_Logger;
        private readonly IUserManager m_UserManager;

        public DeathMessenger(
            IConfiguration configuration, 
            IStringLocalizer stringLocalizer,
            ILogger<DeathMessenger> logger, 
            IUserManager userManager,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_Configuration = configuration;
            m_StringLocalizer = stringLocalizer;
            m_Logger = logger;
            m_UserManager = userManager;
        }

        protected override async UniTask OnLoadAsync()
        {
            await UniTask.SwitchToMainThread();

            PlayerLife.onPlayerDied += OnPlayerDied;
            m_Logger.LogInformation(m_StringLocalizer["PLUGIN_EVENTS:PLUGIN_START"]);

            await UniTask.SwitchToThreadPool();
        }

        protected override async UniTask OnUnloadAsync()
        {
            await UniTask.SwitchToMainThread();

            PlayerLife.onPlayerDied -= OnPlayerDied;
            m_Logger.LogInformation(m_StringLocalizer["PLUGIN_EVENTS:PLUGIN_STOP"]);
            m_Configuration.GetValue()
            await UniTask.SwitchToThreadPool();
        }
        public async void OnPlayerDied(PlayerLife victim, EDeathCause cause, ELimb limb, CSteamID killer)
        {
            await UniTask.SwitchToMainThread();
            switch (cause)
            {
                case EDeathCause.ACID:
                    if (Config.AcidMessage) Say(m_StringLocalizer["DEATH_CAUSES:DEATH_CAUSES:CAUSE_ACID", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL];
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.ANIMAL:
                    if (Config.AnimalMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ANIMAL", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.ARENA:
                    if (Config.ArenaMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ARENA", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BLEEDING:
                    if (Config.BleedingMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BLEEDING", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BONES:
                    if (Config.BonesMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BONES", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BOULDER:
                    if (Config.BoulderMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BOULDER", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BREATH:
                    if (Config.BreathMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BREATH", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BURNER:
                    if (Config.BurnerMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BURNER", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.BURNING:
                    if (Config.BurningMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BURNING", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.CHARGE:
                    if (Config.ChargeMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_CHARGE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.FOOD:
                    if (Config.FoodMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_FOOD", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.FREEZING:
                    if (Config.FreezingMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_FREEZING", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.GRENADE:
                    if (Config.GrenadeMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_GRENADE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.GUN:
                    if (Config.GunMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_GUN", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb), KillerEquip(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.INFECTION:
                    if (Config.InfectionMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_INFECTION", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.KILL:
                    if (Config.KillMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_KILL", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.LANDMINE:
                    if (Config.LandmineMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_LANDMINE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.MELEE:
                    if (Config.MeleeMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_MELEE", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb), KillerEquip(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.MISSILE:
                    if (Config.MissileMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_MISSILE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.PUNCH:
                    if (Config.PunchMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_PUNCH", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.ROADKILL:
                    if (Config.RoadkillMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ROADKILL", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SENTRY:
                    if (Config.SentryMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SENTRY", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SHRED:
                    if (Config.ShredMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SHRED", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SPARK:
                    if (Config.SparkMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SPARK", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SPIT:
                    if (Config.SpitMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SPIT", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SPLASH:
                    if (Config.SplashMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SPLASH", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.SUICIDE:
                    if (Config.SuicideMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SUICIDE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.VEHICLE:
                    if (Config.VehicleMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_VEHICLE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.WATER:
                    if (Config.WaterMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_WATER", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                case EDeathCause.ZOMBIE:
                    if (Config.ZombieMessage) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ZOMBIE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, Config.DeathIconURL);
                    if (Config.LocationMessage) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, Config.LocationIconURL);
                    break;
                default:
                    Logger.LogError("Error. Please contact nelson!");
                    break;
            }
            await UniTask.SwitchToThreadPool();
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
                if (node.type == ENodeType.DEATH_CAUSES:LOCATION)
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
