using Core.Dtos;
using Core.Models.Entities.User;

namespace AxionTech.WEB.GetApi;

    public class UserApi
    {
        private readonly HttpClient _httpClient;

        public UserApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<UserResponseModel> List()
        {
            var response = _httpClient
                .GetFromJsonAsync<APIResponseDTO<List<UserResponseModel>>>("User/List")
                .Result;

            return response.Data;
        }


    }

