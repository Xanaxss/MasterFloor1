using MasterFloor.Pages;
using MasterFloor.Windows;
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


namespace MasterFloor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Model1 _context;
        PartnersPage _partnerPage;
        ParterProductPage _partnerProductPage;

        public MainWindow()
        {
            InitializeComponent();
            _context = new Model1();
            _partnerPage = new PartnersPage(_context);
            _partnerProductPage = new ParterProductPage(_context);
        }

        private void GoToPagePartner(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_partnerPage);
        }

        private void AddPartner_Click(object sender, RoutedEventArgs e)
        {
            AddPartnerWindow addPartnerWindow = new AddPartnerWindow(this, _partnerPage);
            addPartnerWindow.ShowDialog();
            _partnerPage.LoadPartnersData();
        }

        private void GoToPartnerProduct(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(_partnerProductPage);

        }
    }
}
