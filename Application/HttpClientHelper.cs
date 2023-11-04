using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Application
{
    public enum HttpRequestTypeEnum
    {
        Body,
        QueryString
    }

    public class HttpClientHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public LogLevel LogLevel { get; set; } = LogLevel.Trace;

        private readonly List<Type> _dateTimeTypes = new List<Type>
        {
            typeof(DateTimeOffset),
            typeof(DateTime)
        };

        private readonly List<Type> _invalidTypes = new List<Type>
        {
            typeof(string),
            typeof(string),
            typeof(object),
            typeof(object)
        };

        private JsonSerializerOptions _jsonSerializer = new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PropertyNameCaseInsensitive = true,
            IgnoreNullValues = true,
        };
        private TimeSpan? _timeout = null;

        public HttpClientHelper(IHttpClientFactory httpClientFactory, ILogger<HttpClientHelper> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            if (ServicePointManager.MaxServicePointIdleTime > 10000)
            {
                ServicePointManager.MaxServicePointIdleTime = 10000;
            }

            if (ServicePointManager.MaxServicePoints > 0)
            {
                ServicePointManager.MaxServicePoints = 0;
            }

        }

        public async Task<TResponse> CallApi<TRequest, TResponse>(HttpMethod httpMethod, string url,
            TRequest requestModel, WebHeaderCollection headers = null,
            HttpRequestTypeEnum requestType = HttpRequestTypeEnum.Body, long timeoutMillisecond = 0,
            CancellationToken cancellationToken = default)
        {
            return await CallApi<TResponse>(typeof(TRequest), httpMethod, url, requestModel, headers, requestType,
                timeoutMillisecond, cancellationToken);
        }

        public async Task<TResponse> CallApi<TResponse>(HttpMethod httpMethod, string url, object requestModel,
            WebHeaderCollection headers = null, HttpRequestTypeEnum requestType = HttpRequestTypeEnum.Body,
            long timeoutMillisecond = 0, CancellationToken cancellationToken = default)
        {
            var type = typeof(object);
            if (requestModel != null)
                type = requestModel.GetType();

            return await CallApi<TResponse>(type, httpMethod, url, requestModel, headers, requestType,
                timeoutMillisecond, cancellationToken);
        }

        private async Task<TResponse> CallApi<TResponse>(Type type, HttpMethod httpMethod, string url,
            object requestModel, WebHeaderCollection headers = null,
            HttpRequestTypeEnum requestType = HttpRequestTypeEnum.Body, long timeoutMillisecond = 0,
            CancellationToken cancellationToken = default)
        {
            var response = await GetResponse(type, httpMethod, url, requestModel, headers, requestType,
                timeoutMillisecond,
                cancellationToken);

            return await ReadResponse<TResponse>(response);
        }

        private async Task<HttpResponseMessage> GetResponse<TRequest>(Type type, HttpMethod httpMethod, string url,
            TRequest requestModel, WebHeaderCollection headers, HttpRequestTypeEnum requestType,
            long timeoutMillisecond,
            CancellationToken cancellationToken)
        {
            url = url.Replace("//", "/").Replace(":/", "://");
            if (cancellationToken == default) cancellationToken = CancellationToken.None;
            if (headers == null) headers = new WebHeaderCollection();
            var headerDic = new Dictionary<string, string>();
            foreach (string key in headers.AllKeys)
            {
                headerDic.Add(key, headers[key]);
            }

            using (var request = BuildRequest(type, httpMethod, url, requestModel, headerDic, requestType))
            {
                var client = _httpClientFactory.CreateClient("HttpClient");
                if (timeoutMillisecond != 0)
                {
                    client.Timeout = TimeSpan.FromMilliseconds(timeoutMillisecond);

                }
                else
                {
                    if (_timeout.HasValue && _timeout.Value != default && _timeout.Value.TotalMinutes > 0)
                    {
                        client.Timeout = _timeout.Value;
                    }
                }
                try
                {
                    var response =
                        await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

                    return response;
                }
                catch (Exception ex)
                {
                    string cont;
                    try
                    {
                        if (request.Content != null)
                            cont = await request.Content.ReadAsStringAsync();
                        else
                            cont = "Content is null !";
                    }
                    catch (Exception exx)
                    {
                        cont = exx.Message;
                    }

                    _logger.LogError($"Response for request {url} is {ex.Message} ABS( {request.RequestUri.AbsoluteUri} ) Body: {cont} --- {ex.StackTrace}");
                    if (ex.Message.Contains("Cancel") && ex.Message.Contains("Task")) return null;
                    throw;
                }
            }
        }

        private HttpRequestMessage BuildRequest<TRequest>(Type type, HttpMethod httpMethod, string url,
            TRequest requestModel,
            Dictionary<string, string> headers, HttpRequestTypeEnum requestType,
            JsonSerializerOptions serializerOptions = null)
        {
            var request = GetRequest(type, httpMethod, url, requestModel, requestType, serializerOptions, headers);

            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json;v=1.0;v=1.0"));
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> pair in headers)
                {
                    if (string.IsNullOrWhiteSpace(pair.Key)) continue;
                    if (request.Headers.Contains(pair.Key)) request.Headers.Remove(pair.Key);
                    if (string.IsNullOrWhiteSpace(pair.Value)) continue;
                    request.Headers.Add(pair.Key, pair.Value);
                }
            }

            return request;
        }

        private HttpRequestMessage GetRequest<TRequest>(Type type, HttpMethod httpMethod, string url,
            TRequest requestModel,
            HttpRequestTypeEnum requestType, JsonSerializerOptions serializerOptions,
            Dictionary<string, string> headers)
        {
            var body = string.Empty;
            serializerOptions = serializerOptions ?? _jsonSerializer;
            var request = new HttpRequestMessage(httpMethod, url);
            if (requestType == HttpRequestTypeEnum.Body)
            {
                body = requestModel == null ? null : JsonSerializer.Serialize(requestModel, serializerOptions);
                request.Content = body == null ? null : new StringContent(body, Encoding.UTF8, "application/json");
            }
            else if (requestType == HttpRequestTypeEnum.QueryString)
            {
                if (requestModel != null)
                    url = $"{url.TrimEnd('?')}?{GetQueryString(requestModel, type)}";

                request.RequestUri = new Uri(url);
            }
            else
            {
                throw new Exception("Invalid request type");
            }

            var regex = new Regex("(\"[Pp][Aa][Ss][Ss][Ww][Oo][Rr][Dd]\":[ ]*\")([^\"]*)(\"[,}])");
            if (!string.IsNullOrWhiteSpace(body) && regex.IsMatch(body))
            {
                body = regex.Replace(body, "$1******$3");
            }

            var logMessage = $"Request is sent to: {request.RequestUri.AbsoluteUri}, Type: {type}, Data: {body}, Headers: ";
            if (headers.Any())
            {
                logMessage += headers.Select(header => $"{header.Key}: {header.Value}")
                    .Aggregate((current, next) => $"{current}, {next}");
            }
            _logger.Log(LogLevel, logMessage);

            return request;

        }

        private string GetQueryString<TRequest>(TRequest requestModel, Type type)
        {
            var queryString = string.Empty;

            if (typeof(IDictionary).IsAssignableFrom(type))
            {
                var enumerator = ((IDictionary)requestModel).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current != null)
                    {
                        var item = (DictionaryEntry)enumerator.Current;
                        queryString += $"{item.Key}={item.Value}&";
                    }
                }
                return queryString.TrimEnd('&');
            }

            foreach (var item in type.GetProperties())
            {
                var value = item.GetValue(requestModel);
                if (value != null)
                {
                    if (typeof(IEnumerable).IsAssignableFrom(item.PropertyType) && item.PropertyType != typeof(string))
                    {
                        var isEnum = false;
                        if (item.PropertyType.IsGenericType && item.PropertyType.GenericTypeArguments.Any())
                            isEnum = item.PropertyType.GenericTypeArguments.First().IsEnum;

                        var castItem = (IEnumerable)value;

                        foreach (var innerItem in castItem)
                        {
                            if (innerItem != null)
                            {
                                if (isEnum)
                                    queryString += $"{item.Name}={(int)innerItem}&";
                                else
                                    queryString +=
                                        $"{item.Name}={WebUtility.UrlEncode(innerItem.ToString())}&";
                            }
                        }
                    }
                    else if (_dateTimeTypes.Any(x => x == item.PropertyType))
                    {
                        var dateTime = new DateTime();
                        if (value is DateTime dateTimeValue)
                        {
                            dateTime = dateTimeValue;
                        }
                        else if (value is DateTimeOffset dateTimeOffsetValue)
                        {
                            dateTime = dateTimeOffsetValue.DateTime;
                        }

                        var stringValue = dateTime.ToString("yyyy MMMM dd");
                        if (dateTime.TimeOfDay.TotalSeconds > 0)
                            stringValue += " " + dateTime.ToString("HH:mm:ss");
                        stringValue = WebUtility.UrlEncode(stringValue);
                        queryString += $"{item.Name}={stringValue}&";
                    }
                    else if (item.PropertyType.IsEnum)
                    {
                        queryString += $"{item.Name}={(int)value}&";
                    }
                    else
                    {
                        queryString += $"{item.Name}={WebUtility.UrlEncode(value.ToString())}&";
                    }
                }
            }

            return queryString.TrimEnd('&');
        }

        private async Task<TResponse> ReadResponse<TResponse>(HttpResponseMessage response,
            JsonSerializerOptions serializerOptions = null)
        {
            if (response == null) return default;
            var data = string.Empty;
            try
            {
                response.EnsureSuccessStatusCode();

                var isByteArray = typeof(TResponse) == typeof(byte[]);

                object responseData = response.Content == null
                    ? null
                    : isByteArray
                        ? await response.Content.ReadAsByteArrayAsync()
                        : await response.Content.ReadAsStringAsync();
                if (responseData != default)
                {
                    if (isByteArray)
                    {
                        var result = (byte[])responseData;
                        var convertedResponse = Convert.ToBase64String(result);
                        data = convertedResponse.Length > 1000
                            ? convertedResponse.Substring(0, 1000)
                            : convertedResponse;

                        _logger.Log(LogLevel, $"Response of {response.RequestMessage.RequestUri} " +
                                               $"received as followings: {data}");

                        return (TResponse)responseData;
                    }
                    else
                    {
                        var result = (string)responseData;
                        data = result.Length > 10000 ? result.Substring(0, 10000) : result;
                        _logger.Log(LogLevel,
                            $"Response of {response.RequestMessage.RequestUri} received as followings: {data}");

                        if (!_invalidTypes.Contains(typeof(TResponse)))
                        {
                            serializerOptions = serializerOptions ?? _jsonSerializer;
                            var returnValue = JsonSerializer.Deserialize<TResponse>(result, serializerOptions);
                            return returnValue;
                        }

                        return (TResponse)responseData;
                    }
                }

                _logger.Log(LogLevel,
                    $"Response of {response.RequestMessage.RequestUri} is empty");


                return default;

            }
            catch (UnauthorizedAccessException)
            {
                _logger.LogWarning(
                    $"Unauthorized exception was thrown by request {response.RequestMessage.RequestUri}");
                throw;
            }
            catch (TimeoutException)
            {
                _logger.LogCritical($"Time out exception was thrown by request {response.RequestMessage.RequestUri}");
                throw;
            }

            catch (HttpRequestException exp)
            {

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException(exp.Message, exp);
                }

                throw;
            }
            catch (Exception exp)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException(exp.Message, exp);
                }
                var message =
                    $"An error has occured with HTTP status code ({(int)response.StatusCode}) " +
                    $"Request: {response.RequestMessage.RequestUri} " +
                    $"Response: {data}";
                _logger.LogError(exp, message);
                throw;
            }
        }

        public void SetSerializer(JsonSerializerOptions jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public void SetTimeOut(TimeSpan timeout)
        {
            _timeout = timeout;
        }
    }
}
