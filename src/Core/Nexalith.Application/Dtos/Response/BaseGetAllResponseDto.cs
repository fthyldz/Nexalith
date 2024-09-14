namespace Nexalith.Application.Dtos.Response;

public record BaseGetAllResponseDto<TDto>(IEnumerable<TDto> Data) : IBaseResponseDto;