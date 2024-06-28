using Application.Abstractions.Interfaces;
using Application.Models.ViewModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.UserToDoList.Queries
{
    public class GetAllUserQueryHandler(
        IAppDbContext appDbContext,
        IMapper mapper
        ) : IRequestHandler<GetAllUserQuery, List<UserViewModel>>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<List<UserViewModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            if (request.SearchText != null)
            {
                var users = await _context.Users
                                          .Include(x => x.Organization).ThenInclude(x => x.Address)
                                                                  .ThenInclude(x => x.Street)
                                                                  .ThenInclude(x => x.District)
                                                                  .ThenInclude(x => x.Region)
                                                                  .ThenInclude(x => x.Country)
                                           .Include(x => x.Role)
                                           .Where(x => x.FirstName.ToLower().Contains(request.SearchText.ToLower())
                                                    || x.LastName.ToLower().Contains(request.SearchText.ToLower())
                                                    || x.Email.ToLower().Contains(request.SearchText.ToLower())
                                                    || x.Phone.Contains(request.SearchText))
                                           .ToListAsync(cancellationToken);

                return _mapper.Map<List<UserViewModel>>(users);
            }

            return _mapper.Map<List<UserViewModel>>(await _context.Users.ToListAsync(cancellationToken));
        }
    }
}
