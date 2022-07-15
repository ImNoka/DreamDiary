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
    public class NoteProfileService : INoteProfileService
    {
        INoteProfileRepository _noteRepository;
        IMapper _mapper;
        public NoteProfileService(INoteProfileRepository noteRepository,
                            IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(NoteProfileDTO note)
        {
            NoteProfile newNote = new NoteProfile();
            _mapper.Map(note, newNote);
            Task<NoteProfile> task = _noteRepository.AddAsync(newNote);
            await task;
            if (task.IsFaulted)
                return false;
            return true;
        }

        public async Task<bool> Delete(Guid guid)
        {
            return await _noteRepository.DeleteAsync(guid);
        }

        public IEnumerable<NoteProfileDTO> GetAll()
        {
            IEnumerable<NoteProfileDTO> notes = _mapper.Map<IEnumerable<NoteProfile>, IEnumerable<NoteProfileDTO>>(_noteRepository.GetAll());
            return notes;
        }

        public IEnumerable<NoteProfileDTO> GetAllByProfileGuid(Guid guid)
        {
            IEnumerable<NoteProfileDTO> notes = _mapper.Map<IEnumerable<NoteProfile>, IEnumerable<NoteProfileDTO>>(_noteRepository.GetByProfileGuid(guid));
            return notes;
        }

        public async Task<bool> Update(NoteProfileDTO note)
        {
            NoteProfile updated = await _noteRepository.UpdateAsync(_mapper.Map<NoteProfileDTO, NoteProfile>(note));
            if (updated != null)
                return true;
            return false;
        }
    }
}
