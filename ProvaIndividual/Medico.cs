using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

class Medico{
    private string Nome{get; set;}
    private string DataNascimento{get; set;}
    private string CPF{get; set;}
    private string CRM{get; set;}

    public Medico(string nome, string dataNascimento, string Cpf, string Crm){
        if(string.IsNullOrWhiteSpace(Cpf)){
            throw new Exception("Código do Produto inválido");
        }
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = Cpf;
        CRM = Crm;
    }

    public static void CadastrarMedico(List<Medico> medicos){
        try{
            Console.WriteLine("Digite o Nome do medico:");
            string nomeMedico = Console.ReadLine()!;

            Console.WriteLine("Digite o data de nascimento:");
            string dataNascMedico = Console.ReadLine()!;

            Console.WriteLine("Digite o cpf:");
            string cpfMedico = Console.ReadLine()!;
            
            Console.WriteLine("Digite o CRM:");
            string crm = Console.ReadLine()!;
            if(ValidaCPF(cpfMedico)){

                if(VerificaCRM(crm, medicos)){
                    Medico novoProduto = new Medico(nomeMedico, dataNascMedico, cpfMedico, crm);
                    medicos.Add(novoProduto);
                }else{
                    Console.WriteLine("CRM já cadastrado");
                }
            }else{
                throw new Exception("CPF invalido");
            }

        }catch(Exception e){
            Console.WriteLine($"Erro {e}");
        } 

    }
    public static bool ValidaCPF(string CPF){
        return CPF.Length == 11;
    }

    public static bool VerificaCRM(string CRM, List<Medico> medicos){
        foreach (var medico in medicos) {
            if(medico.CRM == CRM){
                return false;
            }
        }
        return true;
    }

    public static void ImprimiMedicos(List<Medico> medicos){
        foreach (var medico in medicos) {
            Console.WriteLine($"--Medico--: \nCPF{medico.CPF}, \nNome: {medico.Nome}, \nDataNasc: {medico.DataNascimento}, \nCRM: {medico.CRM}");
        }
    }
}
