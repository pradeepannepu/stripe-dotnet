namespace Stripe
{
    using System.Threading;
    using System.Threading.Tasks;
    using Stripe.Infrastructure;

    public class StripeSourceTransactionService : StripeBasicService<StripeSourceTransaction>
    {
        public StripeSourceTransactionService()
            : base(null)
        {
        }

        public StripeSourceTransactionService(string apiKey)
            : base(apiKey)
        {
        }

        public virtual StripeList<StripeSourceTransaction> List(string sourceId, StripeSourceTransactionsListOptions options = null, StripeRequestOptions requestOptions = null)
        {
            return this.GetEntityList($"{Urls.BaseUrl}/sources/{sourceId}/source_transactions", requestOptions, options);
        }

        public virtual Task<StripeList<StripeSourceTransaction>> ListAsync(string sourceId, StripeSourceTransactionsListOptions options = null, StripeRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.GetEntityListAsync($"{Urls.BaseUrl}/sources/{sourceId}/source_transactions", requestOptions, cancellationToken, options);
        }
    }
}
