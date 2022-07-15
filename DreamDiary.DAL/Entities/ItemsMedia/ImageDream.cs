using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class ImageDream : ImageBase
    {
        [ForeignKey("DreamGuid")]
        public Dream Dream { get; set; }
        public Guid DreamGuid { get; set; }
    }
}
