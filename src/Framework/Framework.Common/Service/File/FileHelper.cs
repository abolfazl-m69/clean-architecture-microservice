using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using HumanResource.Framework.Common.Enums;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace HumanResource.Framework.Common.Service.File
{
    public class FileHelper : IFileHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SiteSettings _siteSettings;

        public FileHelper(IHttpContextAccessor httpContextAccessor, IOptions<SiteSettings> setting)
        {
            _httpContextAccessor = httpContextAccessor;
            _siteSettings = setting.Value;
        }

        public async Task<string> GetImageUrl(Guid fileId, PictureType pictureType, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            using var client = new HttpClient();
            client.BaseAddress = new Uri(_siteSettings.FileServiceUrl);
            client.DefaultRequestHeaders.Add("Authorization", token);

            var response = await client.GetAsync($"api/picture/downloadFromPath/{fileId}/{pictureType}", cancellationToken);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString != null ? _siteSettings.FileServiceUrl + responseString : string.Empty;
        }

        public async Task<string> GetDocumentUrl(Guid fileId, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();

            var client = new RestClient($"{_siteSettings.FileServiceUrl}api/document/downloadFromPath/{fileId}") { Timeout = -1 };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", token);
            var result = await client.ExecuteAsync(request, cancellationToken);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                if (string.IsNullOrEmpty(result.Content)) return string.Empty;

                return _siteSettings.FileServiceUrl + result.Content;
            }
            return string.Empty;
        }

        public async Task<bool> DeleteFile(Guid fileId, CancellationToken cancellationToken, string token = null, FileType type = FileType.Image)
        {
            return type switch
            {
                FileType.Document => await DeleteDocument(fileId, cancellationToken, token),
                FileType.Image => await DeleteImage(fileId, cancellationToken, token),
                _ => throw new InvalidOperationException()
            };
        }

        public async Task<Guid> UploadFile(IFormFile file, CancellationToken cancellationToken, string token = null, FileType type = FileType.Image)
        {
            return type switch
            {
                FileType.Document => await UploadDocument(file, cancellationToken, token),
                FileType.Image => await UploadImage(file, cancellationToken, token),
                _ => throw new InvalidOperationException()
            };
        }

        private async Task<bool> DeleteImage(Guid fileId, CancellationToken cancellationToken, string token = null)
        {
            token = token == null ? _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString() : $"Bearer {token}";

            var client = new RestClient($"{_siteSettings.FileServiceUrl}api/Picture/Delete/{fileId}") { Timeout = 10000 };
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", token);
            var result = await client.ExecuteAsync(request, cancellationToken);
            return result.StatusCode == HttpStatusCode.OK;
        }

        private async Task<bool> DeleteDocument(Guid fileId, CancellationToken cancellationToken, string token = null)
        {
            token = token == null ? _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString() : $"Bearer {token}";

            var client = new RestClient($"{_siteSettings.FileServiceUrl}api/Document/Delete/{fileId}") { Timeout = 10000 };
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", token);
            var result = await client.ExecuteAsync(request, cancellationToken);
            return result.StatusCode == HttpStatusCode.OK;
        }

        private async Task<Guid> UploadImage(IFormFile image, CancellationToken cancellationToken, string token = null)
        {
            token = token == null ? this._httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString() : "Bearer " + token;
            using var client = new HttpClient();
            client.BaseAddress = new Uri(_siteSettings.FileServiceUrl);
            client.DefaultRequestHeaders.Add("Authorization", token);

            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName?.Trim('"');

            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(image.OpenReadStream())
            {
                Headers =
                {
                    ContentLength = image.Length,
                    ContentType = new MediaTypeHeaderValue(image.ContentType)
                }
            }, "file", fileName);

            var response = await client.PostAsync("api/picture/upload", content, cancellationToken);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString != null ? JsonConvert.DeserializeObject<Guid>(responseString) : Guid.Empty;
        }

        private async Task<Guid> UploadDocument(IFormFile document, CancellationToken cancellationToken, string token = null)
        {
            token = token == null ? this._httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString() : "Bearer " + token;
            using var client = new HttpClient();
            client.BaseAddress = new Uri(_siteSettings.FileServiceUrl);
            client.DefaultRequestHeaders.Add("Authorization", token);
            var fileName = ContentDispositionHeaderValue.Parse(document.ContentDisposition).FileName?.Trim('"');

            using var content = new MultipartFormDataContent();

            content.Add(new StreamContent(document.OpenReadStream())
            {
                Headers =
                    {
                        ContentLength = document.Length,
                        ContentType = new MediaTypeHeaderValue(document.ContentType)
                    }
            }, "file", fileName);

            var response = await client.PostAsync("api/document/upload", content, cancellationToken);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString != null ? JsonConvert.DeserializeObject<Guid>(responseString) : Guid.Empty;
        }
    }
}
