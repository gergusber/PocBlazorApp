using CRUDPOC.Client.Interfaces;
using CRUDPOC.Shared.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRUDPOC.Client.Services
{
    public class FilmService : IFilmService
    {
        private HttpClient _client;

        public FilmService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> DeleteFilm(string id)
        {
            var uri = "Film/" + id;
            var res = await _client.DeleteAsync(uri);
            return res.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<FilmDto>> GetAllFilms()
        {
            return await _client.GetFromJsonAsync<IEnumerable<FilmDto>>("Film");
        }

        public async Task<FilmDto> GetFilmsDetails(string id)
        {
            var uri = "Film/" + id;
            var apiResponse = await _client.GetFromJsonAsync<FilmDto>(uri);
            return apiResponse;
        }

        public async Task SaveFilm(FilmDto film)
        {
            if (film.Id != null)
            {
                using var response = await _client.PutAsJsonAsync<FilmDto>("Film", film);
                var algo = await response.Content.ReadFromJsonAsync<JsonElement>();
            }
            else
            {
                using var response = await _client.PostAsJsonAsync<FilmDto>("Film", film);
                var algo = await response.Content.ReadFromJsonAsync<JsonElement>();
            }
        }
    }
}