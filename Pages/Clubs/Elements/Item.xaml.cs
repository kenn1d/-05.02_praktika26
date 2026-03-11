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

namespace praktika26.Pages.Clubs.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        /// <summary> Главная страница клубов
        Main Main;
        /// <summary> Данные клуба
        Models.Clubs Club;

        public Item(Models.Clubs Club, Main Main)
        {
            InitializeComponent();

            this.Name.Text = Club.Name;
            this.Address.Text = Club.Address;
            this.WorkTime.Text = Club.WorkTime;

            this.Main = Main;
            this.Club = Club;
        }

        /// <summary> Метод изменения
        private void EditClub(object sender, System.Windows.RoutedEventArgs e) =>
            // Открываем страницу добавления, пересылая данные
            MainWindow.init.OpenPages(new Pages.Clubs.Add(this.Main, this.Club));

        /// <summary> Метод удаления
        private void DeleteClub(object sender, System.Windows.RoutedEventArgs e)
        {
            // Удаляем клуб из контекста
            Main.AllClub.Clubs.Remove(this.Club);
            // Сохраняем изменения
            Main.AllClub.SaveChanges();
            // Удаляем элемент со страницы Main
            Main.Parent.Children.Remove(this);
        }
    }
}
