# Fluxo de Caixa - Backend

Este projeto é uma aplicação de **Backend** desenvolvida em **.NET Core 8**, responsável por gerenciar o fluxo de caixa de uma aplicação financeira. A arquitetura do sistema segue o padrão de serviços, com dois principais componentes.

## Tecnologias Utilizadas

- **.NET Core 8**: Plataforma de desenvolvimento utilizada para construir a aplicação.
- **Entity Framework Core**: Para o mapeamento de dados relacionais com o banco de dados.
- **SQL Server/MongoDb**: Bancos de dados utilizados na aplicação.
- **Swagger**: Para documentação e teste da API.
- **Docker**: Para contêineres da aplicação e do banco de dados.

## Estrutura do Projeto

A aplicação é composta por dois serviços principais:

1. **Serviço Relatório**: Responsável por gerar o relatório de saldo consolidado das transações realizadas.
2. **Serviço de Fluxo de Caixa**: Gerencia as entradas e saídas de caixa, registrando todas as transações financeiras realizadas.

Cada serviço está desacoplado, garantindo maior escalabilidade e flexibilidade para manutenção e novas implementações.

## Arquitetura

Abaixo está a arquitetura utilizada no projeto. Esta imagem ilustra os principais componentes e a comunicação entre os serviços.

![Arquitetura do Sistema](https://github.com/cVidalSP/FluxoCaixa/blob/main/ArquiteturaFluxoCaixa.png)

## Como Executar o Projeto

### Pré-requisitos
- [Docker](https://www.docker.com/): para instalação, preparo e subida do projeto.
  
