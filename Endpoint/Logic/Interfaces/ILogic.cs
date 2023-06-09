namespace Endpoint.Logic.Interfaces
{
    public interface ILogic<TReq, TRes>
    {
        void Create(TReq item);
        void Delete(string id);
        TRes Read(string id);
        IList<TRes> ReadAll();
        void Update(string id, TReq item);
    }
}
