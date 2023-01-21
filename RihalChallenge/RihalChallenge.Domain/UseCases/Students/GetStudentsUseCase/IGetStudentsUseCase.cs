
namespace RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;
public interface IGetStudentsUseCase
{
    Task Execute(IGetStudentsPresenter getStudentsPresenter);
}