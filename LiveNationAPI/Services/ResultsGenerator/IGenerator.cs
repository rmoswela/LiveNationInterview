namespace LiveNationAPI;

public interface IGenerator
{
    NumberRangeResponseDto GenerateResult(NumberRangeRequestDto numberRangeRequest);
}
