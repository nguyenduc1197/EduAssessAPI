
using Application.DTOs;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Accounts.Commands
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAccountRepository _accountRepository;

        private readonly ITeacherRepository _teacherRepository;

        private readonly IStudentRepository _studentRepository;

        private readonly IConfiguration _config;

        public LoginHandler(
            IAccountRepository accountRepository,
            ITeacherRepository teacherRepository,
            IStudentRepository studentRepository,
            IConfiguration config)
        {
            _accountRepository = accountRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _config = config;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken ct)
        {
            var account = await _accountRepository.Query().FirstOrDefaultAsync(x => x.Username.ToUpper() == request.Username.ToUpper());
            
            if (account == null) 
                return null;

            var isValid = BCrypt.Net.BCrypt.Verify(request.Password, account.PasswordHash);

            if (!isValid)
                return null;

            var claims = new[]
         {
            new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
            new Claim(ClaimTypes.Name, account.Username),
            new Claim(ClaimTypes.Role, account.Role)
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds);


            return new LoginResponse(new JwtSecurityTokenHandler().WriteToken(token), account.Role, account.Name); ;
        }
    }
}
