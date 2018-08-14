using System.Net;
using NRConfig;

namespace Demo.BuisnessLogic
{
    [InstrumentAttribute(Scopes = InstrumentationScopes.PublicMethods)]
    public class Bar
    {
            // The agent creates a transaction that includes an external service request in its transaction traces.
            public void Bar1()
            {
                new WebClient().DownloadString("http://www.google.com/");
            }

            // Creates  a transaction containing one segment.
            public void Bar2()
            {
                // The Bar3 segment will contain your SQL query inside of it and possibly an execution plan.
                Bar3();
            }

            // If Bar3 is called directly, the agent will not create a transaction.
            // However, if Bar3 is called from Bar1 or Bar2, Bar3 will appear as a segment containing its SQL query.
            private void Bar3()
            {
                 Bar1();
                //using (var connection = new SqlConnection(ConnectionStrings["MsSqlConnection"].ConnectionString))
                //{
                //    connection.Open();
                //    using (var command = new SqlCommand("SELECT * FROM table", connection))
                //    using (var reader = command.ExecuteReader())
                //    {
                //        reader.Read();
                //    }
                //}
            }

    }
}