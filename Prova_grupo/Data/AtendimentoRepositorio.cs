using Prova_grupo.Domain;

namespace Prova_grupo.Data
{
    public class AtendimentoRepositorio
    {
        private List<Atendimento> atendimentoList = new List<Atendimento> ();

        public void AddAtendimento(Atendimento atendimento){
            atendimentoList.Add(atendimento);
        }

        public List<Atendimento> ListarAtendimento(){
            return atendimentoList;
        }
        public int TamListAtendimento(){
            return atendimentoList.Count;
        }

        public bool Delete(int AtendimentoID){
            var removerAtendimento = atendimentoList.Find(x => x.Id == AtendimentoID);
            if(removerAtendimento == null){
                return false;
            }else{
                atendimentoList.Remove(removerAtendimento);
                return true;
            }
        }
        public bool VerificaAtendimentoMedicoPaciente(Medico medicoAtendi, Paciente pacienteAtendida){

            var verificaAtendimento = atendimentoList.Find(x=>x.MedicoResponsavel == medicoAtendi && x._Paciente ==pacienteAtendida);
            if(verificaAtendimento == null){
                return false;
            }else{
                return true;
            }
        }

        public Atendimento buscarPorId(int AtendimentoID){
            return atendimentoList.Find(x => x.Id == AtendimentoID);

        }

        public List<Atendimento> BuscarAtendiSuspeitaDiagnostico(string suspeitaDiagnostico){
            return atendimentoList.FindAll(m => m.SuspeitaInicial.Contains(suspeitaDiagnostico) || m.DiagnosticoFinal.Contains(suspeitaDiagnostico));

        }

        public List<Atendimento> ListarMedicosPorAtendimentosConcluidos(){
            return atendimentoList.OrderBy(x=>x.Fim).ToList();   
        }

        public List<Exame> ListaExamesMaisUtilizadas()
        {
            var todosOsExames = atendimentoList
                .SelectMany(atendimento => atendimento.ListaExamesResultados.Select(tupla => tupla.Item1))
                .ToList();

            var examesAgrupados = todosOsExames
                .GroupBy(exame => exame.Descricao)
                .Select(grupo => new Exame(
                    grupo.Key, 
                    grupo.Average(exame => exame.Valor), 
                    grupo.First().Descricao, 
                    grupo.First().Local
                ))
                .OrderByDescending(exame => exame.Valor)
                .Take(10)
                .ToList();

            return examesAgrupados;
        }

        public List<Atendimento> ListarAtendimentoPorAtendNaoConcl(){
            return atendimentoList.OrderBy(x=>x.Fim==null).ToList();   
        } 

    }
}


