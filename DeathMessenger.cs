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
using Math = System.Math;

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

            await UniTask.SwitchToThreadPool();
        }
        public async void OnPlayerDied(PlayerLife victim, EDeathCause cause, ELimb limb, CSteamID killer)
        {
            await UniTask.SwitchToMainThread();
            Color.
            switch (cause)
            {
                case EDeathCause.ACID:
                    if (m_Configuration.GetSection("Death_Causes:AcidMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:DEATH_CAUSES:CAUSE_ACID", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL];
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.ANIMAL:
                    if (m_Configuration.GetSection("Death_Causes:AnimalMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ANIMAL", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.ARENA:
                    if (m_Configuration.GetSection("Death_Causes:ArenaMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ARENA", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.BLEEDING:
                    if (m_Configuration.GetSection("Death_Causes:BleedingMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BLEEDING", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.BONES:
                    if (m_Configuration.GetSection("Death_Causes:BonesMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BONES", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.BOULDER:
                    if (m_Configuration.GetSection("Death_Causes:BoulderMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BOULDER", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.BREATH:
                    if (m_Configuration.GetSection("Death_Causes:BreathMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BREATH", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.BURNER:
                    if (m_Configuration.GetSection("Death_Causes:BurnerMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BURNER", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.BURNING:
                    if (m_Configuration.GetSection("Death_Causes:BurningMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BURNING", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.CHARGE:
                    if (m_Configuration.GetSection("Death_Causes:ChargeMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_CHARGE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.FOOD:
                    if (m_Configuration.GetSection("Death_Causes:FoodMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_FOOD", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.FREEZING:
                    if (m_Configuration.GetSection("Death_Causes:FreezingMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_FREEZING", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.GRENADE:
                    if (m_Configuration.GetSection("Death_Causes:GrenadeMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_GRENADE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.GUN:
                    if (m_Configuration.GetSection("Death_Causes:GunMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_GUN", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb), KillerEquip(killer), KillerDistance(victim.player, killer)), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.INFECTION:
                    if (m_Configuration.GetSection("Death_Causes:InfectionMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_INFECTION", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.KILL:
                    if (m_Configuration.GetSection("Death_Causes:KillMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_KILL", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.LANDMINE:
                    if (m_Configuration.GetSection("Death_Causes:LandmineMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_LANDMINE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.MELEE:
                    if (m_Configuration.GetSection("Death_Causes:MeleeMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_MELEE", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb), KillerEquip(killer), KillerDistance(victim.player, killer)), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.MISSILE:
                    if (m_Configuration.GetSection("Death_Causes:MissileMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_MISSILE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.PUNCH:
                    if (m_Configuration.GetSection("Death_Causes:PunchMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_PUNCH", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb)), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.ROADKILL:
                    if (m_Configuration.GetSection("Death_Causes:RoadkillMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ROADKILL", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer)), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.SENTRY:
                    if (m_Configuration.GetSection("Death_Causes:SentryMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SENTRY", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.SHRED:
                    if (m_Configuration.GetSection("Death_Causes:ShredMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SHRED", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.SPARK:
                    if (m_Configuration.GetSection("Death_Causes:SparkMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SPARK", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.SPIT:
                    if (m_Configuration.GetSection("Death_Causes:SpitMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SPIT", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.SPLASH:
                    if (m_Configuration.GetSection("Death_Causes:SplashMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SPLASH", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.SUICIDE:
                    if (m_Configuration.GetSection("Death_Causes:SuicideMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SUICIDE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.VEHICLE:
                    if (m_Configuration.GetSection("Death_Causes:VehicleMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_VEHICLE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.WATER:
                    if (m_Configuration.GetSection("Death_Causes:WaterMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_WATER", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
                    break;
                case EDeathCause.ZOMBIE:
                    if (m_Configuration.GetSection("Death_Causes:ZombieMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ZOMBIE", victim.player.channel.owner.playerID.characterName), DeathMsgColor, m_Configuration.GetSection("Death_Causes:DeathIconURL);
                    if (m_Configuration.GetSection("Location:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)), LocationMsgColor, m_Configuration.GetSection("Death_Causes:LocationIconURL);
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
            var tempDistance = float.MaxValue;
            var info = Level.info;
            var local = info?.getLocalization();
            for (var i = 0; i < LevelNodes.nodes.Count; i++)
            {
                var node = LevelNodes.nodes[i];
                if (node.type == ENodeType.LOCATION)
                {
                    var locationNode = node as LocationNode;
                    var distance = Vector3.Distance(locationNode.point, victim.transform.position);
                    if (distance < tempDistance)
                    {
                        //tempLocation = locationNode.point;
                        tempDistance = distance;
                        var text = locationNode?.name;
                        if (!string.IsNullOrEmpty(text))
                        {
                            var key = text.Replace(' ', '_');
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
            var words = text.Split(' ');
            var lines = new List<string>();
            var currentLine = "";
            var maxLength = 250;
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
            var toPlayer = PlayerTool.getSteamPlayer(CSteamID);
            foreach (var m in WrapMessage(message))
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
            foreach (var m in WrapMessage(message))
            {
                ChatManager.serverSendMessage(m, color, fromPlayer: null, toPlayer: null, mode: EChatMode.GLOBAL, iconURL: imageURL, useRichTextFormatting: true);
            }
        }
    }
}
