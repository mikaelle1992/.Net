using System;
using System.Collections.Generic;

class Program {

    static void Main(){
        List<Produto> produtos = new List<Produto>();
        while (true)
        {
            Console.WriteLine("\n===== Sistema de Gerenciamento de Produtos =====");
            Console.WriteLine("1. Adicionar Produtos");
            Console.WriteLine("2. Listar Todas as Produtos");
            Console.WriteLine("3. Pesquisar Produtos");
            Console.WriteLine("4. Atualizar Produtos");
            Console.WriteLine("5. Gerar Relatorio de Estoque Baixo");
            Console.WriteLine("5. Gerar Relatorio de  entre os Valores Minimo e Maximo");
            Console.WriteLine("7. Gerar Relatorio Valor do Total do Estoque");
            Console.WriteLine("0. Sair");

            Console.Write("Escolha uma opção: ");
            string? opc = Console.ReadLine();

            switch(opc){
                case "1":
                    do {
                        SolicitaDados(produtos);

                        Console.WriteLine("Deseja cadastrar outro produto? (S/N)");
                    } while (Console.ReadLine()?.Trim().ToUpper() == "S");
                    
                    foreach(Produto produto in produtos){
                        Console.WriteLine(produto.ToString());
                    }
                    break;
                case "2":
                    Produto.ListaProdutos(produtos);
                    break;

                case "3":
                    Produto.ConsultaProduto(produtos);
                    break;

                case "4":
                        Produto.AtualizarProduto(produtos);
                    break;

                case "5":
                    int limiteEstoqueBaixo = 5;
                       Produto.GerarRelatorioEstoqueBaixo(limiteEstoqueBaixo, produtos);
                    break;
                case "6":
                        int valorMin= 10;
                        int valorMax = 150;

                       Produto.GerarRelatorioValorMinMax(valorMin, valorMax, produtos);
                    break;
                case "7":
                       Produto.GerarRelatorioValorTotalEstoque(produtos);
                    break;
                case "0":
                    Console.WriteLine("Saindo do sistema. Até logo!");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;

            }
        }    
    }

    static void SolicitaDados(List<Produto> produtos){

        try{
            Console.WriteLine("Digite o código do produto:");
            string codigoProduto = Console.ReadLine()!;

            Console.WriteLine("Digite o nome do produto:");
            string nomeProduto = Console.ReadLine()!;

            Console.WriteLine("Digite a quantidade do produto:");
            int qtd = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite o preço Unitário do produto:");
            float precoProduto = float.Parse(Console.ReadLine()!);

            Produto novoProduto = new Produto(codigoProduto, nomeProduto, qtd, precoProduto);

            Produto.CadastrarProduto(novoProduto, produtos);
        }catch(Exception e){
            Console.WriteLine($"Erro {e}");
        }     
    }
}

class Produto{
    private string CodigoProduto { get; set; }
    private string NomeProduto { get; set; }
    private int Quantidade { get; set; }
    private float PrecoUnitario { get; set; }

    public Produto(string codigoProduto, string nomeProduto, int quantidade, float preco){
        if(string.IsNullOrWhiteSpace(codigoProduto)){
            throw new Exception("Código do Produto inválido");
        }
        CodigoProduto = codigoProduto;
        NomeProduto = nomeProduto;
        Quantidade = quantidade;
        PrecoUnitario = preco;
    }

    public static void CadastrarProduto(Produto produto, List<Produto> produtos){
        produtos.Add(produto);
    }

    public override string ToString() {
        return $"Código: {CodigoProduto}, Nome: {NomeProduto}, Quantidade: {Quantidade}, Preço: {PrecoUnitario}";
    }

    public static int BuscaProdutoIndex(List<Produto> produtos, string codigo){
        try{
            for(int i = 0; i < produtos.Count; i++){
                if(produtos[i].CodigoProduto == codigo){
                    return i;
                }
            }
            return -1;
           
        } catch(Exception e){
            Console.WriteLine(e.Message);
            return -1; 
        }
    }

    public static void ListaProdutos(List<Produto> produtos){
        Console.WriteLine("-----Lista de Produtos-----");
        
        foreach(Produto produto in produtos){
            Console.WriteLine($"Código: {produto.CodigoProduto}, \nNome: {produto.NomeProduto},\nQuantidade: {produto.Quantidade}, \nPreço: {produto.PrecoUnitario}");
        }
    }

    public static void ConsultaProduto(List<Produto> produtos){
        Console.WriteLine("Digite o código do produto para busca:");
        string codigoProdutoBusca = Console.ReadLine()!;

        var index_ = BuscaProdutoIndex( produtos, codigoProdutoBusca);
        if(index_ > -1){
            Console.WriteLine(produtos[index_].ToString());

        }else{
            throw new Exception("Produto não encontrado!");
            
        }          
    }

    public static void AtualizarProduto(List<Produto> produtos) {

        Console.WriteLine("Digite o código do produto para atualização:");
        string codigoProdutoAtualizar = Console.ReadLine()!;

        int indiceProduto = BuscaProdutoIndex(produtos, codigoProdutoAtualizar);

        if (indiceProduto != -1) {
            try {

                Console.WriteLine("Digite a nova quantidade do produto:");
                int novaQuantidade = int.Parse(Console.ReadLine()!);

                if (produtos[indiceProduto].Quantidade + novaQuantidade < 0) {
                    Console.WriteLine("Quantidade insuficiente para essa saída.");
                
                }else{
                    produtos[indiceProduto].Quantidade += novaQuantidade;
                    Console.WriteLine($"Quantidade atualizado: {produtos[indiceProduto].Quantidade}");
                }
               
            } catch (FormatException ex) {
                Console.WriteLine($"Erro na atualização: {ex.Message}");
            }
        } else {
            Console.WriteLine("Produto não encontrado para atualização!");
        }

    }

    public static void GerarRelatorioEstoqueBaixo(int limite, List<Produto> produtos) {
        var produtosBaixoEstoque = produtos.Where(p => p.Quantidade < limite).ToList();

        Console.WriteLine("Produtos com estoque baixo:");
        foreach (var produto in produtosBaixoEstoque) {
            Console.WriteLine($"Código: {produto.CodigoProduto}, Nome: {produto.NomeProduto}, Quantidade: {produto.Quantidade}");
        }
    }

    public static void GerarRelatorioValorMinMax(float minimo, float maximo, List<Produto> produtos) {
        var produtosNoIntervalo = produtos.Where(p => p.PrecoUnitario >= minimo && p.PrecoUnitario <= maximo).ToList();

        Console.WriteLine($"Produtos com valor entre {minimo:C} e {maximo:C}:");
        foreach (var produto in produtosNoIntervalo) {
            Console.WriteLine($"Código: {produto.CodigoProduto}, Nome: {produto.NomeProduto}, Preço: {produto.PrecoUnitario}");
        }
    }

    public static void GerarRelatorioValorTotalEstoque(List<Produto> produtos) {
        if (produtos.Count == 0) {
            Console.WriteLine("Nenhum produto disponível para gerar o relatório de valor total do estoque.");
            return;
        }

        float valorTotalEstoque = produtos.Sum(p => p.PrecoUnitario * p.Quantidade);

        Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");

        Console.WriteLine("Valor total de cada produto de acordo com seu estoque:");
        foreach (var produto in produtos) {
            float valorTotalProduto = produto.PrecoUnitario * produto.Quantidade;
            Console.WriteLine($"Código: {produto.CodigoProduto}, Nome: {produto.NomeProduto}, Valor Total: {valorTotalProduto:C}");
        }
    }

}

