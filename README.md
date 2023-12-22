# FinControl - Back-End MVP

## Versão Atual: 0.1.0

## Visão Geral

Bem-vindo ao FinControl, uma aplicação de controle financeiro pessoal. Este repositório contém o código-fonte do back-end da versão inicial do produto (MVP). O MVP se concentra em fornecer funcionalidades básicas para o gerenciamento de contas, transações e categorias.

## Tecnologias Utilizadas

- **Plataforma:** .NET 8
- **ORM (Object-Relational Mapping):** Entity Framework Core
- **Linguagem de Programação:** C#
- **Banco de Dados:** PostgreSQL
- **Arquitetura:** 3 Camadas (Presentation, Business, Data)
- **Autenticação:** JWT (JSON Web Tokens)

## Estrutura do Projeto

O projeto segue a arquitetura de 3 camadas, com as seguintes principais entidades:

1. **User:** Representa um usuário e suas transações financeiras.
2. **Transaction:** Registra uma transação financeira, associada a um usuário e a uma categoria.
3. **Category:** Categorias para classificar transações.
4. **Account:** Gerencia contas, permitindo a associação de vários usuários com diferentes papéis.

## Funcionalidades Principais (MVP)

1. **Registro de Usuário:**
   - Cadastro e autenticação de usuários utilizando JWT.

2. **Gestão de Transações:**
   - Adição, atualização e remoção de transações.
   - Categorização automática de transações.

3. **Gestão de Contas:**
   - Criação de contas, associando usuários com diferentes papéis (Owner, Contributor, Viewer).
   - Associação de transações a contas.

4. **Relatórios Básicos:**
   - Geração de relatórios simples com informações de gastos e receitas.

5. **Segurança:**
   - Autenticação de usuário usando JWT.
   - Proteção de dados sensíveis.

## Iniciando

1. **Pré-requisitos:**
   - Instale o .NET 8.
   - Configure um banco de dados PostgreSQL.

2. **Configuração do Projeto:**
   - Clone este repositório.
   - Configure a conexão com o banco de dados PostgreSQL no arquivo de configuração `appsettings.json`.
   - Configure as chaves para JWT no arquivo `appsettings.json`.

3. **Execução:**
   - Execute `dotnet run` para iniciar o servidor.

## Estrutura de Diretórios

- **FinControlPro.Presentation:** Camada de apresentação.
- **FinControlPro.Business:** Camada de lógica de negócios.
- **FinControlPro.Data:** Camada de acesso a dados.
  
## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).

---

**Edson Santos**
