using EstoqueSabadin.Aplicacao;
using EstoqueSabadin.Enum;
using Microsoft.AspNetCore.Components;
using System;

namespace EstoqueSabadin
{
    class Program
    {
        private static CategoriaAplicacao _categoriaAplicacao = new();
        private static ProdutoAplicacao _produtoAplicacao = new();

        public Program(CategoriaAplicacao categoriaAplicacao, ProdutoAplicacao produtoAplicacao)
        {
            _produtoAplicacao = produtoAplicacao;
            _categoriaAplicacao = categoriaAplicacao;
        }

        private static SituacaoEnum ValidarSituacao(int situacao)
        {
            if (situacao == 0)
            {
                return SituacaoEnum.Desativado;
            }
            if (situacao == 1)
            {
                return SituacaoEnum.Desativado;
            }
            else
            {
                throw new Exception("Opção de situação é invalida.");
            }
        }

        private static void AtualizarCategoria()
        {
            Console.Clear();
            _categoriaAplicacao.ExibirListaCategorias();
            if (_categoriaAplicacao.ExisteAlgumaCategoria())
            {
                Console.Write("Digite o ID que deseja atualizar =>");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Digite o novo nome =>");
                var nome = Console.ReadLine();
                Console.Write("Digite a situacao (1 ativo, 2 inativo) =>");
                int situacao = int.Parse(Console.ReadLine());
                var situacaoEnum = ValidarSituacao(situacao);

                _categoriaAplicacao.Editar(nome, situacaoEnum, id);
            }
            else
            {
                ExibeContinuar();
            }
        }

        private static void CadastrarCategoria()
        {
            Console.Write("Nome:");
            string nome = Console.ReadLine();
            Console.Write("Situacao (0 - ATIVO, 1 - INATIVO):");
            int situacao = int.Parse(Console.ReadLine());
            var situacaoEnum = ValidarSituacao(situacao);

            _categoriaAplicacao.Cadastrar(nome, situacaoEnum);
        }

        private static void MenuCategoria()
        {
            Console.Clear();
            Console.Write("1 - Cadastrar \n2 - Atualizar \n3 - Listar categorias \nSua opcão -->");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    CadastrarCategoria();
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    AtualizarCategoria();
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    _categoriaAplicacao.ExibirListaCategorias();
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Opcao invalida, tente novamente");
                    Console.ReadKey();
                    break;
            }
        }

        private static void MenuProduto()
        {
            Console.Clear();
            Console.Write("1 - Cadastrar \n2 - Atualizar \n3 - Listar categorias \n\nSua opcão -->");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    CadastrarProduto();
                    break;

                case 2:
                    Console.Clear();
                    AtualizarProduto();
                    break;

                case 3:
                    Console.Clear();
                    ExibirProdutos();
                    break;

                default:
                    Console.WriteLine("Opcao invalida, tente novamente");
                    ExibeContinuar();
                    break;
            }
        }

        private static void ExibirProdutos()
        {
            _produtoAplicacao.ExibirProdutos();
            ExibeContinuar();
        }

        private static void AtualizarProduto()
        {
            _produtoAplicacao.ExibirProdutos();
            if (_produtoAplicacao.PossiuAlgumCadastro())
            {
                Console.Write("Digite o ID que deseja atualizar: ");
                int id = int.Parse(Console.ReadLine());
                if (_produtoAplicacao.ObterProdutoId(id) != null)
                {
                    Console.Write("Digite o nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite o valor: ");
                    decimal valor = decimal.Parse(Console.ReadLine());
                    Console.Write("Digite a situacao: ");
                    SituacaoEnum situacao = ValidarSituacao(int.Parse(Console.ReadLine()));
                    Console.WriteLine("==========================================================");
                    _categoriaAplicacao.ExibirListaCategorias();
                    Console.Write("Digite a categoria: ");
                    var categoria = _categoriaAplicacao.BuscarCategoriaPorId(int.Parse(Console.ReadLine()));

                    _produtoAplicacao.AtualizarProduto(id,nome, valor, situacao, categoria);
                }
                else
                {
                    Console.WriteLine("Produto selecionado nao existe");
                }
            }
            ExibeContinuar();
        }

        private static void CadastrarProduto()
        {
            if (_categoriaAplicacao.ExisteAlgumaCategoria())
            {
                Console.Write("Nome do produto: ");
                var nome = Console.ReadLine();
                Console.Write("Quantidade inicial do estoque: ");
                var estoque = int.Parse(Console.ReadLine());
                Console.Write("Valor de venda: ");
                var valor = decimal.Parse(Console.ReadLine());
                Console.Write("Situação (0 - ATIVO, 1 - INATIVO: ");
                var situacao = ValidarSituacao(int.Parse(Console.ReadLine()));
                Console.Write($"Selecione uma categoria para o produto:\n");
                _categoriaAplicacao.ExibirListaCategorias();
                var categoria = _categoriaAplicacao.BuscarCategoriaPorId(int.Parse(Console.ReadLine()));
                _produtoAplicacao.Cadastrar(nome, estoque, valor, situacao, categoria);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nescessario cadastrar categorias primeiro");
                ExibeContinuar();
            }

        }

        private static void MenuPrincipal()
        {
            Console.Clear();
            Console.Write("1 - Menu de produtos \n2 - Menu de categorias \nSua opcão -->");
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    MenuProduto();
                    break;

                case 2:
                    MenuCategoria();
                    break;

                default:
                    Console.WriteLine("Opcao invalida, tente novamente");
                    Console.ReadKey();
                    break;
            }
        }

        private static void ExibeContinuar()
        {
            Console.Write("Aperte ENTER para continuar: ");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                MenuPrincipal();
            }
        }
    }
}
