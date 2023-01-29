using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Classes.UpdateStudentUseCase;

public class UpdateClassUseCase : IUpdateClassUseCase
{
    private readonly IClassesRepository _classesRepository;
    public UpdateClassUseCase(IClassesRepository classesRepository)
    {
        _classesRepository = classesRepository;
    }
    public async Task Execute(UpdateClassRequest request, IPresenter<UpdateClassResponse> updateClassPresenter)
    {
        
        await _classesRepository.UpdateClass(request.Id, request.NewName);
        var student = await _classesRepository.GetById(request.Id.ToString());
        updateClassPresenter.Success(new UpdateClassResponse(request.Id));
    }
}