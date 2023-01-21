using RihalChallenge.Domain.Repositories;
using RihalRihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

namespace RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

public class GetStudentsUseCase : IGetStudentsUseCase
{
    private readonly IStudentsRepository _studentsRepository;
    public GetStudentsUseCase(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }
    public async Task Execute(IGetStudentsPresenter getStudentsPresenter)
    {
        var allStudents = await _studentsRepository.GetAllStudents();

        getStudentsPresenter.Success(new GetStudentsResponse(allStudents));
    }
}