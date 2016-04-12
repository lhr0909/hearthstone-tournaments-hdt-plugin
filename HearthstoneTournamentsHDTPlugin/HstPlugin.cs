using System;
using System.Windows.Controls;
using System.Windows;
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

            webBrowser.LoadCompleted += (sender, args) =>
            {
                var path = webBrowser.Source.PathAndQuery;
                if (path.Equals("/plugin"))
                {
                    GameEvents.OnGameEnd.Add(() =>
                    {
                        var playerName = Core.Game.Player.Name;
                        var opponentName = Core.Game.Opponent.Name;
                        var didPlayerWin = Core.Game.CurrentGameStats.Result == GameResult.Win;
                        var powerLog = Core.Game.PowerLog;
                        try
                        {
                            webBrowser.InvokeScript("uploadReplay", playerName, opponentName, didPlayerWin, string.Join("\n", powerLog));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }                       
                    });
                }
            };
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
        public Version Version => new Version(0, 1, 0, 0);
        public MenuItem MenuItem { get; private set; }

        public MainWindow MainWindow { get; private set; }
    }
}
