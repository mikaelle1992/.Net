using Prova_grupo.Domain;

namespace Prova_grupo.Data{
    public class MedicoRepositorio : PessoaRepoitorio
    {
        private List<Medico> medicoList = new List<Medico>();
        public override void CadastrarMedico(Medico medico){
            base.CadastrarMedico(medico);

            medicoList.Add(medico);
        }

        public List<Medico> ListarTodos(){
            return medicoList;
        }

        public override int TamLista(){
            base.TamLista();
            return medicoList.Count;
        }
        public bool VerificaCRM(string CRM){
            foreach (var medico in medicoList) {
                if(medico.CRM == CRM){
                    return false;
                }
            }
            return true;
        }

        public override bool VerificaCPF(string CPF){
            base.ValidaCPF(CPF);
            foreach (var medico in medicoList) {
                if(medico.CPF == CPF){
                    return false;
                }
            }
            return true;
        }

        public List<Medico> GerarRelatorioIdadeMinMaxMedico(int idadeMinimo, int idadeMaximo){
            return medicoList.FindAll(m => m.IdadePessoa >= idadeMinimo && m.IdadePessoa <= idadeMaximo);
        }


    }
    

}