namespace KyberlifeInterviewCsharp.Domain;

/// <summary>
/// A base entity class. All entities in the application should inherit from this class.
///
/// This file should not be modified.
/// </summary>
public abstract class BaseEntity
{
    public int Id { get; set; } = 0;
}