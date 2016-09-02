using System;
using EloBuddy.SDK.Menu;
using KappAIO.Common;
using KappAIO.Utility.Activator.Spells;

namespace KappAIO.Utility.Activator
{
    internal class Load
    {
        internal static Menu MenuIni, DamageHandler;

        public static void Init()
        {
            try
            {
                MenuIni = MainMenu.AddMenu("KappActivator", "KappActivator");
                MenuIni.CreateCheckBox("Champ", "Sadece Aktivatörü yükle", false);
                DamageHandler = MenuIni.AddSubMenu("HAsarGösterici");
                DamageHandler.CreateCheckBox("Minions", "Canavar Hasarını Tespitet", false);
                DamageHandler.CreateCheckBox("Heros", "Şampiyon Hasarını Tespitet");
                DamageHandler.CreateCheckBox("Turrets", "Kule Hasarını Tespitet");
                DamageHandler.CreateCheckBox("Minion", "Minyon hasarını Tespitet");
                DamageHandler.CreateCheckBox("Skillshots", "Büyülerin Hasarını Tespitet");
                DamageHandler.CreateCheckBox("Targetedspells", "Hedefe Giden Büyü Hasarını Tespitet");
                DamageHandler.CreateSlider("Mod", "Hasar Geliştirmesi Geliyor {0}%", 100, 0, 200);

                Items.Potions.Init();
                Cleanse.Qss.Init();
                Summoners.Init();
                Items.Offence.Init();
                Items.Defence.Init();
            }
            catch (Exception ex)
            {
                Logger.Send("Activator Load Error While Init", ex, Logger.LogLevel.Error);
            }
        }
    }
}
