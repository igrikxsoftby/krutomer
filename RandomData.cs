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
        static string RandomLogin()
        {
            return "login";
        }

        /// <summary>
        /// рандомный пароль
        /// </summary>
        /// <returns>пароль</returns>
        static string RandomPassword()
        {
            return "password";
        }

        /// <summary>
        /// рандомная почта
        /// </summary>
        /// <returns>почта</returns>
        static string RandomEmail()
        {
            return "email";
        }
    }
}
