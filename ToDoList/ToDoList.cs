using System;
using System.Collections.Generic;
using System.IO;

// Define the TodoList class which manages tasks and provides methods to manipulate them
public class TodoList
{
    // List to store tasks
    public List<Task> tasks;

    // Constructor to initialize the tasks list
    public TodoList()
    {
        tasks = new List<Task>();
    }

    // Method to add a task to the list
    public void SaveTask(Task task)
    {
        tasks.Add(task);
    }

    // Method to edit an existing task
    public void EditTask(int taskId, Task updatedTask)
    {
        // Find the task with the given taskId
        Task taskToUpdate = tasks.Find(t => t.TaskId == taskId);
        if (taskToUpdate != null)
        {
            // Update task details with the provided updatedTask
            taskToUpdate.Title = updatedTask.Title;
            taskToUpdate.DueDate = updatedTask.DueDate;
            taskToUpdate.Status = updatedTask.Status;
            taskToUpdate.Project = updatedTask.Project;
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    // Method to delete a task from the list
    public void DeleteTask(int taskId)
    {
        // Find the task with the given taskId
        Task taskToDelete = tasks.Find(t => t.TaskId == taskId);
        if (taskToDelete != null)
        {
            // Remove the task from the list
            tasks.Remove(taskToDelete);
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    // Method to display all tasks in the list
    public void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            // Iterate through each task and display its details
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task ID: {task.TaskId}, Title: {task.Title}, Due Date: {task.DueDate}, Status: {task.Status}, Project: {task.Project}");
            }
        }
    }

    // Method to save tasks to a file
    public void SaveTasksToFile(string filePath)
    {
        // Open a StreamWriter to write tasks to the specified file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write each task's details to the file
            foreach (var task in tasks)
            {
                writer.WriteLine($"{task.TaskId},{task.Title},{task.DueDate},{task.Status},{task.Project}");
            }
        }
    }

    // Method to load tasks from a file
    public void LoadTasksFromFile(string filePath)
    {
        // Clear existing tasks
        tasks.Clear();

        // Open a StreamReader to read tasks from the specified file
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            // Read each line from the file
            while ((line = reader.ReadLine()) != null)
            {
                // Split the line by comma to extract task details
                string[] data = line.Split(',');
                int taskId = int.Parse(data[0]);
                string title = data[1];
                DateTime dueDate = DateTime.Parse(data[2]);
                string status = data[3];
                string project = data[4];
                // Create a new Task object and add it to the tasks list
                Task task = new Task(taskId, title, dueDate, status, project);
                tasks.Add(task);
            }
        }
    }

    // Method to get a task by its ID
    internal Task GetTaskById(int taskId)
    {
        // Find the task with the given taskId
        Task task = tasks.Find(t => t.TaskId == taskId);

        // If task is found, return it; otherwise, throw an exception
        if (task != null)
        {
            return task;
        }
        else
        {
            throw new Exception("Task not found.");
        }
    }
}
