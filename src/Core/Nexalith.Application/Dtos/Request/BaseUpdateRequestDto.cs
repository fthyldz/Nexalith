namespace Nexalith.Application.Dtos.Request;

public record BaseUpdateRequestDto<TId, TResponse>(TId Id)
    : IBaseRequestDto<TResponse>
    where TId : struct
    where TResponse : IBaseResponseDto;