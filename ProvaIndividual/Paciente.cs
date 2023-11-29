using System;

class Paciente{
    private string Nome{get; set;}
    private string DataNascimento{get; set;}
    private string CPF{get; set;}
    private string Sexo{get; set;}
    private string Sintomas{get; set;}

    public Paciente(string nome, string dataNascimento, string Cpf, string sexo, string sintomas){
        if(string.IsNullOrWhiteSpace(Cpf)){
            throw new Exception("CPF inválido");
        }
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = Cpf;
        Sexo = sexo;
        Sintomas = sintomas;
    }

    public static void CadastrarPaciente(List<Paciente> Pacientes){
        try{
            Console.WriteLine("Digite o Nome do Paciente:");
            string nomePaciente = Console.ReadLine()!;

            Console.WriteLine("Digite o data de nascimento:");
            string dataNascPaciente = Console.ReadLine()!;

            Console.WriteLine("Digite o cpf:");
            string cpfPaciente = Console.ReadLine()!;
            
            Console.WriteLine("Digite o Sexo:");
            string sexo = Console.ReadLine()!;

            Console.WriteLine("Digite os sintomas:");
            string sintomas_ = Console.ReadLine()!;

            if(ValidaCPF(cpfPaciente)){
                if(VerificaCPF(cpfPaciente, Pacientes)){
                    Paciente novoProduto = new Paciente(nomePaciente, dataNascPaciente, cpfPaciente, sexo, sintomas_);
                    Pacientes.Add(novoProduto);
                }else{
                    Console.WriteLine("CPF já cadastrado");
                }
            }else{
                Console.WriteLine("CPF invalido");
            }

        }catch(Exception e){
            Console.WriteLine($"Erro {e}");
        } 
    }
    public static bool ValidaCPF(string CPF){
        return CPF.Length == 11;
    }
    public static bool VerificaCPF(string CPF, List<Paciente> pacientes){
        foreach (var paciente in pacientes) {
            if(paciente.CPF == CPF){
                return false;
            }
        }
        return true;
    }

    public static void ImprimiPaciente(List<Paciente> pacientes){
        foreach (var paciente in pacientes) {
            Console.WriteLine($"--Paciente--: \nCPF{paciente.CPF}, \nNome: {paciente.Nome}, \nDataNasc: {paciente.DataNascimento}, \nSexo: {paciente.Sexo}, \nSintomas: {paciente.Sintomas}, \n");
        }
    }

}