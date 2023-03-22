using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Api.Controllers;
using Ecommerce.Api.Extensions;
using Ecommerce.Api.ViewModels;
using Ecommerce.Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using IEmailSender = Ecommerce.Business.Interfaces.IEmailSender;

namespace Ecommerce.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly ILogger _logger;


        public AuthController(INotificador notificador, 
                              SignInManager<IdentityUser> signInManager, 
                              UserManager<IdentityUser> userManager, 
                              IOptions<AppSettings> appSettings,
                              IUser user, 
                              ILogger<AuthController> logger
                              ) : base(notificador, user)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _appSettings = appSettings.Value;
        }

        [HttpGet("usuarios")]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _userManager.Users.ToListAsync();
            return Ok(usuarios);
        }



        //[EnableCors("Development")]
        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GerarJwt(user.Email));
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(registerUser);
        }
    
        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario "+ loginUser.Email +" logado com sucesso");
                return CustomResponse(await GerarJwt(loginUser.Email));
            }
            if (result.IsLockedOut)
            {
                
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }

            NotificarErro("Desculpe! Não foi possível realizar essa operação. Usuário ou Senha incorretos");
            return CustomResponse(loginUser);
        }

        [HttpPost("alterar-senha")]
        public async Task<ActionResult> AlterarSenha(AlterarSenhaViewModel alterarSenha)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = await _userManager.FindByEmailAsync(alterarSenha.Email);

            if (user == null)
            {
                NotificarErro("Desculpe! Não foi possível realizar essa operação. Tente novamente.");
                return CustomResponse(alterarSenha);
            }

            var result = await _userManager.ChangePasswordAsync(user, alterarSenha.SenhaAtual, alterarSenha.NovaSenha);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(user.Email));
            }

            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(alterarSenha);
        }

        //[HttpPost("reset-password")]
        //public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        // Se o usuário não existir, ainda enviamos uma resposta bem-sucedida para evitar que um atacante determine quais endereços de e-mail estão cadastrados no sistema.
        //        return Ok();
        //    }

        //    // Cria um token de redefinição de senha que será enviado ao usuário por e-mail.
        //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //    // Constrói o URL exclusivo de redefinição de senha que será enviado ao usuário por e-mail.
        //    var resetUrl = $"{Request.Scheme}://{Request.Host}/reset-password?email={Uri.EscapeDataString(user.Email)}&token={Uri.EscapeDataString(token)}";

        //    // Constrói o corpo do e-mail.
        //    var message = new StringBuilder()
        //        .AppendLine("Você solicitou uma redefinição de senha.")
        //        .AppendLine("Por favor, clique no link abaixo para redefinir sua senha.")
        //        .AppendLine()
        //        .AppendLine(resetUrl)
        //        .ToString();

        //    // Envia o e-mail ao usuário.
        //    await _emailSender.SendEmailAsync(user.Email, "Redefinir senha", message);

        //    // Retorna uma resposta bem-sucedida.
        //    return Ok();
        //}



        private async Task<LoginResponseViewModel> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c=> new ClaimViewModel{ Type = c.Type, Value = c.Value})
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}