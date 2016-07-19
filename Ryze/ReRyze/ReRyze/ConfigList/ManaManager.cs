using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class ManaManager
    {
        private static readonly Menu Menu;
        private static readonly Slider _LCUseQ; // lane clear min mana to use q
        private static readonly Slider _LCUseE;
        private static readonly Slider _LHUseQ;
        private static readonly Slider _AutoHarassUseQ;

        public static int LaneClearQ_Mana
        {
            get { return _LCUseQ.CurrentValue; }
        }
        public static int LaneClearE_Mana
        {
            get { return _LCUseE.CurrentValue; }
        }
        public static int LastHitQ_Mana
        {
            get { return _LHUseQ.CurrentValue; }
        }
        public static int AutoHarassQ_Mana
        {
            get { return _AutoHarassUseQ.CurrentValue; }
        }

        static ManaManager()
        {
            Menu = Config.Menu.AddSubMenu("Mana manager");
            Menu.AddGroupLabel("Mana yardımcısı ayarları");
            Menu.AddSeparator(15);
            Menu.AddGroupLabel("Lane / Orman Temizleme");
            _LCUseQ = Menu.Add("LCUseQ", new Slider("Q için en az mana", 50, 1, 100));
            _LCUseE = Menu.Add("LCUseW", new Slider("W  için en az mana", 50, 1, 100));

            Menu.AddGroupLabel("Son Vuruş");
            _LHUseQ = Menu.Add("LHUseQ", new Slider("Q için en az mana", 65, 1, 100));

            Menu.AddGroupLabel("Otomatik Dürtme");
            _AutoHarassUseQ = Menu.Add("AutoHarassUseQ", new Slider("Otomatik Dürtme(Q) için en az mana", 75, 1, 100));
        }

        public static void Initialize()
        {
        }
    }
}