using DesafioToLife.Domain.Entities;

namespace DesafioToLife.Domain.Intrerfaces
{
    public interface IAparelhoRepository
    {
        Task<IEnumerable<Aparelho>> ObterTodos(int page, int pageSize);
    }
}
