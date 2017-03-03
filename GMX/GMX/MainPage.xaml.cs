using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Common;
using Telerik.XamarinForms.DataControls;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace GMX
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnItemSwipeCompleted(object sender, ItemSwipeCompletedEventArgs e)
        {
            var listView = sender as RadListView;
            var item = e.Item as Mail;

            listView.EndItemSwipe();

            if (e.Offset >= 70)
            {
                item.IsUnread = false;
            }
            else if (e.Offset <= -70)
            {
                (listView.ItemsSource as ObservableCollection<Mail>).Remove(item);
            }
        }
    }

    public class Mail : NotifyPropertyChangedBase
    {
        bool isUnread;

        public string Sender { get; set; }

        public string Subject { get; set; }

        public bool IsUnread
        {
            get { return isUnread; }
            set
            {
                if (this.isUnread != value)
                {
                    isUnread = value;
                    OnPropertyChanged();
                }
            }
        }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Source = new ObservableCollection<Mail> {
            new Mail{ Sender = "Terry Tye",  Subject = "Re: Summer Vacation" , IsUnread = true},
            new Mail{ Sender = "Felicia Keegan",  Subject = "Seminar Invitation", IsUnread = true},
            new Mail{ Sender = "Jared Linton",  Subject = "Discount code"},
            new Mail{ Sender = "Mark Therese",  Subject = "Quick feedback", IsUnread = true},
            new Mail{ Sender = "Elvina Randall",  Subject = "Happy Birthday!"},
            new Mail{ Sender = "Emilia Porter",  Subject = "Check the attachment", IsUnread = true},
            new Mail{ Sender = "Jared Linton",  Subject = "Gillian Flynn"},
            new Mail{ Sender = "Felicia Keegan",  Subject = "Re: Summer Vacation"},
            new Mail{ Sender = "Felicia Keegan",  Subject = "Pictures"},
        };
        }

        public ObservableCollection<Mail> Source { get; set; }
    }
}
