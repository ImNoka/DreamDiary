using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamDiary.BLL.Interfaces
{
    public interface IImageService<T>
    {
        T Get(Guid guid);
        T Add(byte[] image, Guid guid);
        bool Delete(Guid guid);
        T Update(byte[] image, Guid guid);
    }
}
