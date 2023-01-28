namespace RihalChallenge.Domain.UseCases;

//TODO: find better and cleaner way to implement this

public interface IUseCase<TRequest, TResponse>
{
    public Task Execute(TRequest request, IPresenter<TResponse> presenter);
}

public interface IUseCase<TResponse>
{
    public Task Execute(IPresenter<TResponse> presenter);
}


