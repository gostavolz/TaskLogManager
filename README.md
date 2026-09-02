# TaskLogManager

App em console feito em C# para registrar e organizar as atividades e tarefas do dia a dia de trabalho. Desenvolvi esse projeto para fixar conceitos de Programação Orientada a Objetos e aprender a salvar dados de forma simples na máquina sem precisar configurar um banco de dados robusto de início.

## 🚀 O que usei no projeto
* **C# e .NET Core**: Base de toda a lógica do sistema.
* **Orientação a Objetos**: Separação das responsabilidades entre o modelo da tarefa (`ActivityLog`) e o serviço que gerencia os arquivos (`LogRepository`).
* **System.Text.Json**: Biblioteca nativa que usei para converter a lista de tarefas em texto estruturado e gravar no arquivo físico.
* **Manipulação de Arquivos (`System.IO`)**: Para ler e escrever o arquivo `dados_tarefas.json` no disco.
* **Expressões Lambda**: Uso do `FindAll` para fazer a busca rápida por termos nos títulos gravados.

## 🛠️ Como rodar o sistema localmente

1. Faça o clone deste repositório:
```bash
git clone https://github.com
```

2. Entre na pasta correspondente:
```bash
cd TaskLogManager
```

3. Execute a aplicação pelo terminal:
```bash
dotnet run
```

## 💾 Persistência
Os dados inseridos no console são gerados e atualizados automaticamente em um arquivo local chamado `dados_tarefas.json` assim que você escolhe a opção de sair no menu principal.
