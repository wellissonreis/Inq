using Inq.Data;

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
                    Nome = Path.GetFileName(pdfPath),
                    Path = pdfPath
                });
            }
            return arquivos;
        }
    }
}
