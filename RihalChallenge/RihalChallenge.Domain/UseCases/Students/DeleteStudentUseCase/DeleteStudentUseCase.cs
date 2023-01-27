
using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;


namespace RihalChallenge.Domain.UseCases.Students.DeleteStudentUseCase;

public class DeleteStudentUseCase : IDeleteStudentUseCase
{
    private readonly IStudentsRepository _studentsRepository;

    
    public DeleteStudentUseCase(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }
    public async Task Execute(DeleteStudentRequest request, IPresenter<DeleteStudentResponse> deleteStudentPresenter)
    {
        await _studentsRepository.DeleteStudent(request.StudentId);
        
        deleteStudentPresenter.Success(new DeleteStudentResponse(await _studentsRepository.GetAllStudents()));
    }
}