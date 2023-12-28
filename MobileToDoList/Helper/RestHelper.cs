using MobileToDoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileToDoList.Helper
{
    public static class RestHelper
    {
        public static async Task<object> LoginMethod(Login login)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://app.elifsoft.com.tr/api/AccountApi/Login");
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(login.username), "username");
                content.Add(new StringContent(login.password), "password");
                request.Content = content;
                var response = client.SendAsync(request);
                return await response.Result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
