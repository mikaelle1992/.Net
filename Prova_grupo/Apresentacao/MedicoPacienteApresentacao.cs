using Prova_grupo.Service;
using Prova_grupo.Domain; 

namespace Prova_grupo.Apresentacao{
    public class MedicoPacienteApresentacao{
        MedicoService medicoService = new MedicoService();
        PacienteService pacienteService = new PacienteService();

        public void Menu(){
            List<string> sintomasLista = new List<string>();
            string operador = String.Empty;

            while(operador!="0"){
                Console.WriteLine("1 -Adicionar um novo Medico");
                Console.WriteLine("2 -Listar todos os Medicos");
                Console.WriteLine("3 -Gerar Relatorio de  entre a idade Minima e Maxima do medico");
                Console.WriteLine("4 -Adicionar um novo Paciente");
                Console.WriteLine("5 -Listar todos os Pacientes");
                Console.WriteLine("6 -Listar por ordem alfabetica");
                Console.WriteLine("7 -Gerar Relatorio de  entre a idade Minima e Maxima do paciente");
                Console.WriteLine("8 -Listar Pacientes pelo sexo");
                Console.WriteLine("9 -Listar Pacientes pelos sintomas");
                operador = Console.ReadLine()!;

                switch(operador){
                    case "1":
                        Console.WriteLine("Digite o Nome do medico:");
                        string nomeMedico = Console.ReadLine()!;

                        Console.WriteLine("Digite o data de nascimento:");
                        DateTime dataNascMedico = DateTime.Parse(Console.ReadLine()!);

                        Console.WriteLine("Digite o cpf:");
                        string cpfMedico = Console.ReadLine()!;
                        
                        Console.WriteLine("Digite o CRM:");
                        string crm = Console.ReadLine()!;

                        var response = medicoService.AddMedico(nomeMedico, dataNascMedico, cpfMedico,crm);
                        Console.WriteLine(response);
                        Console.WriteLine("---------------------");

                        break;
                    case "2":
                        var response02 = medicoService.ListarTodosMedicos();
                        Console.WriteLine(response02);
                        Console.WriteLine("---------------------");
                        break;
                    case "3":
                        var response03 = medicoService.GerarRelatorioIdadeMinMax(20, 31);
                        Console.WriteLine(response03);
                        Console.WriteLine("---------------------");
                        break;

                    case "4":
                        Console.WriteLine("Digite o Nome do paciente:");
                        string nomePaciente = Console.ReadLine()!;

                        Console.WriteLine("Digite o data de nascimento:");
                        DateTime dataNascPaciente = DateTime.Parse(Console.ReadLine()!);

                        Console.WriteLine("Digite o cpf:");
                        string cpfPaciente = Console.ReadLine()!;
                        
                        Console.WriteLine("Digite o Sexo (Feminino/ Masculino):");
                        string sexo = Console.ReadLine()!;

                        do {
                            Console.WriteLine("Digite os sintomas:");
                            string sintoma = Console.ReadLine()!;
                            sintomasLista.Add(sintoma);
                            Console.WriteLine("Deseja adicionar mais um sintoma? (S/N)");
                        } while (Console.ReadLine()?.Trim().ToUpper() == "S");

                        var response04 = pacienteService.AddPaciente(nomePaciente, dataNascPaciente, cpfPaciente, sexo, sintomasLista);
                        Console.WriteLine(response04);
                        Console.WriteLine("---------------------");

                        break;
                    case "5":
                        var response05 = pacienteService.ListarPacientes();
                        Console.WriteLine(response05);
                        Console.WriteLine("---------------------");
                        break;

                    case "6":
                        var response06 = pacienteService.ListarPacientesOrdemAlfab();
                        Console.WriteLine(response06);
                        Console.WriteLine("---------------------");
                        break;

                    case "7":
                        var response07 = pacienteService.GerarRelatorioIdadeMinMaxPaciente(20, 35);
                        Console.WriteLine(response07);
                        Console.WriteLine("---------------------");
                        break;

                    case "8":
                        Console.WriteLine("Digite o Sexo (Feminino/ Masculino) para a busca");
                        string sexoPaciente = Console.ReadLine()!;

                        var response08 = pacienteService.BuscaPacienSexo(sexoPaciente);
                        Console.WriteLine(response08);
                        Console.WriteLine("---------------------");
                        break;

                    case "9":
                        Console.WriteLine("Digite os sintomas para a buscar");
                        string sintomasPaciente = Console.ReadLine()!;
                        var response09 = pacienteService.BuscarPacientesPorSintomas(sintomasPaciente);
                        Console.WriteLine(response09);
                        Console.WriteLine("---------------------");
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;
                }

            }

        }


        public void MenuApresentacao(){

            ExameService examesLista = new ExameService();

            
            AtendimentoService atendimentoService = new AtendimentoService();

            List<(Exame, string)> listaExamesAtendimento = new List<(Exame, string)>();

            string operador = String.Empty;

            while(operador!="0"){
                Console.WriteLine("1 -Iniciar Atendimento");
                Console.WriteLine("2 -Listar atendimentos em aberto");
                Console.WriteLine("3 -Buscar atendimento por suspeita ou diagnostico");
                Console.WriteLine("4 -Listar atendimentos não finalizados");
                Console.WriteLine("5 -Listar exames mais utilizados");
                Console.WriteLine("6 -Listar Medicos por quantidade de atendimento concluido");
                Console.WriteLine("7 -Finalizar atendimento");
                operador = Console.ReadLine()!;

                switch(operador){
                    case "1":
                        Console.WriteLine("Digite a suspeita inicial:");
                        string suspeitaInicial = Console.ReadLine()!;

                        do {
                            Console.WriteLine("Digite o titulo do exame:");
                            string titulo = Console.ReadLine()!;

                            Console.WriteLine("Digite o valor do  exame:");
                            float valor = float.Parse(Console.ReadLine()!);

                            Console.WriteLine("Digite a descrição do exame:");
                            string descricao = Console.ReadLine()!;


                            Console.WriteLine("Digite o local exame:");
                            string local = Console.ReadLine()!;


                            listaExamesAtendimento.Add((new Exame(titulo, valor, descricao, local), null));
                            Console.WriteLine("Deseja adicionar mais um sintoma? (S/N)");
                        } while (Console.ReadLine()?.Trim().ToUpper() == "S");

                        Console.WriteLine("Digite o valor do  exame:");
                        float valorAtendimento = float.Parse(Console.ReadLine()!);

                        //Lista de medicos para o atendimento;
                        medicoService.ListarTodosMedicos();

                        Console.WriteLine("Escolha o medico pelo id:");
                        int idMedico = int.Parse(Console.ReadLine()!);
                        var buscaMedicoId = medicoService.BuscarMedicoPorId(idMedico);


                        //Lista de pacienentes para o atendimento;
                        pacienteService.ListarPacientes();
    

                        Console.WriteLine("Escolha o paciente pelo id:");
                        int idPaciente = int.Parse(Console.ReadLine()!);
                        var buscaPaciente = pacienteService.BuscarPacientePorId(idPaciente);

                        atendimentoService.iniciarAtendimento( suspeitaInicial, listaExamesAtendimento, valorAtendimento, buscaMedicoId, buscaPaciente );

                        var response = "";
                        Console.WriteLine(response);
                        Console.WriteLine("---------------------");

                        break;
                    case "2":
                        var response02 = "";
                        Console.WriteLine(response02);
                        Console.WriteLine("---------------------");
                        break;
                    case "3":
                        var response03 = "";
                        Console.WriteLine(response03);
                        Console.WriteLine("---------------------");
                        break;

                    case "4":

                        var response04 ="";
                        Console.WriteLine(response04);
                        Console.WriteLine("---------------------");

                        break;
                    case "5":
                        var response05 = "";
                        Console.WriteLine(response05);
                        Console.WriteLine("---------------------");
                        break;

                    case "6":
                        var response06 = "";
                        Console.WriteLine(response06);
                        Console.WriteLine("---------------------");
                        break;

                    case "7":
                        var response07 = "";
                        Console.WriteLine(response07);
                        Console.WriteLine("---------------------");
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;
                }

            }

        }

    }
}