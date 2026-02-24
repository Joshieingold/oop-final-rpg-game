using Core.Characters;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    public partial class BattleWindow : Window
    {
        Player me = new Player("Josh");
        Enemy notMe = new Enemy("Bob", ProgLang.Js);
        public BattleWindow()
        {
            InitializeComponent();
        }
        

        private void Window_Initialized(object sender, EventArgs e)
        {
            PlayerLabel.Content = me.ToString();
            EnemyLabel.Content = notMe.ToString();

        }
    }
}
