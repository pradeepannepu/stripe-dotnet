﻿namespace Stripe
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Stripe.Infrastructure;

    public class StripeApplicationFeeRefund : StripeEntityWithId, ISupportMetadata
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        #region Expandable Balance Transaction
        public string BalanceTransactionId { get; set; }

        [JsonIgnore]
        public StripeBalanceTransaction BalanceTransaction { get; set; }

        [JsonProperty("balance_transaction")]
        internal object InternalBalanceTransaction
        {
            set
            {
                StringOrObject<StripeBalanceTransaction>.Map(value, s => this.BalanceTransactionId = s, o => this.BalanceTransaction = o);
            }
        }
        #endregion

        [JsonProperty("created")]
        [JsonConverter(typeof(StripeDateTimeConverter))]
        public DateTime Created { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        #region Expandable Fee
        public string FeeId { get; set; }

        [JsonIgnore]
        public StripeApplicationFee Fee { get; set; }

        [JsonProperty("fee")]
        internal object InternalFee
        {
            set
            {
                StringOrObject<StripeApplicationFee>.Map(value, s => this.FeeId = s, o => this.Fee = o);
            }
        }
        #endregion

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}
