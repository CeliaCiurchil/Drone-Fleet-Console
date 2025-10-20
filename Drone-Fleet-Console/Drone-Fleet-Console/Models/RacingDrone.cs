using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Fleet_Console.Models
{
    internal class RacingDrone : Drone
    {
        public RacingDrone() : base()
        {
            Name = "Racing Drone";
        }
        internal override void GetActions()
        {
            throw new NotImplementedException();
        }
    }
}
