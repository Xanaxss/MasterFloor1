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
    /// Логика взаимодействия для ParterProductPage.xaml
    /// </summary>
    public partial class ParterProductPage : Page
    {

        public Model1 _context;
        public ObservableCollection<PartnerProducts> PartnersProduct { get; set; }
        public ParterProductPage(Model1 context)
        {
            InitializeComponent();
            _context = context;
            PartnersProduct = new ObservableCollection<PartnerProducts>();
            LoadPartnerProductData();
            DataContext = this;
        }

        private void LoadPartnerProductData()
        {
            var partnersProductList = _context.PartnerProducts.ToList();

            PartnersProduct.Clear();


            foreach (var partnerProduct in partnersProductList)
            {
                Console.WriteLine("Вызов метода загрузки товаров в цикле");

                PartnersProduct.Add(partnerProduct);
            }

        }
    }
}
