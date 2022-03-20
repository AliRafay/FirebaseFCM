// <copyright file="FCMMessagePOSTRequest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace FirebaseFCM.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FirebaseFCM.Standard;
    using FirebaseFCM.Standard.Utilities;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// FCMMessagePOSTRequest.
    /// </summary>
    public class FCMMessagePOSTRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FCMMessagePOSTRequest"/> class.
        /// </summary>
        public FCMMessagePOSTRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FCMMessagePOSTRequest"/> class.
        /// </summary>
        /// <param name="to">to.</param>
        /// <param name="data">data.</param>
        public FCMMessagePOSTRequest(
            string to,
            Models.Data data)
        {
            this.To = to;
            this.Data = data;
        }

        /// <summary>
        /// Gets or sets To.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        [JsonProperty("data")]
        public Models.Data Data { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FCMMessagePOSTRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is FCMMessagePOSTRequest other &&
                ((this.To == null && other.To == null) || (this.To?.Equals(other.To) == true)) &&
                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true));
        }
        

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.To = {(this.To == null ? "null" : this.To == string.Empty ? "" : this.To)}");
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : this.Data.ToString())}");
        }
    }
}