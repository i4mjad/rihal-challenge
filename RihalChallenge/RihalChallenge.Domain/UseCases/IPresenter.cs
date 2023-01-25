namespace RihalChallenge.Domain.UseCases;

public interface IPresenter<TResponse>
{
    void Success(TResponse response);
    void Error(string error);
}