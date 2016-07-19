using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;


namespace UBSivir
{
    class Config
    {
        public static Menu Menu;
        public static Menu ComboMenu;
        public static Menu ShieldMenu;
        public static Menu ShieldMenu2;
        public static Menu HarassMenu;
        public static Menu LaneClear;
        public static Menu JungleClear;
        public static Menu LasthitMenu;
        public static Menu MiscMenu;
        public static Menu DrawMenu;

        public static void Dattenosa()
        {
            // Menu
            Menu = MainMenu.AddMenu("UB Sivir", "UBSivir");
            Menu.AddGroupLabel("Made by Uzumaki Boruto");
            Menu.AddLabel("Dattenosa");

            //ComboMenu
            ComboMenu = Menu.AddSubMenu("Combo");
            {
                ComboMenu.AddGroupLabel("Combo Settings");
                ComboMenu.Add("useQCombo", new CheckBox("Kullan Q"));
                ComboMenu.Add("useWCombo", new CheckBox("Kullan W"));
                ComboMenu.Add("useRCombo", new CheckBox("Kullan R"));
                ComboMenu.Add("RHitCombo", new Slider("Komboda R sana ve arkadaşlarına kaç kişide kullansın", 4, 1, 4));
            }
            //Shield Menu
            ShieldMenu = Menu.AddSubMenu("ShieldMenu");
            {
                ShieldMenu.AddGroupLabel("Engelleme Ayarları");
                ShieldMenu.Add("blockSpellsE", new CheckBox("Büyüleri Otomatik Blokla (E)"));
                ShieldMenu.AddSeparator();

                ShieldMenu.AddGroupLabel("Düşman büyüleri Engelleme");
            }
            //Shield Menu2
            ShieldMenu2 = Menu.AddSubMenu("ShieldMenu2");
            {
                ShieldMenu2.AddGroupLabel("Ek Ayarları");
                ShieldMenu2.Add("BlockChalleningE", new CheckBox("Otomatik E kullan bazı büyülerden kaçmak için"));
                ShieldMenu2.AddSeparator();

                ShieldMenu2.AddGroupLabel("Düşman büyüleri Engelleme");
            }

            //HarassMenu
            HarassMenu = Menu.AddSubMenu("Harass");
            {
                HarassMenu.AddGroupLabel("Dürtme Ayarları");
                HarassMenu.Add("useQHr", new CheckBox("Kullan Q"));
                HarassMenu.Add("useQHr2", new CheckBox("Sadece minyon arkasında ise kullan Q"));
                HarassMenu.Add("useWHr", new CheckBox("Kullan W"));
                HarassMenu.Add("HrManage", new Slider("Eğer manam şundan azsa kullanma", 50));
            }

            //LaneClear Menu
            LaneClear = Menu.AddSubMenu("LaneClear");
            {
                LaneClear.AddGroupLabel("Lanetemizleme Ayarları");
                LaneClear.Add("useQLc", new CheckBox("Q Kullan", false));
                LaneClear.Add("useWLc", new CheckBox("W Kullan", false));
                LaneClear.Add("WHitLc", new Slider("W için minyon sayısı", 6, 1, 30));
                LaneClear.Add("autoWHr", new CheckBox("Otomatik W şu kadar düşmana çarpacaksa"));
                LaneClear.Add("LcManager", new Slider("Eğer manam şundan azsa kullanma", 50));
            }
            //JungleClear Menu
            JungleClear = Menu.AddSubMenu("JungleClear");
            {
                JungleClear.AddGroupLabel("Ormantemizleme Ayarları");
                JungleClear.Add("useQJc", new CheckBox("Q Kullan"));
                JungleClear.Add("useWJc", new CheckBox("W Kullan"));
                JungleClear.Add("WHitJc", new Slider("Canavar say", 2, 1, 4));
                JungleClear.Add("JcManager", new Slider("Eğer manam şundan azsa kullanma", 50));
            }

            //LasthitMenu
            LasthitMenu = Menu.AddSubMenu("Lasthit");
            {
                LasthitMenu.Add("useQLh", new CheckBox("Q Kullan"));
                LasthitMenu.Add("useWLh", new CheckBox("W Kullan"));
                LasthitMenu.Add("LhManager", new Slider("Eğer manam şundan azsa kullanma", 50));
            }

            //DrawMenu
            DrawMenu = Menu.AddSubMenu("Drawings");
            {
                DrawMenu.Add("drawQ", new CheckBox("Göster Q", false));
                DrawMenu.Add("drawR", new CheckBox("Göster R", false));
            }

            //MiscMenu          
            MiscMenu = Menu.AddSubMenu("MiscMenu");
            {
                MiscMenu.AddGroupLabel("Ek Ayarlar");
                MiscMenu.Add("useQKS", new CheckBox("Q ile çal"));
                MiscMenu.Add("AutoQ", new CheckBox("Sabit hedefe otomatik Q"));
                MiscMenu.Add("AutoW", new CheckBox("Otomatik atak Resetle"));
            }
        }
        public static bool BlockSpells
        {
            get { return ShieldMenu["blockSpellsE"].Cast<CheckBox>().CurrentValue; }
        }
    }
}
