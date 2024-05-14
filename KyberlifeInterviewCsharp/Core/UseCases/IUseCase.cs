using KyberlifeInterviewCsharp.Core.DTO.UseCaseResponses;

namespace KyberlifeInterviewCsharp.Core.UseCases;

/// <summary>
/// Generic UseCase interface. All UseCases must implement this interface.
/// </summary>
public interface IUseCase<in TRequest, TResponse> where TResponse : UseCaseResponseMessage
{
    Task<TResponse> Handle(TRequest request);
}