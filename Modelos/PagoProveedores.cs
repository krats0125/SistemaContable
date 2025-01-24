using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Modelos
{
    public class PagoProveedores
    {
        public DateTime fechaIngreso { get; set; }
        public int idProveedor { get; set; }
        public decimal valor { get; set; }
        public decimal valorPagado { get; set; }
        public string Factura { get; set; }
        public bool Credito { get; set; }
        public decimal Descuento { get; set; }
        public string MedioPago { get; set; }
        public string Banco { get; set; }
        public bool Pagado { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public string Pagador { get; set; }
        public bool retencionFuente { get; set; }
        public decimal subtotal { get; set; }   
        public decimal porcentajeRetencion { get; set; }
        public decimal valorRetencion { get; set; }
        public string Nota { get; set; }
        public string Usuario { get; set; }
    }
}
