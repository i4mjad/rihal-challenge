namespace RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;

public interface IDeleteStudentPresenter
{
    void Success(string response);
    void Error(string error);
}