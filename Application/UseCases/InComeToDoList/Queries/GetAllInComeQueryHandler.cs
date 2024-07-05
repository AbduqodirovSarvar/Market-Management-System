using Application.Abstractions.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.InComeToDoList.Queries
{
    public class GetAllInComeQueryHandler(
        IAppDbContext appDbContext,
        ICurrentUserService currentUserService
        ) : IRequestHandler<GetAllInComeQuery, List<InCome>>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<List<InCome>> Handle(GetAllInComeQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId, cancellationToken)
                                                  ?? throw new Exception("Access denied");

            List<InCome> result = await _context.Incomes.Include(x => x.Product)
                                                    .ThenInclude(x => x.ProductType)
                                                    .ThenInclude(x => x.MeasureOfType)
                                                .Include(x => x.Organization)
                                                    .ThenInclude(x => x.Address)
                                                    .ThenInclude(x => x.Street)
                                                    .ThenInclude(x => x.District)
                                                    .ThenInclude(x => x.Region)
                                                    .ThenInclude(x => x.Country)
                                                .Where(x => x.OrganizationId == currentUser.OrganizationId)
                                                .ToListAsync(cancellationToken);

            if(request.ProductId != null)
            {
                result = result.Where(x => x.ProductId == request.ProductId).ToList();
            }

            if(request.FromDate != null)
            {
                result = result.Where(x => DateOnly.FromDateTime(x.CreatedAt) >= request.FromDate).ToList();
            }

            if(request.ToDate != null)
            {
                result = result.Where(x => DateOnly.FromDateTime(x.CreatedAt) <= request.ToDate).ToList();
            }

            return result;
        }
    }
}
