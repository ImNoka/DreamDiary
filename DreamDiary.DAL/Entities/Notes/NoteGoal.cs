using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class NoteGoal : NoteBase
    {
        public Guid GoalGuid { get; set; }

        [ForeignKey("GoalGuid")]
        public Goal Goal { get; set; }
    }
}
