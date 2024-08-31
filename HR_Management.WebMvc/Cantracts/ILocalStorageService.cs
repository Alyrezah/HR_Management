namespace HR_Management.WebMvc.Cantracts
{
    public interface ILocalStorageService
    {
        void ClearStroge(List<string> keys);
        bool IsExist(string key);
        T GetStrogeValue<T>(string key);
        void SetStorage<T>(string key, T value);
    }
}
