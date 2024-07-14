using Inq.Data;

namespace Inq.Services
{
    public interface IArquivoService
    {
        List<ArquivoPDF> GetPdfs();
        Task ProcessaArquivo(string quest);

    }
}
