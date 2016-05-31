using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ZyraTheTroll
{
    internal static class ZyraTheTrollMeNu
    {
        private static Menu _myMenu;
        public static Menu ComboMenu, DrawMeNu, HarassMeNu, Activator, FarmMeNu, MiscMeNu;

        public static void LoadMenu()
        {
            MyZyraTheTrollPage();
            DrawMeNuPage();
            ComboMenuPage();
            FarmMeNuPage();
            HarassMeNuPage();
            ActivatorPage();
            MiscMeNuPage();
        }

        private static void MyZyraTheTrollPage()
        {
            _myMenu = MainMenu.AddMenu("Zyra The Troll", "main");
            _myMenu.AddLabel(" Zyra The Troll " + Program.Version);
            _myMenu.AddLabel(" Made by MeLoDag");
        }

        private static void DrawMeNuPage()
        {
            DrawMeNu = _myMenu.AddSubMenu("Draw  settings", "Draw");
            DrawMeNu.AddGroupLabel("Gösterge Ayarlarý:");
            DrawMeNu.Add("nodraw",
                new CheckBox("Biþey gösterme", false));
            DrawMeNu.AddSeparator();
            DrawMeNu.Add("draw.Q",
                new CheckBox("Göster Q"));
            DrawMeNu.Add("draw.W",
                new CheckBox("Göster W"));
            DrawMeNu.Add("draw.E",
                new CheckBox("Göster E"));
            DrawMeNu.Add("draw.R",
                new CheckBox("Göster R"));
        }

        private static void ComboMenuPage()
        {
            ComboMenu = _myMenu.AddSubMenu("Combo settings", "Combo");
            ComboMenu.AddGroupLabel("Combo settings:");
            ComboMenu.Add("useQCombo", new CheckBox("Q Kullan"));
            ComboMenu.Add("useECombo", new CheckBox("E Kullan"));
            ComboMenu.Add("useWCombo", new CheckBox("W Kullan"));
            ComboMenu.Add("useRCombo", new CheckBox("R Kullan"));
            ComboMenu.Add("Rcount", new Slider("R için düþman say ", 2, 1, 5));
            ComboMenu.AddGroupLabel("Kombo özellikleri:");
            ComboMenu.Add("combo.CC",
                new CheckBox("CCde E Kullan"));
            ComboMenu.Add("combo.CCQ",
                new CheckBox("CCde Q kullan"));
        }


        private static void FarmMeNuPage()
        {
            FarmMeNu = _myMenu.AddSubMenu("Farm Settings", "FarmSettings");
            FarmMeNu.AddGroupLabel("Lanetemizleme ayarlarý");
            FarmMeNu.Add("qFarmAlways", new CheckBox("Her zaman Q Kullan"));
            FarmMeNu.Add("qFarm", new CheckBox("TÜm modlarda Q ile sonvuruþ"));
            FarmMeNu.AddLabel("Ormantemizleme ayarlarý");
            FarmMeNu.Add("useQJungle", new CheckBox("Kullan Q"));
        }

        private static void HarassMeNuPage()
        {
            HarassMeNu = _myMenu.AddSubMenu("Harass", "Harass");
            HarassMeNu.AddGroupLabel("Dürtme ayarlarý");
            HarassMeNu.Add("useQHarass", new CheckBox("Kullan Q"));
            HarassMeNu.Add("useEHarass", new CheckBox("Kullan E"));
            HarassMeNu.AddSeparator();
            HarassMeNu.AddGroupLabel("Killçalma Ayarlarý:");
            HarassMeNu.Add("ksQ",
                new CheckBox("Kullan Q", false));
                 HarassMeNu.Add("ksE",
                new CheckBox("Kullan E", false));
        }

        private static void ActivatorPage()
        {
            Activator = _myMenu.AddSubMenu("Activator Settings", "Items");
            Activator.AddLabel("Zhonyas Ayarlarý");
            Activator.Add("Zhonyas", new CheckBox("Zhonya Kullan"));
            Activator.Add("ZhonyasHp", new Slider("Benim caným þu kadarda zhonya kullan%", 20, 0, 100));
            Activator.AddSeparator();
            Activator.AddGroupLabel("Ýksir Ayarlarý");
            Activator.Add("spells.Potions.Check",
                new CheckBox("Kullan Ýksirleri"));
            Activator.Add("spells.Potions.HP",
                new Slider("Ýksirleri kullanmak için caným þundan az  {0}(%)", 60, 1));
            Activator.Add("spells.Potions.Mana",
                new Slider("Manam þundan az  {0}(%)", 60, 1));
            Activator.AddSeparator();
            Activator.AddGroupLabel("Büyü ayarlarý:");
            Activator.AddGroupLabel("Ýyileþtirme ayarlarý:");
            Activator.Add("spells.Heal.Hp",
                new Slider("Ýyileþtirme kullanmak için gereken caným {0}(%)", 30, 1));
            Activator.AddGroupLabel("Ignite settings:");
            Activator.Add("spells.Ignite.Focus",
                new Slider("Tutuþtur için gereken düþman cnaý {0}(%)", 10, 1));
        }

        private static void MiscMeNuPage()
        {
            MiscMeNu = _myMenu.AddSubMenu("Misc Menu", "othermenu");
            MiscMeNu.AddGroupLabel("Anti Gap Closer/Interrupt");
            MiscMeNu.Add("gapcloser.E",
                new CheckBox("Kullan E GapCloser"));
            MiscMeNu.Add("interupt.E",
                new CheckBox("Kullan E Interrupt"));
            MiscMeNu.AddGroupLabel("Skin Ayarlarý");
            MiscMeNu.Add("checkSkin",
                new CheckBox("Kostüm hilesi aç:", false));
            MiscMeNu.Add("skin.Id",
                new Slider("Kostüm editör", 5, 0, 10));
        }

        public static bool Nodraw()
        {
            return DrawMeNu["nodraw"].Cast<CheckBox>().CurrentValue;
        }

        public static bool DrawingsQ()
        {
            return DrawMeNu["draw.Q"].Cast<CheckBox>().CurrentValue;
        }

        public static bool DrawingsW()
        {
            return DrawMeNu["draw.W"].Cast<CheckBox>().CurrentValue;
        }

        public static bool DrawingsE()
        {
            return DrawMeNu["draw.E"].Cast<CheckBox>().CurrentValue;
        }

        public static bool DrawingsR()
        {
            return DrawMeNu["draw.R"].Cast<CheckBox>().CurrentValue;
        }

        public static bool DrawingsT()
        {
            return DrawMeNu["draw.T"].Cast<CheckBox>().CurrentValue;
        }

        public static bool SpellsPotionsCheck()
        {
            return Activator["spells.Potions.Check"].Cast<CheckBox>().CurrentValue;
        }

        public static float SpellsPotionsHp()
        {
            return Activator["spells.Potions.HP"].Cast<Slider>().CurrentValue;
        }

        public static float SpellsPotionsM()
        {
            return Activator["spells.Potions.Mana"].Cast<Slider>().CurrentValue;
        }

        public static float SpellsHealHp()
        {
            return Activator["spells.Heal.HP"].Cast<Slider>().CurrentValue;
        }

        public static float SpellsIgniteFocus()
        {
            return Activator["spells.Ignite.Focus"].Cast<Slider>().CurrentValue;
        }

        public static int SkinId()
        {
            return MiscMeNu["skin.Id"].Cast<Slider>().CurrentValue;
        }


        public static bool SkinChanger()
        {
            return MiscMeNu["SkinChanger"].Cast<CheckBox>().CurrentValue;
        }

        public static bool CheckSkin()
        {
            return MiscMeNu["checkSkin"].Cast<CheckBox>().CurrentValue;
        }
    }
}