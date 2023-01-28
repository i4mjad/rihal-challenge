using RihalChallenge.Domain.Repositories;


namespace RihalChallenge.Domain.UseCases.Classes.DeleteClassUseCase;

public class DeleteClassUseCase : IDeleteClassUseCase
{
    private readonly IClassesRepository _classesRepository;

    
    public DeleteClassUseCase(IClassesRepository classesRepository)
    {
        _classesRepository = classesRepository;
    }
    public async Task Execute(DeleteClassRequest request, IPresenter<DeleteClassResponse> presenter)
    {
        await _classesRepository.DeleteClass(request.ClassId);
        
        presenter.Success(new DeleteClassResponse(await _classesRepository.GetAllClasses()));
    }
}