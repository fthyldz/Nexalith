namespace Nexalith.Application.Dtos.Response;

public record BaseCreateResponseDto<TId>(TId Id) : IBaseResponseDto;