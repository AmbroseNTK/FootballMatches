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

namespace FootballMatches.UI
{
    public delegate void GroupClickHandle(GroupControl sender);
    /// <summary>
    /// Interaction logic for GroupControl.xaml
    /// </summary>
    public partial class GroupControl : UserControl
    {
        public event GroupClickHandle OnClick;
        private string text;
        public string Text
        {
            get => text;
            set{
                this.text = value;
                button.Content = value;
            }
        }
        public GroupControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnClick?.Invoke(this);
        }
    }
}
