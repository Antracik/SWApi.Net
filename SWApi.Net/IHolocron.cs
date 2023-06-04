using SWApi.Net.Entities;

namespace SWApi.Net
{
    public interface IHolocron : IDisposable
    {
        Task<IEnumerable<T>> Get<T>(string? search = null) where T : IBaseEntity;
        Task<T?> GetById<T>(int id) where T : IBaseEntity;
    }
}