using System;

class CompanyInfo
{
    static void Main()
    {
        string companyName = Console.ReadLine();
        string companyAddress = Console.ReadLine();
        string phoneNum = Console.ReadLine();
        string faxNum = Console.ReadLine();
        string webSite = Console.ReadLine();
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        string age = Console.ReadLine();
        string managerPhone = Console.ReadLine();

        if (string.IsNullOrEmpty(faxNum))
        {
            faxNum = "(no fax)";
        }

        Console.WriteLine("{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (age: {7}, tel. {8})",
            companyName, companyAddress, phoneNum, faxNum, webSite, firstName, lastName, age, managerPhone);
    }
}