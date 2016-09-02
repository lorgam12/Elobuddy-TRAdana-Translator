using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using KappAIO.Common;
using static KappAIO.Utility.Activator.Database;

namespace KappAIO.Utility.Activator.Items
{
    internal class Defence
    {
        private static Menu Def;

        public static void Init()
        {
            try
            {
                Def = Load.MenuIni.AddSubMenu("Savunma İtemleri");
                Def.CreateCheckBox("ally", "Dostlara Kullan");
                Def.AddSeparator();
                Def.CreateCheckBox(Zhonyas.Id.ToString(), "Zhanya Kullan");
                Def.CreateSlider(Zhonyas.Id + "hp", "Zhonyas için canım şundan az% {0}%", 30);
                Def.CreateCheckBox(Seraphs.Id.ToString(), "Seraph Kullan");
                Def.CreateSlider(Seraphs.Id + "hp", "Seraphs için canım% {0}%", 40);
                Def.CreateCheckBox(Solari.Id.ToString(), "Solari Kullan");
                Def.CreateSlider(Solari.Id + "hp", "Solari için canım% {0}%", 50);
                Def.CreateCheckBox(Randuins.Id.ToString(), "Randuin Kullan");
                Def.CreateSlider(Randuins.Id + "hp", "Randuins için canım% {0}%", 60);

                Events.OnIncomingDamage += Events_OnIncomingDamage;
                Game.OnTick += Game_OnTick;
            }
            catch (Exception ex)
            {
                Logger.Send("Activator Defence Error While Init", ex, Logger.LogLevel.Error);
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            try
            {
                if(Player.Instance.IsDead) return;

                if (Randuins.ItemReady(Def) && Def.CompareSlider(Randuins.Id + "hp", Player.Instance.HealthPercent) && Player.Instance.CountEnemiesInRange(Randuins.Range) > 0
                    && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                {
                    Randuins.Cast();
                }
            }
            catch (Exception ex)
            {
                Logger.Send("Activator Defence Error At Game_OnTick", ex, Logger.LogLevel.Error);
            }
        }

        private static void Events_OnIncomingDamage(Events.InComingDamageEventArgs args)
        {
            try
            {
                if (args.Target == null || args.InComingDamage < 1 || !args.Target.IsKillable())
                    return;

                if (args.Target.IsAlly && !args.Target.IsMe && Def.CheckBoxValue("ally"))
                {
                    if (Solari.ItemReady(Def) && args.Target.IsKillable(600) && Def.SliderValue(Solari.Id + "hp") >= args.Target.HealthPercent)
                    {
                        Solari.Cast();
                        return;
                    }
                }
                if (args.Target.IsMe)
                {
                    if (Zhonyas.ItemReady(Def) && Def.SliderValue(Zhonyas.Id + "hp") >= args.Target.HealthPercent)
                    {
                        Zhonyas.Cast();
                        return;
                    }
                    if (Seraphs.ItemReady(Def) && Def.SliderValue(Seraphs.Id + "hp") >= args.Target.HealthPercent)
                    {
                        Seraphs.Cast();
                        return;
                    }
                    if (Solari.ItemReady(Def) && Def.SliderValue(Solari.Id + "hp") >= args.Target.HealthPercent)
                    {
                        Solari.Cast();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Send("Activator Defence Error At Events_OnIncomingDamage", ex, Logger.LogLevel.Error);
            }
        }
    }
}
