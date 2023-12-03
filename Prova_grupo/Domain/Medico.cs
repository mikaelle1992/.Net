namespace Prova_grupo.Domain{

    public class Medico: Pessoa {

        public Medico(string nome, DateTime dataNascimento, string cpf, string Crm)
            : base(nome, dataNascimento, cpf){

            if (string.IsNullOrWhiteSpace(cpf)){
                throw new Exception("CPF inválido");
            }

        CRM = Crm;
    }
        public string CRM{get; set;}

    }
}
