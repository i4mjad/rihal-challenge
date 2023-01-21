namespace RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

public interface IGetStudentsPresenter
{
    void Success(GetStudentsResponse response);
    void Error(string error);
}