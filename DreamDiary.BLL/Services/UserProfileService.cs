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
    public class UserProfileService : IUserProfileService
    {

        IMapper _mapper;
        IUserProfileRepository _repository;

        public UserProfileService(IMapper mapper,
                                  IUserProfileRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public UserProfileDTO Add(int userId)
        {
            UserProfile userProfile = new UserProfile()
            {
                FirstName = "New",
                LastName = "New",
                UserId = userId
            };
            UserProfileDTO profileDTO = _mapper.Map<UserProfileDTO>(_repository.AddAsync(userProfile).Result);
            return profileDTO;
        }

        public async Task<bool> Delete(Guid guid)
        {
            return await _repository.DeleteAsync(guid);
        }

        public UserProfileDTO Get(int userId)
        {
            UserProfileDTO profileDTO = _mapper.Map<UserProfileDTO>(_repository.Get(userId));
            return profileDTO;
        }

        public UserProfileDTO Update(UserProfileDTO profileDTO)
        {
            if (profileDTO == null)
                return null;
            UserProfile userProfile = _mapper.Map<UserProfile>(profileDTO);
            _repository.UpdateAsync(userProfile).Wait();
            return profileDTO;
        }
    }
}
