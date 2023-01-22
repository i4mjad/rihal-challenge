
namespace RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;
public interface IDeleteStudentUseCase
{
    Task Execute(DeleteStudentRequest request, IDeleteStudentPresenter addStudentPresenter);
}