using RihalChallenge.Domain.Repositories;
using RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.Domain.UseCases.Students.GetStudentUseCase;

public class GetStudentUseCase : IGetStudentUseCase
{
    private readonly IStudentsRepository _studentsRepository;
    public GetStudentUseCase(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public async Task Execute(GetStudentRequest request, IPresenter<GetStudentResponse> presenter)
    {
        var student = await _studentsRepository.GetStudent(request.StudentId);
        presenter.Success(new GetStudentResponse(student));
        
    }
}
