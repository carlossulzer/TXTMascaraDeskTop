using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TextMascara
{
    public partial class TextMascara : UserControl
    {
        public TextMascara()
        {
            InitializeComponent();
        }


        public enum TipoMascara
        {
            Moeda = 0,
            Numero = 1,
            Data = 2,
            Telefone = 3,
            TelefoneDDD = 4,
            Cep = 5,
            Cnpj = 6,
            Cpf = 7,
            Email = 8,
            Hora = 9,
            Decimal3c
        }


        public override string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public int MaxLength
        {
            get { return textBox1.MaxLength; }
            set { textBox1.MaxLength = value; }
        }


        private int teste;

        public int Teste
        {
            get { return teste; }
            set { teste = value; }
        }
	

        private TipoMascara mascara;
        public TipoMascara Mascara
        {
            get
            {
                return (mascara);
            }
            set
            {
                mascara = value;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (mascara)
            {
                case TipoMascara.Moeda:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && (!e.KeyChar.ToString().Equals(",")))
                    {
                        e.Handled = true;
                    }
                    break;
                }
                case TipoMascara.Numero:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    break;
                }
                case TipoMascara.Data:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    else if (e.KeyChar != (char)Keys.Back)
                    {
                        Formatar();
                    }
                    break;
                }

                case TipoMascara.Telefone:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    else if (e.KeyChar != (char)Keys.Back)
                    {
                        Formatar();
                    }
                    break;
                }
                case TipoMascara.TelefoneDDD:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    else if (e.KeyChar != (char)Keys.Back)
                    {
                        Formatar();
                    }
                    break;
                }
                case TipoMascara.Cep:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    else if (e.KeyChar != (char)Keys.Back)
                    {
                        Formatar();
                    }
                    break;
                }

                case TipoMascara.Cnpj:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    else if (e.KeyChar != (char)Keys.Back)
                    {
                        Formatar();
                    }
                    break;
                }
                case TipoMascara.Cpf:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    else if (e.KeyChar != (char)Keys.Back)
                    {
                        Formatar();
                    }
                    break;
                }

                case TipoMascara.Hora:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        e.Handled = true;
                    }
                    else if (e.KeyChar != (char)Keys.Back)
                    {
                        Formatar();
                    }
                    break;
                }
                case TipoMascara.Decimal3c:
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && (!e.KeyChar.ToString().Equals(",")))
                    {
                        e.Handled = true;
                    }
                    break;
                }


            }
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            switch(mascara)
            {
                case TipoMascara.Moeda:
                {
                    try
                    {
                        if (!textBox1.Text.Trim().Equals(string.Empty))
                            textBox1.Text = Convert.ToDouble(textBox1.Text).ToString("###,##0.00");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Valor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                }
                case TipoMascara.Data:
                {
                    if (!textBox1.Text.Trim().Equals(string.Empty))
                    {
                        try
                        {
                            textBox1.Text = Convert.ToDateTime(textBox1.Text).ToString("dd/MM/yyyy");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Data inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Focus();
                            textBox1.SelectAll();
                        }
                    }
                    break;
                }
                case TipoMascara.Cnpj:
                {
                    if ((!textBox1.Text.Trim().Equals(string.Empty)) && (!ValidaCNPJ.Validar(textBox1.Text.Trim())))
                    {
                        MessageBox.Show("Este CNPJ é inválido, favor verificar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Focus();
                        textBox1.SelectAll();
                    }
                    break;
                }
                case TipoMascara.Cpf:
                {
                    if ((!textBox1.Text.Trim().Equals(string.Empty)) && (!ValidaCPF.Validar(textBox1.Text.Trim())))
                    {
                        MessageBox.Show("Este CPF é inválido, favor verificar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Focus();
                        textBox1.SelectAll();
                    }
                    break;
                }

                case TipoMascara.Email:
                {
                    string mensagem = ValidaEmail.Validar(textBox1);
                    if ((!textBox1.Text.Trim().Equals(string.Empty)) && (!mensagem.Equals(string.Empty)))
                    {
                        MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Focus();
                        textBox1.SelectAll();
                    }
                    break;
                }
                case TipoMascara.Hora:
                {
                    if (!textBox1.Text.Trim().Equals(string.Empty))
                    {
                        try
                        {
                            textBox1.Text = Convert.ToDateTime(textBox1.Text).ToString("HH:mm");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hora inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Focus();
                            textBox1.SelectAll();
                        }
                    }
                    break;
                }
                case TipoMascara.Decimal3c:
                {
                    try
                    {
                        if (!textBox1.Text.Trim().Equals(string.Empty))
                            textBox1.Text = Convert.ToDouble(textBox1.Text).ToString("###0.000");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Valor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            switch(mascara)
            {
                case TipoMascara.Moeda:
                {
                    textBox1.TextAlign = HorizontalAlignment.Right;

                    if (!textBox1.Text.Trim().Equals(String.Empty))
                    {
                        if (textBox1.Text.IndexOf(".").Equals(0))
                        {
                            textBox1.Text = textBox1.Text.Replace(",", "");
                            textBox1.Text = textBox1.Text.Insert(textBox1.Text.Length - 2, ",");
                        }
                    }
                    break;
                }
                case TipoMascara.Numero:
                {
                    textBox1.TextAlign = HorizontalAlignment.Right;
                    break;
                }

                case TipoMascara.Data:
                {
                    textBox1.TextAlign = HorizontalAlignment.Center;
                    textBox1.MaxLength = 10;
                    textBox1.SelectAll();
                    break;
                }
                case TipoMascara.Telefone:
                {
                    textBox1.TextAlign = HorizontalAlignment.Left;
                    textBox1.MaxLength = 9;
                    textBox1.SelectAll();
                    break;
                }
                case TipoMascara.TelefoneDDD:
                {
                    textBox1.TextAlign = HorizontalAlignment.Left;
                    textBox1.MaxLength = 13;
                    textBox1.SelectAll();
                    break;
                }
                case TipoMascara.Cep:
                {
                    textBox1.TextAlign = HorizontalAlignment.Left;
                    textBox1.MaxLength = 9;
                    textBox1.SelectAll();
                    break;
                }
                case TipoMascara.Cnpj:
                {
                    textBox1.TextAlign = HorizontalAlignment.Left;
                    textBox1.MaxLength = 18;
                    textBox1.SelectAll();
                    break;
                }
                case TipoMascara.Cpf:
                {
                    textBox1.TextAlign = HorizontalAlignment.Left;
                    textBox1.MaxLength = 14;
                    textBox1.SelectAll();
                    break;
                }
                case TipoMascara.Email:
                {
                    textBox1.TextAlign = HorizontalAlignment.Left;
                    textBox1.MaxLength = 80;
                    textBox1.SelectAll();
                    break;
                }
                case TipoMascara.Hora:
                {
                    textBox1.TextAlign = HorizontalAlignment.Left;
                    textBox1.MaxLength = 5;
                    textBox1.SelectAll();
                    break;
                }
                case TipoMascara.Decimal3c:
                {
                    textBox1.TextAlign = HorizontalAlignment.Right;

                    if (!textBox1.Text.Trim().Equals(String.Empty))
                    {
                        if (textBox1.Text.IndexOf(".").Equals(0))
                        {
                            textBox1.Text = textBox1.Text.Replace(",", "");
                            textBox1.Text = textBox1.Text.Insert(textBox1.Text.Length - 3, ",");
                        }
                    }
                    break;
                }
        }
        }

        private void Formatar()
        {
            switch (mascara)
            {

                case TipoMascara.Data:
                {
                     if (textBox1.Text.Trim().Length.Equals(2) || textBox1.Text.Trim().Length.Equals(5))
                    {
                        textBox1.Text = textBox1.Text + "/";
                        textBox1.SelectionStart = textBox1.Text.Length + 1;
                    }
                    break;
                }
                case TipoMascara.Telefone:
                {
                    if (textBox1.Text.Trim().Length.Equals(4))
                    {
                        textBox1.Text = textBox1.Text.Trim() + "-";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    break;
                }
                case TipoMascara.TelefoneDDD:
                {
                    if (textBox1.Text.Trim().Length.Equals(0))
                    {
                        textBox1.Text = textBox1.Text + "(";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    else if (textBox1.Text.Trim().Length.Equals(3))
                    {
                        textBox1.Text = textBox1.Text + ")";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    else if (textBox1.Text.Trim().Length.Equals(8))
                    {
                        textBox1.Text = textBox1.Text.Trim() + "-";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    break;
                }
                case TipoMascara.Cep:
                {
                    if (textBox1.Text.Trim().Length.Equals(5))
                    {
                        textBox1.Text = textBox1.Text + "-";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    break;
                }
                case TipoMascara.Cnpj:
                {
                    if (textBox1.Text.Trim().Length.Equals(2) || textBox1.Text.Trim().Length.Equals(6)) 
                    {
                        textBox1.Text = textBox1.Text.Trim() + ".";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    else if (textBox1.Text.Trim().Length.Equals(10))
                    {
                        textBox1.Text = textBox1.Text.Trim() + "/";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    else if (textBox1.Text.Trim().Length.Equals(15))
                    {
                        textBox1.Text = textBox1.Text.Trim() + "-";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    break;
                }
                case TipoMascara.Cpf:
                {
                    if (textBox1.Text.Trim().Length.Equals(3))
                    {
                        textBox1.Text = textBox1.Text.Trim() + ".";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    else if (textBox1.Text.Trim().Length.Equals(7))
                    {
                        textBox1.Text = textBox1.Text.Trim() + ".";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    else if (textBox1.Text.Trim().Length.Equals(11))
                    {
                        textBox1.Text = textBox1.Text.Trim() + "-";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    break;
                }

                case TipoMascara.Hora:
                {
                    if (textBox1.Text.Trim().Length.Equals(2))
                    {
                        textBox1.Text = textBox1.Text + ":";
                        textBox1.SelectionStart = textBox1.Text.Trim().Length + 1;
                    }
                    break;
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
