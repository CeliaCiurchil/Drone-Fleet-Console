using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Fleet_Console.Models.Interfaces
{
    public interface ICargoCarrier
    {
        double CapacityKg { get; }
        double CurrentLoadKg { get; }
        bool Load(double kg, out string? message);
        void UnloadAll(out string? message);
    }
}
