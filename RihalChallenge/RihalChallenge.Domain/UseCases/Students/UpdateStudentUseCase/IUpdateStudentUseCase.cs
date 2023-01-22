

namespace RihalChallenge.Domain.UseCases.Students.UpdateStudentUseCase;
public interface IUpdateStudentUseCase
{
    Task Execute(UpdateStudentRequest request, IUpdateStudentPresenter updateStudentPresenter);
}