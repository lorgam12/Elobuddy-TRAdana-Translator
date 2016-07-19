using EloBuddy;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class ChanceHit
    {
        private static readonly Menu Menu;
        private static readonly Slider _ComboMinToUseQ;
        private static readonly Slider _LCMinToUseQ;
        private static readonly Slider _HarassMinToUseQ;
        private static readonly Slider _AutoHarassMinToUseQ;

        public static int ComboMinToUseQ
        {
            get { return _ComboMinToUseQ.CurrentValue; }
        }

        public static int LaneClearMinToUseQ
        {
            get { return _LCMinToUseQ.CurrentValue; }
        }

        public static int HarassMinToUseQ
        {
            get { return _HarassMinToUseQ.CurrentValue; }
        }

        public static int AutoHarassMinToUseQ
        {
            get { return _AutoHarassMinToUseQ.CurrentValue; }
        }

        public static HitChance GetHitChance(int num)
        {
            switch (num)
            {
                case 1: return HitChance.Low;
                case 2: return HitChance.Medium;
                case 3: return HitChance.High;
            }
            return HitChance.Medium;
        }

        static ChanceHit()
        {
            Menu = Config.Menu.AddSubMenu("Hit chance");
            Menu.AddGroupLabel("İsabet Oranı Ayarları");
            Menu.AddGroupLabel("[1-Dusuk / 2-Orta / 3-Yüksek]");
            _ComboMinToUseQ = Menu.Add("MinToUseQ", new Slider("Kombo için Q isabet oranı.", 2, 1, 3));
            _LCMinToUseQ = Menu.Add("LCMinToUseQ", new Slider("Laneclear için Q isabet oranı.", 1, 1, 3));
            _HarassMinToUseQ = Menu.Add("HarassMinToUseQ", new Slider("Dürtme modu için min Q isabet oranı.", 2, 1, 3));
            _AutoHarassMinToUseQ = Menu.Add("AutoHarassMinToUseQ", new Slider("Otomatik dürtme için Q isabet oranı.", 1, 1, 3));
        }

        public static void Initialize()
        {
        }
    }
}