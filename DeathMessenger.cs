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
using System.Linq;

[assembly: PluginMetadata("Tortellio.DeathMessenger", Author = "Tortellio", DisplayName = "DeathMessenger", 
    Website = "https://github.com/Tortellio/DeathMessenger/")]
namespace DeathMessenger
{
    public class DeathMessenger : OpenModUnturnedPlugin
    {
        private readonly IConfiguration m_Configuration;
        private readonly IStringLocalizer m_StringLocalizer;
        private readonly ILogger<DeathMessenger> m_Logger;
        public Color DeathMsgColor;
        public Color LocationMsgColor;
        public DeathMessenger(
            IConfiguration configuration, 
            IStringLocalizer stringLocalizer,
            ILogger<DeathMessenger> logger,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_Configuration = configuration;
            m_StringLocalizer = stringLocalizer;
            m_Logger = logger;
        }

        protected override async UniTask OnLoadAsync()
        {
            await UniTask.SwitchToMainThread();

            PlayerLife.onPlayerDied += OnPlayerDied;
            DeathMsgColor = GetColorFromName(m_Configuration["Colors:DeathColor"], Color.green);
            LocationMsgColor = GetColorFromName(m_Configuration["Colors:LocationColor"], Color.green);

            await UniTask.SwitchToThreadPool();

            m_Logger.LogInformation("DeathMessenger by Tortellio has been loaded.");
        }

        protected override async UniTask OnUnloadAsync()
        {
            await UniTask.SwitchToMainThread();

            PlayerLife.onPlayerDied -= OnPlayerDied;

            await UniTask.SwitchToThreadPool();

            m_Logger.LogInformation("DeathMessenger by Tortellio has been unloaded.");
        }
        public async void OnPlayerDied(PlayerLife victim, EDeathCause cause, ELimb limb, CSteamID killer)
        {
            await UniTask.SwitchToMainThread();

            switch (cause)
            {
                case EDeathCause.ACID:
                    if (m_Configuration.GetSection("Messages:AcidMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:DEATH_CAUSES:CAUSE_ACID", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.ANIMAL:
                    if (m_Configuration.GetSection("Messages:AnimalMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ANIMAL", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.ARENA:
                    if (m_Configuration.GetSection("Messages:ArenaMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ARENA", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.BLEEDING:
                    if (m_Configuration.GetSection("Messages:BleedingMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BLEEDING", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.BONES:
                    if (m_Configuration.GetSection("Messages:BonesMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BONES", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.BOULDER:
                    if (m_Configuration.GetSection("Messages:BoulderMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BOULDER", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.BREATH:
                    if (m_Configuration.GetSection("Messages:BreathMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BREATH", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.BURNER:
                    if (m_Configuration.GetSection("Messages:BurnerMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BURNER", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.BURNING:
                    if (m_Configuration.GetSection("Messages:BurningMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_BURNING", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.CHARGE:
                    if (m_Configuration.GetSection("Messages:ChargeMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_CHARGE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.FOOD:
                    if (m_Configuration.GetSection("Messages:FoodMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_FOOD", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.FREEZING:
                    if (m_Configuration.GetSection("Messages:FreezingMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_FREEZING", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.GRENADE:
                    if (m_Configuration.GetSection("Messages:GrenadeMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_GRENADE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.GUN:
                    if (m_Configuration.GetSection("Messages:GunMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_GUN", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb), KillerEquip(killer), KillerDistance(victim.player, killer)], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.INFECTION:
                    if (m_Configuration.GetSection("Messages:InfectionMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_INFECTION", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.KILL:
                    if (m_Configuration.GetSection("Messages:KillMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_KILL", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.LANDMINE:
                    if (m_Configuration.GetSection("Messages:LandmineMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_LANDMINE", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.MELEE:
                    if (m_Configuration.GetSection("Messages:MeleeMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_MELEE", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb), KillerEquip(killer), KillerDistance(victim.player, killer)], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.MISSILE:
                    if (m_Configuration.GetSection("Messages:MissileMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_MISSILE", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.PUNCH:
                    if (m_Configuration.GetSection("Messages:PunchMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_PUNCH", KillerName(killer), KillerHealth(killer), victim.player.channel.owner.playerID.characterName, VictimLimb(limb)], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.ROADKILL:
                    if (m_Configuration.GetSection("Messages:RoadkillMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ROADKILL", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer)], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.SENTRY:
                    if (m_Configuration.GetSection("Messages:SentryMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SENTRY", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.SHRED:
                    if (m_Configuration.GetSection("Messages:ShredMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SHRED", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.SPARK:
                    if (m_Configuration.GetSection("Messages:SparkMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SPARK", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.SPIT:
                    if (m_Configuration.GetSection("Messages:SpitMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SPIT", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.SPLASH:
                    if (m_Configuration.GetSection("Messages:SplashMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SPLASH", victim.player.channel.owner.playerID.characterName, KillerName(killer), KillerHealth(killer), KillerDistance(victim.player, killer)], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.SUICIDE:
                    if (m_Configuration.GetSection("Messages:SuicideMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_SUICIDE", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.VEHICLE:
                    if (m_Configuration.GetSection("Messages:VehicleMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_VEHICLE", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.WATER:
                    if (m_Configuration.GetSection("Messages:WaterMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_WATER", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                case EDeathCause.ZOMBIE:
                    if (m_Configuration.GetSection("Messages:ZombieMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:CAUSE_ZOMBIE", victim.player.channel.owner.playerID.characterName], DeathMsgColor, m_Configuration["Icons:DeathIconURL"]);
                    if (m_Configuration.GetSection("Messages:LocationMessage").Get<bool>()) Say(m_StringLocalizer["DEATH_CAUSES:LOCATION", victim.player.channel.owner.playerID.characterName, VictimLocation(victim.player)], LocationMsgColor, m_Configuration["Icons:LocationIconURL"]);
                    break;
                default:
                    m_Logger.LogError(m_StringLocalizer["PLUGIN_EVENTS:ERROR"]);
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
            var node = LevelNodes.nodes.OfType<LocationNode>().OrderBy(k => Vector3.Distance(k.point, victim.transform.position)).FirstOrDefault();
            return node.name;
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
        public void Say(string message, Color color, string imageURL)
        {
            foreach (var m in WrapMessage(message))
            {
                ChatManager.serverSendMessage(m, color, fromPlayer: null, toPlayer: null, mode: EChatMode.GLOBAL, iconURL: imageURL, useRichTextFormatting: true);
            }
        }
        public Color GetColorFromName(string colorName, Color fallback)
        {
            switch (colorName.Trim().ToLower())
            {
                case "black": return Color.black;
                case "blue": return Color.blue;
                case "clear": return Color.clear;
                case "cyan": return Color.cyan;
                case "gray": return Color.gray;
                case "green": return Color.green;
                case "grey": return Color.grey;
                case "magenta": return Color.magenta;
                case "red": return Color.red;
                case "white": return Color.white;
                case "yellow": return Color.yellow;
                case "rocket": return GetColorFromRGB(90, 206, 205);
            }

            Color? color = GetColorFromHex(colorName);
            if (color.HasValue) return color.Value;

            return fallback;
        }
        public Color? GetColorFromHex(string hexString)
        {
            hexString = hexString.Replace("#", "");
            if (hexString.Length == 3)
            { // #99f
                hexString = hexString.Insert(1, System.Convert.ToString(hexString[0])); // #999f
                hexString = hexString.Insert(3, System.Convert.ToString(hexString[2])); // #9999f
                hexString = hexString.Insert(5, System.Convert.ToString(hexString[4])); // #9999ff
            }
            int argb;
            if (hexString.Length != 6 || !Int32.TryParse(hexString, System.Globalization.NumberStyles.HexNumber, null, out argb))
            {
                return null;
            }
            byte r = (byte)((argb >> 16) & 0xff);
            byte g = (byte)((argb >> 8) & 0xff);
            byte b = (byte)(argb & 0xff);
            return GetColorFromRGB(r, g, b);
        }
        public Color GetColorFromRGB(byte R, byte G, byte B)
        {
            return GetColorFromRGB(R, G, B, 100);
        }
        public Color GetColorFromRGB(byte R, byte G, byte B, short A)
        {
            return new Color((1f / 255f) * R, (1f / 255f) * G, (1f / 255f) * B, (1f / 100f) * A);
        }
    }
}
