using AutoMapper;
using Ecommerce.Application.DTO;
using Ecommerce.Application.Interface;
using Ecommerce.Domain.Interface;
using Ecommerce.Transversal.Common;
using Ecommerce.Application.Validator;

namespace Ecommerce.Application.Main
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUsersDomain _usersDomain;
        private readonly IMapper _mapper;
        private readonly UsersDtoValidator _validator;
        public UsersApplication(IUsersDomain usersDomain, IMapper mapper, UsersDtoValidator validator)
        {
            _usersDomain = usersDomain;
            _mapper = mapper;
            _validator = validator;
        }

        public Response<UsersDto> Authenticate(string username, string password)
        {
            var response = new Response<UsersDto>();
            var validation = _validator.Validate(new UsersDto() { UserName = username, Password = password });
            if (!validation.IsValid)
            {
                response.Message = "Errores de validacion.";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _usersDomain.Authenticate(username, password);
                response.Data = _mapper.Map<UsersDto>(user);
                response.IsSucces = true;
                response.Message = "Autenticacion Exitosa!!!";
            }
            catch (InvalidOperationException)
            {
                response.IsSucces = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
