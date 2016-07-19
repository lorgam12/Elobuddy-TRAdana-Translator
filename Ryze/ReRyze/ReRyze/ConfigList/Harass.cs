using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class Harass
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _HarassWithQ;
        private static readonly CheckBox _AutoHarassWithQ;
        private static readonly Slider _AutoHarassChance;
        private static readonly CheckBox _AutoHarassUnderTurret;

        public static bool HarassWithQ
        {
            get { return _HarassWithQ.CurrentValue; }
        }

        public static bool AutoHarassWithQ
        {
            get { return _AutoHarassWithQ.CurrentValue; }
        }
        public static int AutoHarassChance
        {
            get { return _AutoHarassChance.CurrentValue; }
        }
        public static bool AutoHarassUnderTurret
        {
            get { return _AutoHarassUnderTurret.CurrentValue; }
        }

        static Harass()
        {
            Menu = Config.Menu.AddSubMenu("Harass");
            Menu.AddGroupLabel("Dürtme Ayarları");
            _HarassWithQ = Menu.Add("HarasWithQ", new CheckBox("Dürtme modunda Otomatik Q Kullan."));
            Menu.AddGroupLabel("Otomatik Dürtme Ayarları");
            _AutoHarassWithQ = Menu.Add("AutoHarassWithQ", new CheckBox("Q ile Otomatik Dürt."));
            _AutoHarassChance = Menu.Add("AutoHarassChance", new Slider("Otomatik Dürtme İsabet oranı.", 50, 1, 100));
            _AutoHarassUnderTurret = Menu.Add("AutoHarassUnderTurret", new CheckBox("Düşman kule altında otomatik Dürtmeye izin ver.", false));
        }

        public static void Initialize()
        {
        }
    }
}