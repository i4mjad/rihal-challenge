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
        var student = await _classesRepository.GetById(request.Id.ToString());
        await _classesRepository.UpdateClass(request.Id, request.NewName);

        updateClassPresenter.Success(new UpdateClassResponse(request.Id));
    }
}