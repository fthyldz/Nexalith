namespace Nexalith.Application.Dtos.Response;

public record BaseDeleteResponseDto(bool IsSuccess) : IBaseResponseDto;