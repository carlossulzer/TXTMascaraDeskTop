using System;

/// <summary>
/// Summary description for Class1.
/// </summary>
public class ValidaCNPJ
{
	public ValidaCNPJ()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public static bool Validar(string cnpj)
	{
        int[] mult1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma;
        int resto;
        string digito;
        string tempCnpj;

        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        if (cnpj.Equals(string.Empty) || cnpj.Length != 14)
            return false;

        // Verifica se o valor é uma sequência repetida do mesmo número ex: 11111111111111
        bool seqRepetida = true;
        for (int x = 0; x <= cnpj.Length - 1; x++)
        {
            string caracter = cnpj.Substring(x, 1);
            if (x > 0 && caracter != cnpj.Substring(x - 1, 1))
                seqRepetida = false;
        }

        if (seqRepetida)
            return false;


        tempCnpj = cnpj.Substring(0, 12);

        soma = 0;
        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * mult1[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCnpj = tempCnpj + digito;
        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * mult2[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cnpj.EndsWith(digito);
    }
}

