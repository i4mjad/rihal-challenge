
using RihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;

namespace RihalRihalChallenge.Domain.UseCases.Countries.GetCountriesUseCase;
public interface IGetCountriesUseCase
{
    Task Execute(IGetCountriesPresenter createUserPresenter);
}