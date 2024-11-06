using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Company companyEntities = new Company();
        public MainWindow()
        {
            InitializeComponent();
            dg.ItemsSource = companyEntities.Employee.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employee em = new Employee();
            if (txtID.Text != "")
            {
                MessageBox.Show("ID generated successfully!");
            }
            em.EmployeeName = txtName.Text;
            em.EmployeePosition = txtPosition.Text;
            companyEntities.Employee.Add(em);
            companyEntities.SaveChanges();

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            int id = int.Parse(txtID.Text);
            emp = companyEntities.Employee.First(x => x.EmployeeID == id);
            emp.EmployeeName = txtName.Text;
            emp.EmployeePosition = txtPosition.Text;
            companyEntities.Employee.AddOrUpdate(emp);
            MessageBox.Show("Data Updated");
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtID.Text);
            Employee emp = companyEntities.Employee.Remove(companyEntities.Employee.First(x => x.EmployeeID == id));
            MessageBox.Show("Deleted");
            companyEntities.SaveChanges();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = companyEntities.Employee.ToList();
        }
    }
}
