namespace ATI.ProjectPrueba.Frontend.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> GetAsync<T>(string url);

        Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model); // no devuelve respuesta

        Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T mode); // si devuelve respuesta


    }
}
