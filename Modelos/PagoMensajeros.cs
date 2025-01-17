using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaContable.Modelos
{
    public class PagoMensajeros
    {
        public decimal Deuda { get; set; }
        public decimal FichosSemana { get; set; }
        public decimal FichosValorS { get; set; }
        public decimal FichosDomingo { get; set; }
        public decimal FichosValorD { get; set; }
        public decimal FichosTotales { get; set; }
        public decimal OtrosServicios { get; set; }
        public decimal Pendiente { get; set; }
        public decimal Valor { get; set; }
        public decimal TotalPago { get; set; }

        public void calcularPago(bool aprobo)
        {
            if (aprobo)
            {
                FichosValorS = FichosSemana * 2000;
                FichosValorD =FichosDomingo* 2000;
            }
            else
            {
                FichosValorS = FichosSemana * 1500;
                FichosValorD = FichosDomingo * 1800;
            }
            TotalPago = (FichosValorS + FichosValorD + OtrosServicios) - Pendiente - Deuda;
            FichosTotales = FichosSemana + FichosDomingo;
            Valor = FichosValorD + FichosValorS;
        }

    }
}
