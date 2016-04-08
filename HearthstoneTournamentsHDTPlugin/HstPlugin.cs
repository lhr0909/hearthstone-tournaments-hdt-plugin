using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthstoneTournamentsHDTPlugin.Controls;
using Hearthstone_Deck_Tracker.Plugins;

namespace HearthstoneTournamentsHDTPlugin
{
    public class HstPlugin : IPlugin
    {
        public void OnLoad()
        {
            SetUpMenuItem();
            MainWindow = new MainWindow();
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
            MenuItem.Click += (sender, args) =>
            {
                if (!MainWindow.IsLoaded)
                {
                    MainWindow = new MainWindow();
                }
                MainWindow.Show();
            };
        }

        public string Name => "hearthstone-tournaments";
        public string Description => "Play Automated Hearthstone Tournaments Online!";
        public string ButtonText => "Plugin Settings";
        public string Author => "Simon Liang";
        public Version Version => new Version(0, 0, 0, 1);
        public MenuItem MenuItem { get; private set; }

        public MainWindow MainWindow { get; private set; }
    }
}
