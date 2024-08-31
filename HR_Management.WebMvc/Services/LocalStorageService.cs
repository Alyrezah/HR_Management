using Hanssens.Net;
using HR_Management.WebMvc.Cantracts;

namespace HR_Management.WebMvc.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly LocalStorage _localStorage;

        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "HRMANAGEMENT"
            };
            _localStorage = new LocalStorage(config);
        }

        public void ClearStroge(List<string> keys)
        {
            foreach (var key in keys)
            {
                _localStorage.Remove(key);
            }
        }

        public T GetStrogeValue<T>(string key)
        {
            return _localStorage.Get<T>(key);
        }

        public bool IsExist(string key)
        {
            return _localStorage.Exists(key);
        }

        public void SetStorage<T>(string key, T value)
        {
            _localStorage.Store(key, value);
            _localStorage.Persist();
        }
    }
}
