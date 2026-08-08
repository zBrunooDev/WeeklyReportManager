# WeeklyReportManager

O **WeeklyReportManager** é uma aplicação desenvolvida em **C# (.NET Console)** para registrar, consultar, editar e excluir atividades realizadas ao longo do dia. O projeto surgiu de uma necessidade real do meu ambiente de trabalho: em determinado momento, fui questionado como se eu não estivesse produzindo ou não tivesse evidências claras das atividades que executava diariamente.

Em vez de apenas registrar tarefas de forma improvisada, decidi transformar esse problema em um projeto para praticar desenvolvimento de software, programação orientada a objetos, organização em camadas, refatoração e controle de versão com Git.

Mais do que um exercício técnico, este projeto representa um passo importante na minha evolução como desenvolvedor.

## Funcionalidades da V1

* Cadastro de atividades
* Listagem de todas as atividades registradas
* Busca de atividade por ID
* Edição de atividades
* Exclusão de atividades
* Interface de console organizada com mensagens padronizadas
* Estrutura separada em camadas (Model, Service e UI)

## Tecnologias utilizadas

* C#
* .NET
* Console Application
* Git
* GitHub

## Estrutura do projeto

```text
WeeklyReportManager
│
├── Model
│   └── ActivityReport.cs
│
├── Service
│   └── ActivityReportService.cs
│
├── UI
│   └── Menu.cs
│
└── Program.cs
```

## Como executar

1. Clone o repositório
2. Abra a solução no Visual Studio
3. Execute o projeto
4. Utilize o menu para cadastrar, listar, editar e excluir atividades

## Próximos passos (V2)

A V1 foi desenvolvida para consolidar conceitos fundamentais de C# e POO. A próxima etapa do projeto será transformá-lo em um sistema mais completo de organização de atividades, incluindo:

* Persistência dos dados em arquivo (JSON ou banco de dados)
* Organização de tarefas por status (A Fazer, Em Andamento e Concluído)
* Indicadores de produtividade
* Relatórios por período
* Gráficos de desempenho
* Dashboard com estatísticas
* Interface mais avançada (Windows Forms, WPF ou aplicação Web)

A ideia é evoluir o WeeklyReportManager de um registrador simples de atividades para uma ferramenta de acompanhamento de produtividade e gestão de tarefas.

## Aprendizados

Durante o desenvolvimento desta versão pratiquei:

* Programação Orientada a Objetos
* Encapsulamento e separação de responsabilidades
* Organização em camadas
* Refatoração
* Métodos auxiliares e reutilização de código
* Tratamento de entradas do usuário
* Estruturação de commits com Git
* Evolução incremental de um projeto real

Este projeto continua em desenvolvimento e será utilizado como base para futuras versões e novos estudos dentro do ecossistema .NET.
