using System;

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();

        while (true)
        {
            Console.WriteLine("\n===== Sistema de Gerenciamento de Tarefas =====");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Todas as Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas Pendentes");
            Console.WriteLine("5. Listar Tarefas Concluídas");
            Console.WriteLine("6. Excluir Tarefa");
            Console.WriteLine("7. Pesquisar Tarefas por Palavra-chave");
            Console.WriteLine("8. Exibir Estatísticas");
            Console.WriteLine("0. Sair");

            Console.Write("Escolha uma opção: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Título da Tarefa: ");
                    string? title = Console.ReadLine(); 
                    Console.Write("Descrição da Tarefa: ");
                    string? description = Console.ReadLine(); 
                    Console.Write("Data de Vencimento (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
                    {
                        taskManager.AddTask(title ?? string.Empty, description ?? string.Empty, dueDate); 
                    }
                    else
                    {
                        Console.WriteLine("Formato de data inválido. Tarefa não adicionada.");
                    }
                    break;

                case "2":
                    taskManager.ListAllTasks();
                    break;

                case "3":
                    Console.Write("Índice da Tarefa a ser marcada como concluída: ");
                    if (int.TryParse(Console.ReadLine(), out int completedIndex))
                    {
                        taskManager.MarkTaskAsCompleted(completedIndex);
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido. Operação cancelada.");
                    }
                    break;

                case "4":
                    taskManager.ListPendingTasks();
                    break;

                case "5":
                    taskManager.ListCompletedTasks();
                    break;

                case "6":
                    Console.Write("Índice da Tarefa a ser excluída: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                    {
                        taskManager.DeleteTask(deleteIndex);
                    }
                    else
                    {
                        Console.WriteLine("Índice inválido. Operação cancelada.");
                    }
                    break;

                case "7":
                    Console.Write("Digite a palavra-chave para a pesquisa: ");
                    string? keyword = Console.ReadLine();
                    taskManager.SearchTasks(keyword);
                    break;

                case "8":
                    taskManager.DisplayStatistics();
                    break;

                case "0":
                    Console.WriteLine("Saindo do sistema. Até logo!");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
