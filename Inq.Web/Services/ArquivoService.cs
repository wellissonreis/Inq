using GenerativeAI.Models;
using GenerativeAI.Types;
using Inq.Data;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

namespace Inq.Services
{
    public class ArquivoService : IArquivoService
    {
        IWebHostEnvironment _hostingEnvironment;
        public ArquivoService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public List<ArquivoPDF> GetPdfs()
        {
            List<ArquivoPDF> arquivos = new List<ArquivoPDF>();
            string path = $"{_hostingEnvironment.WebRootPath}\\Uploads\\";

            int arquivoId = 1;

            foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                arquivos.Add(new ArquivoPDF()
                {
                    ArquivoId = arquivoId++,
                    Nome = System.IO.Path.GetFileName(pdfPath),
                    Path = pdfPath
                });
            }
            return arquivos;
        }

        public async Task ProcessaArquivo(string quest)
        {
            string apiKey = "";

            var model = new GenerativeModel(apiKey);

            var handler = new Action<string>((a) =>
            {
                Console.Write(a);
            });

            var chat = model.StartChat(new StartChatParams());


            string path = $"{_hostingEnvironment.WebRootPath}\\Uploads\\";

            foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                PdfReader leitor = new PdfReader(pdfPath);

                StringBuilder texto = new StringBuilder();

                for (int i = 1; i <= leitor.NumberOfPages; i++)
                {
                    texto.Append(PdfTextExtractor.GetTextFromPage(leitor, i));
                }
                var text = texto.ToString();

                await chat.StreamContentAsync($"{quest} | Deixe o texto em formato CSV | {text}", handler);
            }
        }
    }
}
