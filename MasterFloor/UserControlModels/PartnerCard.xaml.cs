using MasterFloor.Pages;
using MasterFloor.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasterFloor.UserControlModels
{
    /// <summary>
    /// Логика взаимодействия для PartnerCard.xaml
    /// </summary>
    public partial class PartnerCard : UserControl
    {
        public event EventHandler<Partners> PartnerDeleted;

        public PartnerCard()
        {
            InitializeComponent();
        }

        private void EditPartner_Click(object sender, RoutedEventArgs e)
        {
            var partner = (Partners)this.DataContext;
            var context = new Model1();

            EditPartnerWindow editPartnerWindow = new EditPartnerWindow(partner, context);
            editPartnerWindow.ShowDialog();

            this.DataContext = context.Partners.FirstOrDefault(p => p.id == partner.id);
        }

        private void DeletePartner_Click(object sender, RoutedEventArgs e)
        {
            var partner = (Partners)this.DataContext;

            var context = new Model1();

            var partnerToDelete = context.Partners.FirstOrDefault(p => p.id == partner.id);

            if (partnerToDelete != null)
            {
                context.Partners.Remove(partnerToDelete);
                context.SaveChanges();

                PartnerDeleted?.Invoke(this, partner);

                MessageBox.Show("Партнер успешно удален!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Партнер не найден в базе данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
