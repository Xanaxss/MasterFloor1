using MasterFloor.Pages;
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

namespace MasterFloor.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPartnerWindow.xaml
    /// </summary>
    public partial class AddPartnerWindow : Window
    {
        private readonly Model1 _context;
        private readonly Window _mainWindow;
        private readonly PartnersPage _partnersPage;


        public AddPartnerWindow(Window mainWindow, PartnersPage partnersPage)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _context = new Model1();
            _partnersPage = partnersPage;
            LoadPartnersType();

        }

        private void LoadPartnersType()
        {
            var partnerTypes = _context.TypePartners.ToList();


            // Привязка списка к ComboBox
            PartnerTypeComboBox.ItemsSource = partnerTypes;
            PartnerTypeComboBox.DisplayMemberPath = "type_partner";   // Отображаемое название
            PartnerTypeComboBox.SelectedValuePath = "id";
        }

        private void OpenMainWindow_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Show();

            this.Close();
        }

        private void AddPartner_Click(object sender, RoutedEventArgs e)
        {
            int selectedPartnerTypeId = (int)PartnerTypeComboBox.SelectedValue;

            var newPartner = new Partners
            {
                name_type = selectedPartnerTypeId,
                name_partner = name_partner_box.Text,
                director = director_box.Text,
                mail = mail_box.Text,
                phone = phone_box.Text,
                legal_address = address_box.Text,
                inn = inn_box.Text,
                rating = int.TryParse(rating_box.Text, out int parsedRating) ? parsedRating : 0
            };

            _context.Partners.Add(newPartner);
            _context.SaveChanges();

            _partnersPage.LoadPartnersData();


            MessageBox.Show("Партнёр успешно добавлен!", "Успех");
            this.Close();
            _mainWindow.Show();
        }
    }
}
