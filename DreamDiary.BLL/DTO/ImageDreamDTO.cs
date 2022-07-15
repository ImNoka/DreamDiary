using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.DTO
{
    public class ImageDreamDTO
    {
        public Guid Guid { get; set; }
        public byte[] Image { get; set; }
        public Guid DreamGuid { get; set; }
    }
}
