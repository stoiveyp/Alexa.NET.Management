namespace Alexa.NET.Management.Manifest
{
    public static class PermissionNames
    {
        public const string ReadWriteReminders = "alexa::alerts:reminders:skill:readwrite";
        public const string ReadCustomerAddress = "alexa::devices:all:address:full:read";
        public const string ReadCustomerCountryAndPostcode = "alexa:devices:all:address:country_and_postal_code:read";
        public const string ReadCustomerFullName = "alexa::profile:name:read";
        public const string ReadCustomerGivenName = "alexa::profile:given_name:read";
        public const string ReadCustomerEmailAddress = "alexa::profile:email:read";
        public const string ReadCustomerPhoneNumber = "alexa::profile:mobile_number:read";
        public const string ReadAlexaLists = "alexa::household:lists:read";
        public const string WriteAlexaLists = "alexa::household:lists:write";
        public const string SendNotifications = "alexa::devices:all:notifications:write";
        public const string WriteHealthProfile = "alexa::health:profile:write";
        public const string ReadPerson = "alexa::person_id:read";
    }
}