using AutoMapper;
using DreamDiary.BLL.DTO;
using DreamDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.Mappers
{
    public class DreamMapper : Profile
    {

        public DreamMapper()
        {
            
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<UserProfileDTO, UserProfile>();
            CreateMap<UserProfile, UserProfileDTO>();

            //CreateMap<Note, NoteDTO>();
            //CreateMap<NoteDTO, Note>();

            //CreateMap<Dream, DreamDTO>();
            //CreateMap<DreamDTO, Dream>();

        }
    }
}
