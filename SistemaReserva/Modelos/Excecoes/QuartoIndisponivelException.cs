using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReserva.Modelos.Excecoes
{
    public class QuartoIndisponivelException : Exception
    {
        public QuartoIndisponivelException(string message) : base(message) { }
    }
}
