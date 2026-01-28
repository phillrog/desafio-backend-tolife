namespace DesafioToLife.Application.DTOs
{
    /// <summary>
    /// Objeto de transferência de dados para o Aparelho e suas ofertas de planos.
    /// </summary>
    /// <param name="Id">Identificador único do aparelho.</param>
    /// <param name="Name">Nome comercial do dispositivo (ex: Samsung Galaxy S8).</param>
    /// <param name="Planos">Lista de planos em oferta que são únicos, vigentes e ordenados por prioridade.</param>
    public record AparelhoDto(int Id, string Name, List<PlanoDto> Planos);
}
