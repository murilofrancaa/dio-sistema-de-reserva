using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReserva.Modelos
{
    public class Hospede
    {
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Telefone { get; private set; }

        public Hospede(string nome, string documento, string telefone) 
        { 
            

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(documento) || string.IsNullOrWhiteSpace(telefone))
            {
                throw new ArgumentException("Todos os campos do hóspede são obrigatórios. Verifique o nome, documento e telefone.");
            }

            
            string documentoLimpo = new string(documento.Where(char.IsDigit).ToArray());

            if (documentoLimpo.Length != 11)
            {
                throw new ArgumentException("CPF inválido. Deve conter 11 dígitos numéricos.");
            }

            Nome = nome;
            Documento = documentoLimpo;
            Telefone = telefone;

        }
        public override string ToString()
        {
            return $"Hóspede: {Nome} (Documento: {Documento}) | Telefone: {Telefone}";
        }
    }
}
