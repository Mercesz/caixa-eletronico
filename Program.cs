using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CaixaEletronico
{
    class Program
    {
        static List<ContaBancaria> contas = new List<ContaBancaria>();
        static string caminhoArquivo = "contas.json";

        static void Main(string[] args)
        {
            CarregarContas();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Caixa Eletrônico ===");
                Console.WriteLine("1. Criar Conta");
                Console.WriteLine("2. Fazer login");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CriarConta();
                        break;
                    case "2":
                        FazerLogin();
                        break;
                    case "0":
                        SalvarContas();
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        static void CriarConta()
        {
            Console.Clear();
            Console.WriteLine("=== Criar Conta ===");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            contas.Add(new ContaBancaria(nome, senha));
            SalvarContas();

            Console.WriteLine("Conta criada com sucesso!");
        }

        static void FazerLogin()
        {
            Console.Clear();
            Console.WriteLine("=== Fazer login ===");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            ContaBancaria conta = contas.Find(c => c.Nome == nome && c.Senha == senha);

            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada ou senha incorreta.");
                return;
            }

            Console.WriteLine($"Bem-vindo, {conta.Nome}!");
            MenuConta(conta);
        }

        static void MenuConta(ContaBancaria conta)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== Conta de {conta.Nome} ===");
                Console.WriteLine("1. Ver Saldo");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Sacar");
                Console.WriteLine("4. Encerrar Conta");
                Console.WriteLine("0. Sair da Conta");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        conta.ExibirSaldo();
                        break;
                    case "2":
                        Console.Write("Valor para depositar: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal dep))
                        {
                            conta.Depositar(dep);
                            SalvarContas();
                            Console.WriteLine("Depósito realizado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido para depósito.");
                        }
                        break;
                    case "3":
                        Console.Write("Valor para sacar: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal saque))
                        {
                            if (conta.Sacar(saque))
                            {
                                SalvarContas();
                                Console.WriteLine("Saque realizado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Saldo insuficiente para saque.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido para saque.");
                        }
                        break;
                    case "4":
                        contas.Remove(conta);
                        SalvarContas();
                        Console.WriteLine("Conta encerrada com sucesso!");
                        return;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        static void CarregarContas()
        {
            if (File.Exists(caminhoArquivo))
            {
                string json = File.ReadAllText(caminhoArquivo);
                contas = JsonSerializer.Deserialize<List<ContaBancaria>>(json);
            }
        }

        static void SalvarContas()
        {
            string json = JsonSerializer.Serialize(contas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminhoArquivo, json);
        }
    }
}
