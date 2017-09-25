using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CloudManagement.Helper
{
    public static class HttpExtensionMethods
    {
        public static readonly string AuthenticationScheme = "Authorization";
        public static readonly string AuthenticationType = "Basic ";
        /// <summary>
        /// Executes the HTTP GET service call.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <param name="token">The token value.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// Request Url cannot be null or white space.
        /// or
        /// Endpoint cannot be null or white space.
        /// or
        /// Resource cannot be null or white space.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">tokenManager</exception>
        public static async Task<HttpResponseMessage> ExecuteGetServiceCall(this string requestUrl, string token, string endpoint)
        {
            ValidateParameters(requestUrl, token, endpoint);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(endpoint);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationScheme, token);

                return await httpClient.GetAsync(endpoint + requestUrl).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Executes the HTTP POST service call.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUrl">The request URL.</param>
        /// <param name="token">The token value.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="postContent">Content of the post.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">postContent</exception>
        public static async Task<HttpResponseMessage> ExecutePostServiceCall<T>(this string requestUrl, string token, string endpoint, T postContent)
        {
            ValidateParameters(requestUrl, token, endpoint);
            if (postContent == null)
            {
                throw new ArgumentNullException(nameof(postContent));
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(endpoint);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationScheme, token);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(postContent), Encoding.UTF8, "application/json");

                return await httpClient.PostAsync(requestUrl, content).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Executes the HTTP DELETE service call.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <param name="token">The token value.</param>
        /// <param name="endpoint">The endpoint.</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> ExecuteDeleteServiceCall(this string requestUrl, string token, string endpoint)
        {
            ValidateParameters(requestUrl, token, endpoint);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(endpoint);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationScheme, token);

                return await httpClient.DeleteAsync(requestUrl).ConfigureAwait(false);
            }
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private static void ValidateParameters(string requestUrl, string token, string endpoint)
        {
            if (string.IsNullOrWhiteSpace(requestUrl))
            {
                throw new ArgumentException("Request Url cannot be null or white space.");
            }

            if (string.IsNullOrWhiteSpace(endpoint))
            {
                throw new ArgumentException("Endpoint cannot be null or white space.");
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentNullException("Token cannot be null or white space.");
            }
        }
    }
}