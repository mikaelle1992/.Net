using System;
class Program{

    static void Main(){
        List<Medico> medicos = new List<Medico>();
        List<Paciente> pacientes = new List<Paciente>();

        while (true)
        {
            Console.WriteLine("\n===== Sistema de Gerenciamento medico =====");
            Console.WriteLine("1. Adicionar Medico");
            Console.WriteLine("2. Lista de Medicos");
            Console.WriteLine("3. Adicionar Paciente");
            Console.WriteLine("4. Lista de Paciente");
            Console.WriteLine("5. Gerar Relatorio de  entre a idade Minima e Maxima do medico");
            Console.WriteLine("6. Gerar Relatorio de  entre a idade Minima e Maxima do Paciente");
            Console.WriteLine("7. Listar pacientes pelo sexo");
            Console.WriteLine("0. Sair");

            Console.Write("Escolha uma opção: ");
            string? opc = Console.ReadLine();

            switch(opc){
                case "1":
                    do {
                         Medico.CadastrarMedico(medicos);
                        Console.WriteLine("Deseja cadastrar outro produto? (S/N)");
                    } while (Console.ReadLine()?.Trim().ToUpper() == "S");
                    
                    break;
                case "2":
                    if(VerificaTamanhoListaMedico(medicos) > 0){
                        Medico.ImprimiMedicos(medicos);
                    }else{
                        Console.WriteLine("----Lista Vazia");
                    }
                    break;

                case "3":

                    do {
                        Paciente.CadastrarPaciente(pacientes);
                        Console.WriteLine("Deseja cadastrar outro produto? (S/N)");
                    } while (Console.ReadLine()?.Trim().ToUpper() == "S");
                    break;

                case "4":
                        if(VerificaTamanhoListaPaciente(pacientes) > 0){
                            Paciente.ImprimiPaciente(pacientes);
                        }else{
                            Console.WriteLine("---Lista Vazia");
                        }
                    break;

                case "5":
                        if(VerificaTamanhoListaMedico(medicos) > 0){
                            Medico.GerarRelatorioIdadeMinMax(31, 32, medicos);
                        }else{
                            Console.WriteLine("---Lista Vazia");
                        }

                    break;
                case "6":
                        if(VerificaTamanhoListaPaciente(pacientes) > 0){
                            Paciente.GerarRelatorioIdadeMinMaxPaciente(31, 21, pacientes);
                        }else{
                            Console.WriteLine("---Lista Vazia");
                        }

                    break;
                case "7":
                        if(VerificaTamanhoListaPaciente(pacientes) > 0){
                            Paciente.BuscarPacientesPeloSexo("feminimo", pacientes);
                        }else{
                            Console.WriteLine("---Lista Vazia");
                        }
                    break;
                case "0":
                    Console.WriteLine("Saindo do sistema. Até logo!");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;

            }
        }  

        static int VerificaTamanhoListaMedico(List<Medico> medicos) {
            return medicos.Count;
        }

        static int VerificaTamanhoListaPaciente(List<Paciente> pacientes) {
            return pacientes.Count;
        }
    }
}
