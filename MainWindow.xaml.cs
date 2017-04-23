using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;

namespace checkoutprice
{
  
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tb_items_list.Text = "A:2,B:1,A:2";
        }

        private string[] spilt_string(string item_list)
        {
            char[] delimiterChars = { ',' };
            string[] out_str= item_list.Split(delimiterChars);

            return out_str;
        }

    
        private double get_total_price(string item_list)
        {
            //committed to dicitonary but wouldn't use it in in live version, go for another container thats updateable
            Dictionary<string, int> item_dictlist = new Dictionary<string, int>();
            string[] itemqty_list =spilt_string(item_list);       
            int in_quant=0;
            int current_quantity = 0;
            string in_name = "";
            double total_price_val = 0;
            var url = "https://api.myjson.com/bins/gx6vz";

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(url);
                var prices = JsonConvert.DeserializeObject<List<price>>(json);
            }

            foreach (string s in itemqty_list)
            {
                int.TryParse(s.Substring(s.IndexOf(":") + 1),out in_quant);
                in_name = s.Substring(0, s.IndexOf(":"));

                if ( in_quant == 0)
                {
                    Console.WriteLine("Invalid quantity");
                }

                if (item_dictlist.ContainsKey(in_name))
                {
                    item_dictlist.TryGetValue(in_name, out current_quantity);
                    item_dictlist.Remove(in_name);                    
                }
                else
                {
                    current_quantity = 0;
                }
                item_dictlist.Add(in_name, current_quantity + in_quant);
            }


            return item_dictlist.Sum(x => x.Value); 
        }

        private void calculate_price_click(object sender, RoutedEventArgs e)
        {
            tb_total_price.Text =  get_total_price(tb_items_list.Text ).ToString();
        }
    }
}
