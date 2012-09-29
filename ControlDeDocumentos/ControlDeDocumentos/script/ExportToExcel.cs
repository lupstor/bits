using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data;
namespace ControlDeDocumentos.script
{
    class ExportToExcel
    {

   
        public void exportaExcel(System.Windows.Forms.DataGridView dgvConsulta)
        {
            try
            {
                string temp;
                int iColumnas = 0;
                Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();//creo una aplicación Excel
                xlsApp.DisplayAlerts = false;
                Worksheet xlsSheet; //creo una hoja
                Workbook xlsBook; //creo un libro
                xlsApp.Visible = false; //la aplicación no es visible
                xlsBook = xlsApp.Workbooks.Add(true);//añado el libro a la aplicación
                xlsSheet = (Worksheet)xlsBook.ActiveSheet; //activo la hoja, para el libro
                //titulo
                xlsSheet.Cells[1, 1] = "Consulta De Documentos";
                xlsSheet.get_Range("A1","A1").Font.Bold = true;
                xlsSheet.get_Range("A1", "A1").Font.Size =22;

                for (int iCol = 0; iCol < dgvConsulta.Columns.Count; iCol++)
                {
                    if (dgvConsulta.Columns[iCol].Visible == true)
                    {
                        xlsSheet.Cells[3, iCol + 1] = dgvConsulta.Columns[iCol].HeaderText;
                        iColumnas++;
                    }
                }

                int fila = 4;
                
                for (int iRow = 0; iRow < dgvConsulta.Rows.Count; iRow++)
                {
                 
                    for (int iCol = 0; iCol < dgvConsulta.Columns.Count; iCol++)
                    {
                        if (dgvConsulta.Columns[iCol].Visible == true)
                        {
                            temp = dgvConsulta[iCol, iRow].Value.ToString();
                            xlsSheet.Cells[iRow + 4, iCol + 1] = temp;
                        }
                    }
                    xlsSheet.get_Range("A" + fila, "W" + fila).HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    if ((fila % 2) == 0) {
                        xlsSheet.get_Range("A" + fila, "W" + fila).Interior.ColorIndex = 37;
                    }
                    fila++;
                }

               //Formato De Celdas
                xlsSheet.get_Range("A4", "W" + (fila - 1)).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                xlsSheet.get_Range("A4", "W" + (fila - 1)).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                xlsSheet.get_Range("A4", "W" + (fila - 1)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                xlsSheet.get_Range("A4", "W" + (fila - 1)).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                xlsSheet.get_Range("A4", "W" + (fila - 1)).Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
                xlsSheet.get_Range("A4", "W" + (fila - 1)).Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
                         
                xlsSheet.get_Range("A3","W3").Font.Bold = true;
                xlsSheet.get_Range("A3", "W3").BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, XlColorIndex.xlColorIndexAutomatic);
                xlsSheet.get_Range("A3", "W3").Interior.ColorIndex = 23;
                xlsSheet.get_Range("A3", "W3").Font.ColorIndex = 2; 
                xlsSheet.Columns.AutoFit(); //Ajusta ancho de todas las columnas 
             
                xlsApp.Visible = true;
              
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error al exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void exportQuery(String query,String tabla) {
                try
                {
                    Microsoft.Office.Interop.Excel.Application xlsApp = new Microsoft.Office.Interop.Excel.Application();//creo una aplicación Excel
                    xlsApp.DisplayAlerts = false;
                    Worksheet xlsSheet; //creo una hoja
                    Workbook xlsBook; //creo un libro
                    xlsApp.Visible = false; //la aplicación no es visible
                    xlsBook = xlsApp.Workbooks.Add(true);//añado el libro a la aplicación
                    xlsSheet = (Worksheet)xlsBook.ActiveSheet; //activo la hoja, para el libro
                    //titulo
                    xlsSheet.Cells[1, 1] = "Reporte De " +tabla;
                    xlsSheet.get_Range("A1", "A1").Font.Bold = true;
                    xlsSheet.get_Range("A1", "A1").Font.Size = 22;


                    xlsSheet.Cells[3, 1] = "Documento";
                    xlsSheet.Cells[3, 2] = "Edición";
                    xlsSheet.Cells[3, 3] = "Id " +tabla;
                    xlsSheet.Cells[3, 4] = "Nombre";
                    xlsSheet.Cells[3, 5] = "Referencia";
                    int fila = 4;

                     DataSet ds = DataManager.selTab(query, tabla);
                     foreach (DataRow row in ds.Tables[tabla].Rows)
                     {
                         xlsSheet.Cells[fila ,1] = row[0].ToString();
                         xlsSheet.Cells[fila, 2] = row[1].ToString();
                         xlsSheet.Cells[fila, 3] = row[2].ToString() + "/" + maskField(row[3].ToString()) +"-"+row[4].ToString();
                         xlsSheet.Cells[fila, 4] = row[5].ToString();
                         xlsSheet.Cells[fila, 5] = row[6].ToString();

                         xlsSheet.get_Range("A" + fila, "E" + fila).HorizontalAlignment = XlHAlign.xlHAlignLeft;
                         if ((fila % 2) == 0)
                         {
                             xlsSheet.get_Range("A" + fila, "E" + fila).Interior.ColorIndex = 37;
                         }
                         fila++;
                     }
                    //Formato De Celdas
                    xlsSheet.get_Range("A4", "E" + (fila - 1)).Borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
                    xlsSheet.get_Range("A4", "E" + (fila - 1)).Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                    xlsSheet.get_Range("A4", "E" + (fila - 1)).Borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
                    xlsSheet.get_Range("A4", "E" + (fila - 1)).Borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
                    xlsSheet.get_Range("A4", "E" + (fila - 1)).Borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
                    xlsSheet.get_Range("A4", "E" + (fila - 1)).Borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;

                    xlsSheet.get_Range("A3", "E3").Font.Bold = true;
                    xlsSheet.get_Range("A3", "E3").BorderAround(XlLineStyle.xlContinuous, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, XlColorIndex.xlColorIndexAutomatic);
                    xlsSheet.get_Range("A3", "E3").Interior.ColorIndex = 23;
                    xlsSheet.get_Range("A3", "E3").Font.ColorIndex = 2;
                    xlsSheet.Columns.AutoFit(); //Ajusta ancho de todas las columnas 

                    xlsApp.Visible = true;

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error al exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        public String maskField(String value)
        {
            if (value.Length == 1)
            {
                return "0" + value;
            }
            else
            {
                return value;
            }
        }
    }
}
