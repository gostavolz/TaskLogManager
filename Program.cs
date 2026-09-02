using System;
using System.Collections.Generic;

namespace TaskLogManager
{
    class Program
    {
        static void Main(string[] args)
        {
            LogRepository repo = new LogRepository();
            List<ActivityLog> meusLogs = repo.CarregarDados();
            
            bool rodando = true;

            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("--- GERENCIADOR DE TAREFAS (LOGS) ---");
                Console.WriteLine("1 - Cadastrar Nova Atividade");
                Console.WriteLine("2 - Mostrar Todos os Logs");
                Console.WriteLine("3 - Filtrar por Título");
                Console.WriteLine("4 - Salvar Dados e Sair");
                Console.Write("\nEscolha uma das opções acima: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CriarNovoLog(meusLogs);
                        break;
                    case "2":
                        ExibirLogs(meusLogs);
                        break;
                    case "3":
                        FiltrarLogs(meusLogs);
                        break;
                    case "4":
                        repo.GravarDados(meusLogs);
                        Console.WriteLine("\nAlterações salvas! Fechando o programa...");
                        rodando = false;
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Aperte qualquer tecla pra tentar de novo.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CriarNovoLog(List<ActivityLog> lista)
        {
            Console.Clear();
            Console.WriteLine("[ NOVO REGISTRO ]\n");

            Console.Write("Título do Log: ");
            string t = Console.ReadLine();

            Console.Write("Descrição da Atividade: ");
            string d = Console.ReadLine();

            Console.Write("Tempo gasto (em minutos): ");
            // Usei int.TryParse pra não quebrar o programa se o usuário digitar uma letra sem querer
            if (int.TryParse(Console.ReadLine(), out int tempo))
            {
                ActivityLog novo = new ActivityLog(t, d, tempo);
                lista.Add(novo);
                Console.WriteLine("\nSucesso! Adicionado na lista temporária.");
            }
            else
            {
                Console.WriteLine("\nErro: O tempo precisa ser um número inteiro. Cadastro cancelado.");
            }

            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static void ExibirLogs(List<ActivityLog> lista)
        {
            Console.Clear();
            Console.WriteLine("[ TODOS OS LOGS SALVOS ]\n");

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum registro encontrado por enquanto.");
            }
            else
            {
                foreach (var item in lista)
                {
                    Console.WriteLine($"ID: {item.Id} | Data: {item.CreatedAt:dd/MM/yyyy HH:mm}");
                    Console.WriteLine($"Título: {item.Title}");
                    Console.WriteLine($"Duração: {item.MinutesSpent} min");
                    Console.WriteLine($"Resumo: {item.Description}");
                    Console.WriteLine("----------------------------------------");
                }
            }

            Console.WriteLine("\nAperte qualquer tecla para voltar...");
            Console.ReadKey();
        }

        static void FiltrarLogs(List<ActivityLog> lista)
        {
            Console.Clear();
            Console.WriteLine("[ FILTRAR POR TERMO ]\n");

            Console.Write("Digite o termo que busca no título: ");
            string busca = Console.ReadLine()?.ToLower();

            // Usando FindAll com uma expressão lambda simples pra buscar as ocorrências
            var encontrados = lista.FindAll(x => x.Title.ToLower().Contains(busca));

            Console.WriteLine($"\nEncontrei {encontrados.Count} resultado(s):\n");

            foreach (var item in encontrados)
            {
                Console.WriteLine($"-> [{item.Id}] {item.Title} - {item.MinutesSpent} min");
                Console.WriteLine($"   {item.Description}");
                Console.WriteLine();
            }

            Console.WriteLine("Aperte qualquer tecla para retornar...");
            Console.ReadKey();
        }
    }
}
