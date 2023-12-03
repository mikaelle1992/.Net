using Prova_grupo.Data;
using Prova_grupo.Domain;
using Prova_grupo.Service;
using System.Text;

namespace Prova_grupo.Service
{
    public class AtendimentoService
    {
        AtendimentoRepositorio atendimentoRepositorio = new AtendimentoRepositorio();

        public string iniciarAtendimento(DateTime inicio, string suspeitaInicial, List<(Exame, string)> examesResultado, float valor, Medico medicoResponsavel, Paciente paciente){
            var bulder = new StringBuilder();
            var atendimentoid = atendimentoRepositorio.TamListAtendimento() + 1;
            var verificaAtendimento = atendimentoRepositorio.VerificaAtendimentoMedicoPaciente(medicoResponsavel, paciente);

            if (!verificaAtendimento){
                return bulder.Append("Médico já atendeu essa paciente!").ToString();
            }else{
                atendimentoRepositorio.AddAtendimento(new Atendimento(atendimentoid, inicio, suspeitaInicial, examesResultado, valor, medicoResponsavel, paciente));
                bulder.Append("Medico adicionado com sucesso!").ToString(); 
            }

            return bulder.ToString();
        }


        public string fimAtendimento(DateTime fimData, string diagnostico, int id){
            var bulder = new StringBuilder();
            var fimAtend = atendimentoRepositorio.buscarPorId(id);
            var tamanhoLista = atendimentoRepositorio.TamListAtendimento();

            if(tamanhoLista == 0){
                return bulder.Append("Lista vazia!").ToString();
            }if(fimData <= fimAtend.Inicio){
                return bulder.Append("Data final só poderá ser posterior à data inicial!").ToString();
            }
            if(fimData > fimAtend.Inicio){
                fimAtend.Fim = fimData;
                fimAtend.DiagnosticoFinal = diagnostico;
                bulder.Append("Atendimento finalizado com sucesso");
            }
            return bulder.ToString();
        }

        public string BuscaPorAtendimentoFinalizado(){
            var bulder = new StringBuilder();
            var buscaPorAtendimentoConclui = atendimentoRepositorio.ListarMedicosPorAtendimentosConcluidos();
            var tamanhoLista = atendimentoRepositorio.TamListAtendimento();

            if(tamanhoLista == 0){
                return bulder.Append("Lista vazia!").ToString();
            }else{
                foreach(Atendimento atendimento in buscaPorAtendimentoConclui){
                    bulder.AppendLine($"--Paciente--: \nInicio: {atendimento.Inicio}, \nSuspeita Inicial: {atendimento.SuspeitaInicial}, \nValor: {atendimento.Valor}, \nFim: {atendimento.Fim}, \nMédico: {atendimento.MedicoResponsavel}, \nPaciente: {atendimento._Paciente}, \nDiagnostico: {atendimento.DiagnosticoFinal}, \n");
                    foreach ((Exame exame, string resultado) in atendimento.ListaExamesResultados){
                        bulder.AppendLine($"- Exame - \nTítulo: {exame.Titulo}, \nValor: {exame.Valor}, \nDescrição: {exame.Descricao}, \nLocal: {exame.Local}, \nResultado: {resultado}");
                    }
                }
                return bulder.ToString();
            }
        }


        public string BuscaPorSuspeitaDiagnosticoFinal(string suspeitaDiagnostico){
            var bulder = new StringBuilder();
            var buscaPorSuspeitaDiag = atendimentoRepositorio.BuscarAtendiSuspeitaDiagnostico(suspeitaDiagnostico);
            var tamanhoLista = atendimentoRepositorio.TamListAtendimento();

            if(tamanhoLista == 0){
                return bulder.Append("Lista vazia!").ToString();
            }else{
                foreach(Atendimento atendimento in buscaPorSuspeitaDiag){
                    bulder.AppendLine($"--Paciente--: \nInicio: {atendimento.Inicio}, \nSuspeita Inicial: {atendimento.SuspeitaInicial}, \nValor: {atendimento.Valor}, \nFim: {atendimento.Fim}, \nMédico: {atendimento.MedicoResponsavel}, \nPaciente: {atendimento._Paciente}, \nDiagnostico: {atendimento.DiagnosticoFinal}, \n");
                    foreach ((Exame exame, string resultado) in atendimento.ListaExamesResultados){
                        bulder.AppendLine($"- Exame - \nTítulo: {exame.Titulo}, \nValor: {exame.Valor}, \nDescrição: {exame.Descricao}, \nLocal: {exame.Local}, \nResultado: {resultado}");
                    }
                }
                return bulder.ToString();
            }
        }

        public string ListarMedicosPorAtendimentosConcluidosOrdenada(){
            var bulder = new StringBuilder();
            var listaOrdenadaPoratendeConcluido = atendimentoRepositorio.ListarMedicosPorAtendimentosConcluidos();
            var tamanhoLista = atendimentoRepositorio.TamListAtendimento();

            if(tamanhoLista == 0){
                return bulder.Append("Lista vazia!").ToString();
            }else{
                foreach(Atendimento atendimento in listaOrdenadaPoratendeConcluido){
                    bulder.AppendLine($"--Paciente--: \nInicio: {atendimento.Inicio}, \nSuspeita Inicial: {atendimento.SuspeitaInicial}, \nValor: {atendimento.Valor}, \nFim: {atendimento.Fim}, \nMédico: {atendimento.MedicoResponsavel}, \nPaciente: {atendimento._Paciente}, \nDiagnostico: {atendimento.DiagnosticoFinal}, \n");
                    foreach ((Exame exame, string resultado) in atendimento.ListaExamesResultados)
                    {
                        bulder.AppendLine($"- Exame - \nTítulo: {exame.Titulo}, \nValor: {exame.Valor}, \nDescrição: {exame.Descricao}, \nLocal: {exame.Local}, \nResultado: {resultado}");
                    }
                }
                return bulder.ToString();
                
            }
        }




    }
}

