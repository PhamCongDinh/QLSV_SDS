namespace QLSVDapperSDS.Reposirories
{
    public interface IGenericRepository<T,TReq>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> GetByMaAsync(string ma);
        public Task<T> AddAsync(TReq item);
        public Task<T> UpdateAsync(int id,TReq item);

    }
}
