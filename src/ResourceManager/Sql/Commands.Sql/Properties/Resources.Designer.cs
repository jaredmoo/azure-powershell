﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Sql.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Azure.Commands.Sql.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to More than one Active Directory group with the display name &apos;{0}&apos; was found. Please provide an Azure Active Directory object id to select the correct group. To get the object id use Get-AzureRmADGroup -SearchString &quot;{0}&quot;.
        /// </summary>
        internal static string ADGroupMoreThanOneFound {
            get {
                return ResourceManager.GetString("ADGroupMoreThanOneFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find the Azure Active Directory object &apos;{0}&apos;. Please make sure that the user or group you are authorizing is registered in the current subscription&apos;s Azure Active directory. To get a list of Azure Active Directory groups use Get-AzureRmADGroup, or to get a list of Azure Active Directory users use Get-AzureRmADUser..
        /// </summary>
        internal static string ADObjectNotFound {
            get {
                return ResourceManager.GetString("ADObjectNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to More than one Azure Active Directory user with the display name &apos;{0}&apos; was found. Please provide an Azure Active Directory object id to select the correct user. To get the object id use Get-AzureRmADUser -SearchString &quot;{0}&quot;.
        /// </summary>
        internal static string ADUserMoreThanOneFound {
            get {
                return ResourceManager.GetString("ADUserMoreThanOneFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to In order to enable Threat Detection, please enable database auditing..
        /// </summary>
        internal static string AuditingIsTurnedOff {
            get {
                return ResourceManager.GetString("AuditingIsTurnedOff", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to About to process resource.
        /// </summary>
        internal static string BaseConfirmActionProcessMessage {
            get {
                return ResourceManager.GetString("BaseConfirmActionProcessMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Database with name: &apos;{0}&apos; already exists in server &apos;{1}&apos;..
        /// </summary>
        internal static string DatabaseNameExists {
            get {
                return ResourceManager.GetString("DatabaseNameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Auditing cannot be enabled . Upgrade to Basic, Standard or Premium Service Tier to enable auditing on your database(s).
        /// </summary>
        internal static string DatabaseNotInServiceTierForAuditingPolicy {
            get {
                return ResourceManager.GetString("DatabaseNotInServiceTierForAuditingPolicy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot set a lower bound which is larger than the higher bound.
        /// </summary>
        internal static string DataMaskingNumberRuleIntervalDefinitionError {
            get {
                return ResourceManager.GetString("DataMaskingNumberRuleIntervalDefinitionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No dynamic data masking rule is defined for column: &quot;{0}&quot; table &quot;{1}&quot; schema &quot;{2}&quot; .
        /// </summary>
        internal static string DataMaskingRuleDoesNotExist {
            get {
                return ResourceManager.GetString("DataMaskingRuleDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} cmdlet is deprecated and will be removed in a future release..
        /// </summary>
        internal static string DeprecatedCmdletUsageWarning {
            get {
                return ResourceManager.GetString("DeprecatedCmdletUsageWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Elastic Pool with name: &apos;{0}&apos; already exists in server &apos;{1}&apos;..
        /// </summary>
        internal static string ElasticPoolNameExists {
            get {
                return ResourceManager.GetString("ElasticPoolNameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One or more of the email addresses you entered are not valid..
        /// </summary>
        internal static string EmailsAreNotValid {
            get {
                return ResourceManager.GetString("EmailsAreNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {your_password_here}.
        /// </summary>
        internal static string EnterPassword {
            get {
                return ResourceManager.GetString("EnterPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {your_user_id_here}.
        /// </summary>
        internal static string EnterUserId {
            get {
                return ResourceManager.GetString("EnterUserId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Active Directory Group &apos;{0}&apos; is not security enabled. Only Azure Active Directory Security Enabled Groups are supported..
        /// </summary>
        internal static string InvalidADGroupNotSecurity {
            get {
                return ResourceManager.GetString("InvalidADGroupNotSecurity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot use the &apos;None&apos; option with other detection types.
        /// </summary>
        internal static string InvalidDetectionTypeList {
            get {
                return ResourceManager.GetString("InvalidDetectionTypeList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot use the None option with other event types..
        /// </summary>
        internal static string InvalidEventTypeSet {
            get {
                return ResourceManager.GetString("InvalidEventTypeSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot use the &apos;{0}&apos; option with other excluded detection types..
        /// </summary>
        internal static string InvalidExcludedDetectionTypeSet {
            get {
                return ResourceManager.GetString("InvalidExcludedDetectionTypeSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please use Set-AzureRmEnvironment to set a valid GraphEndpoint for the current AzureEnvironment..
        /// </summary>
        internal static string InvalidGraphEndpoint {
            get {
                return ResourceManager.GetString("InvalidGraphEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot use audit table retention without specifying TableIdentifier. You may want to use &apos;{0}&apos;..
        /// </summary>
        internal static string InvalidRetentionTypeSet {
            get {
                return ResourceManager.GetString("InvalidRetentionTypeSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please set a valid tenant id in the AzureEnvironment..
        /// </summary>
        internal static string InvalidTenantId {
            get {
                return ResourceManager.GetString("InvalidTenantId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Job account with name: &apos;{0}&apos; already exists in server &apos;{1}&apos;..
        /// </summary>
        internal static string JobAccountNameExists {
            get {
                return ResourceManager.GetString("JobAccountNameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You need to provide at least one email address or set EmailAdmins to True..
        /// </summary>
        internal static string NeedToProvideEmail {
            get {
                return ResourceManager.GetString("NeedToProvideEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A rule that was defined on the same column already exists..
        /// </summary>
        internal static string NewDataMaskingRuleIdAlreadyExistError {
            get {
                return ResourceManager.GetString("NewDataMaskingRuleIdAlreadyExistError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot set auditing policy without a storage account name..
        /// </summary>
        internal static string NoStorageAccountWhenConfiguringAuditingPolicy {
            get {
                return ResourceManager.GetString("NoStorageAccountWhenConfiguringAuditingPolicy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PHP Data Objects(PDO) Sample Code:.
        /// </summary>
        internal static string PdoTitle {
            get {
                return ResourceManager.GetString("PdoTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error connecting to SQL Server.
        /// </summary>
        internal static string PhpConnectionError {
            get {
                return ResourceManager.GetString("PhpConnectionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permanently removing Azure Sql Database &apos;{0}&apos; on server &apos;{1}&apos;..
        /// </summary>
        internal static string RemoveAzureSqlDatabaseDescription {
            get {
                return ResourceManager.GetString("RemoveAzureSqlDatabaseDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permanently removing Azure Sql Database Elastic Pool &apos;{0}&apos; on server &apos;{1}&apos;..
        /// </summary>
        internal static string RemoveAzureSqlDatabaseElasticPoolDescription {
            get {
                return ResourceManager.GetString("RemoveAzureSqlDatabaseElasticPoolDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the Azure Sql Database Elastic Pool &apos;{0}&apos; on server &apos;{1}&apos;?.
        /// </summary>
        internal static string RemoveAzureSqlDatabaseElasticPoolWarning {
            get {
                return ResourceManager.GetString("RemoveAzureSqlDatabaseElasticPoolWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the Azure Sql Database &apos;{0}&apos; on server &apos;{1}&apos;?.
        /// </summary>
        internal static string RemoveAzureSqlDatabaseWarning {
            get {
                return ResourceManager.GetString("RemoveAzureSqlDatabaseWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permanently removing job account &apos;{0}&apos; for Azure Sql Database Server &apos;{1}&apos;..
        /// </summary>
        internal static string RemoveAzureSqlJobAccountDescription {
            get {
                return ResourceManager.GetString("RemoveAzureSqlJobAccountDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the job account &apos;{0}&apos; for Azure Sql Database Server &apos;{1}&apos;?.
        /// </summary>
        internal static string RemoveAzureSqlJobAccountWarning {
            get {
                return ResourceManager.GetString("RemoveAzureSqlJobAccountWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing Azure Sql Server Active Directory Administrator on server &apos;{0}&apos;..
        /// </summary>
        internal static string RemoveAzureSqlServerActiveDirectoryAdministratorDescription {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerActiveDirectoryAdministratorDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the Azure Sql Server Active Directory Administrator on server &apos;{0}&apos;?.
        /// </summary>
        internal static string RemoveAzureSqlServerActiveDirectoryAdministratorWarning {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerActiveDirectoryAdministratorWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permanently removing Azure Sql Server communication link &apos;{0}&apos; on server &apos;{1}&apos;..
        /// </summary>
        internal static string RemoveAzureSqlServerCommunicationLinkDescription {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerCommunicationLinkDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the Azure Sql Server communication link &apos;{0}&apos; on server &apos;{1}&apos;?.
        /// </summary>
        internal static string RemoveAzureSqlServerCommunicationLinkWarning {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerCommunicationLinkWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permanently removing Azure Sql Database Server &apos;{0}&apos;..
        /// </summary>
        internal static string RemoveAzureSqlServerDescription {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permanently removing Azure Sql Disaster Recovery Configuration &apos;{0}&apos; on server &apos;{1}&apos;..
        /// </summary>
        internal static string RemoveAzureSqlServerDisasterRecoveryConfigurationDescription {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerDisasterRecoveryConfigurationDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the Azure Sql Disaster Recovery Configuration &apos;{0}&apos; on server &apos;{1}&apos;?.
        /// </summary>
        internal static string RemoveAzureSqlServerDisasterRecoveryConfigurationWarning {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerDisasterRecoveryConfigurationWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Permanently removing Firewall Rule &apos;{0}&apos; for Azure Sql Database Server &apos;{1}&apos;..
        /// </summary>
        internal static string RemoveAzureSqlServerFirewallRuleDescription {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerFirewallRuleDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the Firewall Rule &apos;{0}&apos; for Azure Sql Database Server &apos;{1}&apos;?.
        /// </summary>
        internal static string RemoveAzureSqlServerFirewallRuleWarning {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerFirewallRuleWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the Azure Sql Database Server &apos;{0}&apos;?.
        /// </summary>
        internal static string RemoveAzureSqlServerWarning {
            get {
                return ResourceManager.GetString("RemoveAzureSqlServerWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing data masking rule for column:&quot;{0}&quot; table:&quot;{1}&quot; schema:&quot;{2}&quot;.
        /// </summary>
        internal static string RemoveDatabaseDataMaskingRuleDescription {
            get {
                return ResourceManager.GetString("RemoveDatabaseDataMaskingRuleDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to remove the data masking rule for column:&quot;{0}&quot; table:&quot;{1}&quot; schema:&quot;{2}&quot;?.
        /// </summary>
        internal static string RemoveDatabaseDataMaskingRuleWarning {
            get {
                return ResourceManager.GetString("RemoveDatabaseDataMaskingRuleWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Server communication link with name: &apos;{0}&apos; already exists in server &apos;{1}&apos;..
        /// </summary>
        internal static string ServerCommunicationLinkNameExists {
            get {
                return ResourceManager.GetString("ServerCommunicationLinkNameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Server Disaster Recovery Configuration already exists in server &apos;{1}&apos;..
        /// </summary>
        internal static string ServerDisasterRecoveryConfigurationNameExists {
            get {
                return ResourceManager.GetString("ServerDisasterRecoveryConfigurationNameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Firewall Rule with name: &apos;{0}&apos; already exists for server &apos;{1}&apos;..
        /// </summary>
        internal static string ServerFirewallRuleNameExists {
            get {
                return ResourceManager.GetString("ServerFirewallRuleNameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Server with name: &apos;{0}&apos; already exists..
        /// </summary>
        internal static string ServerNameExists {
            get {
                return ResourceManager.GetString("ServerNameExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dynamic Data Masking is only available in the latest SQL Database Update (V12). Please upgrade to set it up on your database..
        /// </summary>
        internal static string ServerNotApplicableForDataMasking {
            get {
                return ResourceManager.GetString("ServerNotApplicableForDataMasking", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Threat detection is only available for the latest SQL Database Update (V12). Please upgrade to set it up on your database..
        /// </summary>
        internal static string ServerNotApplicableForThreatDetection {
            get {
                return ResourceManager.GetString("ServerNotApplicableForThreatDetection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Request for upgrade of server &apos;{0}&apos; already exists..
        /// </summary>
        internal static string ServerUpgradeExists {
            get {
                return ResourceManager.GetString("ServerUpgradeExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updating auto execute status of the advisor &apos;{0}&apos; to &apos;{1}&apos;..
        /// </summary>
        internal static string SetAdvisorAutoExecuteStatusDescription {
            get {
                return ResourceManager.GetString("SetAdvisorAutoExecuteStatusDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to update auto execute status of the advisor &apos;{0}&apos; to &apos;{1}&apos;?.
        /// </summary>
        internal static string SetAdvisorAutoExecuteStatusWarning {
            get {
                return ResourceManager.GetString("SetAdvisorAutoExecuteStatusWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A data masking rule for the column does not exist.
        /// </summary>
        internal static string SetDataMaskingRuleIdDoesNotExistError {
            get {
                return ResourceManager.GetString("SetDataMaskingRuleIdDoesNotExistError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Set Options were provided.
        /// </summary>
        internal static string SetDisasterRecoveryConfigurationNoOptionProvided {
            get {
                return ResourceManager.GetString("SetDisasterRecoveryConfigurationNoOptionProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updating state of recommended action &apos;{0}&apos; to &apos;{1}&apos;..
        /// </summary>
        internal static string SetRecommendedActionStateDescription {
            get {
                return ResourceManager.GetString("SetRecommendedActionStateDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to update state of the recommended action &apos;{0}&apos; to &apos;{1}&apos;.
        /// </summary>
        internal static string SetRecommendedActionStateWarning {
            get {
                return ResourceManager.GetString("SetRecommendedActionStateWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Set Options were provided.
        /// </summary>
        internal static string SetSecondaryNoOptionProvided {
            get {
                return ResourceManager.GetString("SetSecondaryNoOptionProvided", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm.
        /// </summary>
        internal static string ShouldProcessCaption {
            get {
                return ResourceManager.GetString("ShouldProcessCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SQL Server Extension Sample Code:.
        /// </summary>
        internal static string sqlSampleTitle {
            get {
                return ResourceManager.GetString("sqlSampleTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Azure Sql Database Elastic Pool name is required for this operation.
        /// </summary>
        internal static string StandaloneDatabaseActivityNotSupported {
            get {
                return ResourceManager.GetString("StandaloneDatabaseActivityNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stopping upgrade for Azure Sql Database Server &apos;{0}&apos;..
        /// </summary>
        internal static string StopAzureSqlServerUpgradeDescription {
            get {
                return ResourceManager.GetString("StopAzureSqlServerUpgradeDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to stop the upgrade for Azure Sql Database Server &apos;{0}&apos;?.
        /// </summary>
        internal static string StopAzureSqlServerUpgradeWarning {
            get {
                return ResourceManager.GetString("StopAzureSqlServerUpgradeWarning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find a storage account with the name &apos;{0}&apos;. It either does not exist, associated with a different subscription or you do not have the appropriate credentials to access it..
        /// </summary>
        internal static string StorageAccountNotFound {
            get {
                return ResourceManager.GetString("StorageAccountNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot use a server&apos;s auditing policy before it is configured..
        /// </summary>
        internal static string UseServerWithoutStorageAccount {
            get {
                return ResourceManager.GetString("UseServerWithoutStorageAccount", resourceCulture);
            }
        }
    }
}
