namespace RihalChallenge.Domain.UseCases.GetStudentsUseCase;

public interface IGetStudentsPresenter
{
    void Success(GetStudentsResponse response);
    void Error(string error);
}