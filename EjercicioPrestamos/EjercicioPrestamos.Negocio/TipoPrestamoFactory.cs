using EjercicioPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrestamos.Negocio
{
    public static class TipoPrestamoFactory
    {
        private static List<TipoPrestamo> _tipos;

        static TipoPrestamoFactory()
        {
            _tipos = new List<TipoPrestamo>();
            _tipos.Add(new TipoPrestamo("Préstamo Personal", 50, 1));
            _tipos.Add(new TipoPrestamo("Préstamo Hipotecario", 15, 2));
            _tipos.Add(new TipoPrestamo("Préstamo Empresas", 10, 3));
            _tipos.Add(new TipoPrestamo("Préstamo Prendario", 70, 4));
        }

        public static List<TipoPrestamo> Get()
        {
            return _tipos;
        }

        public static TipoPrestamo Get(int id)
        {
            return _tipos.SingleOrDefault(x => x.Id == id);
        }


    }
}
