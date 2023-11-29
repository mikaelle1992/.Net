using System;
using System.Xml.Serialization;

class Paciente{
    private string Nome{get; set;}
    private DateTime DataNascimento{get; set;}
    private string CPF{get; set;}
    private string Sexo{get; set;}
    private string Sintomas{get; set;}

    public int IdadePaciente => DateTime.Now.Year -DataNascimento.Year;


    public Paciente(string nome, DateTime dataNascimento, string Cpf, string sexo, string sintomas){
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
            DateTime dataNascPaciente = DateTime.Parse(Console.ReadLine()!);

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

    public static void GerarRelatorioIdadeMinMaxPaciente(int idadeMinimo, int idadeMaximo, List<Paciente> pacientes) {
    var idadeNoIntervalo = pacientes.Where(m => m.IdadePaciente >= idadeMinimo && m.IdadePaciente <= idadeMaximo).ToList();

    Console.WriteLine($"Médicos com idade entre {idadeMinimo} e {idadeMaximo}:");
    foreach (var paciente in idadeNoIntervalo) {
        Console.WriteLine($"Paciente \nNome: {paciente.Nome}, Idade: {paciente.IdadePaciente}");
    }
    }

    public static void BuscarPacientesPeloSexo(string sexo,List<Paciente> pacientes){
        var pacientesSexo = pacientes.Where(m => m.Sexo == sexo).ToList();
        foreach (var paciente in pacientes) {
            Console.WriteLine($"Paciente \nNome: {paciente.Nome}, Sexo: {paciente.Sexo}");
            
        }

    }


}