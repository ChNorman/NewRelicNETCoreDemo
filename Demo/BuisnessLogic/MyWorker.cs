using System.Collections.Generic;
using System.Threading;
using NRConfig;

namespace Demo.BuisnessLogic
{

    [InstrumentAttribute(Scopes = InstrumentationScopes.Methods)]
    public class MyWorker
    {
       
        public void DoWork()
        {
            //Call private Do Work Method
            var eventAttributes = new Dictionary<string, object>() { { "foo", "bar" }, { "alice", "bob" } };
            NewRelic.Api.Agent.NewRelic.RecordCustomEvent("MyCustomEvent", eventAttributes);
            _DoWork();

        }

        
        private void _DoWork()
        {

            NewRelic.Api.Agent.NewRelic.AddCustomParameter("delay", "10000");
            Thread.Sleep(10000);
        }
    }
}