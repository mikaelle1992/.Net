using System;
using System.Collections.Generic;
using System.Linq;

public class TaskManager
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(string? title, string? description, DateTime dueDate)
    {
        title ??= string.Empty;
        description ??= string.Empty;

        Task newTask = new Task
        {
            Title = title,
            Description = description,
            DueDate = dueDate
        };
        tasks.Add(newTask);
        Console.WriteLine("Tarefa adicionada com sucesso!");
    }

    public void ListAllTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"Título: {task.Title}");
            Console.WriteLine($"Descrição: {task.Description}");
            Console.WriteLine($"Data de Vencimento: {task.DueDate}");
            Console.WriteLine($"Concluída: {task.IsCompleted}");
            Console.WriteLine("------------------------");
        }
    }

    public void MarkTaskAsCompleted(int taskIndex)
    {
        if (taskIndex >= 0 && taskIndex < tasks.Count)
        {
            tasks[taskIndex].IsCompleted = true;
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Índice de tarefa inválido.");
        }
    }

    public void ListPendingTasks()
    {
        var pendingTasks = tasks.Where(task => !task.IsCompleted).ToList();
        Console.WriteLine("Tarefas Pendentes:");
        foreach (var task in pendingTasks)
        {
            Console.WriteLine($"Título: {task.Title}");
            Console.WriteLine($"Data de Vencimento: {task.DueDate}");
            Console.WriteLine("------------------------");
        }
    }

    public void ListCompletedTasks()
    {
        var completedTasks = tasks.Where(task => task.IsCompleted).ToList();
        Console.WriteLine("Tarefas Concluídas:");
        foreach (var task in completedTasks)
        {
            Console.WriteLine($"Título: {task.Title}");
            Console.WriteLine($"Data de Vencimento: {task.DueDate}");
            Console.WriteLine("------------------------");
        }
    }

    public void DeleteTask(int taskIndex)
    {
        if (taskIndex >= 0 && taskIndex < tasks.Count)
        {
            tasks.RemoveAt(taskIndex);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else
        {
            Console.WriteLine("Índice de tarefa inválido.");
        }
    }

    public void SearchTasks(string? keyword)
    {
        keyword ??= string.Empty; 
        var matchingTasks = tasks.Where(task =>
            task.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            task.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

        Console.WriteLine($"Tarefas encontradas com a palavra-chave '{keyword}':");
        foreach (var task in matchingTasks)
        {
            Console.WriteLine($"Título: {task.Title}");
            Console.WriteLine($"Data de Vencimento: {task.DueDate}");
            Console.WriteLine("------------------------");
        }
    }

    public void DisplayStatistics()
    {
        int pendingCount = tasks.Count(task => !task.IsCompleted);
        int completedCount = tasks.Count(task => task.IsCompleted);

        if (tasks.Any())
        {
            var oldestTask = tasks.OrderBy(task => task.DueDate).First();
            var newestTask = tasks.OrderByDescending(task => task.DueDate).First();

            Console.WriteLine($"Número de tarefas pendentes: {pendingCount}");
            Console.WriteLine($"Número de tarefas concluídas: {completedCount}");
            Console.WriteLine($"Tarefa mais antiga: {oldestTask.Title} (Data de Vencimento: {oldestTask.DueDate})");
            Console.WriteLine($"Tarefa mais recente: {newestTask.Title} (Data de Vencimento: {newestTask.DueDate})");
        }
        else
        {
            Console.WriteLine("Não há tarefas registradas.");
        }
    }
}
