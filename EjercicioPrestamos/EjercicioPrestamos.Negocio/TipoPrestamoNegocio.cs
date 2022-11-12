using EjercicioPrestamos.Datos;
using EjercicioPrestamos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrestamos.Negocio
{
    public class TipoPrestamoNegocio
    {
        //Atributos
        private TipoPrestamoMapper _tipoPrestamoMapper;

        //Constructores
        public TipoPrestamoNegocio()
        {
            _tipoPrestamoMapper = new TipoPrestamoMapper();
        }

        //Funciones-Métodos
        public List<TipoPrestamo> GetListaTipoPrestamos()
        {
            //Declaración de variables
            List<TipoPrestamo> _totalTipoPrestamos = new List<TipoPrestamo>();

            _totalTipoPrestamos = _tipoPrestamoMapper.Get();

            return _totalTipoPrestamos;
        }

        public void AgregarTipoPrestamo(TipoPrestamo nuevoTipoPrestamo)
        {

        }
    }
}
