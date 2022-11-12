using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrestamos.Negocio.Excepciones
{
    public class TipoPrestamoInexistenteException : Exception
    {
        public TipoPrestamoInexistenteException() : base("El Tipo de prestamo indicado no corresponde a ningun tipo de préstamo válido, intente nuevamente.")
        {

        }
    }
}
