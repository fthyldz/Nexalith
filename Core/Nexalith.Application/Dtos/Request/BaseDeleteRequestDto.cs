using Nexalith.Application.Dtos.Response;

namespace Nexalith.Application.Dtos.Request;

public record BaseDeleteRequestDto<TId, TResponse>(TId Id)
    : IBaseRequestDto<TResponse>
    where TId : struct
    where TResponse : IBaseResponseDto;