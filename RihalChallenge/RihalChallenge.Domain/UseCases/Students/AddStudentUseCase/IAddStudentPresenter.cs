namespace RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;

public interface IAddStudentPresenter
{
    void Success(AddStudentResponse response);
    void Error(string error);
}