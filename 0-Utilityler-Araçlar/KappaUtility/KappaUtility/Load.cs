namespace KappaUtility
{
    using System;

    using EloBuddy;
    using EloBuddy.SDK;
    using EloBuddy.SDK.Events;
    using EloBuddy.SDK.Menu;

    using Common;

    using EloBuddy.SDK.Menu.Values;

    using Items;

    using Misc;

    using Summoners;

    using Trackers;

    internal class Load
    {
        protected static bool loadedreveal = false;

        protected static bool loadedtrack = false;

        public static Menu UtliMenu;

        public static void Execute()
        {
            UtliMenu = MainMenu.AddMenu("KappaUtility", "KappaUtility");
            UtliMenu.AddGroupLabel("Genel Ayarlar [Değiştirirsen F5 basman gerekir]");
            UtliMenu.Add("AutoLvlUp", new CheckBox("Aktif OtomatikLevel"));
            UtliMenu.Add("AutoQSS", new CheckBox("Aktif AutoQSS(Arınma)"));
            UtliMenu.Add("AutoTear", new CheckBox("Aktif AutoTear"));
            UtliMenu.Add("AutoReveal", new CheckBox("Aktif AutoReveal(Gizlenen görme)"));
            UtliMenu.Add("GanksDetector", new CheckBox("Aktif GanksDetector(GangUyarıcı)"));
            UtliMenu.Add("Tracker", new CheckBox("Aktif TakipEdici(Tracker)"));
            UtliMenu.Add("SkinHax", new CheckBox("Aktif SkinHilesi"));
            UtliMenu.Add("Spells", new CheckBox("Aktif SihirdarBüyüleri"));
            UtliMenu.Add("Potions", new CheckBox("Aktif İksirler"));
            UtliMenu.Add("Offensive", new CheckBox("Aktif Saldırgan İtemler"));
            UtliMenu.Add("Defensive", new CheckBox("Aktif Defansif İtemler"));
            if (UtliMenu["AutoLvlUp"].Cast<CheckBox>().CurrentValue)
            {
                AutoLvlUp.OnLoad();
            }
            if (UtliMenu["AutoQSS"].Cast<CheckBox>().CurrentValue)
            {
                AutoQSS.OnLoad();
            }
            if (UtliMenu["AutoTear"].Cast<CheckBox>().CurrentValue)
            {
                AutoTear.OnLoad();
            }
            if (UtliMenu["AutoReveal"].Cast<CheckBox>().CurrentValue)
            {
                AutoReveal.OnLoad();
                loadedreveal = true;
            }
            if (UtliMenu["GanksDetector"].Cast<CheckBox>().CurrentValue)
            {
                GanksDetector.OnLoad();
            }
            if (UtliMenu["Tracker"].Cast<CheckBox>().CurrentValue)
            {
                Tracker.OnLoad();
                Surrender.OnLoad();
                loadedtrack = true;
            }
            if (UtliMenu["SkinHax"].Cast<CheckBox>().CurrentValue)
            {
                SkinHax.OnLoad();
            }
            if (UtliMenu["Spells"].Cast<CheckBox>().CurrentValue)
            {
                Spells.OnLoad();
                Flash.FOnLoad();
            }
            if (UtliMenu["Potions"].Cast<CheckBox>().CurrentValue)
            {
                Potions.OnLoad();
            }
            if (UtliMenu["Offensive"].Cast<CheckBox>().CurrentValue)
            {
                Offensive.OnLoad();
            }
            if (UtliMenu["Defensive"].Cast<CheckBox>().CurrentValue)
            {
                Defensive.OnLoad();
            }
            
            Game.OnTick += GameOnTick;
            Drawing.OnEndScene += OnEndScene;
            Drawing.OnDraw += DrawingOnDraw;
        }

        private static void DrawingOnDraw(EventArgs args)
        {
            try
            {
                Spells.Drawings();
                GanksDetector.OnDraw();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void OnEndScene(EventArgs args)
        {
            try
            {
                if (loadedreveal)
                {
                    AutoReveal.Drawings();
                }
                if (loadedtrack)
                {
                    Traps.Draw();
                    Tracker.HPtrack();
                    Tracker.track();
                }
                GanksDetector.OnEndScene();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void GameOnTick(EventArgs args)
        {
            try
            {
                var flags = Orbwalker.ActiveModesFlags;
                if (flags.HasFlag(Orbwalker.ActiveModes.Combo))
                {
                    Offensive.Items();
                    Defensive.Items();
                }

                if (loadedreveal)
                {
                    AutoReveal.Reveal();
                }

                AutoLvlUp.Levelup();
                AutoTear.OnUpdate();
                GanksDetector.OnUpdate();
                Smite.Smiteopepi();
                Spells.Cast();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}