public class EmailDTO
{
    public string? Destinatario {get; set;}
    public string? Asunto {get; set;} = string.Empty;
    public string? Contenido {get; set;} = string.Empty;
}