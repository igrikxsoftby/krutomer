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
        Http.Http http = new Http.Http();
        // регистрирует данные
        public void ParseCaptha()
        { 
            // сначало выводим капчу и подготовливаем данные для post запроса
            // получаем содержимое страницы и распарсиваем капчу для вывода на экран
            
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
        public string Register(string capcha)
        {
            login = RandomData.RandomLogin();
            password = RandomData.RandomPassword();
            email = RandomData.RandomEmail();
            http.PostData = @"check_form=1&login=" + login + "&password=" + password + "&repeat=" + password + "&nick=" + login + "&name=" + login + "&day=1&month=4&year=1990&sex=1&flavour=3&country=134&email=" + email + "&friend=&code=" + capcha;
            http.Post(@"http://www.krutomer.ru/register");
            http.Get(@"http://www.krutomer.ru/");

            System.Threading.Thread.Sleep(5000);

            Match prov = Regex.Match(http.DataGet, "td id='p_small'>(.*), <b>");
            if (prov.Success)
            {
                MessageBox.Show("Зарегились)))\r\nЛогин: " + login + "\r\nПароль: " + password + "\r\nМыло: " + email);
            }
            else { MessageBox.Show("От ХУЯ УШИ!!!"); }
            
            return "k";
        }

    }
}
