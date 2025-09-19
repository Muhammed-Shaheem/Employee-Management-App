using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeManagement.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddEmployee_Click(object sender, RoutedEventArgs e)
    {
        if (EmptyValueCheck())
        {
            
        }
    }

    private bool EmptyValueCheck()
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Name is required.");
            txtName.BorderBrush = Brushes.Red;
            return false;
        }
        else if (string.IsNullOrWhiteSpace(txtBasicSalary.Text))
        {
            MessageBox.Show("BasicSalary is required.");
            txtBasicSalary.BorderBrush = Brushes.Red;
            return false;

        }
        else if (string.IsNullOrWhiteSpace(txtAllowances.Text))
        {
            MessageBox.Show("Allowances is required.");
            txtAllowances.BorderBrush = Brushes.Red;
            return false;
        }
        else if (string.IsNullOrWhiteSpace(txtPFPercent.Text))
        {
            MessageBox.Show("PfPercent is required.");
            txtPFPercent.BorderBrush = Brushes.Red;
            return false;
        }

        return true;
    }

    private void CalculatePayroll_Click(object sender, RoutedEventArgs e)
    {

    }
}