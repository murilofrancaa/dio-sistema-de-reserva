using SistemaReserva.Modelos;
using SistemaReserva.Servicos;
using System;
using System.Collections.Generic;

namespace SistemaReserva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServicoReservas servico = new ServicoReservas();

            List<Quarto> quartos = new List<Quarto>
            {
                new Quarto(101, "Luxo", 300),
                new Quarto(102, "Standard", 200),
                new Quarto(103, "Luxo", 350),
                new Quarto(104, "Standard", 180)
            };

            while (true)
            {
                Console.WriteLine("=== Sistema de Reservas ===");
                Console.WriteLine("1 - Criar Reserva");
                Console.WriteLine("2 - Listar Reservas");
                Console.WriteLine("3 - Fazer Check-out");
                Console.WriteLine("4 - Listar Quartos Disponíveis");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        try
                        {
                            Console.Write("Nome do hóspede: ");
                            string nome = Console.ReadLine();

                            Console.Write("Documento (CPF): ");
                            string documento = Console.ReadLine();

                            Console.Write("Telefone: ");
                            string telefone = Console.ReadLine();

                            Hospede hospede = new Hospede(nome, documento, telefone);

                            Console.WriteLine("Quartos disponíveis:");
                            foreach (var q in servico.ListarQuartosDisponiveis(quartos))
                            {
                                Console.WriteLine(q);
                            }

                            Console.Write("Número do quarto: ");
                            int numeroQuarto = int.Parse(Console.ReadLine());
                            Quarto quartoSelecionado = quartos.Find(q => q.NumeroQuarto == numeroQuarto);

                            Console.Write("Data de entrada (dd/MM/yyyy): ");
                            DateTime entrada = DateTime.Parse(Console.ReadLine());

                            Console.Write("Data de saída (dd/MM/yyyy): ");
                            DateTime saida = DateTime.Parse(Console.ReadLine());

                            Reserva reserva = new Reserva(hospede, quartoSelecionado, entrada, saida);
                            servico.AdicionarReserva(reserva);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro: {ex.Message}");
                        }
                        break;

                    case "2":
                        servico.ListarReservas();
                        break;

                    case "3":
                        Console.Write("Informe o número do quarto para check-out: ");
                        int numQuartoCheckOut = int.Parse(Console.ReadLine());
                        Reserva reservaCheckOut = servico.BuscarReservaPorNumeroQuarto(numQuartoCheckOut);
                        if (reservaCheckOut != null)
                        {
                            servico.FazerCheckOut(reservaCheckOut);
                        }
                        else
                        {
                            Console.WriteLine("Reserva não encontrada.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Quartos disponíveis:");
                        foreach (var q in servico.ListarQuartosDisponiveis(quartos))
                        {
                            Console.WriteLine(q);
                        }
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
