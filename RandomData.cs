using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace krutomer
{
    /// <summary>
    /// класс для рандомного определния данных
    /// </summary>
    static class RandomData
    {
        /// <summary>
        /// рандомный логи
        /// </summary>
        /// <returns>логин</returns>
        static public string RandomLogin()
        {
            Random rand = new Random();
            int n = rand.Next(10, 15);
            string login = "";
            for (int i = 0; i < n; i++)
            {
                login += ((char)rand.Next(97, 122)).ToString();
            }
            return login;
        }

        /// <summary>
        /// рандомный пароль
        /// </summary>
        /// <returns>пароль</returns>
        static public string RandomPassword()
        {
            Random rand = new Random();
            string password = "";
            for (int i = 0; i < 7; i++)
            {
                password += ((char)rand.Next(97, 122)).ToString();
            }
            return password;
        }

        /// <summary>
        /// рандомная почта
        /// </summary>
        /// <returns>почта</returns>
        static public string RandomEmail()
        {
            string[] domen = new string[] { "@mail.ru", "@inbox.ru", "@bk.ru", "@list.ru", "@rambler.ru", "@yandex.ru" };
            Random rand = new Random();
            int n = rand.Next(9, 16);
            string email = "";
            for (int i = 0; i < n; i++)
            {
                email += ((char)rand.Next(97, 122)).ToString();
            }
            return email+domen[rand.Next(0,5)];
        }
    }
}
