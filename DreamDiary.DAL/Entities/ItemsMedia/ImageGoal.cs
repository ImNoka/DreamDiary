using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class ImageGoal : ImageBase
    {
        [ForeignKey("GoalGuid")]
        public Goal Goal { get; set; }
        public Guid GoalGuid { get; set; }
    }
}
