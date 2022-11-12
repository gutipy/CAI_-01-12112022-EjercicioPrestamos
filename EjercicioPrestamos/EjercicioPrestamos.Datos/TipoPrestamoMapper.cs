using EjercicioPrestamos.Datos.Utilidades;
using EjercicioPrestamos.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPrestamos.Datos
{
    public class TipoPrestamoMapper
    {
        public List<TipoPrestamo> Get()
        {
            string json2 = WebHelper.Get("/prestamotipo");
            List<TipoPrestamo> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insert(TipoPrestamo tipoprestamo)
        {
            NameValueCollection obj = ReverseMap(tipoprestamo);

            string result = WebHelper.Post("/api/v1/prestamo", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        private List<TipoPrestamo> MapList(string json)
        {
            List<TipoPrestamo> lst = JsonConvert.DeserializeObject<List<TipoPrestamo>>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(TipoPrestamo tipoprestamo)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Tna", tipoprestamo.Tna.ToString("0.00"));
            n.Add("Linea", tipoprestamo.Linea);
            n.Add("Id", tipoprestamo.Id.ToString());

            return n;
        }

        private TransactionResult MapResultado(string json)
        {
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }
    }
}
