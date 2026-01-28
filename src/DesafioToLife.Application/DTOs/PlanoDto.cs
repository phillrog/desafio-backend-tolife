namespace DesafioToLife.Application.DTOs
{
    /// <summary>
    /// Representa os detalhes de uma oferta de plano associada a um aparelho.
    /// </summary>
    /// <param name="Id">Identificador único do plano.</param>
    /// <param name="Type">Tipo do plano (ex: Controle, Pós, Pré).</param>
    /// <param name="Name">Nome descritivo do plano.</param>
    /// <param name="PhonePrice">Preço original do aparelho sem o plano.</param>
    /// <param name="PhonePriceOnPlan">Preço promocional do aparelho ao contratar este plano.</param>
    /// <param name="Installments">Quantidade máxima de parcelas permitidas.</param>
    /// <param name="MonthlyFee">Valor da mensalidade do plano.</param>
    /// <param name="Schedule">Informações sobre a vigência da oferta.</param>
    /// <param name="Localidade">Dados de região e prioridade de exibição.</param>
    public record PlanoDto(int Id,
        string Type,
        string Name,
        decimal PhonePrice,
        decimal PhonePriceOnPlan,
        int Installments,
        decimal MonthlyFee,
        ScheduleDto Schedule,
        LocalidadeDto Localidade);
}
