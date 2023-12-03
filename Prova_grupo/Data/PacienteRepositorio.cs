using System.Runtime.Serialization;
using Prova_grupo.Domain;

namespace Prova_grupo.Data
{
    public class PacienteRepositorio: PessoaRepoitorio
    {
        private List<Paciente> pacienteList = new List<Paciente>();
        private List<string> sintomas = new List<string> ();

        public override void CadastrarPaciente(Paciente paciente)
        {
            base.CadastrarPaciente(paciente);
            pacienteList.Add(paciente);

        }

        public void AddSintomas(string sintoma){
            sintomas.Add(sintoma);
        }

        public List<Paciente> ListaTodosPacientes(){
            return pacienteList;
        }

        public override int TamLista()
        {
            base.TamLista();
            return pacienteList.Count;
        }

        public override bool VerificaCPF(string CPF){
            base.ValidaCPF(CPF);
            foreach (var paciente in pacienteList) {
                if(paciente.CPF == CPF){
                    return false;
                }
            }
            return true;
        }

        public List<Paciente> GerarRelatorioIdadeMinMaxPaciente(int idadeMinimo, int idadeMaximo){
            return pacienteList.FindAll(m => m.IdadePessoa >= idadeMinimo && m.IdadePessoa <= idadeMaximo);
        }

        public List<Paciente> BuscarPacientesPeloSexo(string sexo){
            return pacienteList.FindAll(m => m.Sexo == sexo);

        }

        public List<Paciente> ImprimiPacienteOrdemAlfabetica(){
            return pacienteList.OrderBy(p => p.Nome).ToList();
        }

        public List<Paciente> BuscaPacienteSintomas(string sintoma){
            return pacienteList.FindAll(p => p.Sintomas.Contains(sintoma));
        }


        


    }
}