namespace Common.Messaging.ChannelTypes.AzureServiceBus
{
    public static class Constants
    {
        #region ServicePrincipal Constants

        public const string SP_CLIENT_ID_KEY = "SP_RUN_CLIENT_ID";
        public const string SP_CLIENT_SECRET_KEY = "SP_RUN_CLIENT_SECRET";
        public const string SP_TENANT_ID_KEY = "SP_RUN_TENANT_ID";

        #endregion

        #region ServiceBus Constants

        public const string SERVICEBUS_ENDPOINT_KEY_NAME = "SB_Endpoint";
        public const string SERVICEBUS_TOPICNAME_KEY_NAME = "SB_TopicName";

        #endregion
    }
}
