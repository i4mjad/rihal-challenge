using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Students.GetStudentsUseCase;

//public class GetStudentsUseCase : IGetStudentsUseCase
//{
//    private readonly IStudentsRepository _studentsRepository;
//    public GetStudentsUseCase(IStudentsRepository studentsRepository)
//    {
//        _studentsRepository = studentsRepository;
//    }
//    public async Task Execute(IGetStudentsPresenter getStudentsPresenter)
//    {
//        var allStudents = await _studentsRepository.GetAllStudents();

//        getStudentsPresenter.Success(new GetStudentsResponse(allStudents));
//    }
//}

public class GetStudentsUseCase : IUseCase<GetStudentsResponse>
{
    private readonly IStudentsRepository _studentsRepository;
    public GetStudentsUseCase(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }
    public async Task Execute(IPresenter<GetStudentsResponse> getStudentsPresenter)
    {
        var allStudents = await _studentsRepository.GetAllStudents();

        getStudentsPresenter.Success(new GetStudentsResponse(allStudents));
    }
}