using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
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
            HstWebBrowser.Source = new Uri("https://www.tavern.gg/plugin");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = true;
            this.Hide();
        }
    }
}
