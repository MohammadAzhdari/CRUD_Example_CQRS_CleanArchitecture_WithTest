using MediatR;

namespace Mc2.CrudTest.Core.Query.Customer
{
    public class GetById : IRequest<Entities.Customer>
    {
        public int Id { get; }

        public GetById(int id)
        {
            Id = id;
        }
    }
}
