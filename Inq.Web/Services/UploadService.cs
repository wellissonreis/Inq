using Microsoft.AspNetCore.Components.Forms;

namespace Inq.Services
{
    public class UploadService : IUploadService
    {
        private long tamanhoMaximoPermitido = 1024 * 500;//512000
        IWebHostEnvironment _hostingEnvironment;
        public UploadService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task ArquivoUpload(IBrowserFile arquivo)
        {
            if (arquivo.Size > tamanhoMaximoPermitido)
            {
                Console.WriteLine("Tamanho do arquivo excede o limite permitido");
            }
            else
            {
                try
                {
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads", arquivo.Name);
                    await using FileStream fs = new(path, FileMode.Create);
                    await arquivo.OpenReadStream().CopyToAsync(fs);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
