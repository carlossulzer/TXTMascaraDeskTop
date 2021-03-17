using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace TextMascara
{
    class ValidaEmail
    {
        public static string Validar(TextBox txt)
        {
            txt.BackColor = Color.White;
            if (!txt.Text.Equals(string.Empty))
            {
                Regex regExHor = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                if (regExHor.IsMatch(txt.Text))
                {
                    txt.BackColor = Color.White;
                    return string.Empty;
                }
                else
                {
                    txt.BackColor = Color.FromArgb(255, 255, 153);
                    return "E-mail inválido.";
                }
            }
            else
                return "Favor informar o E-Mail do usuário.";
        }
    }
}
