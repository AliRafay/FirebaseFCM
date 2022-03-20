// <copyright file="MiscController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FirebaseFCM.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using FirebaseFCM.Standard;
    using FirebaseFCM.Standard.Authentication;
    using FirebaseFCM.Standard.Http.Client;
    using FirebaseFCM.Standard.Http.Request;
    using FirebaseFCM.Standard.Http.Response;
    using FirebaseFCM.Standard.Utilities;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// MiscController.
    /// </summary>
    public class MiscController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MiscController"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal MiscController(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Send Direct Message to Device with given id. HTTP Request.
        /// </summary>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        public void FCMMessagePOST(
                string authorization,
                Models.FCMMessagePOSTRequest body)
        {
            Task t = this.FCMMessagePOSTAsync(authorization, body);
            ApiHelper.RunTaskSynchronously(t);
        }

        /// <summary>
        /// Send Direct Message to Device with given id. HTTP Request.
        /// </summary>
        /// <param name="authorization">Required parameter: Example: .</param>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task FCMMessagePOSTAsync(
                string authorization,
                Models.FCMMessagePOSTRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/send");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "Authorization", authorization },
                { "Content-Type", "application/json" },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);
        }
    }
}