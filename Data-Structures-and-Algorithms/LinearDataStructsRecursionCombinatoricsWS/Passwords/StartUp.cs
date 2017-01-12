using System;

namespace Passwords
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var relations = Console.ReadLine();
            var target = int.Parse(Console.ReadLine());
            var passArr = new char[n];
            counter = target;
            GeneratePassword(passArr, n, relations, 0);
        }

        public static int counter;

        public static void GeneratePassword(char[] password, int n, string relations, int index)
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
                    password[0] = i;
                    GeneratePassword(password, n - 1, relations, index + 1);
                }

                return;
            }

            if (index - 1 >= relations.Length)
            {
                return;
            }

            if (relations[index - 1] == '=')
            {
                password[index] = password[index - 1];
                GeneratePassword(password, n - 1, relations, index + 1);
            }
            else if (relations[index - 1] == '<')
            {
                var last = password[index - 1] == '0' ? '9' : (char)(password[index - 1] - 1);
                for (char i = '1'; i <= last; i++)
                {
                    password[index] = i;
                    GeneratePassword(password, n - 1, relations, index + 1);
                }
            }
            else if (password[index - 1] != '0')
            {
                password[index] = '0';
                GeneratePassword(password, n - 1, relations, index + 1);

                for (char i = (char)(password[index - 1] + 1); i <= '9'; i++)
                {
                    password[index] = i;
                    GeneratePassword(password, n - 1, relations, index + 1);
                }
            }
        }
    }
}
