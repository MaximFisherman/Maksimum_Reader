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
using System.ComponentModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for SelectBook.xaml
    /// </summary>
    public partial class SelectBook : Window
    {
        public SelectBook()
        {
            InitializeComponent();
        }

        public MainWindow m_parent;

        public SelectBook(MainWindow frm1)
        {
            InitializeComponent();
            m_parent = frm1;
        }

        string[] str;
        int index;
        bool flag_click = false;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            str = Directory.GetFiles(@"book\", "*.fb2");
            for (int i = 0; i <= str.Length - 1; i++)
            {
                listBox.Items.Add(str[i].Remove(0, 5));
            }
            //label.Content += "1";
        }
        public void button_Click(object sender, RoutedEventArgs e)
        {
            flag_click = true;
            m_parent.Show_book(flag_click,index);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index = listBox.SelectedIndex;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        ////////////////////////поиск////////////////////////////////////////////////////////
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string str_find = textBox.Text;
            
        }
    }
}
