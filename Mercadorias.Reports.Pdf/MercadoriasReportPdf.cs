using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;//biblioteca itext7
using iText.Layout;
using iText.Layout.Element;
using System.Collections.Generic;
using System.IO;
using Mercadorias.Application.Responses;
namespace Mercadorias.Reports.Pdf
{
    /// <summary>
    /// Classe para geração de relatórios em formato PDF
    /// </summary>
    public class MercadoriasReportPdf
    {
        public byte[] GerarRelatorio(List<RelatorioMensalModel> mercadorias)
        {

            //criando um documento PDF
            var memoryStream = new MemoryStream();
            var pdf = new PdfDocument(new PdfWriter(memoryStream));

            //abrindo o conteudo do arquivo
            using (var document = new Document(pdf))
            {
                //adicionando uma imagem no documento
                var img = ImageDataFactory.Create("https://api.nuget.org/v3-flatcontainer/itext7/8.0.0/icon");
                document.Add(new Image(img));

                //formatação do titulo:
                var fmtTitulo = new Style();
                fmtTitulo.SetFontSize(26);
                fmtTitulo.SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(9, 69, 136)));

                //adicionando um titulo ao documento
                document.Add(new Paragraph("Relatório de Mercadorias").AddStyle(fmtTitulo));

                //formatação do titulo:
                var fmtSubtitulo = new Style();
                fmtSubtitulo.SetFontSize(15);
                fmtSubtitulo.SetFontColor(Color.ConvertRgbToCmyk(new DeviceRgb(9, 69, 136)));

                //adicionando um subtitulo ao documento
                document.Add(new Paragraph("Sistema de controle de mercadorias - " + mercadorias[0].Mes + " de " + mercadorias[0].Ano + "\n\n").AddStyle(fmtSubtitulo));


                //desenhando uma tabela para exibir as tarefas
                var table = new Table(5);

                //células de cabeçalho da tabela
                table.AddHeaderCell("Nome da mercadoria");
                table.AddHeaderCell("Número do Registro");
                table.AddHeaderCell("Quantidade de Entrada");
                table.AddHeaderCell("Quantidade de Saída");
                table.AddHeaderCell("Quantidade Restante");

                //imprimir o conteudo da tabela
                foreach (var item in mercadorias)
                {
                    table.AddCell(item.NomeMercadoria);
                    table.AddCell(item.NumeroRegistro);
                    table.AddCell(item.QuantidadeEntrada.ToString());
                    table.AddCell(item.QuantidadeSaida.ToString());
                    table.AddCell(item.QuantidadeRestante.ToString());

                }

                //imprimindo a tabela no documento PDF
                document.Add(table);

                //imprimindo a quantidade de tarefas
                document.Add(new Paragraph($"Quantidade de tarefas: {mercadorias.Count}"));
            }

            //retornando o relatorio em formato byte[]
            return memoryStream.ToArray();
            

        }
    }
}
