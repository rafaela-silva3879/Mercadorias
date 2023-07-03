using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Collections.Generic;
using System.IO;
using Mercadorias.Application.Responses;
using System.Linq;
using ScottPlot;

namespace Mercadorias.Reports.Pdf
{
    public class MercadoriasReportPdf
    {
        public byte[] GerarRelatorio(List<RelatorioMensalModel> mercadorias)
        {
            var memoryStream = new MemoryStream();
            var pdf = new PdfDocument(new PdfWriter(memoryStream));

            using (var document = new Document(pdf))
            {
                var img = ImageDataFactory.Create("https://api.nuget.org/v3-flatcontainer/itext7/8.0.0/icon");
                document.Add(new iText.Layout.Element.Image(img));

                var fmtTitulo = new iText.Layout.Style();
                fmtTitulo.SetFontSize(26);
                fmtTitulo.SetFontColor(iText.Kernel.Colors.Color.ConvertRgbToCmyk(new DeviceRgb(9, 69, 136)));

                document.Add(new Paragraph("Relatório de Mercadorias").AddStyle(fmtTitulo));

                var fmtSubtitulo = new iText.Layout.Style();
                fmtSubtitulo.SetFontSize(15);
                fmtSubtitulo.SetFontColor(iText.Kernel.Colors.Color.ConvertRgbToCmyk(new DeviceRgb(9, 69, 136)));

                document.Add(new Paragraph($"Sistema de controle de mercadorias - {mercadorias[0].Mes} de {mercadorias[0].Ano}\n\n").AddStyle(fmtSubtitulo));

                var plt = new ScottPlot.Plot(600, 400);

                var xLabels = mercadorias.Select(m => m.NomeMercadoria).ToArray();
                var yEntrada = mercadorias.Select(m => (double)m.QuantidadeEntrada).ToArray();
                var ySaida = mercadorias.Select(m => (double)m.QuantidadeSaida).ToArray();

                plt.PlotScatter(yEntrada, ySaida, label: "Entrada vs Saída");
                plt.PlotScatter(yEntrada, ySaida, markerSize: 10, markerShape: MarkerShape.filledCircle);

                plt.Grid(enable: false);

                plt.XAxis.Label("Quantidade de Entrada");
                plt.YAxis.Label("Quantidade de Saída");

                plt.Legend();

                using (var bitmap = plt.GetBitmap())
                using (var memoryStreamChart = new MemoryStream())
                {
                    bitmap.Save(memoryStreamChart, System.Drawing.Imaging.ImageFormat.Png);
                    var chartBytes = memoryStreamChart.ToArray();
                    var chartImage = ImageDataFactory.Create(chartBytes);
                    document.Add(new iText.Layout.Element.Image(chartImage));
                }

                var table = new Table(5);
                table.AddHeaderCell("Nome da mercadoria");
                table.AddHeaderCell("Número do Registro");
                table.AddHeaderCell("Quantidade de Entrada");
                table.AddHeaderCell("Quantidade de Saída");
                table.AddHeaderCell("Quantidade Restante");

                foreach (var item in mercadorias)
                {
                    table.AddCell(item.NomeMercadoria);
                    table.AddCell(item.NumeroRegistro);
                    table.AddCell(item.QuantidadeEntrada.ToString());
                    table.AddCell(item.QuantidadeSaida.ToString());
                    table.AddCell(item.QuantidadeRestante.ToString());
                }

                document.Add(table);
                document.Add(new Paragraph($"Quantidade de tarefas: {mercadorias.Count}"));
            }

            return memoryStream.ToArray();
        }
    }
}
