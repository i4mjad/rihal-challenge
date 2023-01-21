namespace RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;

public interface IGetClassesPresenter
{
    void Success(GetClassesResponse response);
    void Error(string error);
}