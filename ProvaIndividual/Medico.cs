using System;
using System.Runtime.CompilerServices;

class Medico{
    private string Nome{get; set;}
    private string DataNascimento{get; set;}
    private string CPF{get; set;}
    private string CRM{get; set;}

    public Medico(string nome, string dataNascimento, string Cpf, string Crm){
        if(string.IsNullOrWhiteSpace(CPF)){
            throw new Exception("Código do Produto inválido");
        }
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = Cpf;
        CRM = Crm;
    }

    public static void CadastrarMedico(Medico medico, List<Medico> medicos){
        medicos.Add(medico);
    }

    public static void ValidacoesDados(Medico medico){
        
    }
    public static void SolicitaDados(List<Medico> medicos){

        try{
            Console.WriteLine("Digite o Nome do medico:");
            string nomeMedico = Console.ReadLine()!;

            Console.WriteLine("Digite o data de nascimento:");
            string dataNascMedico = Console.ReadLine()!;

            Console.WriteLine("Digite o cpf:");
            string cpfMedico = Console.ReadLine()!;
            
            Console.WriteLine("Digite o preço Unitário do produto:");
            string crm = Console.ReadLine()!;

            Medico novoProduto = new Medico(nomeMedico, dataNascMedico, cpfMedico, crm);

            Medico.CadastrarMedico(novoProduto, medicos);


        }catch(Exception e){
            Console.WriteLine($"Erro {e}");
        }     
    }
}