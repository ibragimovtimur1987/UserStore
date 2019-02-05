namespace UserStore.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IVideoService CreateUserService(string connection);
    }
}
