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
            CreateMap<ImageDream,ImageDreamDTO>();
            CreateMap<ImageDreamDTO, ImageDream>();


            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<UserProfileDTO, UserProfile>();
            CreateMap<UserProfile, UserProfileDTO>();

            CreateMap<ImageProfile, ImageProfileDTO>();
            CreateMap<ImageProfileDTO, ImageProfile>();



            CreateMap<Dream, DreamDTO>()
                .ForMember(dest=>dest.Image, opt=>opt.MapFrom(src=>src.ImageDream));
            CreateMap<DreamDTO, Dream>()
                .ForMember(dest=>dest.ImageDream, opt=>opt.MapFrom(src=>src.Image));

            CreateMap<NoteProfile, NoteProfileDTO>();
            CreateMap<NoteProfileDTO, NoteProfile>();

            //CreateMap<Note, NoteDTO>();
            //CreateMap<NoteDTO, Note>();

            //CreateMap<Dream, DreamDTO>();
            //CreateMap<DreamDTO, Dream>();

        }
    }
}
