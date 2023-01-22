
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
    public async Task Execute(DeleteStudentRequest request, IDeleteStudentPresenter addStudentPresenter)
    {
        await _studentsRepository.DeleteStudent(request.StudentId);
        
        addStudentPresenter.Success("deleted");
    }

    
}