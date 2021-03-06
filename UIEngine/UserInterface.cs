﻿using System.Drawing;

namespace UIEngine
{
    public abstract class UserInterface
    {
        public Point Position { get; set; }
        public float Rotation { get; set; }
        public Size Size { get; set; }

        public Rectangle Bound
        {
            get { return new Rectangle(Position, Size); }
            set
            {
                Position = value.Location; Size = value.Size;
            }
        }
        public Point Origin { get { return new Point(Position.X + Size.Width / 2, Position.Y + Size.Height / 2);} }

        public Fill Fill { get; set; } = Fill.DefaultFill;
        public Fill BackgroundFill { get; set; } = Fill.DefaultBackgroundFill;

        public bool BackgroundTransparencyEqual { get; set; } = true;
        
        public virtual void Draw(Graphics g)
        {
            if (BackgroundTransparencyEqual)
                BackgroundFill.Transparency = Fill.Transparency;
            //g.ResetTransform();
            g.TranslateTransform(Origin.X, Origin.Y);
            g.RotateTransform(Rotation);
            g.TranslateTransform(-Origin.X, -Origin.Y);
            //System.Diagnostics.Debug.WriteLine(string.Join(", ", g.Transform.Elements));
            BackgroundFill.FillRectangle(g, Bound);
        }
    }
}
