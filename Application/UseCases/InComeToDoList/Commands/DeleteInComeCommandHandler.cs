using Application.Abstractions.Interfaces;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.InComeToDoList.Commands
{
    public class DeleteInComeCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<DeleteInComeCommand, bool>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<bool> Handle(DeleteInComeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new NotFoundException();

            var inCome = await _context.Incomes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                  ?? throw new NotFoundException();

            if(currentUser.OrganizationId != inCome.OrganizationId)
            {
                throw new Exception("Access denied");
            }

            _context.Incomes.Remove(inCome);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
