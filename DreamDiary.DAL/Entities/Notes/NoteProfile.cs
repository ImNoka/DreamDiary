using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class NoteProfile : NoteBase
    {
        public Guid ProfileGuid { get; set; }

        [ForeignKey("ProfileGuid")]
        public UserProfile Profile { get; set; }
    }
}
