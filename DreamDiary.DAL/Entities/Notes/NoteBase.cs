using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class NoteBase : BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
