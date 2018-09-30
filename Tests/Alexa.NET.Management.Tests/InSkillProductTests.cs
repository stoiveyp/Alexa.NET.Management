using System;
using System.Collections.Generic;
using System.Linq;
using Alexa.NET.Management.InSkillProduct;
using Xunit;

namespace Alexa.NET.Management.Tests
{

    public class InSkillProductTests
    {
        [Fact]
        public void SubscriptionGeneratesCorrectly()
        {
            var usPublish = new LocalePublishingInformation
            {
                Name = "Treasure Finders Plus",
                SmallIcon = new Uri("https://small-icon-uri",UriKind.Absolute).ToString(),
                LargeIcon = new Uri("https://large-icon-uri",UriKind.Absolute).ToString(),
                Summary = "1 new members-only adventure each month + over 10 previously released adventures.",
                Description = "Get access to a new adventure each month for members only, along with a growing collection of over 10 previously released members-only adventures. Includes Crystal Catchers, The Light Stone, The Dark Pool, The Cave Fish, Long Way Down and more.",
                ExamplePhrases = new List<string>
                {
                    "Alexa, open treasure finders plus",
                    "Alexa, play with treasure finders plus"
                },
                Keywords = new List<string> {"Games"},
                CustomProductPrompts = new CustomProductPrompts
                {
                    PurchasePromptDescription = "{PREMIUM_CONTENT_TITLE} includes access to all of our current adventures and a new one each month.",
                    BoughtCardDescription = "Enjoy {PREMIUM_CONTENT_TITLE}! Ask for a list of adventures to explore your purchase.."
                }
            };

            var sub = new SubscriptionProduct
            {
                ReferenceName = "treasure_finders_plus",
                SubscriptionInformation = new SubscriptionInformation
                {
                    SubscriptionPaymentFrequency = SubscriptionFrequency.Monthly, TrialPeriodDays = 7
                },
                PublishingInformation = new PublishingInformation
                {
                    DistributionCountries = new[] {"US"}.ToList(),
                    Locales = new Dictionary<string, LocalePublishingInformation>
                    {
                        {"en-US",usPublish}
                    },
                    AmazonMarketplace = new MarketplacePricing
                    {
                        ReleaseDateUtc = DateTime.Parse("2018-12-28T01:25Z").ToUniversalTime(),
                        DefaultPriceListing = new PriceListing
                        {
                            Price = (decimal)1.99,
                            CurrencyCode = "USD"
                        }
                    },
                    TaxInformation = new TaxInformation(TaxCategory.Software)
                },
                PrivacyAndCompliance = new PrivacyAndCompliance{
                    Locales = new Dictionary<string, LocalePrivacyAndCompliance>
                    {
                        {"en-US",new LocalePrivacyAndCompliance(new Uri("https://url-to-privacy-policy").ToString())}
                    }
                },
                TestingInstructions = "Sample testing instructions.",
                PurchasableState = PurchasableState.Purchasable
            };
            Assert.True(Utility.CompareJson(sub,"subscription.json"));
        }

        [Fact]
        public void SubscriptionDeserializesCorrectly()
        {
            var sub = Utility.ExampleFileContent<SubscriptionProduct>("subscription.json");
            Assert.Equal("1.0",sub.Version);
            Assert.Equal(PurchasableState.Purchasable,sub.PurchasableState);
            Assert.Equal("Sample testing instructions.",sub.TestingInstructions);

            Assert.NotNull(sub.SubscriptionInformation);
            Assert.Equal(SubscriptionFrequency.Monthly,sub.SubscriptionInformation.SubscriptionPaymentFrequency);
            Assert.Equal(7,sub.SubscriptionInformation.TrialPeriodDays);

            Assert.NotNull(sub.PublishingInformation);
            var pub = sub.PublishingInformation;

            Assert.Equal(TaxCategory.Software,pub.TaxInformation.Category);
            Assert.Equal("USD",pub.AmazonMarketplace.DefaultPriceListing.CurrencyCode);
            Assert.Equal((decimal)1.99,pub.AmazonMarketplace.DefaultPriceListing.Price);
            Assert.Single(pub.DistributionCountries);
            Assert.Equal("US",pub.DistributionCountries.First());

            var privacy = sub.PrivacyAndCompliance;
            Assert.Equal("https://url-to-privacy-policy/",privacy.Locales["en-US"].PrivacyPolicyUrl);

        }
    }

}