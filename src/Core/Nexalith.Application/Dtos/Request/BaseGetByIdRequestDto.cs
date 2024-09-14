namespace Nexalith.Application.Dtos.Request;

public record BaseGetByIdRequestDto<TId, TResponse>(TId Id)
    : IBaseRequestDto<TResponse>
    where TId : struct
    where TResponse : IBaseResponseDto;