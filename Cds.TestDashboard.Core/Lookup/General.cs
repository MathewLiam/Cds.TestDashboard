namespace Cds.TestDashboard.Core.Lookup
{
    /// <summary>
    /// Defines general types and constants.
    /// </summary>
    public class General
    {
        /// <summary>
        /// Enum defining test types
        /// </summary>
        public enum TestType
        {
            SecurityTest,
            AutomationTest,
            RegressionTest,
            SmokeTest
        }

        /// <summary>
        /// Enum defining notification types.
        /// </summary>
        public enum NotificationType
        {
            Default,
            Message,
            Test,
            Build
        }
    }
}
