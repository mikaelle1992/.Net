using System;
class Program{

    static void Main(){
        List<Medico> medicos = new List<Medico>();

        while (true)
        {
            Console.WriteLine("\n===== Sistema de Gerenciamento medico =====");
            Console.WriteLine("1. Adicionar Medico");
            Console.WriteLine("2.");
            Console.WriteLine("3. ");
            Console.WriteLine("4.");
            Console.WriteLine("5. ");
            Console.WriteLine("5. Gerar Relatorio de  entre os Valores Minimo e Maximo");
            Console.WriteLine("7. ");
            Console.WriteLine("0. Sair");

            Console.Write("Escolha uma opção: ");
            string? opc = Console.ReadLine();

            switch(opc){
                case "1":
                    do {

                        Console.WriteLine("Deseja cadastrar outro produto? (S/N)");
                    } while (Console.ReadLine()?.Trim().ToUpper() == "S");
                    
                
                    break;
                case "2":
                    
                    break;

                case "3":
                    
                    break;

                case "4":
                        
                    break;

                case "5":
                   
                    break;
                case "6":

                    break;
                case "7":
                       
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

    static bool ValidaCPF(string cpf){
        return cpf.Length == 11;
    }
}
