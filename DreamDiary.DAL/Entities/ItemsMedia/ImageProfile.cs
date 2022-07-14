using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class ImageProfile : ImageBase
    {
        [ForeignKey("ProfileGuid")]
        public UserProfile UserProfile { get; set; }
        public Guid ProfileGuid { get; set; }
    }
}
