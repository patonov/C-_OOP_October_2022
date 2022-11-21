using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PersonInfo
{
    public class Robot : IRobot
    {
        public Robot(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
