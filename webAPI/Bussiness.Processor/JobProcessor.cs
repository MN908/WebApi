using AutoMapper;
using Umbraco.Core.Models.Membership;
using webAPI.Bussiness.Processor.Interface;
using webAPI.Entity;
using webAPI.Entity.Request;
using webAPI.Models;
using webAPI.Repository;
using webAPI.Repository.Interface;

namespace webAPI.Bussiness.Processor
{
    public class JobProcessor : IJobProcessor
    {
        private readonly IMapper _mapper;
        private readonly IJobRepository _jobRepository;
        public JobProcessor(IMapper mapper , IJobRepository jobRepository)
        {
            _mapper = mapper;
            _jobRepository = jobRepository;
        }
        public async Task<JobModel> CreateAsync(JobCreateRequest request)
        {
            var jobs = _mapper.Map<Job>(request);

            jobs.Id = Guid.NewGuid();

            await _jobRepository.AddAsync(jobs);

            return _mapper.Map<JobModel>(jobs);

        }
        public async Task<JobModel> GetById(Guid id)
        {
            return _mapper.Map<JobModel>( await _jobRepository.GetAnyEntityByIdAsync(id));
        }
        public async Task DeleteAsync(Guid id)
        {
            var job = await _jobRepository.SearchAsync(x => x.Id == id);

            if (job == null)
            {
                throw new DirectoryNotFoundException();
            }

            await _jobRepository.RemoveByIdAsync(id);
        }
        public async Task<IEnumerable<JobModel>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<JobModel>>(await _jobRepository.SearchAsync(x => !x.IsDeleted));
        }
        public async Task UpdateAsync(JobUpdateRequest request)
        {
            var alreadyjob = await _jobRepository.SearchAsync(x => x.Id == request.Id);

            if(alreadyjob == null)
            {
                throw new DirectoryNotFoundException();
            }

            var job = _mapper.Map<Job>(request);

            job.JobName = request.JobName;

            job.JobDescription = request.JobDescription;

            job.JobType = request.JobType;

            await _jobRepository.UpdateAsync(job);
        }
    }
}
