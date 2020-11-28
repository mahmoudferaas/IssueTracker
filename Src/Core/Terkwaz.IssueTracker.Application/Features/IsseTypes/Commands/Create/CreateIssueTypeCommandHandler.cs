using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Terkwaz.IssueTracker.Application.Common.Dtos;
using Terkwaz.IssueTracker.Application.Common.Interfaces;
using Terkwaz.IssueTracker.Domain.Entities;

namespace Terkwaz.IssueTracker.Application.Features.IsseTypes.Commands.Create
{
    public class CreateIssueTypeCommandHandler : IRequestHandler<CreateIssueTypeCommand, Output>
    {
        private readonly IIssueTrackerDbContext _context;
        private readonly IMapper _mapper;

        public CreateIssueTypeCommandHandler(IIssueTrackerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Output> Handle(CreateIssueTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<IssueType>(request);

                _context.IssueTypes.Add(entity);

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