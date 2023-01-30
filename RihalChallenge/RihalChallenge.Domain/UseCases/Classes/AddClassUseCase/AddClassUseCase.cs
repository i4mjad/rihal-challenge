using RihalChallenge.Domain.Entities;
using RihalChallenge.Domain.Repositories;
using RihalChallenge.Domain.UseCases.Students.AddStudentUseCase;

namespace RihalChallenge.Domain.UseCases.Classes.AddClassUseCase;

public class AddClassUseCase : IAddClassUseCase
{
    private readonly IClassesRepository _classesRepository;
    
    public AddClassUseCase(IClassesRepository classesRepository)
    {
        _classesRepository = classesRepository;
    }
    
    public async Task Execute(AddClassRequest request, IPresenter<AddClassResponse> presenter)
    {
        var newClass = new Class()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };

        await _classesRepository.AddClass(newClass);
        presenter.Success(new AddClassResponse(newClass.Id));


    }
}