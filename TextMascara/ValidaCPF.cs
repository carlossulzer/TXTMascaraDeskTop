using System;


/// <summary>
/// Summary description for ValidaCPF.
/// </summary>
public static class ValidaCPF
{


	public static bool Validar(string cpf)
	{
        int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Equals(string.Empty) || cpf.Length != 11)
            return false;

        // Verifica se o valor é uma sequência repetida do mesmo número ex: 11111111111
        bool seqRepetida = true;
        for (int x = 0; x <= cpf.Length - 1; x++)
        {
            string caracter = cpf.Substring(x, 1);
            if (x > 0 && caracter != cpf.Substring(x - 1, 1))
                seqRepetida = false;
        }

        if (seqRepetida)
            return false;


        tempCpf = cpf.Substring(0, 9);
        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * mult1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCpf = tempCpf + digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * mult2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
	}
}

