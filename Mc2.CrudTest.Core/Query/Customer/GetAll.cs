using MediatR;
using System.Collections.Generic;

namespace Mc2.CrudTest.Core.Query.Customer
{
    public class GetAll : IRequest<List<Entities.Customer>>
    {
    }
}
