using System; // Importing the System namespace which contains fundamental types and base class features

// Task class represents individual tasks

public class Task // Declaration of the Task class
{
    // Properties of a task
    public int TaskId { get; set; } // Property to store the unique identifier of the task
    public string Title { get; set; } // Property to store the title or description of the task
    public DateTime DueDate { get; set; } // Property to store the deadline or due date of the task
    public string Status { get; set; } // Property to store the current status of the task
    public string Project { get; set; } // Property to store the project or category of the task

    // Constructor to initialize task properties
    public Task(int taskId, string title, DateTime dueDate, string status, string project)
    {
        // Assigning the values passed to the constructor to the corresponding properties

        TaskId = taskId;  // Assigning the taskId parameter to the TaskId property
        Title = title;  // Assigning the title parameter to the Title property
        DueDate = dueDate;  // Assigning the dueDate parameter to the DueDate property
        Status = status;  // Assigning the status parameter to the Status property
        Project = project;  // Assigning the project parameter to the Project property
    }

    // Parameterless constructor
    public Task() { } // This constructor is used when creating Task objects without initializing their properties
}
