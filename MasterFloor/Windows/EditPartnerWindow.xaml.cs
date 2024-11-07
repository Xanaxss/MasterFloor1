using MasterFloor.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для EditPartnerWindow.xaml
    /// </summary>
    public partial class EditPartnerWindow : Window
    {
        Partners _partner;
        private readonly Model1 _context;


        public EditPartnerWindow(Partners partner, Model1 context)
        {
            InitializeComponent();
            _partner = partner;
            _context = context;

            var partnerTypes = _context.TypePartners.ToList();
            PartnerTypeComboBox.ItemsSource = partnerTypes;
            PartnerTypeComboBox.SelectedValue = _partner.name_type;
            name_partner_box.Text = _partner.name_partner;
            director_box.Text = _partner.director;
            mail_box.Text = _partner.mail;
            phone_box.Text = _partner.phone;
            address_box.Text = _partner.legal_address;
            inn_box.Text = _partner.inn;
            rating_box.Text = _partner.rating.HasValue ? _partner.rating.Value.ToString() : "";
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var existingPartner = _context.Partners.FirstOrDefault(p => p.id == _partner.id);

            if (existingPartner != null)
            {
                existingPartner.name_type = (int)PartnerTypeComboBox.SelectedValue;
                existingPartner.name_partner = name_partner_box.Text;
                existingPartner.director = director_box.Text;
                existingPartner.mail = mail_box.Text;
                existingPartner.phone = phone_box.Text;
                existingPartner.legal_address = address_box.Text;
                existingPartner.inn = inn_box.Text;
                existingPartner.rating = int.TryParse(rating_box.Text, out int rating) ? rating : (int?)null;

                    _context.SaveChanges();
            }

            // Закрываем окно после сохранения
            this.Close();
        }

        private void OpenMainWindow_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
