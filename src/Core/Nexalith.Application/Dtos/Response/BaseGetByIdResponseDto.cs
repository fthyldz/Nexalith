namespace Nexalith.Application.Dtos.Response;

public record BaseGetByIdResponseDto<TDto>(TDto Data) : IBaseResponseDto;