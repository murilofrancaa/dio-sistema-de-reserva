using SistemaReserva.Modelos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReserva.Modelos
{
    public class Reserva
    {
        public Hospede Hospede { get; private set; }
        public Quarto Quarto { get; private set; }

        public DateTime DataEntrada { get; private set; }
        public DateTime DataSaida { get; private set; }


        public Reserva(Hospede hospede, Quarto quarto, DateTime dataEntrada, DateTime dataSaida)
        {
            if (dataSaida <= dataEntrada)
            {
                throw new ReservaInvalidaException("A data de saída deve ser posterior à data de entrada.");
            }

            if (!quarto.Disponivel)
            {
                throw new QuartoIndisponivelException("O quarto selecionado não está disponível.");
            }

            Hospede = hospede;
            Quarto = quarto;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;

            
            quarto.Ocupar();
        }

        public decimal CalcularValorTotal()
        {
            int dias = (DataSaida - DataEntrada).Days;

            if (dias <= 0)
            {
                throw new ReservaInvalidaException("A reserva deve ter pelo menos uma diária.");
            }

            return dias * Quarto.PrecoPorNoite;
        }

        public override string ToString()
        {
            decimal total = CalcularValorTotal();

            return $"Reserva de {Hospede.Nome}\n" +
                   $"Quarto {Quarto.NumeroQuarto} - {Quarto.TipoQuarto}\n" +
                   $"Entrada: {DataEntrada:dd/MM/yyyy} | Saída: {DataSaida:dd/MM/yyyy}\n" +
                   $"Total: R${total:F2}";
        }
    }
}
