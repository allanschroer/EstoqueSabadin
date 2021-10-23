using EstoqueSabadin.Aplicacao;
using EstoqueSabadin.Enum;
using Microsoft.AspNetCore.Components;
using System;

namespace EstoqueSabadin
{
    class Program
    {
        private static CategoriaAplicacao _categoriaAplicacao = new CategoriaAplicacao();

        public Program(CategoriaAplicacao categoriaAplicacao)
        {
            _categoriaAplicacao = categoriaAplicacao;
        }

        
        static void Main(string[] args)
        {
            while (true)
            {
                MenuPrincipal();
            }
        }

        private static void Atualizar()
        {
            Console.Write("Digite o ID que deseja atualizar =>");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Digite o novo nome =>");
            var nome = Console.ReadLine();
            Console.Write("Digite a situacao (1 ativo, 2 inativo) =>");
            int situacao = int.Parse(Console.ReadLine());
            var situacaoEnum = ValidarSituacao(situacao);

            _categoriaAplicacao.Editar(new Modelos.CategoriaModelo { Nome = nome, Situacao = situacaoEnum }, id );
        }

        private static void Cadastrar()
        {
            Console.Write("ID:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nome:");
            string nome = Console.ReadLine();
            Console.Write("Situacao (1 ou 2):");
            int situacao = int.Parse(Console.ReadLine());
            var situacaoEnum = ValidarSituacao(situacao);

            _categoriaAplicacao.Cadastrar(id, nome, situacaoEnum);
        }

        private static SituacaoEnum ValidarSituacao(int situacao)
        {
            if (situacao == 2)
            {
                return SituacaoEnum.Desativado;
            }
            else
            {
                return SituacaoEnum.Ativo;
            }
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
                    Cadastrar();
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Clear();
                    Atualizar();
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
    }
}
