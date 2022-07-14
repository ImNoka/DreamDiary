using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class NoteTask : NoteBase
    {
        public Guid TaskGuid { get; set; }

        [ForeignKey("TaskGuid")]
        public GoalTask Task { get; set; }
    }
}
