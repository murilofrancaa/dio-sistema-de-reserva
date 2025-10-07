using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaReserva.Modelos;
using SistemaReserva.Modelos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaReserva.Servicos
{
    public class ServicoReservas
    {
        private List<Reserva> Reservas { get; set; } = new List<Reserva>();

        public void AdicionarReserva(Reserva reserva)
        {
            try
            {
                Reservas.Add(reserva);
                Console.WriteLine("Reserva adicionada com sucesso!");
            }
            catch (QuartoIndisponivelException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (ReservaInvalidaException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void ListarReservas()
        {
            if (!Reservas.Any())
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
                return;
            }

            foreach (var reserva in Reservas)
            {
                Console.WriteLine(reserva);
                Console.WriteLine("-------------------------");
            }
        }

        public void FazerCheckOut(Reserva reserva)
        {
            if (Reservas.Contains(reserva))
            {
                reserva.Quarto.Liberar();
                Reservas.Remove(reserva);
                Console.WriteLine("Check-out realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Reserva não encontrada.");
            }
        }

        public List<Reserva> BuscarReservasPorHospede(string nomeHospede)
        {
            return Reservas
                    .Where(r => r.Hospede.Nome.Equals(nomeHospede, StringComparison.OrdinalIgnoreCase))
                    .ToList();
        }

        public List<Quarto> ListarQuartosDisponiveis(List<Quarto> todosQuartos)
        {
            return todosQuartos.Where(q => q.Disponivel).ToList();
        }
    }
}

