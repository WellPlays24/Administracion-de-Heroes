using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaExcepciones:ApplicationException
    {
        public LogicaExcepciones(string mensaje) : base(mensaje)
        {
        }

        public LogicaExcepciones(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }


    }
}
