using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace johnLib
{
    /// <summary>
    /// HttpUtil Class provides utilities for HTML actions (LIB COMPLETE)
    /// </summary>
    public static class HttpUtils
    {
        /// <summary>
        /// CheckSession - check for availability of session variables. If session key = NULL --> redirect to other page
        /// </summary>
        /// <param name="key">Session variables need to be check ie. username - password</param>
        /// <param name="redirectTarget">Link - redirect to page incase session not available.</param>
        public static void CheckSession(string key, string redirectTarget)
        {
            HttpSessionState session = HttpContext.Current.Session;
            HttpResponse response = HttpContext.Current.Response;
            //if session key is not available --> not good --> redirect to other page
            if (session[key] == null)
            {
                response.Redirect(redirectTarget, true);
            }
        }

        /// <summary>
        /// Process page title from url (NEED BETTER ENGINE)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetWebPageTitle(string url)
        {
            // Create a request to the url
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;

            // If the request wasn't an HTTP request (like a file), ignore it
            if (request == null) return null;

            // Use the user's credentials
            request.UseDefaultCredentials = true;

            // Obtain a response from the server, if there was an error, return nothing

            HttpWebResponse response = null;

            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }

            catch (WebException) { return null; }

            // Regular expression for an HTML title
            string regex = @"(?<=<title.*>)([\s\S]*)(?=</title>)";

            // If the correct HTML header exists for HTML text, continue
            if (new List<string>(response.Headers.AllKeys).Contains("Content-Type"))
            {

                if (response.Headers["Content-Type"].StartsWith("text/html"))
                {

                    // Download the page

                    WebClient web = new WebClient();

                    web.UseDefaultCredentials = true;

                    string page = web.DownloadString(url);



                    // Extract the title

                    Regex ex = new Regex(regex, RegexOptions.IgnoreCase);

                    return ex.Match(page).Value.Trim();

                }
            }
            // Not a valid HTML page
            return null;
        }       
    }
}