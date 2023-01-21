using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Classes.GetClassesUseCase;

public class GetClassesUseCase : IGetClassesUseCase
{
    private readonly IClassesRepository _classesRepository;
    public GetClassesUseCase(IClassesRepository classesRepository)
    {
        _classesRepository = classesRepository;
    }
    public async Task Execute(IGetClassesPresenter getClassesPresenter)
    {
        var allClasses = await _classesRepository.GetAllClasses();

        getClassesPresenter.Success(new GetClassesResponse(allClasses));
    }
}