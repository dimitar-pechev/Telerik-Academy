using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = "Dimitar";
        string lastName = "Pechev";
        byte age = 23;
        char gender = 'M';
        ulong personalIdNumber = 8306112507;
        int eployeeNumber = 27569999;

        Console.WriteLine("First Name: {0}\nLast Name: {1}\nAge: {2}\nGender: {3}\nID Number: {4}\nEmplyee Number: {5}", 
        firstName, lastName, age, gender, personalIdNumber, eployeeNumber);
    }
}
