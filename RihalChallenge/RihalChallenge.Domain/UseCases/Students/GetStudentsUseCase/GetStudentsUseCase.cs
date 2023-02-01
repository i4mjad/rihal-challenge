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
        await _studentsRepository.DeleteStudent(Guid.Parse("3d526851-f72d-43a4-b802-c15d1bd6f1aa"));
        var allStudents = await _studentsRepository.GetAllStudents();

        presenter.Success(new GetStudentsResponse(allStudents));
    }
}
