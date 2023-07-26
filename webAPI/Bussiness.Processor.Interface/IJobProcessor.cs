using webAPI.Entity.Request;
using webAPI.Models;

namespace webAPI.Bussiness.Processor.Interface
{
    public interface IJobProcessor
    {
        Task<JobModel> CreateAsync(JobCreateRequest request);

        Task<JobModel> GetById(Guid ids);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<JobModel>> GetAllAsync();

        Task UpdateAsync(JobUpdateRequest request);
    }
}
