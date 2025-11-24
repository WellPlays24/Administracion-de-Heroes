using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosExcepciones:ApplicationException
    {

        public DatosExcepciones(string mensaje) : base(mensaje)
        {
        }

        public DatosExcepciones(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }

    }
}
