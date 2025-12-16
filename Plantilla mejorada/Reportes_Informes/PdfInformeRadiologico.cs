using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.IO;
using System.Windows.Forms;

namespace Borrador
{
    public static class PdfInformeRadiologico
    {
        public static void Generar(
            int idInforme,
            string paciente,
            string tipoEstudio,
            DateTime fechaEstudio,
            DateTime fechaInforme,
            string radiologo,
            string descripcionHallazgos,
            string conclusionDiagnostica,
            string estadoInforme,
            string medicoSolicitante = "",
            string salaEquipo = "",
            string observaciones = ""
        )
        {
            try
            {
                string ruta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"InformeRadiologico_{idInforme}_{paciente.Replace(" ", "_")}_{DateTime.Now:yyyyMMddHHmm}.pdf"
                );

                Document doc = new Document(PageSize.A4, 40, 40, 50, 50);
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // ==== FUENTES ====
                Font titulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, new BaseColor(64, 64, 64));
                Font subtitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, new BaseColor(52, 73, 94));
                Font normal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                Font negrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                Font pequeño = FontFactory.GetFont(FontFactory.HELVETICA, 8, new BaseColor(128, 128, 128));

                // ==== ENCABEZADO PRINCIPAL ====
                Paragraph encabezado = new Paragraph("INFORME RADIOLÓGICO", titulo);
                encabezado.Alignment = Element.ALIGN_CENTER;
                encabezado.SpacingAfter = 5;
                doc.Add(encabezado);

                Paragraph subencabezado = new Paragraph("Departamento de Imagenología",
                    FontFactory.GetFont(FontFactory.HELVETICA, 11, new BaseColor(128, 128, 128)));
                subencabezado.Alignment = Element.ALIGN_CENTER;
                subencabezado.SpacingAfter = 20;
                doc.Add(subencabezado);

                // ==== LÍNEA SEPARADORA ====
                doc.Add(new Chunk(new LineSeparator(1f, 100f, new BaseColor(211, 211, 211), Element.ALIGN_CENTER, -2)));
                doc.Add(new Paragraph(" "));

                // ==== INFORMACIÓN DEL INFORME ====
                PdfPTable infoInforme = new PdfPTable(2);
                infoInforme.WidthPercentage = 100;
                infoInforme.SetWidths(new float[] { 35, 65 });
                infoInforme.SpacingAfter = 15;

                AgregarCeldaInfo(infoInforme, "ID Informe:", idInforme.ToString(), negrita, normal);
                AgregarCeldaInfo(infoInforme, "Estado:", estadoInforme, negrita, normal);
                AgregarCeldaInfo(infoInforme, "Fecha de Informe:", fechaInforme.ToString("dd/MM/yyyy HH:mm"), negrita, normal);

                doc.Add(infoInforme);

                // ==== DATOS DEL PACIENTE ====
                doc.Add(new Paragraph("DATOS DEL PACIENTE", subtitulo));
                doc.Add(new Paragraph(" "));

                PdfPTable datosPaciente = new PdfPTable(2);
                datosPaciente.WidthPercentage = 100;
                datosPaciente.SetWidths(new float[] { 35, 65 });
                datosPaciente.SpacingAfter = 15;

                AgregarCeldaInfo(datosPaciente, "Paciente:", paciente, negrita, normal);
                if (!string.IsNullOrWhiteSpace(medicoSolicitante))
                {
                    AgregarCeldaInfo(datosPaciente, "Médico Solicitante:", medicoSolicitante, negrita, normal);
                }

                doc.Add(datosPaciente);

                // ==== DATOS DEL ESTUDIO ====
                doc.Add(new Paragraph("DATOS DEL ESTUDIO", subtitulo));
                doc.Add(new Paragraph(" "));

                PdfPTable datosEstudio = new PdfPTable(2);
                datosEstudio.WidthPercentage = 100;
                datosEstudio.SetWidths(new float[] { 35, 65 });
                datosEstudio.SpacingAfter = 15;

                AgregarCeldaInfo(datosEstudio, "Tipo de Estudio:", tipoEstudio, negrita, normal);
                AgregarCeldaInfo(datosEstudio, "Fecha del Estudio:", fechaEstudio.ToString("dd/MM/yyyy HH:mm"), negrita, normal);
                if (!string.IsNullOrWhiteSpace(salaEquipo))
                {
                    AgregarCeldaInfo(datosEstudio, "Sala/Equipo:", salaEquipo, negrita, normal);
                }
                AgregarCeldaInfo(datosEstudio, "Radiólogo Informante:", radiologo, negrita, normal);

                doc.Add(datosEstudio);

                // ==== HALLAZGOS ====
                doc.Add(new Paragraph("DESCRIPCIÓN DE HALLAZGOS", subtitulo));
                doc.Add(new Paragraph(" "));

                PdfPTable tablaHallazgos = new PdfPTable(1);
                tablaHallazgos.WidthPercentage = 100;
                tablaHallazgos.SpacingAfter = 15;

                PdfPCell cellHallazgos = new PdfPCell(new Phrase(
                    string.IsNullOrWhiteSpace(descripcionHallazgos) ? "Sin hallazgos registrados." : descripcionHallazgos,
                    normal
                ));
                cellHallazgos.MinimumHeight = 80;
                cellHallazgos.Padding = 10;
                cellHallazgos.BackgroundColor = new BaseColor(250, 250, 250);
                cellHallazgos.BorderColor = new BaseColor(200, 200, 200);
                tablaHallazgos.AddCell(cellHallazgos);

                doc.Add(tablaHallazgos);

                // ==== CONCLUSIÓN DIAGNÓSTICA ====
                doc.Add(new Paragraph("CONCLUSIÓN DIAGNÓSTICA", subtitulo));
                doc.Add(new Paragraph(" "));

                PdfPTable tablaConclusiones = new PdfPTable(1);
                tablaConclusiones.WidthPercentage = 100;
                tablaConclusiones.SpacingAfter = 15;

                PdfPCell cellConclusiones = new PdfPCell(new Phrase(
                    string.IsNullOrWhiteSpace(conclusionDiagnostica) ? "Sin conclusión registrada." : conclusionDiagnostica,
                    normal
                ));
                cellConclusiones.MinimumHeight = 60;
                cellConclusiones.Padding = 10;
                cellConclusiones.BackgroundColor = new BaseColor(245, 248, 255);
                cellConclusiones.BorderColor = new BaseColor(52, 73, 94);
                cellConclusiones.BorderWidth = 1.5f;
                tablaConclusiones.AddCell(cellConclusiones);

                doc.Add(tablaConclusiones);

                // ==== OBSERVACIONES (OPCIONAL) ====
                if (!string.IsNullOrWhiteSpace(observaciones))
                {
                    doc.Add(new Paragraph("OBSERVACIONES ADICIONALES", subtitulo));
                    doc.Add(new Paragraph(" "));

                    PdfPTable tablaObs = new PdfPTable(1);
                    tablaObs.WidthPercentage = 100;
                    tablaObs.SpacingAfter = 15;

                    PdfPCell cellObs = new PdfPCell(new Phrase(observaciones, normal));
                    cellObs.MinimumHeight = 40;
                    cellObs.Padding = 10;
                    cellObs.BackgroundColor = new BaseColor(255, 255, 240);
                    cellObs.BorderColor = new BaseColor(200, 200, 200);
                    tablaObs.AddCell(cellObs);

                    doc.Add(tablaObs);
                }

                // ==== FIRMA Y PIE DE PÁGINA ====
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph(" "));

                // Línea para firma
                Paragraph firmaLinea = new Paragraph("_________________________________", normal);
                firmaLinea.Alignment = Element.ALIGN_CENTER;
                doc.Add(firmaLinea);

                Paragraph firmaNombre = new Paragraph(radiologo, negrita);
                firmaNombre.Alignment = Element.ALIGN_CENTER;
                doc.Add(firmaNombre);

                Paragraph firmaCargo = new Paragraph("Radiólogo Informante", normal);
                firmaCargo.Alignment = Element.ALIGN_CENTER;
                firmaCargo.SpacingAfter = 20;
                doc.Add(firmaCargo);

                // ==== FOOTER ====
                doc.Add(new Chunk(new LineSeparator(0.5f, 100f, new BaseColor(211, 211, 211), Element.ALIGN_CENTER, -2)));

                Paragraph footer = new Paragraph(
                    $"Documento generado el {DateTime.Now:dd/MM/yyyy HH:mm} | ID Informe: {idInforme}",
                    pequeño
                );
                footer.Alignment = Element.ALIGN_CENTER;
                footer.SpacingBefore = 10;
                doc.Add(footer);

                Paragraph confidencial = new Paragraph(
                    "Este documento contiene información médica confidencial",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 7, new BaseColor(128, 128, 128))
                );
                confidencial.Alignment = Element.ALIGN_CENTER;
                doc.Add(confidencial);

                doc.Close();

                MessageBox.Show($"PDF generado correctamente en el Escritorio:\n{Path.GetFileName(ruta)}",
                    "PDF Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el PDF automáticamente
                System.Diagnostics.Process.Start(ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF del Informe Radiológico:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== MÉTODOS AUXILIARES ==================

        private static void AgregarCeldaInfo(
            PdfPTable tabla,
            string etiqueta,
            string valor,
            Font fontEtiqueta,
            Font fontValor
        )
        {
            PdfPCell cellEtiqueta = new PdfPCell(new Phrase(etiqueta, fontEtiqueta));
            cellEtiqueta.Border = Rectangle.NO_BORDER;
            cellEtiqueta.Padding = 5;
            cellEtiqueta.BackgroundColor = new BaseColor(245, 245, 245);
            tabla.AddCell(cellEtiqueta);

            PdfPCell cellValor = new PdfPCell(new Phrase(valor, fontValor));
            cellValor.Border = Rectangle.NO_BORDER;
            cellValor.Padding = 5;
            tabla.AddCell(cellValor);
        }
    }
}