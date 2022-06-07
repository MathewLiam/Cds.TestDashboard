namespace Cds.TestDashboard.Core.Helpers
{
    using static Cds.TestDashboard.Core.Lookup.General;

    /// <summary>
    /// Defines css helper methods.
    /// </summary>
    public static class CssHelper
    {
        /// <summary>
        /// Method to get test card style.
        /// </summary>
        /// <param name="type">The type of test.</param>
        /// <returns>The css class for test card.</returns>
        public static string GetTestCardStyle(TestType type)
        {
            switch (type)
            {
                case TestType.SecurityTest:
                    return "bg-blue";
                case TestType.SmokeTest:
                    return "bg-red";
                case TestType.RegressionTest:
                    return "bg-green";
                case TestType.AutomationTest:
                    return "bg-black";
                default:
                    return "bg-teal";
            }
        }

        public static string GetValidationSeverityStyle(string severity)
        {
            switch(severity.ToLower())
            {
                case "error":
                    return "danger";
                case "info":
                    return "info";
                case "success":
                    return "success";
                case "defualt":
                    return "default";
                default:
                    return "danger";
            }
        }
    }
}
