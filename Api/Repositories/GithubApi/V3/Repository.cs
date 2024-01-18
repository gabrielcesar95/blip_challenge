
using Api.Models;
using Api.Repositories.GithubApi.Contracts;

namespace Api.Repositories.GithubApi;

class Repository : IRepository
{
    public async Task<IEnumerable<Models.Repository>> GetRepositories()
    {
        // TODO: requisitar á API

        // TODO: Retornar repositórios como no model (ignorando parametros a mais retornados pela API)
        return new List<Models.Repository> { new Models.Repository() };

        // TODO (menor prioridade): Cache dos resultados e parâmetros recebidos
    }

}