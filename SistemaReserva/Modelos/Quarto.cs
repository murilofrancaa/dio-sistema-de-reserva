using SistemaReserva.Modelos.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SistemaReserva.Modelos
{
    public class Quarto
    {

        public int NumeroQuarto { get; private set; }

        public string TipoQuarto { get; private set; }

        public decimal PrecoPorNoite { get; private set; }

        public bool Disponivel { get; private set; }

        public Quarto(int numero, string tipo, decimal preco, bool disponivel = true)
        {
            NumeroQuarto = numero;
            TipoQuarto = tipo;
            PrecoPorNoite = preco;
            Disponivel = disponivel;

            if (preco <= 0) { throw new ArgumentException("O preço da diária deve ser maior que zero. " +
               "Informe um valor válido para o quarto."); }
        }

        public void Ocupar()
        {
            if (!Disponivel)
            {
                throw new QuartoIndisponivelException("O quarto já está ocupado.");

            }

            Disponivel = false;

        }

        public void Liberar()
        {
            Disponivel = true;

            Console.WriteLine($"Quarto {NumeroQuarto} liberado com sucesso!");
        }

        public override string ToString()
        {

            string status = Disponivel ? "Sim" : "Não";
            return $"Quarto {NumeroQuarto} - Tipo: {TipoQuarto} | R${PrecoPorNoite} por noite | Disponível: {status}";
        }
    }
}

     

