
namespace RPM_Programming_Excercise.Common
{
    public static class Constants
    {
        public const string EiaPetroleumApiName = "EiaPetroleumApiClient";

        public static class DatabaseConstants
        {
            public const string ConnectionStringsContainer = "ConnectionStrings";
            public static class ConnectionStringKeys
            {
                public static string RPMProgrammingExcerciseDBConnectionStringKey => ConnectionStringsContainer + ":RPMProgrammingExcerciseDB";
            }
        }

        public static class CustomValuesConfiguration
        {
            public const string ValuesContainer = "Values";
            public static class ValueKeys
            {
                public static string DaysCountKey => ValuesContainer + ":DaysCount";
                public static string ExecutionDelayKey => ValuesContainer + ":ExecutionDelay";
            }
        }
    }
}
