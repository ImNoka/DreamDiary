using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.DTO
{
    public class ImageProfileDTO
    {
        public Guid Guid { get; set; }
        public byte[] Image { get; set; }
        public Guid ProfileGuid { get; set; }
    }
}
