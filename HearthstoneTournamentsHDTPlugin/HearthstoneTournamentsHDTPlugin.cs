using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone_Deck_Tracker.Plugins;

namespace HearthstoneTournamentsHDTPlugin
{
    public class HearthstoneTournamentsHDTPlugin : IPlugin
    {
        public void OnLoad()
        {
            SetUpMenuItem();
            return;
        }

        public void OnUnload()
        {
            return;
        }

        public void OnButtonPress()
        {
            return;
        }

        public void OnUpdate()
        {
            return;
        }

        private void SetUpMenuItem()
        {
            MenuItem = new MenuItem { Header = "hearthstone-tournaments" };
        }

        public string Name => "hearthstone-tournaments";
        public string Description => "Play Automated Hearthstone Tournaments Online!";
        public string ButtonText => "Plugin Settings";
        public string Author => "Simon Liang";
        public Version Version => new Version(0, 0, 0, 1);
        public MenuItem MenuItem { get; private set; }
    }
}
