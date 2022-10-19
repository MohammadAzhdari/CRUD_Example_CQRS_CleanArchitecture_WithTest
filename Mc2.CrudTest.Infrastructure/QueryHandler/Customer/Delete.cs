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
    public class Delete : IRequestHandler<Core.Query.Customer.Delete, bool>
    {
        private readonly IRepository _repository;

        public Delete(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(Core.Query.Customer.Delete request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync<Core.Entities.Customer>(new Core.Entities.Customer
            {
                Id = request.Id,
            });
            return result;
        }
    }
}
