using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

public class GetStudentsUseCase : IGetStudentsUseCase
{
    private readonly IStudentsRepository _studentsRepository;
    public GetStudentsUseCase(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public async Task Execute(IPresenter<GetStudentsResponse> presenter)
    {
        var allStudents = await _studentsRepository.GetAllStudents();

        presenter.Success(new GetStudentsResponse(allStudents));
    }
}
