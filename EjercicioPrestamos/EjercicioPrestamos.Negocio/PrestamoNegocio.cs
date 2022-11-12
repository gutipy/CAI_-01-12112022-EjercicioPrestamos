using EjercicioPrestamos.Datos;
using EjercicioPrestamos.Entidades;
using EjercicioPrestamos.Negocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrestamos.Negocio
{
    public class PrestamoNegocio
    {
        //Atributos
        private PrestamoMapper _prestamoMapper;

        //Constructores
        public PrestamoNegocio()
        {
            _prestamoMapper = new PrestamoMapper();
        }

        //Funciones-Métodos
        public List<Prestamo> GetListaPrestamos(string registro)
        {
            //Declaración de variables
            List<Prestamo> _totalPrestamos = new List<Prestamo>();

            _totalPrestamos = _prestamoMapper.Get(registro);

            foreach(Prestamo p in _totalPrestamos)
            {
                p.TipoPrestamo = TipoPrestamoFactory.Get(p.IdTipo);
            }

            return _totalPrestamos;
        }

        public void AgregarPrestamo(Prestamo nuevoPrestamo)
        {
            //Declaración de variables
            List<Prestamo> _totalPrestamos = new List<Prestamo>();
            int maxCapitalInicial = 1000000;

            _totalPrestamos = _prestamoMapper.Get(nuevoPrestamo.Usuario); //Guardo en la lista '_totalPrestamos' los datos de todos los prestamos por nro de registro que me trae la capa de Datos

            if (nuevoPrestamo == null) //Si el objeto que llega por parámetro es nulo se lo comunico al usuario mediante una excepción custom
            {
                throw new ObjetoInvalidoException("Prestamo");
            }

            else if (nuevoPrestamo.Monto > maxCapitalInicial) //Regla de negocio que implica que si un préstamo posee más de ARS $1.000.000 de Capital Inicial entonces le muestro una excepcion al user
            {
                throw new MaximoCapitalInicialException(maxCapitalInicial);
            }

            else if (TipoPrestamoFactory.Get(nuevoPrestamo.IdTipo) == null)
            {
                throw new TipoPrestamoInexistenteException();
            }

            else
            {
                TransactionResult transaction = _prestamoMapper.Insert(nuevoPrestamo); //Agrego el prestamo al repositorio de datos

                if (!transaction.IsOk) //Si la transacción no se pudo completar le comunico el error al usuario mediante una excepción
                {
                    throw new Exception(transaction.Error);
                }
            }
        }

    }
}
