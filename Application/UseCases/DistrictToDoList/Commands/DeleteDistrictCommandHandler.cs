using Application.Abstractions.Interfaces;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DistrictToDoList.Commands
{
    public class DeleteDistrictCommandHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<DeleteDistrictCommand, bool>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<bool> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (currentUser.RoleId != superAdmin!.Id)
            {
                throw new Exception("Access denied");
            }

            var district = await _context.Districts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                                  ?? throw new NotFoundException();

            _context.Districts.Remove(district);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
