
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalRihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;
public interface IGetStudentsUseCase
{
    Task Execute(IGetStudentsPresenter createUserPresenter);
}