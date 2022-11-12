using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrestamos.Entidades
{
    public class Prestamo
    {
        //Atributos
        private string _linea;
        private double _tna;
        private int _plazo;
        private double _monto;
        private string _usuario;
        private int _idTipo;
        private int _id;
        private int _idCliente;
        private TipoPrestamo _tipoPrestamo;

        //Constructores
        public Prestamo(TipoPrestamo tipoPrestamo, int plazo, double monto, string usuario)
        {
            _tipoPrestamo = tipoPrestamo;
            _linea = tipoPrestamo.Linea;
            _tna = tipoPrestamo.Tna;
            _idTipo = tipoPrestamo.Id;
            _plazo = plazo;
            _monto = monto;
            _usuario = usuario;
        }
        //Propiedades
        public string Linea { get => _linea; set => _linea = value; }
        public double Tna { get => _tna; set => _tna = value; }
        public int Plazo { get => _plazo; set => _plazo = value; }
        public double Monto { get => _monto; set => _monto = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public int IdTipo { get => _idTipo; set => _idTipo = value; }
        public int Id { get => _id; set => _id = value; }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public TipoPrestamo TipoPrestamo { get => _tipoPrestamo; set => _tipoPrestamo = value; }
        public double CuotaCapital { get => Monto / Plazo; }
        public double CuotaInteres { get => CuotaCapital * (Tna / 12 / 100); }
        public double Cuota { get => CuotaCapital + CuotaInteres; }

        //Funciones-Métodos
        public override string ToString()
        {
            //id) Días  dias - ARS CapitalInicial (interés Interés) – tipo o (desc del tipo plazo fijo) - )
            return $"{Id}) {Plazo} días - ARS {Monto} ({CuotaInteres} Interés por cuota) - {Linea} - ";
        }
    }
}
