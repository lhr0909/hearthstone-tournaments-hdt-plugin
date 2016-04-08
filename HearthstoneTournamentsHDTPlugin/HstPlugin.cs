using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.Plugins;
using HearthstoneTournamentsHDTPlugin.Controls;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Enums;
using Core = Hearthstone_Deck_Tracker.API.Core;

namespace HearthstoneTournamentsHDTPlugin
{
    public class HstPlugin : IPlugin
    {
        public void OnLoad()
        {
            SetUpBrowserWindowHooks();
            SetUpMenuItem();
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

        private void SetUpBrowserWindowHooks()
        {
            MainWindow = new MainWindow();
            var webBrowser = MainWindow.HstWebBrowser;
            
            GameEvents.OnGameStart.Add(() =>
            {
                var opponentName = Core.Game.Opponent.Name;
                var opponentClass = Core.Game.Opponent.Class;
                try
                {
                    webBrowser.InvokeScript("alert", opponentClass);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            });
        }

        private void SetUpMenuItem()
        {
            MenuItem = new MenuItem { Header = "hearthstone-tournaments" };
            MenuItem.Click += (sender, args) =>
            {
                if (!MainWindow.IsLoaded)
                {
                    SetUpBrowserWindowHooks();
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
