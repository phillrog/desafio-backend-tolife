using AutoMapper;
using DesafioToLife.Application.DTOs;
using DesafioToLife.Domain.Entities;
using DesafioToLife.Domain.Intrerfaces;

namespace DesafioToLife.Application.Services
{
    public class AparelhoService : IAparelhoService
    {
        private readonly IAparelhoRepository _aparelhoRepository;
        private readonly IMapper _mapper;

        public AparelhoService(IAparelhoRepository aparelhoRepository, IMapper mapper)
        {
            _aparelhoRepository = aparelhoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AparelhoDto>> Ofertas(int page, int pageSize)
        {
            var aparelhos = await _aparelhoRepository.ObterTodos(page, pageSize);

            return  _mapper.Map<IEnumerable<AparelhoDto>>(aparelhos);
        }
    }
}
