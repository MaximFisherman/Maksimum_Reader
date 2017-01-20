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
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Favorites.xaml
    /// </summary>
    public partial class Favorites : Window
    {
        public MainWindow m_parent;
        public Favorites(MainWindow mw)
        {
            InitializeComponent();
            m_parent = mw;
        }
        bool flag_favorites = false;
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            StreamReader sw = new StreamReader(@"History.txt", true);
            string[] readText = File.ReadAllLines(@"History.txt");
            for(int i=0;i<readText.Length;i++)
            listBox.Items.Add(readText[i]);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            StreamReader sw = new StreamReader(@"History.txt", true);
            string[] readText = File.ReadAllLines(@"History.txt");
            for (int i = 0; i < readText.Length; i++)
                listBox.Items.Add(readText[i]);
        }

       //Избранное ......................................................................
        string[] readText;
        private void button1_Click_1(object sender, RoutedEventArgs e)
        { 
            flag_favorites = true;
            listBox.Items.Clear();
            StreamReader sw = new StreamReader(@"Favorites.txt", true);
            readText = File.ReadAllLines(@"Favorites.txt");
            //path[0] = Convert.ToString(readText[0]);
            for (int i = 0; i <= readText.Length-1; i++)
            {
                listBox.Items.Add(readText[i]);         
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if(flag_favorites)
             m_parent.Favorites(true,false,readText[listBox.SelectedIndex]);
        }


        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
        }
        
    }
}
