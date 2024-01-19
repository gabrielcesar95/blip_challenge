using Api.Repositories.GithubApi.Contracts;

namespace Api.Repositories.GithubApi.V3;

class Repository : BaseRepository, IRepository
{
    public async Task<IEnumerable<Models.Repository>> GetRepositories()
    {
        // TODO: requisitar á API
        var response = await this.List("orgs/takenet/repos");

        // TODO: Retornar repositórios como no model (ignorando parametros a mais retornados pela API)
        return [];

        // TODO (menor prioridade): Cache dos resultados e parâmetros recebidos
    }

}