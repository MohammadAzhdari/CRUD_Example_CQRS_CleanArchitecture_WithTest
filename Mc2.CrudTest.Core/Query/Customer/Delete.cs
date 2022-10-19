using MediatR;

namespace Mc2.CrudTest.Core.Query.Customer
{
    public class Delete : IRequest<bool>
    {
        public int Id { get; set; }

        public Delete(int id)
        {
            this.Id = id;
        }
    }
}
