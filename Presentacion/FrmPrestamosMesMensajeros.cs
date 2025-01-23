using SistemaContable.Repositorios.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.Presentacion
{
    public partial class FrmPrestamosMesMensajeros : Form
    {
        private string fechaInicio;
        private string fechaFin;
        public FrmPrestamosMesMensajeros(string fechaInicio,string fechaFin)
        {
            InitializeComponent();
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
        }

        private void FrmPrestamosMesMensajeros_Load(object sender, EventArgs e)
        {
            traerDeudas();
        }

        private void traerDeudas()
        {
            DateTime startDate = DateTime.Parse(fechaInicio);
            DateTime endDate = DateTime.Parse(fechaFin);

            // Generamos la consulta dinámica para el rango de fechas
            string query = BuildPivotQuery(startDate, endDate);

            // Ejecutamos la consulta y obtenemos los resultados
            var resultados = ExecuteQuery(query);

            // Limpiamos las filas previas en el DataGridView
            dgvPrestamosMes.Rows.Clear();

            // Definir las columnas del DataGridView dinámicamente
            dgvPrestamosMes.Columns.Clear();
            dgvPrestamosMes.Columns.Add("Nombre", "Nombre"); // Columna para el nombre del trabajador

            // Crear columnas para cada fecha en el rango (según la consulta PIVOT)
            DateTime currentDate = startDate;
            while (currentDate <= endDate)
            {
                string dateFormatted = currentDate.ToString("yyyy-MM-dd");
                dgvPrestamosMes.Columns.Add(dateFormatted, dateFormatted); // Columna para cada fecha
                currentDate = currentDate.AddDays(1);
            }

            // Agregar los resultados al DataGridView
            foreach (var resultado in resultados)
            {
                // Agregar una fila por cada resultado obtenido
                //dgvPrestamosMes.Rows.Add(resultado);
                // Crear una lista de objetos para la fila que se agregará
                List<object> fila = new List<object>();
                fila.Add(resultado[0]); // El nombre del trabajador es el primer valor (Índice 0)

                // Formatear los valores de las fechas como moneda
                for (int i = 1; i < resultado.Length; i++)  // Empieza desde el segundo elemento (los valores de las fechas)
                {
                    decimal valor = 0;
                    if (decimal.TryParse(resultado[i], out valor))
                    {
                        // Formatear como moneda en formato COP (puedes cambiar 'es-CO' por 'en-US' o el código regional que prefieras)
                        string valorComoMoneda = valor.ToString("C", new System.Globalization.CultureInfo("es-CO"));
                        fila.Add(valorComoMoneda);
                    }
                    else
                    {
                        fila.Add(resultado[i]); // Si no es un valor numérico, agregamos el valor tal cual
                    }
                }

                // Agregar la fila al DataGridView
                dgvPrestamosMes.Rows.Add(fila.ToArray());
            }

        }
        public static string BuildPivotQuery(DateTime startDate, DateTime endDate)
        {
            StringBuilder dateColumns = new StringBuilder();
            StringBuilder dateValues = new StringBuilder();
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                string dateFormatted = currentDate.ToString("yyyy-MM-dd");
                dateColumns.Append($"[{dateFormatted}], ");
                dateValues.Append($"[{dateFormatted}], ");

                currentDate = currentDate.AddDays(1);
            }

            if (dateColumns.Length > 0)
                dateColumns.Length -= 2;
            if (dateValues.Length > 0)
                dateValues.Length -= 2;

            string query = $@"
            SELECT 
            Nombre, 
            {dateValues} 
            FROM 
            (SELECT m.Nombre, pm.Valor, CONVERT(VARCHAR, pm.Fecha, 23) AS Fecha
             FROM PRESTAMOS_MENSAJEROS pm 
             INNER JOIN MENSAJEROS m ON pm.IdTrabajador = m.IdTrabajador
             WHERE pm.Fecha BETWEEN '{startDate:yyyy-MM-dd}' AND '{endDate:yyyy-MM-dd}') AS SourceTable
             PIVOT
            (SUM(Valor) FOR Fecha IN ({dateColumns})) AS PivotTable;";

            return query;
        }

        // Método para ejecutar la consulta y devolver los resultados
        public static List<string[]> ExecuteQuery(string query)
        {
            CONEXION conexion = new CONEXION();
            List<string[]> resultados = new List<string[]>();

            using (SqlConnection cn = new SqlConnection(conexion.conexionLaBodegaDeNacho()))
            {
                SqlCommand command = new SqlCommand(query, cn);
                cn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] row = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i].ToString();
                    }
                    resultados.Add(row);
                }
            }

            return resultados;
        }
    }
}
