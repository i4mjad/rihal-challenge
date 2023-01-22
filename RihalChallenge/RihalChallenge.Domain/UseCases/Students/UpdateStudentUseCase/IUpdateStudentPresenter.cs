namespace RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;

public interface IUpdateStudentPresenter
{
    void Success(UpdateStudentResponse response);
    void Error(string error);
}