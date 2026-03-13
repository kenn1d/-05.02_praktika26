using praktika26.Classes;
using System.Windows.Controls;

namespace praktika26.Pages.Users.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public ClubContext AllClub = new ClubContext();
        Main Main;
        Models.Users User;

        public Item(Models.Users user, Main main)
        {
            InitializeComponent();

            this.User = user;
            this.Main = main;

            this.FIO.Text = user.FIO;
            this.RentStart.Text = user.RentStart.ToString("yyyy-MM-dd");
            this.RentTime.Text = user.RentStart.ToString("HH:mm");
            this.Duration.Text = user.Duration.ToString();
            this.Club.Text = AllClub.Clubs.Where(x => x.Id == user.IdClub).First().Name;
        }

        private void EditUser(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(new Add(this.Main, this.User));
        }

        private  void DeleteUser(object sender, System.Windows.RoutedEventArgs e)
        {
            Main.AllUsers.Users.Remove(User);
            Main.AllUsers.SaveChanges();
            Main.Parent.Children.Remove(this);
        }
    }
}
