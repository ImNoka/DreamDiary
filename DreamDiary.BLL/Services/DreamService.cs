using AutoMapper;
using DreamDiary.BLL.DTO;
using DreamDiary.BLL.Interfaces;
using DreamDiary.DAL.Entities;
using DreamDiary.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.Services
{
    public class DreamService : IDreamService
    {
        IMapper _mapper;
        IDreamRepository _dreamRepository;
        IImageDreamRepository _dreamImageRepository;
        public DreamService(IMapper mapper,
                            IDreamRepository dreamRepository,
                            IImageDreamRepository dreamImageRepository) // add to builder
        {
            _mapper = mapper;
            _dreamRepository=dreamRepository;
            _dreamImageRepository = dreamImageRepository;
        }


        public DreamDTO Add(string name, string text, Guid profileGuid, byte[] image)
        {
            
            Dream dream = new Dream()
            {
                Name = name,
                Text = text,
                ProfileGuid = profileGuid
            };
            ImageDream imageDream = new ImageDream()
            {
                Image = image,
                DreamGuid = dream.Guid
            };
            Task<Dream> task = _dreamRepository.AddAsync(dream);
            task.Wait();
            Task<ImageDream> task1 = _dreamImageRepository.AddAsync(imageDream);
            task1.Wait();
            dream = _dreamRepository.GetByGuid(task1.Result.DreamGuid);

            return _mapper.Map<DreamDTO>(dream);
        }

        public DreamDTO Add(DreamDTO dreamDTO, byte[] image)
        {
            dreamDTO.Image.Image=image;
            Dream dream = new Dream();
            _mapper.Map(dreamDTO, dream); // Add map
            Task<Dream> task = _dreamRepository.AddAsync(dream);
            task.Wait();
            dream = task.Result;
            return _mapper.Map<DreamDTO>(task.Result);
        }

        public bool Delete(Guid guid)
        {
            Task<bool> task = _dreamRepository.DeleteAsync(guid);
            task.Wait();
            return task.Result;
        }

        public IEnumerable<DreamDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Dream>,IEnumerable<DreamDTO>>(_dreamRepository.GetAll());
        }

        public DreamDTO GetByGuid(Guid guid)
        {
            return _mapper.Map<DreamDTO>(_dreamRepository.GetByGuid(guid));
        }

        public IEnumerable<DreamDTO> GetByProfileGuid(Guid guid)
        {
            return _mapper.Map<IEnumerable<Dream>, IEnumerable<DreamDTO>>(_dreamRepository.GetByProfileGuid(guid));
        }

        public DreamDTO Update(DreamDTO dreamDTO)
        {
            Dream dream = _mapper.Map<Dream>(dreamDTO);
            Task<Dream> task = _dreamRepository.UpdateAsync(dream);
            task.Wait();
            return _mapper.Map<DreamDTO>(task.Result);
        }
    }
}
