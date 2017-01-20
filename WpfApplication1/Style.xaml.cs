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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Style.xaml
    /// </summary>
    public partial class Style : Window
    {
        private MainWindow m_parents;
        public Style(MainWindow frm1)
        {
            InitializeComponent();
            m_parents=frm1;
        }
        int index_style;//Индекс стиля

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index_style = listBox.SelectedIndex;
            if (index_style == 0)
            {
                ImageSourceConverter imgs = new ImageSourceConverter();
                image.SetValue(Image.SourceProperty, imgs.ConvertFromString(@"Image\Full_Red.png"));
            }

            if (index_style == 1)
            {
                ImageSourceConverter imgs = new ImageSourceConverter();
                image.SetValue(Image.SourceProperty, imgs.ConvertFromString(@"Image\Extrim.png"));
            }
            if (index_style == 2)
            {
                ImageSourceConverter imgs = new ImageSourceConverter();
                image.SetValue(Image.SourceProperty, imgs.ConvertFromString(@"Image\Normal.png"));
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ///////////////////Первый вариант Full Red////////////////////////////////////////
            if(index_style==0)
            {
                m_parents.Smena_Color("Red");
            }
            /////////////////2-ой вариант Extrim////////////////////////////////////////////
            if(index_style==1)
            {
                m_parents.Smena_Color("Black");
            }
            ///////////////3-Й вариант Normal////////////////////////////////////////////////
            if(index_style==2)
            {
                m_parents.Smena_Color("Normal");
            }

            

        }
    }
}
