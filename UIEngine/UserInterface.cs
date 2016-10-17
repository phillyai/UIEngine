﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace UIEngine
{
    public abstract class UserInterface
    {
        public Point Position { get; set; }
        public Size Size { get; set; }
        public Rectangle Bound
        {
            get { return new Rectangle(Position, Size); }
            set
            {
                Position = value.Location; Size = value.Size;
            }
        }

        public Fill Fill { get; set; }
        public Fill BackgroundFill { get; set; }

        public virtual void Draw(Graphics g)
        {

        }
    }
}
