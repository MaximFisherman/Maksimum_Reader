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
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.richTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        }
        //Форма всех книг в директории Book
        SelectBook form = new SelectBook();
        bool flag_update_style = false;
        string update_style = "";


        bool flag_Favorites = false;
        bool flag_History = false;

        string[] paths;
        string file_dir;//Сдесь запоминается путь открытого файла 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ////////////////////////////////Загрузка всех элементов директоррии Book
            paths = Directory.GetFiles(@"book\", "*.fb2");
            ///////////////////////////////////////////////////////////////////////////////////////////////////
        }

        /////////////////////////////////////////Избранное и История//////////////////////////////////////////
        ///Добавление/////////////////////////////////////////////////////////////////////////////////////////
        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"D:\Колледж\Практики\КПЗ\WpfApplication1\WpfApplication1\bin\Debug\Favorites.txt", true);
            sw.WriteLine(file_dir);
            sw.Close();
        }
        public void Favorites(bool flag_Favorites,bool flag_History,string path)
        {
            if (flag_History==true)
            {
                StreamWriter sw = new StreamWriter(@"D:\Колледж\Практики\КПЗ\WpfApplication1\WpfApplication1\bin\Debug\History.txt", true);
                string s = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
                sw.WriteLine(path + " ||" + s);
                sw.Close();
            }

            if(flag_Favorites==true)
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                XmlReader Reader = XmlReader.Create(path);
                string str = "";
                while (Reader.Read())
                {
                    str = str + Reader.Value;
                }
                richTextBox.Document.Blocks.Clear();
                this.Style_Redaer(str, str_color);
            }
        }

        //Стиль Читалки 
        string str_color = "Black";
        public void Smena_Color(string str_color1)
        {
            str_color = str_color1;
            //Проерка на обновление стиля////////////////////////////////////////////////////////////////
            if (flag_update_style)           
                this.Update_style(flag_update_style, update_style);
        }
 
        //////////////////////////////Обновление стиля //////////////////////////////////////////////////////
        public void Update_style(bool flag,string str)
        {
            richTextBox.Document.Blocks.Clear();
            this.Style_Redaer(str,str_color);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Style_Redaer(string str, string Color)
        {
            TextRange tr = new TextRange(richTextBox.Document.ContentEnd, richTextBox.Document.ContentEnd);
            tr.Text = "textToColorize";
            if (Color == "Red")
            { tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red); richTextBox.Background = new SolidColorBrush(Colors.Black); }
            if (Color == "Black")
            { tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black); richTextBox.Background = new SolidColorBrush(Colors.DarkKhaki); }
            if (Color== "Normal")
            { tr.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black); richTextBox.Background = new SolidColorBrush(Colors.Bisque); }
            richTextBox.AppendText(str);
        }

       
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void Show_book(bool flag,int index)
        {
            if (flag)
            {
                MessageBox.Show("Подождите пока загрузится книга");
                richTextBox.Document.Blocks.Clear();
               var xmlDoc = new XmlDocument();
                string file = paths[index];
                ////////////////////ДЛя добавления в Историю//////////////////////////////////////////////////
                flag_History = true;
                file_dir= paths[index];
                this.Favorites(flag_Favorites,flag_History,paths[index]);
                /////////////////////////////////////////////////////////////////////////////////////////////
                xmlDoc.Load(file);
                XmlReader Reader = XmlReader.Create(file);
                string str = "";
                while (Reader.Read())
                {
                    str = str + Reader.Value;
                }
                /////////////////////////////////////sdasdas////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////////////////////////
                this.Style_Redaer(str, str_color);
                /////Для динамического обновления стиля ////////////////////////////////////////////////////////
                flag_update_style = true;
                update_style = str;
            }
        }
        

/// /////////////////////Для открытия книги в проводнике //////////////////////////////////////////////////////
        string[] files;//Директория 
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////
            var ofd = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "Fichiers vidéos (*.fb2)|*.fb2|Tous les fichiers (*.*)|*.*"
            };

            if (ofd.ShowDialog() ?? false)
            {
                richTextBox.Document.Blocks.Clear();
                var d = ofd.FileNames;
                files = ofd.SafeFileNames;
                var xmlDoc = new XmlDocument();
                //////////////////Для добавления в историю либо избранное///////////////////////////////////////
                flag_History = true;
                file_dir = @"Book\" + files[0];
                this.Favorites(flag_Favorites, flag_History, @"Book\" + files[0]);
                ////////////////////////////////////////////////////////////////////////////////////////////////
                xmlDoc.Load(@"Book\" + files[0]);
                XmlReader Reader = XmlReader.Create(@"Book\" + files[0]);
                string str = "";
                while (Reader.Read() )
                {
                    str = str + Reader.Value;
                }
                MessageBox.Show("Подождите пока загрузится книга");
                this.Style_Redaer(str, str_color);
                /////Для динамического обновления стиля ////////////////////////////////////////////////////////
                flag_update_style = true;
                update_style = str;
            }
       }



    public void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            SelectBook form = new SelectBook(this);
            form.ShowDialog();//в модальном режиме ,то что надо :)
        }

 //Смена цветовой расскраски 
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Style style = new Style(this);
            style.ShowDialog();
        }

 //Печать документа
        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(richTextBox, "Текстовый элемент и кнопка");
            }
        }

       //Открытие формы избранного///////////////////////////////////////////
        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            Favorites f = new Favorites(this);
            f.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
 
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
       

        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
    }
}
