using Nexalith.Application.Dtos.Response;

namespace Nexalith.Application.Dtos.Request;

public interface IBaseRequestDto<out TResponse> where TResponse : IBaseResponseDto
{
}