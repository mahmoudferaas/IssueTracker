using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;

namespace Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Update
{
    public class UpdateIssueTypeCommandHandler : IRequestHandler<UpdateIssueTypeCommand, Output>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public UpdateIssueTypeCommandHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Output> Handle(UpdateIssueTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _context.IssueTypes.Find(request.Id);

                _mapper.Map(request, entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new Output { Status = true };
            }
            catch (System.Exception ex)
            {
                return new Output { Status = false, ErrorMessage = ex.Message };
                throw;
            }
        }
    }
}