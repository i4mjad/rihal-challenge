using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Classes.GetStudentUseCase;

public class GetClassUseCase : IGetClassUseCase
{
    private readonly IClassesRepository _classesRepository;
    public GetClassUseCase(IClassesRepository classesRepository)
    {
        _classesRepository = classesRepository;
    }

    public async Task Execute(GetClassRequest request, IPresenter<GetClassResponse> presenter)
    {
        var studentsClass = await _classesRepository.GetById(request.ClassId.ToString());
        presenter.Success(new GetClassResponse(studentsClass));
    }
}
