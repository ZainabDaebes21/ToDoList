using System;
using System.Threading.Tasks; // Importing necessary namespaces

class Program
{
    static void Main(string[] args)
    {
        TodoList todoList = new TodoList(); // Create a new instance of TodoList

        while (true) // Infinite loop to display menu options repeatedly
        {
            // Display menu options
            Console.WriteLine("ToDoList Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Edit Task");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. Display Tasks");
            Console.WriteLine("5. Save Tasks to File");
            Console.WriteLine("6. Load Tasks from File");
            Console.WriteLine("7. Exit");

            // Prompt user for choice
            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice)) // Validate user input
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            // Perform actions based on user choice
            switch (choice)
            {
                case 1:
                    AddTask(todoList);
                    break;
                case 2:
                    EditTask(todoList);
                    break;
                case 3:
                    DeleteTask(todoList);
                    break;
                case 4:
                    todoList.DisplayTasks();
                    break;
                case 5:
                    SaveTasks(todoList);
                    break;
                case 6:
                    LoadTasks(todoList);
                    break;
                case 7:
                    Environment.Exit(0); // Exit the program
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a number between 1 and 7.");
                    break;
            }
        }
    }

    // Get task details from user input and add task to the todo list
    static void AddTask(TodoList todoList)
    {
        Console.WriteLine("Enter Task Details:");
        Console.Write("Task Title: ");
        string title = Console.ReadLine();
        Console.Write("Due Date (YYYY-MM-DD): ");
        DateTime dueDate;
        if (!DateTime.TryParse(Console.ReadLine(), out dueDate)) // Validate date input
        {
            Console.WriteLine("Invalid date format.");
            return;
        }
        Console.Write("Status: ");
        string status = Console.ReadLine();
        Console.Write("Project: ");
        string project = Console.ReadLine();

        // Create new task object and add it to the list
        Task task = new Task
        {
            TaskId = todoList.tasks.Count() + 1,
            DueDate = dueDate,
            Status = status,
            Title = title,
            Project = project
        };

        todoList.SaveTask(task); // Add task to the todo list
        Console.WriteLine("Task added successfully.");
    }

    // Edit an existing task
    static void EditTask(TodoList todoList)
    {
        // Prompt user for task ID to edit
        Console.Write("Enter Task ID to edit: ");
        int taskId;
        if (!int.TryParse(Console.ReadLine(), out taskId)) // Validate task ID input
        {
            Console.WriteLine("Invalid task ID.");
            return;
        }

        // Find the task to edit
        Task task = todoList.GetTaskById(taskId);
        if (task != null) // Task found
        {
            // Display task details
            Console.WriteLine("Task Details:");
            Console.WriteLine($"ID: {task.TaskId}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Due Date: {task.DueDate}");
            Console.WriteLine($"Status: {task.Status}");
            Console.WriteLine($"Project: {task.Project}");
        }
        else
        {
            Console.WriteLine("Task not found.");
            return;
        }

        // Get updated task details from user input
        Console.WriteLine("Enter new Task Details:");
        Console.Write("Task Title: ");
        string title = Console.ReadLine();
        Console.Write("Due Date (YYYY-MM-DD): ");
        DateTime dueDate;
        if (!DateTime.TryParse(Console.ReadLine(), out dueDate)) // Validate date input
        {
            Console.WriteLine("Invalid date format.");
            return;
        }
        Console.Write("Status: ");
        string status = Console.ReadLine();
        Console.Write("Project: ");
        string project = Console.ReadLine();

        // Create updated task object and update the task in the list
        Task updatedTask = new Task(taskId, title, dueDate, status, project);
        todoList.EditTask(taskId, updatedTask);
        Console.WriteLine("Task updated successfully.");
    }

    // Delete a task from the todo list
    static void DeleteTask(TodoList todoList)
    {
        // Prompt user for task ID to delete
        Console.Write("Enter Task ID to delete: ");
        int taskId;
        if (!int.TryParse(Console.ReadLine(), out taskId)) // Validate task ID input
        {
            Console.WriteLine("Invalid task ID.");
            return;
        }

        // Delete the task from the list
        todoList.DeleteTask(taskId);
        Console.WriteLine("Task deleted successfully.");
    }

    // Save tasks to a file
    static void SaveTasks(TodoList todoList)
    {
        // Prompt user for file path to save tasks
        Console.Write("Enter file path to save tasks: ");
        string filePath = Console.ReadLine();
        todoList.SaveTasksToFile(filePath);
        Console.WriteLine("Tasks saved to file successfully.");
    }

    // Load tasks from a file
    static void LoadTasks(TodoList todoList)
    {
        // Prompt user for file path to load tasks from
        Console.Write("Enter file path to load tasks from: ");
        string filePath = Console.ReadLine();
        todoList.LoadTasksFromFile(filePath);
        Console.WriteLine("Tasks loaded from file successfully.");
    }
}
