using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Fleet_Console.Models.Interfaces
{
    public interface IPhotoCapture
    {
        void TakePhoto(out string? message);
        int PhotoCount { get; }
    }
}
