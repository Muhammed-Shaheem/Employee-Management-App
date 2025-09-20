using System.Text.RegularExpressions;

namespace EmployeeManagementLibrary;

public class Utility
{
    public static decimal CalculatePF(decimal basicSalary, decimal pfPercent)
    {
        decimal pf = basicSalary * (pfPercent / 100);
        return pf;

    }
    public static (decimal, decimal) LeaveDeduction(decimal basicSalary, decimal allowances, int leaveDays)
    {
        decimal gross = basicSalary + allowances;
        int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        decimal perDaySalary = gross / daysInMonth;
        decimal leaveDeduction = perDaySalary * leaveDays;

        return (leaveDeduction, gross);

    }

    public static decimal NetPayment(decimal gross, decimal pf, decimal leaveDeduction)
    {
        decimal netPay = gross - pf - leaveDeduction;
        return netPay;

    }
}