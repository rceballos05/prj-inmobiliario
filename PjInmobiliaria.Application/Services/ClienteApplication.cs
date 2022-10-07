using AutoMapper;
using PjInmobiliaria.Application.Commons.Bases;
using PjInmobiliaria.Application.Dto_s.Request;
using PjInmobiliaria.Application.Dto_s.Response;
using PjInmobiliaria.Application.Interfaces;
using PjInmobiliaria.Application.Validators.Cliente;
using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;
using PjInmobiliaria.Infrastructure.Persistences.Interfaces;
using PjInmobiliaria.Utilities.Statics;

namespace PjInmobiliaria.Application.Services
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IUnitOfWorks unitOfWorks;
        private readonly IMapper mapper;
        private readonly ClienteValidator validations;

        public ClienteApplication(IUnitOfWorks _unitOfWorks, IMapper _mapper, ClienteValidator _validations)
        {
            unitOfWorks = _unitOfWorks;
            mapper = _mapper;
            validations = _validations;
        }
        public async Task<BaseResponse<BaseEntityResponse<ClienteDtoResponse>>> ListaClientes(BaseFilterRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ClienteDtoResponse>>();
            var clientes = await unitOfWorks.Cliente.ListCliente(filters);
            if( clientes is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<BaseEntityResponse<ClienteDtoResponse>>(clientes);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<IEnumerable<ClienteDtoResponse>>> ListaClientesCombo()
        {
            var response = new BaseResponse<IEnumerable<ClienteDtoResponse>>();
            var cliente = await unitOfWorks.Cliente.GetAllAsync();

            if(cliente is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<IEnumerable<ClienteDtoResponse>>(cliente);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }
        public async Task<BaseResponse<ClienteDtoResponse>> ClienteById(int id)
        {
            var response = new BaseResponse<ClienteDtoResponse>();
            var cliente = await unitOfWorks.Cliente.GetByIdAsync(id);

            if(cliente is not null)
            {
                response.IsSuccess = true;
                response.Data = mapper.Map<ClienteDtoResponse>(cliente);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RegistrarCliente(ClienteDtoRequest clienteDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await validations.ValidateAsync(clienteDto);

            if(!validationResult.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATION;
                response.Errors = validationResult.Errors;
                return response;
            }

            var cliente = mapper.Map<Cliente>(clienteDto);
            response.Data = await unitOfWorks.Cliente.RegisterAsync(cliente);

            if(response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }
        
        public async Task<BaseResponse<bool>> EditarCliente(int id, ClienteDtoRequest clienteDto)
        {
            var response = new BaseResponse<bool>();
            var editarCliente = await ClienteById(id);

            if(editarCliente.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            var cliente = mapper.Map<Cliente>(clienteDto);
            cliente.Id = id;
            response.Data = await unitOfWorks.Cliente.EditAsync(cliente);

            if(response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> EliminarCliente(int id)
        {
            var response = new BaseResponse<bool>();
            var cliente = await ClienteById(id);

            if(cliente.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await unitOfWorks.Cliente.RemoveAsync(id);

            if(response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;

            }

            return response;

        }

        
    }
}
