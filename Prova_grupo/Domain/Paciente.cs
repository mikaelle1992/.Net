namespace Prova_grupo.Domain{
  public class Paciente: Pessoa{

    public string Sexo{get; set;}
    public List<string> Sintomas{get; set;}
    public Paciente(string nome, DateTime dataNascimento, string cpf, string sexo, List<string> sintomas)
            : base(nome, dataNascimento, cpf){
                
            if (string.IsNullOrWhiteSpace(cpf)){
                throw new Exception("CPF inválido");
            }

            Sexo = sexo;
            Sintomas = sintomas;
        }
    }
}