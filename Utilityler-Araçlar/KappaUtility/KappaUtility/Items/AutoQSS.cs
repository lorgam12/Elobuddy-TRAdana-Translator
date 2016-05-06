namespace KappaUtility.Items
{
    using System.Linq;

    using EloBuddy;
    using EloBuddy.SDK;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK.Menu.Values;

    internal class AutoQSS
    {
        public static Spell.Active Cleanse;

        protected static readonly Item Mercurial_Scimitar = new Item(ItemId.Mercurial_Scimitar);

        protected static readonly Item Quicksilver_Sash = new Item(ItemId.Quicksilver_Sash);

        public static readonly Item Dervish_Blade = new Item(ItemId.Dervish_Blade);

        protected static bool loaded = false;

        public static Menu QssMenu { get; private set; }

        internal static void OnLoad()
        {
            QssMenu = Load.UtliMenu.AddSubMenu("AutoQSS");
            QssMenu.AddGroupLabel("AutoQSS Ayarları");
            QssMenu.Add("enable", new CheckBox("Aktif", false));
            QssMenu.Add("Mercurial", new CheckBox("Cıva Yatağan Kullan", false));
            QssMenu.Add("Quicksilver", new CheckBox("Kullan Cıvalı Kuşak", false));
            if (Player.Spells.FirstOrDefault(o => o.SData.Name.Contains("SummonerBoost")) != null)
            {
                QssMenu.Add("Cleanse", new CheckBox("Arındırma aktif", false));
                Cleanse = new Spell.Active(Player.Instance.GetSpellSlotFromName("SummonerBoost"));
            }

            QssMenu.AddSeparator();
            QssMenu.AddGroupLabel("Şu durumlardan kurtar:");
            QssMenu.Add("blind", new CheckBox("Körse?", false));
            QssMenu.Add("charm", new CheckBox("Çekciliğe bürünmüşse(ahri)?", false));
            QssMenu.Add("disarm", new CheckBox("Etkisizhale gelmişse?", false));
            QssMenu.Add("fear", new CheckBox("Korkmuşsa?", false));
            QssMenu.Add("frenzy", new CheckBox("Donmuşsa?", false));
            QssMenu.Add("silence", new CheckBox("Susturulmuşsa?", false));
            QssMenu.Add("snare", new CheckBox("Tuzağa Düşmüşse?", false));
            QssMenu.Add("sleep", new CheckBox("Uyutulmuşsa?", false));
            QssMenu.Add("stun", new CheckBox("Sabitlenmişse?", false));
            QssMenu.Add("supperss", new CheckBox("Supperss?", false));
            QssMenu.Add("slow", new CheckBox("Yavaşlatılmışsa?", false));
            QssMenu.Add("knockup", new CheckBox("Havaya Kaldırılmışsa?", false));
            QssMenu.Add("knockback", new CheckBox("Use On Knock Backs?", false));
            QssMenu.Add("nearsight", new CheckBox("Yakındaysa(tehlike durumunda)?", false));
            QssMenu.Add("root", new CheckBox("Use On Roots?", false));
            QssMenu.Add("tunt", new CheckBox("Alay Ediliyorsa?", false));
            QssMenu.Add("poly", new CheckBox("Use On Polymorph?", false));
            QssMenu.Add("poison", new CheckBox("Zehirlenmişse?", false));

            QssMenu.AddSeparator();
            QssMenu.AddGroupLabel("Ults Ayarları:");
            QssMenu.Add("liss", new CheckBox("Lissandra Ult?", false));
            QssMenu.Add("naut", new CheckBox("Nautilus Ult?", false));
            QssMenu.Add("zed", new CheckBox("Zed Ult?", false));
            QssMenu.Add("vlad", new CheckBox("Vlad Ult?", false));
            QssMenu.Add("fizz", new CheckBox("Fizz Ult?", false));
            QssMenu.Add("fiora", new CheckBox("Fiora Ult?", false));
            QssMenu.AddSeparator();
            QssMenu.Add("hp", new Slider("Sadece canım şunun altında ise %", 25, 0, 100));
            QssMenu.Add("human", new Slider("İnsancıl Gecikme", 150, 0, 1500));
            QssMenu.Add("Rene", new Slider("Daire Ykaınındaki düşmanlar", 1, 0, 5));
            QssMenu.Add("enemydetect", new Slider("Düşmanları tespit etme mesafesi", 1000, 0, 2000));
            loaded = true;

            Obj_AI_Base.OnBuffGain += OnBuffGain;
        }

        private static void OnBuffGain(Obj_AI_Base sender, Obj_AI_BaseBuffGainEventArgs args)
        {
            if (!loaded)
            {
                return;
            }

            if (QssMenu["enable"].Cast<CheckBox>().CurrentValue)
            {
                if (sender.IsMe)
                {
                    var debuff = (QssMenu["charm"].Cast<CheckBox>().CurrentValue
                                  && (args.Buff.Type == BuffType.Charm || Player.Instance.HasBuffOfType(BuffType.Charm)))
                                 || (QssMenu["tunt"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Taunt || Player.Instance.HasBuffOfType(BuffType.Taunt)))
                                 || (QssMenu["stun"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Stun || Player.Instance.HasBuffOfType(BuffType.Stun)))
                                 || (QssMenu["fear"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Fear || Player.Instance.HasBuffOfType(BuffType.Fear)))
                                 || (QssMenu["silence"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Silence || Player.Instance.HasBuffOfType(BuffType.Silence)))
                                 || (QssMenu["snare"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Snare || Player.Instance.HasBuffOfType(BuffType.Snare)))
                                 || (QssMenu["supperss"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Suppression || Player.Instance.HasBuffOfType(BuffType.Suppression)))
                                 || (QssMenu["sleep"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Sleep || Player.Instance.HasBuffOfType(BuffType.Sleep)))
                                 || (QssMenu["poly"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Polymorph || Player.Instance.HasBuffOfType(BuffType.Polymorph)))
                                 || (QssMenu["frenzy"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Frenzy || Player.Instance.HasBuffOfType(BuffType.Frenzy)))
                                 || (QssMenu["disarm"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Disarm || Player.Instance.HasBuffOfType(BuffType.Disarm)))
                                 || (QssMenu["nearsight"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.NearSight || Player.Instance.HasBuffOfType(BuffType.NearSight)))
                                 || (QssMenu["knockback"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Knockback || Player.Instance.HasBuffOfType(BuffType.Knockback)))
                                 || (QssMenu["knockup"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Knockup || Player.Instance.HasBuffOfType(BuffType.Knockup)))
                                 || (QssMenu["slow"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Slow || Player.Instance.HasBuffOfType(BuffType.Slow)))
                                 || (QssMenu["poison"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Poison || Player.Instance.HasBuffOfType(BuffType.Poison)))
                                 || (QssMenu["blind"].Cast<CheckBox>().CurrentValue
                                     && (args.Buff.Type == BuffType.Blind || Player.Instance.HasBuffOfType(BuffType.Blind)))
                                 || (QssMenu["zed"].Cast<CheckBox>().CurrentValue && args.Buff.Name == "zedrtargetmark")
                                 || (QssMenu["vlad"].Cast<CheckBox>().CurrentValue && args.Buff.Name == "vladimirhemoplaguedebuff")
                                 || (QssMenu["liss"].Cast<CheckBox>().CurrentValue && args.Buff.Name == "LissandraREnemy2")
                                 || (QssMenu["fizz"].Cast<CheckBox>().CurrentValue && args.Buff.Name == "fizzmarinerdoombomb")
                                 || (QssMenu["naut"].Cast<CheckBox>().CurrentValue && args.Buff.Name == "nautilusgrandlinetarget")
                                 || (QssMenu["fiora"].Cast<CheckBox>().CurrentValue && args.Buff.Name == "fiorarmark");
                    var enemys = QssMenu["Rene"].Cast<Slider>().CurrentValue;
                    var hp = QssMenu["hp"].Cast<Slider>().CurrentValue;
                    var enemysrange = QssMenu["enemydetect"].Cast<Slider>().CurrentValue;
                    var delay = QssMenu["human"].Cast<Slider>().CurrentValue;
                    if (debuff && Player.Instance.HealthPercent <= hp && Player.Instance.Position.CountEnemiesInRange(enemysrange) >= enemys)
                    {
                        Core.DelayAction(QssCast, delay);
                    }
                }
            }
        }

        public static void QssCast()
        {
            if (Quicksilver_Sash.IsOwned() && Quicksilver_Sash.IsReady() && QssMenu["Quicksilver"].Cast<CheckBox>().CurrentValue)
            {
                Quicksilver_Sash.Cast();
            }

            if (Mercurial_Scimitar.IsOwned() && Mercurial_Scimitar.IsReady() && QssMenu["Mercurial"].Cast<CheckBox>().CurrentValue)
            {
                Mercurial_Scimitar.Cast();
            }

            if (Dervish_Blade.IsOwned() && Dervish_Blade.IsReady() && QssMenu["Mercurial"].Cast<CheckBox>().CurrentValue)
            {
                Dervish_Blade.Cast();
            }

            if (Cleanse != null)
            {
                if (QssMenu["Cleanse"].Cast<CheckBox>().CurrentValue && Cleanse.IsReady())
                {
                    Cleanse.Cast();
                }
            }
        }
    }
}