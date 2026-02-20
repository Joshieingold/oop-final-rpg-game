using System.IO;
using System.Text.Json;
using System.Windows;
using GameLibrary;

namespace GameUI
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "GameData",
                    "Jsons",
                    "Items.json");

            string json = File.ReadAllText(path);

            var root = JsonSerializer.Deserialize<ItemRoot>(json);

            lstTest.Items.Clear();
            foreach (var item in root.Items)
            {
                lstTest.Items.Add(item.ToString());
            }
        }
    }
}
