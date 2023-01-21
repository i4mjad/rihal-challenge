
namespace RihalChallenge.Domain.UseCases.GetStudentsUseCase;
public interface IGetStudentsUseCase
{
    Task Execute(IGetStudentsPresenter createUserPresenter);
}