namespace KappaUtility.Items
{
    using EloBuddy;
    using EloBuddy.SDK;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK.Menu.Values;

    internal class Defensive
    {
        public static readonly Item Zhonyas = new Item(ItemId.Zhonyas_Hourglass);

        public static readonly Item Seraph = new Item(ItemId.Seraphs_Embrace);

        public static readonly Item FOTM = new Item(ItemId.Face_of_the_Mountain);

        public static readonly Item Solari = new Item(ItemId.Locket_of_the_Iron_Solari);

        public static readonly Item Randuin = new Item(ItemId.Randuins_Omen, 500f);

        public static int Seraphh => DefMenu["Seraphh"].Cast<Slider>().CurrentValue;

        public static int Solarih => DefMenu["Solarih"].Cast<Slider>().CurrentValue;

        public static int FaceOfTheMountainh => DefMenu["FaceOfTheMountainh"].Cast<Slider>().CurrentValue;

        public static int Zhonyash => DefMenu["Zhonyash"].Cast<Slider>().CurrentValue;

        public static int Seraphn => DefMenu["Seraphn"].Cast<Slider>().CurrentValue;

        public static int Solarin => DefMenu["Solarin"].Cast<Slider>().CurrentValue;

        public static int FaceOfTheMountainn => DefMenu["FaceOfTheMountainn"].Cast<Slider>().CurrentValue;

        public static int Zhonyasn => DefMenu["Zhonyasn"].Cast<Slider>().CurrentValue;

        public static bool Seraphc => DefMenu["Seraph"].Cast<CheckBox>().CurrentValue && Seraph.IsOwned() && Seraph.IsReady();

        public static bool Solaric => DefMenu["Solari"].Cast<CheckBox>().CurrentValue && Solari.IsOwned() && Solari.IsReady();

        public static bool FaceOfTheMountainc => DefMenu["FaceOfTheMountain"].Cast<CheckBox>().CurrentValue && FOTM.IsOwned() && FOTM.IsReady();

        public static bool Zhonyasc => DefMenu["Zhonyas"].Cast<CheckBox>().CurrentValue && Zhonyas.IsOwned() && Zhonyas.IsReady();

        public static Menu DefMenu { get; private set; }

        protected static bool loaded = false;

        internal static void OnLoad()
        {
            DefMenu = Load.UtliMenu.AddSubMenu("Defence Items");
            DefMenu.AddGroupLabel("Savunma Ayarları");
            DefMenu.Add("Zhonyas", new CheckBox("Kullan Zhonyas", false));
            DefMenu.Add("Zhonyash", new Slider("Kullan Zhonyas canım şundan az [{0}%]", 35));
            DefMenu.Add("Zhonyasn", new Slider("Kullan Zhonyas eğer daha fazla zarar geliyorsa [{0}%]", 50));
            DefMenu.AddSeparator();
            DefMenu.Add("Seraph", new CheckBox("Kullan Seraph", false));
            DefMenu.Add("Seraphh", new Slider("Kullan Seraph Canım şundan az [{0}%]", 45));
            DefMenu.Add("Seraphn", new Slider("Kullan Seraph eğer daha fazla zarar geliyorsa [{0}%]", 45));
            DefMenu.AddSeparator();
            DefMenu.Add("FaceOfTheMountain", new CheckBox("Kullan Dağın Sureti", false));
            DefMenu.Add("FaceOfTheMountainh", new Slider("Kullan Dağın sureti için canım şundan az [{0}%]", 50));
            DefMenu.Add("FaceOfTheMountainn", new Slider("Kullan Dağın eğer daha fazla zarar geliyorsa [{0}%]", 50));
            DefMenu.AddSeparator();
            DefMenu.Add("Solari", new CheckBox("Kullan Solari", false));
            DefMenu.Add("Solarih", new Slider("Kullan Solari can şundan azsa [{0}%]", 30));
            DefMenu.Add("Solarin", new Slider("Kullan Solari eğer canımı şundan aşağı düşürecek hasar geliyorsa [{0}%]", 35));
            DefMenu.AddSeparator();
            DefMenu.Add("Randuin", new CheckBox("Kullan Randuin", false));
            DefMenu.Add("Randuinh", new Slider("Kullan Randuin şu kadar düşmanda", 2, 1, 5));
            DefMenu.AddSeparator();
            DefMenu.AddGroupLabel("Zhonya tehlike seviyesi");
            DefMenu.Add("ZhonyasD", new CheckBox("Tehlikeli büyülerde kullanma", false));
            Common.DamageHandler.OnLoad();
            Zhonya.OnLoad();
            loaded = true;
        }

        internal static void Items()
        {
            if (!loaded)
            {
                return;
            }

            if (Randuin.IsReady() && Randuin.IsOwned(Player.Instance)
                && Player.Instance.CountEnemiesInRange(Randuin.Range) >= DefMenu["Randuinh"].Cast<Slider>().CurrentValue
                && DefMenu["Randuin"].Cast<CheckBox>().CurrentValue)
            {
                Randuin.Cast();
            }
        }
    }
}