using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class Goal : BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }

        [ForeignKey("ProfileGuid")]
        public UserProfile UserProfile { get; set; }
        public Guid ProfileGuid { get; set; }
        public IEnumerable<NoteGoal>? GoalNotes { get; set; }
        public IEnumerable<GoalTask>? Tasks { get; set; }

        [ForeignKey("ImageDreamGuid")]
        public ImageGoal? Image { get; set; }
        public Guid? ImageGuid { get; set; }

        public bool IsCompleted { get; set; }

    }
}
