using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TaskLogManager
{
    public class LogRepository
    {
        // Define onde o arquivo vai ser criado (na mesma pasta onde o app roda)
        private string arquivoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dados_tarefas.json");

        // Método pra salvar a lista atualizada
        public void GravarDados(List<ActivityLog> lista)
        {
            try
            {
                // Deixando o json identado pra ficar fácil de ler se eu abrir o arquivo na mão
                var configuracao = new JsonSerializerOptions { WriteIndented = true };
                string jsonTexto = JsonSerializer.Serialize(lista, configuracao);
                
                File.WriteAllText(arquivoPath, jsonTexto);
            }
            catch (Exception erro)
            {
                // Se der ruim na escrita do arquivo, avisa no terminal pro app não fechar do nada
                Console.WriteLine("Erro ao tentar salvar no arquivo: " + erro.Message);
            }
        }

        // Método que busca os dados quando o app inicia
        public List<ActivityLog> CarregarDados()
        {
            try
            {
                // Se for a primeira vez rodando e o arquivo não existir, retorna a lista zerada
                if (!File.Exists(arquivoPath))
                {
                    return new List<ActivityLog>();
                }

                string jsonTexto = File.ReadAllText(arquivoPath);
                
                // Converte o texto de volta pra lista de objetos C#
                var resultado = JsonSerializer.Deserialize<List<ActivityLog>>(jsonTexto);
                
                return resultado ?? new List<ActivityLog>();
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao carregar o arquivo: " + erro.Message);
                return new List<ActivityLog>();
            }
        }
    }
}
