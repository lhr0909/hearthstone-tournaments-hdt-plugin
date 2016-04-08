using System;
using MahApps.Metro.Controls;

namespace HearthstoneTournamentsHDTPlugin.Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                //Code that throws the exception
            }
            HstWebBrowser.Source = new Uri("https://hs-tournament.herokuapp.com/");
        }
    }
}
