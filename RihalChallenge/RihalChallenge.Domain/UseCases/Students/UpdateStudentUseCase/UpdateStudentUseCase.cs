using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;

namespace RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;

public class UpdateStudentUseCase : IUpdateStudentUseCase
{
    private readonly IStudentsRepository _studentsRepository;
    public UpdateStudentUseCase(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }
    public async Task Execute(UpdateStudentRequest request, IPresenter<UpdateStudentResponse> updateStudentPresenter)
    {
        var student = await _studentsRepository.GetStudent(request.Id);
        await _studentsRepository.UpdateStudent(request.Id, request.NewName, Guid.Parse(request.NewClassId), Guid.Parse(request.NewCountryId), request.NewDayOfBirth);

        updateStudentPresenter.Success(new UpdateStudentResponse(request.Id));
    }
}