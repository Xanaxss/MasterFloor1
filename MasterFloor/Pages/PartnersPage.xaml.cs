using MasterFloor.UserControlModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MasterFloor.Pages
{
    /// <summary>
    /// Логика взаимодействия для PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {

        public Model1 _context;
        public ObservableCollection<Partners> Partners { get; set; }

        public PartnersPage(Model1 context)
        {
            InitializeComponent();
            _context = context;
            Partners = new ObservableCollection<Partners>();
            LoadPartnersData();
            DataContext = this;
        }

        public void LoadPartnersData()
        {
            var partnersList = _context.Partners.ToList();

            Partners.Clear();

            foreach (var partner in partnersList)
            {
                int totalProductsSold = _context.PartnerProducts
                    .Where(p => p.parnter_id == partner.id)
                    .Sum(p => (int?)p.number_products) ?? 0;

                // Рассчитываем скидку
                double discount = CalculateDiscount(totalProductsSold);

                // Устанавливаем рассчитанную скидку в партнера
                partner.Discount = discount;
                Partners.Add(partner);
            }
        }

        private void PartnerCard_PartnerDeleted(object sender, Partners deletedPartner)
        {
            if (deletedPartner != null)
            {
                Partners.Remove(deletedPartner);
            }
        }

        public double CalculateDiscount(int totalProductsSold)
        {
            if (totalProductsSold >= 300000)
                return 15.0;
            else if (totalProductsSold >= 50000)
                return 10.0;
            else if (totalProductsSold >= 10000)
                return 5.0;
            else
                return 0.0;
        }

    }
}
