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

namespace Application.UseCases.Auth.Commands
{
    public class LoginCommandHandler(
        IAppDbContext appDbContext,
        IHashService hashService,
        ITokenService tokenService,
        IMapper mapper
        ) : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly IAppDbContext _context = appDbContext;
        private readonly IHashService _hashService = hashService;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IMapper _mapper = mapper;

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
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

            if (!_hashService.VerifyHash(request.Password, user.PasswordHash))
            {
                throw new Exception("Login or password incorrect!");
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Role, user.RoleId.ToString())
            };

            return new LoginViewModel()
            {
                User = _mapper.Map<UserViewModel>(user),
                AccessToken = _tokenService.GetAccessToken([.. claims])
            };
        }
    }
}
