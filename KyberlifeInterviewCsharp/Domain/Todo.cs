namespace KyberlifeInterviewCsharp.Domain;

/// <summary>
/// Represents a To-do item.
///
/// This file should not be modified.
/// </summary>
public class Todo : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }

    public Todo(string title, string description, bool isComplete)
    {
        Id = 0;
        Title = title;
        Description = description;
        IsComplete = isComplete;
    }

    public Todo(int id, string title, string description, bool isComplete)
    {
        Id = id;
        Title = title;
        Description = description;
        IsComplete = isComplete;
    }

    public override string ToString()
    {
        var isCompleteRender = IsComplete ? "x" : " ";
        return $"TODO [{Id}][{isCompleteRender}] {Title}: {Description}";
    }
}