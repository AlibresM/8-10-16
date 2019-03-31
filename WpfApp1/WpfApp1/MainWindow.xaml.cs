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
    public partial class MainWindow : Window
    {
        public string alph = "0123456789ABCDEF";

        public MainWindow()
        {
            InitializeComponent();
        }

        public int val(char c)
        {
            if (c >= '0' && c <= '9')
                return (int)c - '0';
            else return (int)c - 'A' + 10;
        }

        public string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

        string numfromdec(int num, int nbase)
        {
            string res = "";
            while (num > 0)
            {
                res = res + alph[num % nbase];
                num /= nbase;
            }
            res = Reverse(res);
            return res;
        }

        string numtodec(string num, int nbase)
        {
            int p = 1;
            int res = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                res += val(num[i]) * p;
                p = p * nbase;
            }
            return res.ToString();
        }


        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tb10.Text = numtodec(tb8.Text, 8);
            tb16.Text = numfromdec(int.Parse(tb10.Text), 16);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tb10.Text = numtodec(tb16.Text, 16);
            tb8.Text = numfromdec(int.Parse(tb10.Text), 8);
        }
    }
}
