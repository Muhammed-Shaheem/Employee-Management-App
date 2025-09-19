using EmployeeManagementLibrary;
using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Models;
using System.Windows;
using System.Windows.Media;

namespace EmployeeManagement.Desktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IDatabaseData data;
    public List<EmployeeModel> Employees { get; set; } = new();

    public MainWindow(IDatabaseData data)
    {
        InitializeComponent();
        this.data = data;
        LoadEmployeesInDropDown();
    }

    private void AddEmployee_Click(object sender, RoutedEventArgs e)
    {
        if (EmptyValueCheck())
        {
            var employee = new EmployeeModel
            {
                Name = txtName.Text,
                BasicSalary = decimal.Parse(txtBasicSalary.Text),
                Allowances = decimal.Parse(txtAllowances.Text),
                PFPercent = decimal.Parse(txtPFPercent.Text)

            };
            data.AddEmployee(employee);
            MessageBox.Show("New Employee Added", "Success Message", MessageBoxButton.OK, MessageBoxImage.Information);
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


    private void LoadEmployeesInDropDown()
    {
        Employees = data.GetAllEmployees();
        cmbEmployees.ItemsSource = Employees;
        cmbEmployees.DisplayMemberPath = "Name";

    }
    private void CalculatePayroll_Click(object sender, RoutedEventArgs e)
    {
        if (cmbEmployees.SelectedItem is EmployeeModel selectedEmployee)
        {
            int leaveDays = int.TryParse(txtLeaveDays.Text, out int val) ? val : 0;

            decimal pf = Utility.CalculatePF(selectedEmployee.BasicSalary, selectedEmployee.PFPercent);
            (decimal leaveDeduction, decimal gross) = Utility.LeaveDeduction(selectedEmployee.BasicSalary, selectedEmployee.Allowances, leaveDays);
            decimal netPay = Utility.NetPayment(gross, pf, leaveDeduction);

            txtGross.Text = $"Gross: {gross:C}";
            txtPF.Text = $"PF: {pf:C}";
            txtLeaveDeduction.Text = $"Leave Deduction: {leaveDeduction:C}";
            txtNet.Text = $"Net Pay: {netPay:C}";
        }
        else
        {
            MessageBox.Show("Please select an employee first.","Error",MessageBoxButton.OK,MessageBoxImage.Error);
        }

    }

   
}