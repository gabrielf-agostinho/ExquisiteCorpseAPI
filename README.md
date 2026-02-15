# ExquisiteCorpseAPI

API REST para geração de frases aleatórias baseada no conceito de Exquisite Corpse (cadáver esquisito), permitindo combinações dinâmicas de palavras organizadas por idioma.

## Estrutura do Projeto

```text
📦ExquisiteCorpseAPI
 ┣ 📂ExquisiteCorpseAPI
 ┃ ┣ 📂Controllers
 ┃ ┃ ┗ 📜Generate.controller.cs
 ┃ ┣ 📂Data
 ┃ ┃ ┣ 📜Context.cs
 ┃ ┃ ┗ 📜ExquisiteCorpse.db
 ┃ ┣ 📂Enums
 ┃ ┃ ┗ 📜Languages.enum.cs
 ┃ ┣ 📂Extensions
 ┃ ┃ ┗ 📜Language.extension.cs
 ┃ ┣ 📂Mappings
 ┃ ┃ ┣ 📜Adjective.mapping.cs
 ┃ ┃ ┣ 📜Language.mapping.cs
 ┃ ┃ ┣ 📜ObjectWord.mapping.cs
 ┃ ┃ ┣ 📜Subject.mapping.cs
 ┃ ┃ ┣ 📜Verb.mapping.cs
 ┃ ┃ ┗ 📜WordBaseMapping.cs
 ┃ ┣ 📂Migrations
 ┃ ┃ ┣ 📜20260215145254_Initial.cs
 ┃ ┃ ┣ 📜20260215145254_Initial.Designer.cs
 ┃ ┃ ┗ 📜ContextModelSnapshot.cs
 ┃ ┣ 📂Models
 ┃ ┃ ┣ 📜Adjective.cs
 ┃ ┃ ┣ 📜Language.cs
 ┃ ┃ ┣ 📜ObjectWord.cs
 ┃ ┃ ┣ 📜Subject.cs
 ┃ ┃ ┣ 📜Verb.cs
 ┃ ┃ ┗ 📜WordBase.cs
 ┃ ┣ 📂Properties
 ┃ ┃ ┗ 📜launchSettings.json
 ┃ ┣ 📂Repositories
 ┃ ┃ ┣ 📂Interfaces
 ┃ ┃ ┃ ┣ 📜IGenerate.repository.cs
 ┃ ┃ ┃ ┗ 📜ILanguage.repository.cs
 ┃ ┃ ┣ 📜Generate.repository.cs
 ┃ ┃ ┗ 📜Language.repository.cs
 ┃ ┣ 📂Services
 ┃ ┃ ┣ 📂Interfaces
 ┃ ┃ ┃ ┣ 📜IGenerate.service.cs
 ┃ ┃ ┃ ┗ 📜ILanguage.service.cs
 ┃ ┃ ┣ 📜Generate.service.cs
 ┃ ┃ ┗ 📜Language.service.cs
 ┃ ┣ 📜appsettings.Development.json
 ┃ ┣ 📜appsettings.json
 ┃ ┣ 📜DependencyInjector.cs
 ┃ ┣ 📜ExquisiteCorpseAPI.csproj
 ┃ ┗ 📜Program.cs
 ┣ 📜.gitignore
 ┣ 📜ExquisiteCorpseAPI.sln
 ┣ 📜LICENSE
 ┗ 📜README.md
 ```

 ## Tecnologias
  * .NET 9
  * Entity Framework Core
  * SQLite
  * ASP.NET Web API

 ## Instalação

 Clone o repositório:

 ```bash
 git clone https://github.com/gabrielf-agostinho/ExquisiteCorpseAPI.git
 cd ExquisiteCorpseAPI
 ```

 Restaure as dependências
 
 ```bash
 dotnet restore
 ```

 Execute a aplicação
 
 ```bash
 dotnet run
 ```

 A API estará disponível em:

```bash
 http://localhost:5059
 ```

## Banco de dados

  * O projeto utiliza SQLite como banco de dados.

  * O banco é criado automaticamente na inicialização

  * Seeds são aplicados para popular dados iniciais

## Seed de dados

O projeto possui um mecanismo de seed para popular palavras por idioma.

Exemplo de idioma:
```text
 Português Brasileiro (pt-BR)
 ```

Cada idioma possui:

  * Subjects

  * Adjectives

  * Verbs

  * ObjectWords

## Geração de frases

A geração de frases ocorre combinando registros aleatórios de cada categoria:

```text
 Subject + Adjective + Verb + Object
 ```

 Exemplo:

 ```text
 "O gato curioso observa o universo"
 ```

 ## Endpoints (exemplo)
 
 Gerar frase

```bash
 curl -X GET "http://localhost:5059/api/generate?acronym=pt-BR"
 ```

 Response

 ```bash
"O cachorro estranho destrói a realidade"
 ```

## Licença
Este projeto está sob a licença MIT.
Veja o arquivo `LICENSE` para mais detalhes.