using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace ReRyze.ConfigList
{
    public static class Combo
    {
        private static readonly Menu Menu;
        private static readonly CheckBox _ComboQ;
        private static readonly CheckBox _ComboW;
        private static readonly CheckBox _ComboE;

        private static readonly CheckBox _ComboWithoutQ;
        private static readonly CheckBox _ComboWithoutW;
        private static readonly CheckBox _ComboWithoutE;
        private static readonly Slider _ComboLogic;

        private static readonly CheckBox _SmartCombo;

        public static bool ComboQ
        {
            get { return _ComboQ.CurrentValue; }
        }
        public static bool ComboW
        {
            get { return _ComboW.CurrentValue; }
        }
        public static bool ComboE
        {
            get { return _ComboE.CurrentValue; }
        }

        public static bool ComboWithoutQ
        {
            get { return _ComboWithoutQ.CurrentValue; }
        }
        public static bool ComboWithoutW
        {
            get { return _ComboWithoutW.CurrentValue; }
        }
        public static bool ComboWithoutE
        {
            get { return _ComboWithoutE.CurrentValue; }
        }

        public static int GetComboLogic
        {
            get { return _ComboLogic.CurrentValue; }
        }
        public static bool SmartCombo
        {
            get { return _SmartCombo.CurrentValue; }
        }

        static Combo()
        {
            Menu = Config.Menu.AddSubMenu("Combo");
            Menu.AddGroupLabel("Kombo Ayarları");
            _ComboQ = Menu.Add("ComboQ", new CheckBox("Q Kullan"));
            _ComboW = Menu.Add("ComboW", new CheckBox("W Kullan"));
            _ComboE = Menu.Add("ComboE", new CheckBox("E Kullan"));

            Menu.AddGroupLabel("Static combo");
            _ComboWithoutQ = Menu.Add("ComboWithoutQ", new CheckBox("Q hazır değilse diğerlerine atlamasına izin ver."));
            _ComboWithoutW = Menu.Add("ComboWithoutW", new CheckBox("W hazır değilse diğerlerine atlamasına izin ver."));
            _ComboWithoutE = Menu.Add("ComboWithoutE", new CheckBox("E hazır değilse diğerlerine atlamasına izin ver."));
            _ComboLogic = Menu.Add("ComboLogic", new Slider("Kombo türü [QEQWQEQE] / [QEEQWQEQ]", 0, 0, 1));

            Menu.AddGroupLabel("Dinamik combo");
            _SmartCombo = Menu.Add("SmartCombo", new CheckBox("Akıllı kombo kullan."));
        }

        public static void Initialize()
        {
        }
    }
}