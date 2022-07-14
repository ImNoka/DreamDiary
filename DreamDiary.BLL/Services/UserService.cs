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
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private IUserRepository _userRepository;
        public UserService(IMapper mapper,
                            IUserRepository userRepisotory)
        {
            _mapper = mapper;
            _userRepository = userRepisotory;
        }

        public async Task<bool> Delete(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            IEnumerable<UserDTO> users = new List<UserDTO>();
            //_mapper.Map(_userRepository.GetAll().Join(_profileRepository.GetAll(), u=>u.Id,p=>p.UserId), users);
            users = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(_userRepository.GetAll());
            //_mapper.Map(_profileRepository.GetAll(),users);
            //var users = _mapper.Map<IEnumerable<User>, List<UserDTO>>(_userRepository.GetAll());
            return users;
        }

        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO Register(UserDTO userDTO)
        {
            User user = _mapper.Map<UserDTO, User>(userDTO);
            UserDTO newUserDTO = _mapper.Map<UserDTO>(_userRepository.AddAsync(user).Result);
            return newUserDTO;
        }

        public UserDTO Update(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            _userRepository.UpdateAsync(user).Wait();
            return userDTO;
        }
    }
}
