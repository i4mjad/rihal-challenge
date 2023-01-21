
using RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;

namespace RihalChallenge.Domain.UseCases.Classes.GetStudentsUseCase;
public interface IGetClassesUseCase
{
    Task Execute(IGetClassesPresenter getClassesPresenter);
}