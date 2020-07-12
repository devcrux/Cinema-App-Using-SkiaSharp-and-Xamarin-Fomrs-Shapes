using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CinemaApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Tickets = GetTickets();
            this.BindingContext = this;
        }

        public ObservableCollection<Ticket> Tickets { get; set; }
        public Ticket SelectedTicket { get; set; }

        private ObservableCollection<Ticket> GetTickets()
        {
            return new ObservableCollection<Ticket>
            {
                new Ticket { MovieTitle = "Bad Boys For LIfe", Image = "BadBoys.jpg", ShowingDate = DateTime.Now.AddDays(15), Seats = new int[] { 61, 62, 63 } },
                new Ticket { MovieTitle = "The Old Guard", Image = "OldGuard.jpg", ShowingDate = DateTime.Now.AddDays(22), Seats = new int[] { 111, 112 } },
                new Ticket { MovieTitle = "Tenet", Image = "Tenet.jpg", ShowingDate = DateTime.Now.AddDays(25), Seats = new int[] { 12, 25, 35 } },
                new Ticket { MovieTitle = "No Time To Die", Image = "TimeToDie.jpg", ShowingDate = DateTime.Now.AddDays(20), Seats = new int[] { 99 } }
            };
        }

        private void TicketSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                this.Navigation.PushAsync(new SeatsPage(SelectedTicket));
            }
        }
    }

    public class Ticket
    {
        public string MovieTitle { get; set; }
        public DateTime ShowingDate { get; set; }
        public string Image { get; set; }
        public int[] Seats { get; set; }
    }
}
