using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Modelos
{
    public class CuentaCobro
    {
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public decimal Valor { get; set; }
        public decimal Fichos { get; set; }
        public decimal OtrosServicios { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public int NumeroCuenta { get; set; }
        public string ValorLetras { get; set; }
        public decimal deuda { get; set; }
        public decimal TotalPago { get; set; }
    }
}
