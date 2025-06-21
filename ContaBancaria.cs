using System;

namespace CaixaEletronico
{
    public class ContaBancaria
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public decimal Saldo { get; private set; }

        public ContaBancaria(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
            Saldo = 0;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public bool Sacar(decimal valor)
        {
            if (valor > Saldo)
                return false;

            Saldo -= valor;
            return true;
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual: R${Saldo:F2}");
        }
    }
}
