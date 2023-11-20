using System;

public class Task
{
    public string Title { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
}