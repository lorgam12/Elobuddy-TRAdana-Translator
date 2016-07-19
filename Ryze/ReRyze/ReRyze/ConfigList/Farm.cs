using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class Farm
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _FarmQ;
        private static readonly CheckBox _FarmQLastHit;
        private static readonly CheckBox _FarmE;
        private static readonly Slider _FarmECount;
        private static readonly CheckBox _IgnoreECountJng;

        public static bool FarmQ
        {
            get { return _FarmQ.CurrentValue; }
        }
        public static bool FarmQLastHit
        {
            get { return _FarmQLastHit.CurrentValue; }
        }
        public static bool FarmE
        {
            get { return _FarmE.CurrentValue; }
        }
        public static int FarmECount
        {
            get { return _FarmECount.CurrentValue; }
        }
        public static bool FarmEIgnore
        {
            get { return _IgnoreECountJng.CurrentValue; }
        }

        static Farm()
        {
            Menu = Config.Menu.AddSubMenu("Farm");
            Menu.AddGroupLabel("Farm Ayarları");
            _FarmQ = Menu.Add("FarmQ", new CheckBox("Q Kullan."));
            _FarmE = Menu.Add("FarmE", new CheckBox("E Kullan."));
            Menu.AddSeparator();
            _IgnoreECountJng = Menu.Add("IgnoreECountJng", new CheckBox("E kullanmak için orman canavarı(mob) sayısını umursama."));
            _FarmECount = Menu.Add("FarmECount", new Slider("E kullanmak için gereken mob sayısı", 2, 1, 5));
            Menu.AddGroupLabel("Son Vuruş");
            _FarmQLastHit = Menu.Add("FarmQLastHit", new CheckBox("Son vuruş için Q Kullan."));
        }

        public static void Initialize()
        {
        }
    }
}