using Application.Abstractions.Interfaces;
using Application.Models.ViewModels;
using AutoMapper;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.UserToDoList.Queries;

public class GetUserByPhoneNumberQueryHandler(
    IAppDbContext appDbContext,
    IMapper mapper
    ) : IRequestHandler<GetUserByPhoneNumberQuery, UserViewModel>
{
    private readonly IAppDbContext _context = appDbContext;
    private readonly IMapper _mapper = mapper;
    public async Task<UserViewModel> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
                                     .Include(x => x.Organization).ThenInclude(x => x.Address)
                                                                  .ThenInclude(x => x.Street)
                                                                  .ThenInclude(x => x.District)
                                                                  .ThenInclude(x => x.Region)
                                                                  .ThenInclude(x => x.Country)
                                     .Include(x => x.Role)
                                     .FirstOrDefaultAsync(x => x.Phone == request.Phone, cancellationToken)
                                            ?? throw new NotFoundException();

        return _mapper.Map<UserViewModel>(user);
    }
}
