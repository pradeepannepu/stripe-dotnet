namespace Stripe.Issuing
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class Dispute : StripeEntityWithId, ISupportMetadata
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("created")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("livemode")]
        public bool LiveMode { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        #region Expandable Transaction
        public string TransactionId { get; set; }

        [JsonIgnore]
        public Transaction Transaction { get; set; }

        [JsonProperty("transaction")]
        internal object InternalTransaction
        {
            set
            {
                StringOrObject<Transaction>.Map(value, s => this.TransactionId = s, o => this.Transaction = o);
            }
        }
        #endregion
    }
}
