using Api.Repositories.GithubApi.Contracts;
using Newtonsoft.Json;

namespace Api.Repositories.GithubApi.V3;

class Repository : BaseRepository, IRepository
{
    public async Task<IEnumerable<Models.Repository>> GetRepositories()
    {
        var response = await List("orgs/takenet/repos");

        // var test = JsonConvert.DeserializeObject<Models.Repository>(response);

        // TODO: Retornar repositórios como no model (ignorando parametros a mais retornados pela API)
        return [];

        // TODO (menor prioridade): Cache dos resultados e parâmetros recebidos
    }



}