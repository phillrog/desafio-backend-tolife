using DesafioToLife.Application.DTOs;

namespace DesafioToLife.Domain.Intrerfaces
{
    public interface IAparelhoService
    {
        Task<IEnumerable<AparelhoDto>> Ofertas(int page, int pageSize);
    }
}
