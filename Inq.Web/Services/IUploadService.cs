using Microsoft.AspNetCore.Components.Forms;

namespace Inq.Services
{
    public interface IUploadService
    {
        Task ArquivoUpload(IBrowserFile arquivo);
    }
}
