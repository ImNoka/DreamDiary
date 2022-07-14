using DreamDiary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.DTO
{
    public class DreamDTO
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public Guid ProfileGuid { get; set; }
        public ImageDream Image { get; set; }
    }
}
