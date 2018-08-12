﻿using System.Threading.Tasks;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models.List;
using Mollie.Api.Models.List.Specific;
using Mollie.Api.Models.Subscription;

namespace Mollie.Api.Client {
    public class SubscriptionClient : BaseMollieClient, ISubscriptionClient {
        public SubscriptionClient(string apiKey) : base(apiKey) {
        }

        public async Task<ListResponse<SubscriptionListData>> GetSubscriptionListAsync(string customerId, string from = null, int? limit = null) {
            return await this.GetListAsync<ListResponse<SubscriptionListData>>($"customers/{customerId}/subscriptions", from, limit).ConfigureAwait(false);
        }

        public async Task<SubscriptionResponse> GetSubscriptionAsync(string customerId, string subscriptionId) {
            return await this.GetAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions/{subscriptionId}").ConfigureAwait(false);
        }

        public async Task<SubscriptionResponse> CreateSubscriptionAsync(string customerId, SubscriptionRequest request) {
            return await this.PostAsync<SubscriptionResponse>($"customers/{customerId}/subscriptions", request).ConfigureAwait(false);
        }

        public async Task CancelSubscriptionAsync(string customerId, string subscriptionId) {
            await this.DeleteAsync($"customers/{customerId}/subscriptions/{subscriptionId}").ConfigureAwait(false);
        }
    }
}