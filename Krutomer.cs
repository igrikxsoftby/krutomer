using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace krutomer
{
    /// <summary>
    /// класс для работы с сервисом krutomer.ru
    /// </summary>
    class Krutomer
    {
        private string login;
        private string password;
        private string email;
        private Image captha;

        // события при выводе капчи
        public delegate void InputCaptha(object sender, Image image);
        public event InputCaptha Captha;

        // регистрирует данные
        public void Register()
        { 
            // сначало выводим капчу и подготовливаем данные для post запроса
            // получаем содержимое страницы и распарсиваем капчу для вывода на экран
            Http.Http http = new Http.Http();
            http.Get(@"http://www.krutomer.ru/register");
            Match idCaptha = Regex.Match(http.DataGet, "temp/(.*).jpg");
            if (idCaptha.Success)
            {
                //MessageBox.Show(idCaptha.Groups[1].Value);
                if (Captha != null)
                    Captha(this, http.GetCaptha(@"http://www.krutomer.ru/temp/" + idCaptha.Groups[1].Value + ".jpg"));
            }
            else
            {
                MessageBox.Show("Страница на капчу не распарсена!");
            }
        }
    }
}
