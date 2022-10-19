using Mc2.CrudTest.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.QueryHandler.Customer
{
    public class GetById : IRequestHandler<Core.Query.Customer.GetById, Core.Entities.Customer>
    {
        private readonly IRepository _repository;

        public GetById(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Core.Entities.Customer> Handle(Core.Query.Customer.GetById request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync<Core.Entities.Customer>(request.Id);
            return result;
        }
    }
}
