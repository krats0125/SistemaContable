using iTextSharp.text.pdf;
using iTextSharp.text;
using SistemaContable.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SistemaContable.Repositorios.Utilitarios;

namespace SistemaContable.Repositorios
{
    public class CuentaDeCobroRepository
    {
        CONEXION conexion = new CONEXION();
        ConvertirRepository convertir = new ConvertirRepository();
        public void GenerarPDF(CuentaCobro cuentaCobro, string rutaArchivo)
        {
            try
            {
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
                {
                    Document documento = new Document(PageSize.LETTER, 50, 50, 50, 50);
                    PdfWriter writer = PdfWriter.GetInstance(documento, fs);

                    documento.Open();

                    //Image logo = Image.GetInstance(rutaLogo);
                    //logo.ScaleToFit(100, 100); // Ajustar tamaño del logo
                    //logo.Alignment = Image.ALIGN_LEFT;
                    //documento.Add(logo);

                    // Fuentes personalizadas
                    Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                    Font fuenteTexto = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                    Font fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                    Paragraph numeroCuenta = new Paragraph($"CUENTA DE COBRO N° {cuentaCobro.NumeroCuenta}\n\n", fuenteTexto);
                    numeroCuenta.Alignment = Element.ALIGN_RIGHT;
                    documento.Add(numeroCuenta);
                    // Fecha y número de cuenta de cobro
                    Paragraph fecha = new Paragraph($"{cuentaCobro.Fecha:dddd, dd MMMM yyyy}\n", fuenteTexto);
                    fecha.Alignment = Element.ALIGN_LEFT;
                    documento.Add(fecha);

                    // Encabezado de texto (se ajusta para dejar espacio al logo)
                    Paragraph encabezado = new Paragraph("LOPEZ HIGUITA S.A.S\nNIT: 900329895-1\n\n", fuenteTitulo);
                    encabezado.Alignment = Element.ALIGN_CENTER;
                    documento.Add(encabezado);

                    // Datos del destinatario
                    Paragraph destinatario = new Paragraph($"DEBE A:\n\n{cuentaCobro.Nombre.ToUpper()}\n" +
                        $"Identificado con el número N° {cuentaCobro.Documento}\n\n", fuenteTexto);
                    destinatario.Alignment = Element.ALIGN_CENTER;
                    documento.Add(destinatario);

                    // Valor y concepto
                    Paragraph valor = new Paragraph($"La suma de: {cuentaCobro.TotalPago.ToString("C0")}", fuenteNegrita);
                    valor.Alignment = Element.ALIGN_CENTER;
                    documento.Add(valor);

                    cuentaCobro.ValorLetras = ConvertirRepository.ConvertirNumeroALetras(cuentaCobro.TotalPago); ;
                    Paragraph PagoEnLetras = new Paragraph($"({cuentaCobro.ValorLetras.ToUpper()})\n\n", fuenteTexto);
                    PagoEnLetras.Alignment = Element.ALIGN_CENTER;
                    documento.Add(PagoEnLetras);

                    Paragraph concepto = new Paragraph($"Por concepto de:\n\n{cuentaCobro.Concepto}\n\n", fuenteTexto);
                    concepto.Alignment = Element.ALIGN_CENTER;
                    documento.Add(concepto);

                    // Pie de página
                    Paragraph texto = new Paragraph("Favor entregar el pago en efectivo\n\n", fuenteTexto);
                    texto.Alignment = Element.ALIGN_CENTER;
                    documento.Add(texto);

                    Paragraph texto2 = new Paragraph("Cordialmente,\n\n\n", fuenteTexto);
                    texto2.Alignment = Element.ALIGN_LEFT;
                    documento.Add(texto2);

                    Paragraph firma = new Paragraph(new Chunk("__________________________________", fuenteNegrita));
                    firma.Alignment = Element.ALIGN_LEFT;
                    documento.Add(firma);

                    Paragraph textoFirma = new Paragraph($"{cuentaCobro.Nombre}\n{cuentaCobro.Documento}\n\n\n", fuenteNegrita);
                    textoFirma.Alignment = Element.ALIGN_LEFT;
                    documento.Add(textoFirma);

                    Paragraph textoFinal = new Paragraph("Certifico que no he contratado o vinculado 2 o más empleados relacionados con mi actividad económica, por lo tanto, no efectuar retención en la fuente según el artículo 383 del estatuto tributario.", fuenteTexto);
                    textoFinal.Alignment = Element.ALIGN_CENTER;
                    documento.Add(textoFinal);

                    // Cerrar el documento
                    documento.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el PDF: " + ex.Message);
            }
        }


        public int hallarCuentaCobro(Trabajador trabajador)
        {
            int numeroCuenta = 0;
            try
            {
                string consulta = "select COUNT(Id_Mensajero) from tbl_PagoMensajeros where Nombre = @Nombre and Id_Mensajero=@Documento";

                using (SqlConnection cn=new SqlConnection(conexion.conexionLaBodegaDeNacho()))
                {
                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrEmpty(trabajador.Nombre) ? DBNull.Value : (object)trabajador.Nombre);
                        cmd.Parameters.AddWithValue("@Documento", string.IsNullOrEmpty(trabajador.Documento) ? DBNull.Value : (object)trabajador.Documento);
                        cn.Open();
                        object result= Convert.ToInt32(cmd.ExecuteScalar());
                        numeroCuenta = Convert.ToInt32(result)+1;

                    }

                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al hallar la cuenta de cobro: " + ex.Message);
            }
            return numeroCuenta;
        }
    }
}
