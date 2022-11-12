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
    public class PrestamoMapper
    {
        public List<Prestamo> Get(string registro)
        {
            string json2 = WebHelper.Get("/prestamo/" + registro);
            List<Prestamo> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insert(Prestamo prestamo)
        {
            NameValueCollection obj = ReverseMap(prestamo);

            string result = WebHelper.Post("/prestamo/", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        private List<Prestamo> MapList(string json)
        {
            List<Prestamo> lst = JsonConvert.DeserializeObject<List<Prestamo>>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(Prestamo prestamo)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("Id", prestamo.Id.ToString());
            n.Add("Tna", prestamo.Tna.ToString("0.00"));
            n.Add("Linea", prestamo.Linea);
            n.Add("Plazo", prestamo.Plazo.ToString());
            n.Add("Id Cliente", prestamo.IdCliente.ToString());
            n.Add("Id Tipo", prestamo.IdTipo.ToString());
            n.Add("Monto", prestamo.Monto.ToString("0.00"));
            n.Add("Cuota", prestamo.Cuota.ToString());
            n.Add("Usuario", prestamo.Usuario);
            n.Add("Tipo Prestamo TNA", prestamo.Tna.ToString("0.00"));
            n.Add("Tipo Prestamo Linea", prestamo.Linea);
            n.Add("Tipo Prestamo ID", prestamo.IdTipo.ToString());


            return n;
        }

        private TransactionResult MapResultado(string json)
        {
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }
    }
}
