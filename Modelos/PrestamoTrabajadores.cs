using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Modelos
{
    public class PrestamoTrabajadores
    {
        public int IdPrestamo { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public string Concepto { get; set; }
        public string Caja { get; set; }
        public string Autoriza { get; set; }
        public string Observacion { get; set; }
    }
}
