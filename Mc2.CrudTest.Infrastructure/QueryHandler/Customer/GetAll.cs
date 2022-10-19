using Mc2.CrudTest.Infrastructure.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.QueryHandler.Customer
{
    public class GetAll : IRequestHandler<Core.Query.Customer.GetAll, List<Core.Entities.Customer>>
    {
        private readonly IRepository _repository;

        public GetAll(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Core.Entities.Customer>> Handle(Core.Query.Customer.GetAll request, CancellationToken cancellationToken)
        {
            var result = await _repository.ListAsync<Core.Entities.Customer>();
            return result;
        }
    }
}
