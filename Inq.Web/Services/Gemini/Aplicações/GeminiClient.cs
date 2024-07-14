

using GenerativeAI;
using System.Net.Http.Headers;

namespace Inq.Web.Services.Gemini.Aplicações
{
    public class GeminiClient
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://generativelanguage.googleapis.com/v1/")
        };

        public GeminiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "seu-token-aqui");
        }

        void EnviarPergunta()
        {
            
        }
    }
}
