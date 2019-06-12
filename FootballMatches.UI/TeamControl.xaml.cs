using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using FootballLib;

namespace FootballMatches.UI
{
    /// <summary>
    /// Interaction logic for TeamControl.xaml
    /// </summary>
    public partial class TeamControl : UserControl
    {
        private Team team;
        private ImageSource imgFlag;
        private string assetsDir = System.AppDomain.CurrentDomain.BaseDirectory + "assets\\";
        public Team Team
        {
            get
            {
                return this.team;
            }
            set
            {
                this.team = value;
                if (team != null)
                {
                    tbName.Text = team.Name;
                    this.Visibility = Visibility.Visible;
                    if (System.IO.File.Exists(assetsDir + team.Code + ".png"))
                    {

                        imgFlag = new BitmapImage(new Uri(assetsDir + team.Code + ".png"));
                        btMain.Background = new ImageBrush(imgFlag);
                    }
                    else
                    {
                        btMain.Background = new LinearGradientBrush(Color.FromRgb(0, 0, 20), Color.FromRgb(0, 100, 255), 0.0);
                    }
                }
                else
                {
                    tbName.Text = "";
                    btMain.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    this.Visibility = Visibility.Hidden;
                }
            }
        }
        public TeamControl()
        {
            InitializeComponent();
        }
    }
}
