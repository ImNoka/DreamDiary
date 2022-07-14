using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.DAL.Entities
{
    public class ImageBase : BaseEntity
    {
        public byte[] Image { get; set; }
    }
}
