namespace CoreWCFDemoServer
{
    using CoreWCF;

    namespace CoreWCfDemoServer
    {

        [ServiceContract]
        public interface IEchoService
        {
            [OperationContract]
            string Echo(string text);

            [OperationContract]
            string ComplexEcho(EchoMessage text);

            [OperationContract]
            [FaultContract(typeof(EchoFault))]
            string FailEcho(string text);

        }

    }
}
