using System;

class Paciente{
    private string Nome{get; set;}
    private string DataNascimento{get; set;}
    private string CPF{get; set;}
    private string Sexo{get; set;}
    private string Sintomas{get; set;}

    public Paciente(string nome, string dataNascimento, string Cpf, string sexo, string sintomas){
        if(string.IsNullOrWhiteSpace(CPF)){
            throw new Exception("Código do Produto inválido");
        }
        Nome = nome;
        DataNascimento = dataNascimento;
        CPF = Cpf;
        Sexo = sexo;
        Sintomas = sintomas;
    }
}