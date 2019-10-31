using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinClient
{
    public class NetManager
    {
        private const string BASE_URL = "https://wikilibs-dev-api.azurewebsites.net/";
        private const string API_KEY = "12cbfcc1-2159-4814-8812-eeb4decdc9b7";
        private string _token;
        private bool _shuttingDown = false;
        private DateTime _lastToken = DateTime.UtcNow;
        private dynamic _authErr;

        public NetManager(string usr, string pss)
        {
            dynamic d = null;
            bool res = Post(false, "auth/internal/login", out d, JObject.FromObject(new
            {
                email = usr,
                password = pss
            }));
            if (!res)
                _authErr = d;
            else
            {
                _lastToken = DateTime.UtcNow;
                _token = d;
                Task.Run(ContinousRun);
            }
        }

        public dynamic GetAuthError()
        {
            return (_authErr);
        }

        public NetManager()
        {
            _token = null;
        }

        public void Exit()
        {
            _shuttingDown = true;
        }

        private void ContinousRun()
        {
            while (!_shuttingDown)
            {
                if ((DateTime.UtcNow - _lastToken).TotalMinutes >= 3)
                {
                    dynamic d = null;
                    bool res = Patch(true, "auth/refresh", out d, null);
                    if (!res)
                        throw new Exception();
                    else
                    {
                        _lastToken = DateTime.UtcNow;
                        _token = d;
                    }
                }
            }
        }

        public bool Get(bool auth, string url, out dynamic response)
        {
            WebRequest req = WebRequest.Create(BASE_URL + url);

            req.Method = "GET";
            if (auth)
                req.Headers.Add("Authorization", "Bearer " + _token);
            else
                req.Headers.Add("Authorization", API_KEY);
            try
            {
                WebResponse rsp = req.GetResponse();
                using (Stream stream = rsp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseStr = reader.ReadToEnd();
                    rsp.Close();
                    response = JsonConvert.DeserializeObject(responseStr);
                    return (true);
                }
            }
            catch (WebException ex)
            {
                using (Stream stream = ex.Response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseStr = reader.ReadToEnd();
                    ex.Response.Close();
                    response = JsonConvert.DeserializeObject(responseStr);
                    return (false);
                }
            }
        }

        public bool Post(bool auth, string url, out dynamic response, JObject data)
        {
            WebRequest req = WebRequest.Create(BASE_URL + url);

            req.Method = "POST";
            if (auth)
                req.Headers.Add("Authorization", "Bearer " + _token);
            else
                req.Headers.Add("Authorization", API_KEY);
            if (data != null)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(data.ToString(Formatting.None));
                req.ContentType = "application/json";
                req.ContentLength = byteArray.Length;
                Stream stream = req.GetRequestStream();
                stream.Write(byteArray, 0, byteArray.Length);
                stream.Close();
            }
            try
            {
                WebResponse rsp = req.GetResponse();
                using (Stream stream = rsp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseStr = reader.ReadToEnd();
                    rsp.Close();
                    if (responseStr.StartsWith("\"") && responseStr.EndsWith("\""))
                        response = responseStr.Substring(1, responseStr.Length - 2);
                    response = JsonConvert.DeserializeObject(responseStr);
                    return (true);
                }
            }
            catch (WebException ex)
            {
                using (Stream stream = ex.Response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseStr = reader.ReadToEnd();
                    ex.Response.Close();
                    response = JsonConvert.DeserializeObject(responseStr);
                    return (false);
                }
            }
        }

        public dynamic Patch(bool auth, string url, out dynamic response, JObject data)
        {
            WebRequest req = WebRequest.Create(BASE_URL + url);

            req.Method = "PATCH";
            if (auth)
                req.Headers.Add("Authorization", "Bearer " + _token);
            else
                req.Headers.Add("Authorization", API_KEY);
            if (data != null)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(data.ToString(Formatting.None));
                req.ContentType = "application/json";
                req.ContentLength = byteArray.Length;
                Stream stream = req.GetRequestStream();
                stream.Write(byteArray, 0, byteArray.Length);
                stream.Close();
            }
            try
            {
                WebResponse rsp = req.GetResponse();
                using (Stream stream = rsp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseStr = reader.ReadToEnd();
                    rsp.Close();
                    if (responseStr.StartsWith("\"") && responseStr.EndsWith("\""))
                        response = responseStr.Substring(1, responseStr.Length - 2);
                    response = JsonConvert.DeserializeObject(responseStr);
                    return (true);
                }
            }
            catch (WebException ex)
            {
                using (Stream stream = ex.Response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseStr = reader.ReadToEnd();
                    ex.Response.Close();
                    response = JsonConvert.DeserializeObject(responseStr);
                    return (false);
                }
            }
        }

        public dynamic Delete(bool auth, string url, out dynamic response)
        {
            WebRequest req = WebRequest.Create(BASE_URL + url);

            req.Method = "DELETE";
            if (auth)
                req.Headers.Add("Authorization", "Bearer " + _token);
            else
                req.Headers.Add("Authorization", API_KEY);
            try
            {
                WebResponse rsp = req.GetResponse();
                using (Stream stream = rsp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseStr = reader.ReadToEnd();
                    rsp.Close();
                    response = JsonConvert.DeserializeObject(responseStr);
                    return (true);
                }
            }
            catch (WebException ex)
            {
                using (Stream stream = ex.Response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseStr = reader.ReadToEnd();
                    ex.Response.Close();
                    response = JsonConvert.DeserializeObject(responseStr);
                    return (false);
                }
            }
        }
    }
}
