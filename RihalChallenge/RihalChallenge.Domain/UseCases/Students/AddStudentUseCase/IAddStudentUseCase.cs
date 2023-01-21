
namespace RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;
public interface IAddStudentUseCase
{
    Task Execute(AddStudentRequest request, IAddStudentPresenter addStudentPresenter);
}