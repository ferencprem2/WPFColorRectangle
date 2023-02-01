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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ChangeColor(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctRectangle.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliderRed.Value), Convert.ToByte(sliderGreen.Value), Convert.ToByte(sliderBlue.Value)));
        }

        private void BtnFix(object sender, RoutedEventArgs e)
        {
            String colorDatas = $"{Convert.ToByte(sliderRed.Value)}; {Convert.ToByte(sliderGreen.Value)}; {Convert.ToByte(sliderBlue.Value)}";
            if (!lbColors.Items.Contains(colorDatas))
            {
                lbColors.Items.Add(colorDatas);
            }
        }

        private void BtnDelete(object sender, RoutedEventArgs e)
        {
            if (lbColors.SelectedIndex>=0)
            {
                    lbColors.Items.RemoveAt(lbColors.SelectedIndex);
                    
            }
            else
            {
                MessageBox.Show("No selected item in the list");
            }
        }

        private void BtnUnload(object sender, RoutedEventArgs e)
        {
            lbColors.Items.Clear();
        }

        private void SelectColorToPass(object sender, MouseButtonEventArgs e)
        {
            string[] itemsInList = {"0", "0", "0" };
            if (lbColors.SelectedItem != null)
            {
                itemsInList = lbColors.SelectedItem.ToString().Split(';');
            }
            sliderRed.Value = Convert.ToByte(itemsInList[0]);
            sliderGreen.Value = Convert.ToByte(itemsInList[1]);
            sliderBlue.Value = Convert.ToByte(itemsInList[2]);
            rctRectangle.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(itemsInList[0]), Convert.ToByte(itemsInList[1]), Convert.ToByte(itemsInList[2])));
        }
    }
}
