using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace RyzePro
{
    class Menu
    {
        public static EloBuddy.SDK.Menu.Menu MaiinMenu, ComboMenu, LaneClearMenu, JungleClearMenu, HarassMenu, LastHitMenu, DrawMenu, HumanizerMenu;
        public static void Init()
        {
            MaiinMenu = MainMenu.AddMenu("RyzePro", "RyzePro");
            MaiinMenu.AddGroupLabel("Ryze Pro Loaded..");
            MaiinMenu.AddLabel("Rexy Tarafından kodlanmıştır");
            MaiinMenu.AddLabel("Eğer hata alırsanız lütfen discorddan yapımcıya bildirin");
            

            ComboMenu = MaiinMenu.AddSubMenu("Combo");
            ComboMenu.Add("combo.useQ", new CheckBox("Kullan Q"));
            ComboMenu.Add("combo.useW", new CheckBox("Kullan W"));
            ComboMenu.Add("combo.useE", new CheckBox("Kullan E"));
            ComboMenu.Add("combo.useR", new CheckBox("Hedefe giderken R Kullan"));
            ComboMenu.Add("combo.aa", new CheckBox("Komboda AA yapma"));
            ComboMenu.Add("combo.gapcloser", new CheckBox("Otomatik GapCloser Düşman"));

            HarassMenu = MaiinMenu.AddSubMenu("Harass");
            HarassMenu.Add("harass.useQ", new CheckBox("Kullan Q"));
            HarassMenu.Add("harass.useW", new CheckBox("Kullan W"));
            HarassMenu.Add("harass.useE", new CheckBox("Kullan E"));
            HarassMenu.Add("harass.mana", new Slider("Min % Mana", 15));

            LaneClearMenu = MaiinMenu.AddSubMenu("LaneClear");
            LaneClearMenu.Add("laneclear.useQ", new CheckBox("Kullan Q"));
            LaneClearMenu.Add("laneclear.useW", new CheckBox("Kullan W"));
            LaneClearMenu.Add("laneclear.useE", new CheckBox("Kullan E"));
            LaneClearMenu.Add("laneclear.useR", new CheckBox("Kullan R"));
            LaneClearMenu.Add("laneclear.mana", new Slider("Min % Mana", 15));

            JungleClearMenu = MaiinMenu.AddSubMenu("JungleClear");
            JungleClearMenu.Add("jungleclear.useQ", new CheckBox("Kullan Q"));
            JungleClearMenu.Add("jungleclear.useW", new CheckBox("Kullan W"));
            JungleClearMenu.Add("jungleclear.useE", new CheckBox("Kullan E"));
            JungleClearMenu.Add("jungleclear.useR", new CheckBox("Kullan R"));
            JungleClearMenu.Add("jungleclear.mana", new Slider("Min % Mana", 15));

            LastHitMenu = MaiinMenu.AddSubMenu("LastHit");
            LastHitMenu.Add("lasthit.useQ", new CheckBox("Kullan Q"));

            DrawMenu = MaiinMenu.AddSubMenu("Draw Settings");
            DrawMenu.Add("draw.no", new CheckBox("No Drawings"));
            DrawMenu.Add("draw.Q", new CheckBox("Göster Q Menzili"));
            DrawMenu.Add("draw.W", new CheckBox("Göster W Menzili"));
            DrawMenu.Add("draw.E", new CheckBox("Göster E Menzili"));

            HumanizerMenu = MaiinMenu.AddSubMenu("Humanizer");
            HumanizerMenu.Add("humanizer.active", new CheckBox("İnsancıl ayar Aktif", false));
            HumanizerMenu.Add("humanizer.mindelay", new Slider("En az Gecikme", 150, 0, 1000));
            HumanizerMenu.Add("humanizer.maxdelay", new Slider("En çok Gecikme", 250, 0, 1000));
        }
    }
}
