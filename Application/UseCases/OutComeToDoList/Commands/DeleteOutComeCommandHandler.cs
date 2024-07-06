using Application.Abstractions.Interfaces;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.OutComeToDoList.Commands
{
    public class DeleteOutComeCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<DeleteOutComeCommand, bool>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<bool> Handle(DeleteOutComeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                               ?? throw new NotFoundException();

            var outCome = await _context.Outcomes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                               ?? throw new NotFoundException();

            if (currentUser.OrganizationId != outCome.OrganizationId)
            {
                throw new Exception("Access denied");
            }

            _context.Outcomes.Remove(outCome);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
