using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ORM;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoXpoRest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Button item = new Button();
            item.Content = "Create an item from code";
            this.MainGrid.Children.Add(item);
            this.Loaded += MainPage_Loaded;
           
            item.Click += Btn1_Click;
            item.Enabled = true;
            }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Createitem(Guid.NewGuid().ToString());
        }

     

        void OnClick1(object sender, RoutedEventArgs e)
        {
            Createitem("Uno");
        }

        private static void Createitem(string uno)
        {
            UnitOfWork UoW = new UnitOfWork();
            Item Item = new Item(UoW);
            Item.Id = uno;
            Item.Description = $"Hello from uno {DateTime.Now.TimeOfDay.ToString()}";
            UoW.CommitChanges();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //Createitem("Uno load event");
        }
    }
}
