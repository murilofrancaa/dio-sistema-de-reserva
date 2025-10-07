using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReserva.Modelos.Excecoes
{
    public class ReservaInvalidaException : Exception
    {
        public ReservaInvalidaException(string mensagem) : base(mensagem) { }
           
        
        
    }
}
