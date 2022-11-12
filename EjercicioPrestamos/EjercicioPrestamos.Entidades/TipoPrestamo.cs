using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrestamos.Entidades
{
    public class TipoPrestamo
    {
        //Atributos
        private string _linea;
        private double _tna;
        private int _id;

        //Constructores
        public TipoPrestamo(string linea, double tna, int id)
        {
            _linea = linea;
            _tna = tna;
            _id = id;
        }

        //Propiedades
        public string Linea { get => _linea; set => _linea = value; }
        public double Tna { get => _tna; set => _tna = value; }
        public int Id { get => _id; set => _id = value; }

        //Funciones-Métodos
        public override string ToString()
        {
            return $"{Id} - {Linea} - Tasa {Tna}%";
        }
    }
}
