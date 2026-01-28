using DesafioToLife.Domain.Entities;

namespace DesafioToLife.Application.DTOs
{
    public record AparelhoDto(int Id, string Name, List<PlanoDto> Planos);
}
