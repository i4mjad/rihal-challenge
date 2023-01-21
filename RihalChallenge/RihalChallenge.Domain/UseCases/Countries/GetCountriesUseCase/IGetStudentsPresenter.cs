namespace RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;

public interface IGetCountriesPresenter
{
    void Success(GetCountriesResponse response);
    void Error(string error);
}