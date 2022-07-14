using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.DTO
{
    public class NoteProfileDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid ProfileGuid { get; set; }
    }
}
