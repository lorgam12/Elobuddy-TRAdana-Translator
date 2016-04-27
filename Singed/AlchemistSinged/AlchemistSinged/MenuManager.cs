using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace AlchemistSinged
{
    internal class MenuManager
    {
        // Create Main Segments
        public static Menu AlchemistSingedMenu, ComboMenu, HarassMenu, JungleMenu, LaneClearMenu, LastHitMenu, DrawingMenu, SettingMenu;

        public static void Initialize()
        {
            // Addon Menu
            AlchemistSingedMenu = MainMenu.AddMenu("AlchemistSinged", "AlchemistSinged");
            AlchemistSingedMenu.AddGroupLabel("Alchemist Singed");

            // Combo Menu
            ComboMenu = AlchemistSingedMenu.AddSubMenu("Combo Features", "ComboFeatures");
            ComboMenu.AddGroupLabel("Combo Ayarları");
            ComboMenu.AddLabel("Büyü Ayarları:");
            ComboMenu.Add("Qcombo", new CheckBox("Kullan Q"));
            ComboMenu.Add("Wcombo", new CheckBox("Kullan W"));
            ComboMenu.Add("Ecombo", new CheckBox("Kullan E"));
            ComboMenu.Add("Rcombo", new CheckBox("Kullan R"));
            ComboMenu.AddSeparator(1);
            ComboMenu.Add("Lcombo", new Slider("Use R if Enemies in Range >= ", 3, 1, 5));

            // Harass Menu
            HarassMenu = AlchemistSingedMenu.AddSubMenu("Harass Features", "HarassFeatures");
            HarassMenu.AddGroupLabel("Dürtme Ayarları");
            HarassMenu.AddLabel("Büyü Ayarları:");
            HarassMenu.Add("Qharass", new CheckBox("Kullan Q"));

            // Jungle Menu
            JungleMenu = AlchemistSingedMenu.AddSubMenu("Jungle Features", "JungleFeatures");
            JungleMenu.AddGroupLabel("Orman Ayarları");
            JungleMenu.AddLabel("Büyü Ayarları:");
            JungleMenu.Add("Qjungle", new CheckBox("Kullan Q"));
            JungleMenu.Add("Ejungle", new CheckBox("Kullan E"));

            // LaneClear Menu
            LaneClearMenu = AlchemistSingedMenu.AddSubMenu("Lane Clear Features", "LaneClearFeatures");
            LaneClearMenu.AddGroupLabel("Lane Temizleme Ayarları");
            LaneClearMenu.AddLabel("Büyü Ayarları:");
            LaneClearMenu.Add("Qlanec", new CheckBox("Kullan Q"));
            LaneClearMenu.Add("Elanec", new CheckBox("Kullan E", false));
            LaneClearMenu.AddSeparator(1);
            LaneClearMenu.AddLabel("Lanetemizliğinde AA devredışı bırakma");
            LaneClearMenu.Add("AAdisable", new CheckBox("Devredışı AA"));

            // LastHit Menu
            LastHitMenu = AlchemistSingedMenu.AddSubMenu("Last Hit Features", "LastHitFeatures");
            LastHitMenu.AddGroupLabel("Son vuruş Ayarı");
            LastHitMenu.AddLabel("Büyü Ayarları:");
            LastHitMenu.Add("Elasthit", new CheckBox("Kullan E"));

            // Drawing Menu
            DrawingMenu = AlchemistSingedMenu.AddSubMenu("Drawing Features", "DrawingFeatures");
            DrawingMenu.AddGroupLabel("Gösterge ayarları");
            DrawingMenu.Add("Udraw", new CheckBox("Gösterge modu"));
            DrawingMenu.AddSeparator(1);
            DrawingMenu.AddLabel("Büyü Ayarları:");
            DrawingMenu.Add("Wdraw", new CheckBox("Göster W"));
            DrawingMenu.Add("Edraw", new CheckBox("Göster E"));
            DrawingMenu.AddSeparator(1);
            DrawingMenu.AddLabel("Skin Değiştirici");
            DrawingMenu.Add("Udesign", new CheckBox("Göster Skin Design"));
            DrawingMenu.Add("Sdesign", new Slider("Skin Değiştrici: ", 0, 0, 7));

            // Setting Menu
            SettingMenu = AlchemistSingedMenu.AddSubMenu("Settings", "Settings");
            SettingMenu.AddGroupLabel("Ayarlar");
            SettingMenu.AddLabel("Otomatik level");
            SettingMenu.Add("Ulevel", new CheckBox("Otomatik level"));
            SettingMenu.AddSeparator(1);
            SettingMenu.AddLabel("Zehirle kite yapma");
            SettingMenu.Add("Ukite", new CheckBox("Kite yaparken Q kullan"));
            SettingMenu.AddLabel("Otomatik yük Kasma");
            SettingMenu.Add("Ustack", new CheckBox("yük modu"));
            SettingMenu.AddSeparator(1);
            SettingMenu.AddLabel("Interrupter");
            SettingMenu.Add("Uinterrupt", new CheckBox("Interrupt Modu"));
            SettingMenu.Add("Einterrupt", new CheckBox("E Kullan İnterrupt"));
            SettingMenu.AddLabel("Gap Closer");
            SettingMenu.Add("Ugapc", new CheckBox("Gap Closer Mode"));
            SettingMenu.Add("Egapc", new CheckBox("E kullan gapclose"));
        }

        // Assign Global Checks+
        public static bool ComboUseQ { get { return ComboMenu["Qcombo"].Cast<CheckBox>().CurrentValue; } }
        public static bool ComboUseW { get { return ComboMenu["Wcombo"].Cast<CheckBox>().CurrentValue; } }
        public static bool ComboUseE { get { return ComboMenu["Ecombo"].Cast<CheckBox>().CurrentValue; } }
        public static bool ComboUseR { get { return ComboMenu["Rcombo"].Cast<CheckBox>().CurrentValue; } }
        public static int ComboRLimiter { get { return ComboMenu["Lcombo"].Cast<Slider>().CurrentValue; } }

        public static bool HarassUseQ { get { return HarassMenu["Qharass"].Cast<CheckBox>().CurrentValue; } }

        public static bool JungleUseQ { get { return JungleMenu["Qjungle"].Cast<CheckBox>().CurrentValue; } }
        public static bool JungleUseE { get { return JungleMenu["Ejungle"].Cast<CheckBox>().CurrentValue; } }
        
        public static bool LaneClearUseQ { get { return LaneClearMenu["Qlanec"].Cast<CheckBox>().CurrentValue; } }
        public static bool LaneClearUseE { get { return LaneClearMenu["Elanec"].Cast<CheckBox>().CurrentValue; } }
        public static bool LaneClearAaDisable { get { return LaneClearMenu["AAdisable"].Cast<CheckBox>().CurrentValue; } }
        
        public static bool LateGameMode { get { return LaneClearMenu["Ulategame"].Cast<CheckBox>().CurrentValue; } }
        public static int LateGameLevel { get { return LaneClearMenu["Llategame"].Cast<Slider>().CurrentValue; } }
        public static int LateGameMana { get { return LaneClearMenu["Mlategame"].Cast<Slider>().CurrentValue; } }

        public static bool LastHitUseE { get { return LastHitMenu["Elasthit"].Cast<CheckBox>().CurrentValue; } }
        
        public static bool DrawMode { get { return DrawingMenu["Udraw"].Cast<CheckBox>().CurrentValue; } }
        public static bool DrawW { get { return DrawingMenu["Wdraw"].Cast<CheckBox>().CurrentValue; } }
        public static bool DrawE { get { return DrawingMenu["Edraw"].Cast<CheckBox>().CurrentValue; } }
        public static bool DesignerMode { get { return DrawingMenu["Udesign"].Cast<CheckBox>().CurrentValue; } }
        public static int DesignerSkin { get { return DrawingMenu["Sdesign"].Cast<Slider>().CurrentValue; } }

        public static bool LevelerMode { get { return SettingMenu["Ulevel"].Cast<CheckBox>().CurrentValue; } }
        public static bool StackMode { get { return SettingMenu["Ustack"].Cast<CheckBox>().CurrentValue; } }
        public static bool KiteMode { get { return SettingMenu["Ukite"].Cast<CheckBox>().CurrentValue; } }

        public static bool InterrupterMode { get { return SettingMenu["Uinterrupt"].Cast<CheckBox>().CurrentValue; } }
        public static bool InterrupterUseE { get { return SettingMenu["Einterrupt"].Cast<CheckBox>().CurrentValue; } }
        public static bool GapCloserMode { get { return SettingMenu["Ugapc"].Cast<CheckBox>().CurrentValue; } }
        public static bool GapCloserUseE { get { return SettingMenu["Egapc"].Cast<CheckBox>().CurrentValue; } }
    }
}
