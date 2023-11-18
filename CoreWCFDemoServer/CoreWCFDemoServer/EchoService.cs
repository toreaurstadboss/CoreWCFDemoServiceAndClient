using CoreWCF;
using CoreWCFDemoServer.CoreWCfDemoServer;

namespace CoreWCFDemoServer
{

    public class EchoService : IEchoService
    {
        public string Echo(string text)
        {
            System.Console.WriteLine($"Received {text} from client!");
            return $"EchoService responded at [{DateTime.Now}]: {text}";
        }

        public string ComplexEcho(EchoMessage text)
        {
            System.Console.WriteLine($"Received {text.Text} from client!");
            return $"EchoService responded at [{DateTime.Now}]: {text.Text}";
        }

        public string FailEcho(string text)
            => throw new FaultException<EchoFault>(new EchoFault() { Text = "WCF Fault OK" }, new FaultReason("FailReason"));

    }

}
