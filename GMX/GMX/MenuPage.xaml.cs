using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GMX
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public ListView ListView => listView;

        public MenuPage()
        {
            InitializeComponent();
            var masterPageItems = new List<MasterPageItem>
            {
                new MasterPageItem
                {
                    Title = "Home",
                    TargetType = typeof(MainPage)
                },
                new MasterPageItem
                {
                    Title = "Search",
                    TargetType = typeof(SearchPage)
                }
            };

            listView.ItemsSource = masterPageItems;
        }
    }

    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
    }
}
