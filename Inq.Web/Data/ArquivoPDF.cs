namespace Inq.Data;
public class ArquivoPDF
{
    public int ArquivoId { get; set; }
    public string Nome { get; set; } = "";
    public string Path { get; set; } = "";
    public List<ArquivoPDF> Arquivos { get; set; } = new List<ArquivoPDF>();
}

