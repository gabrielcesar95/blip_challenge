# blip_challenge

Desafio para a vaga de Chatbot Developer

O projeto consiste no desenvolvimento de uma API e um contato inteligente para consumo dos repositórios da Blip no Github. O objetivo é listar os repositórios mais antigos, desenvolvidos na linguagem C#

Funcionalidades:
Listagem e filtragem de repositórios por linguagem

## Como executar esse projeto

### API

#### Servidor no Microsoft Azure:

A API está disponível no link: https://blipchallengeapis.azure-api.net. Este é o mesmo link consumido nas requisições feitas pelo Contato Inteligente.

#### .NET

De dentro da pasta `Api`, rodar o comando:

```bash
dotnet run ./Api.sln
```

Uma vez que a API esteja em execução, fazer as requisições para o endpoint retornado no console (ex: http://localhost:5005)

#### Docker

```bash
docker build -t blip_challenge -f dockerfile .
docker run -d --entrypoint "./GithubClient" -p 8080:8080 blip_challenge
```

---

### Contato Inteligente (chatbot)

Importar o arquivo `Flow/mybotflow.json` na [plataforma Blip](https://portal.blip.ai/application), conforme o [tutorial](https://help.blip.ai/hc/pt-br/articles/4474433224087)

## Fazendo requisições

O arquivo `Flow/Insomnia_Collection.json` contém uma Collection do aplicativo Insomnia, para testes de requisições diretas á API do projeto ou á API do Github.
