using MediatR;
using MediatRDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IMediator _mediator { get; }
        public ContactsController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{id}")]
        public async Task<Contact> GetContact([FromRoute] Query query) => await _mediator.Send(query);

        #region Nested Classes
        public class Query : IRequest<Contact>
        {
            public int Id { get; set; }
        }

        public class ContactHandler : IRequestHandler<Query, Contact>
        {
            private ContactsContext _db;
            public ContactHandler(ContactsContext db) => _db = db;
            public Task<Contact> Handle(Query request, CancellationToken cancellationToken)
            {
                return _db.Contacts.SingleOrDefaultAsync(c => c.Id == request.Id);
            }
        }

        #endregion

    }
}
