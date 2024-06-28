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

namespace Application.UseCases.AuthToDoList.Commands
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
            };

            var superAdmin = await _context.Roles.FirstOrDefaultAsync(x => x.NameEn == "SuperAdmin" && x.NameUz == "SuperAdmin" && x.NameRu == "СуперАдмин", cancellationToken);

            if (user.RoleId == superAdmin!.Id)
            {
                foreach (var id in _context.Roles.Select(x => x.Id))
                {
                    claims.Add(new Claim(ClaimTypes.Role, id.ToString()));
                }
            }
            else {
                claims.Add(new Claim(ClaimTypes.Role, user.RoleId.ToString()));
            }

            return new LoginViewModel()
            {
                User = _mapper.Map<UserViewModel>(user),
                AccessToken = _tokenService.GetAccessToken([.. claims])
            };
        }
    }
}
