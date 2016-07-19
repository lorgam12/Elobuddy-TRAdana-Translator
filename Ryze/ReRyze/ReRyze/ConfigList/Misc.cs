using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class Misc
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _KSWithQ;
        private static readonly CheckBox _KSWithW;
        private static readonly CheckBox _KSWithE;

        private static readonly CheckBox _FleeWithEWQ;

        private static readonly CheckBox _SkinManagerStatus;
        private static readonly Slider _SkinManager;
        private static readonly Slider _Delay;
        private static readonly Slider _MaxRandomDelay;

        public static bool KSWithQ
        {
            get { return _KSWithQ.CurrentValue; }
        }
        public static bool KSWithW
        {
            get { return _KSWithW.CurrentValue; }
        }
        public static bool KSWithE
        {
            get { return _KSWithE.CurrentValue; }
        }
        public static bool FleeWithEWQ
        {
            get { return _FleeWithEWQ.CurrentValue; }
        }
        public static bool GetSkinManagerStatus
        {
            get { return _SkinManagerStatus.CurrentValue; }
        }
        public static int GetSkinManager
        {
            get { return _SkinManager.CurrentValue; }
        }
        public static int GetSpellDelay
        {
            get { return _Delay.CurrentValue; }
        }
        public static int GetMaxAditDelay
        {
            get { return _MaxRandomDelay.CurrentValue; }
        }

        static Misc()
        {
            Menu = Config.Menu.AddSubMenu("Misc");
            Menu.AddGroupLabel("Ek ayarlar");
            _KSWithQ = Menu.Add("KSWithQ", new CheckBox("Q ile killçal."));
            _KSWithW = Menu.Add("KSWithW", new CheckBox("W ile killçal."));
            _KSWithE = Menu.Add("KSWithE", new CheckBox("E ile killçal."));
            _FleeWithEWQ = Menu.Add("FleeWithEWQ", new CheckBox("Kaçış(Flee)Mounda EWQ kullan."));

            Menu.AddGroupLabel("Kostüm Yardımcısı");
            _SkinManagerStatus = Menu.Add("SkinManagerStatus", new CheckBox("Kostüm değiştirici kullan."));
            _SkinManager = Menu.Add("SkinManager", new Slider("Kostüm seç.", 1, 0, 10));

            Menu.AddGroupLabel("İnsancıl Ayarlama");
            _Delay = Menu.Add("Delay", new Slider("Büyüler arası gecikme ayarla (ms).", 150, 100, 500));
            _MaxRandomDelay = Menu.Add("MaxRandomDelay", new Slider("Karışık Gecikme Kullan (ms).", 75, 50, 100));
        }

        public static void Initialize()
        {
        }
    }
}