
namespace RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;
public interface IGetClassesUseCase
{
    Task Execute(IGetClassesPresenter getClassesPresenter);
}