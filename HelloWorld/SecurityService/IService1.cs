using System.ServiceModel;

namespace SecurityService
{
    [ServiceContract]
    public interface ISecurityService
    {
        [OperationContract]
        string GetKey();
    }
}