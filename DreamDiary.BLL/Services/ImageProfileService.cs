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
    public class ImageProfileService : IImageProfileService
    {
        IImageProfileRepository _repository;
        IMapper _mapper;

        public ImageProfileService( IImageProfileRepository repository,
                                    IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ImageProfileDTO Add(byte[] image, Guid profileGuid)
        {
            ImageProfile newImage = new ImageProfile()
            {
                Image = image,
                ProfileGuid = profileGuid
            };
            _repository.AddAsync(newImage).Wait();
            return _mapper.Map<ImageProfileDTO>(newImage);
        }

        public bool Delete(Guid guid)
        {
            Task task = _repository.DeleteAsync( guid );
            task.Wait();
            return task.IsCompleted;
        }

        public ImageProfileDTO Get(Guid guid)
        {
            ImageProfileDTO image = _mapper.Map<ImageProfileDTO>(_repository.Get( guid ).Result);
            return image;
        }

        public ImageProfileDTO Update(byte[] image, Guid guid)
        {
            ImageProfileDTO current = new ImageProfileDTO { Guid = guid, Image=image };
            Task task = _repository.UpdateAsync(_mapper.Map<ImageProfile>(current));
            task.Wait();
            if (task.IsCompleted)
                return current;
            return null;

        }
    }
}
