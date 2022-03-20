// <copyright file="MiscControllerTest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FirebaseFCM.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using FirebaseFCM.Standard;
    using FirebaseFCM.Standard.Controllers;
    using FirebaseFCM.Standard.Exceptions;
    using FirebaseFCM.Standard.Http.Client;
    using FirebaseFCM.Standard.Http.Response;
    using FirebaseFCM.Standard.Utilities;
    using FirebaseFCM.Tests.Helpers;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;

    /// <summary>
    /// MiscControllerTest.
    /// </summary>
    [TestFixture]
    public class MiscControllerTest : ControllerTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private MiscController controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.MiscController;
        }

        /// <summary>
        /// Send Direct Message to Device with given id. HTTP Request..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestFCMMessagePOST()
        {
            // Parameters for the API call
            string authorization = "key=AAAANEY1wb8:APA91bFef9HCm0CJKp8v77rbQQwRtHGzn0RGJ8YJNkLEPvCAHuz-yxQqG5-77hKnO9d2lIJNKpE7R56CaAHrabhWMkoGW68-KleWggje4404hwAO63XyLsRfto2LRAq3YOVXHmM2bj1W";
            Standard.Models.FCMMessagePOSTRequest body = ApiHelper.JsonDeserialize<Standard.Models.FCMMessagePOSTRequest>("{
  \"to\": \"\",
  \"data\": {
    \"body\": \"First Notification\",
    \"title\": \"ALT App Testing\"
  }
}");

            // Perform API call
            try
            {
                await this.controller.FCMMessagePOSTAsync(authorization, body);
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");
        }
    }
}