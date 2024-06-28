using Application.Abstractions.Interfaces;
using Application.Models.ViewModels;
using AutoMapper;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.UserToDoList.Queries
{
    public class GetUserQueryHandler(
        IAppDbContext appDbContext,
        IMapper mapper
        ) : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != null && Guid.TryParse(request.Id, out Guid id)) 
            {
                var user = await _context.Users
                                        .Include(x => x.Organization).ThenInclude(x => x.Address)
                                                                                      .ThenInclude(x => x.Street)
                                                                                      .ThenInclude(x => x.District)
                                                                                      .ThenInclude(x => x.Region)
                                                                                      .ThenInclude(x => x.Country)
                                                         .Include(x => x.Role)
                                        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                if (user != null)
                {
                    return _mapper.Map<UserViewModel>(user);
                }
            }
            if(request.Phone != null)
            {
                var user = await _context.Users
                                        .Include(x => x.Organization).ThenInclude(x => x.Address)
                                                                                      .ThenInclude(x => x.Street)
                                                                                      .ThenInclude(x => x.District)
                                                                                      .ThenInclude(x => x.Region)
                                                                                      .ThenInclude(x => x.Country)
                                                         .Include(x => x.Role)
                                        .FirstOrDefaultAsync(x => x.Phone == request.Phone, cancellationToken);
                if (user != null)
                {
                    return _mapper.Map<UserViewModel>(user);
                }
            }
            if (request.Email != null)
            {
                var user = await _context.Users
                                        .Include(x => x.Organization).ThenInclude(x => x.Address)
                                                                                      .ThenInclude(x => x.Street)
                                                                                      .ThenInclude(x => x.District)
                                                                                      .ThenInclude(x => x.Region)
                                                                                      .ThenInclude(x => x.Country)
                                                         .Include(x => x.Role)
                                        .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken);
                if (user != null)
                {
                    return _mapper.Map<UserViewModel>(user);
                }
            }

            throw new NotFoundException();
        }
    }
}
