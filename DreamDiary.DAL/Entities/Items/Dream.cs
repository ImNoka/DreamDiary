using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class Dream : BaseEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        [ForeignKey("ProfileGuid")]
        public UserProfile UserProfile { get; set; }
        public Guid ProfileGuid { get; set; }
        [ForeignKey("ImageDreamGuid")]
        public ImageDream? ImageDream { get; set; }
        public Guid? ImageDreamGuid { get; set; }
    }
}
