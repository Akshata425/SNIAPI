using PayPal.Api;
using System;

namespace SNIAPI.Helpers.Paypal
{
    public static class PayPalConfig
    {
        // ###AccessToken
        // Retrieve the access token from OAuthTokenCredential by passing in
        // ClientID and ClientSecret
        // It is not mandatory to generate Access Token on a per call basis.
        // Typically the access token can be generated once and reused within the expiry window  
        public static string GenerateAccessToken()
        {
            string accessToken = string.Empty;
            try
            {
                // Get a reference to the config
                var config = ConfigManager.Instance.GetProperties(); //Note :  Paypal mode ('live' or 'sandbox'), change live for production
                // Use OAuthTokenCredential to request an access token from PayPal
                accessToken = new OAuthTokenCredential(config).GetAccessToken();


            }
            catch (Exception ex)
            {
                throw;
            }

            return accessToken;
        }
    }
}