using System;

namespace Passwords
{
    public class StartUp
    {
        public static int counter;
        
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var relations = Console.ReadLine();
            var targetIndex = int.Parse(Console.ReadLine());

            counter = targetIndex;
            var password = new char[n];
            CalculatePassword(password, 0, n, relations);
        }

        private static void CalculatePassword(char[] password, int index, int n, string relations)
        {
            if (counter == 0)
            {
                return;
            }

            if (n <= 0)
            {
                counter--;
                if (counter == 0)
                {
                    Console.WriteLine(string.Join("", password));
                }
                return;
            }

            if (index == 0)
            {
                for (char i = '0'; i <= '9'; i++)
                {
                    password[index] = i;
                    CalculatePassword(password, index + 1, n - 1, relations);
                }
            }
            
            if (index == 0)
            {
                return;
            }

            if (relations[index - 1] == '=')
            {
                password[index] = password[index - 1];
                CalculatePassword(password, index + 1, n - 1, relations);
            }

            if (relations[index - 1] == '>')
            {
                if (password[index - 1] == '0')
                {
                    return;
                }

                if ((char)password[index - 1] > '0')
                {
                    password[index] = '0';
                    CalculatePassword(password, index + 1, n - 1, relations);
                }
                
                for (char i = (char)(password[index - 1] + 1); i <= '9'; i++)
                {
                    password[index] = i;
                    CalculatePassword(password, index + 1, n - 1, relations);
                }
            }

            if (relations[index - 1] == '<')
            {
                var prev = password[index - 1] == '0' ? '9' : (char)(password[index - 1] - 1);
                for (char i = '1'; i <= prev; i++)
                {
                    password[index] = i;
                    CalculatePassword(password, index + 1, n - 1, relations);
                }
            }
        }
    }
}
