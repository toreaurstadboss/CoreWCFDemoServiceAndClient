namespace CoreWCFDemoServer
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    namespace CoreWCfDemoServer
    {
        [DataContract]
        public class EchoMessage
        {
            [AllowNull]
            [DataMember]
            public string Text { get; set; }
        }
    }
}
