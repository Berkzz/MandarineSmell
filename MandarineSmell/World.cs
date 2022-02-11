using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandarineSmell
{
    public class World
    {
        public World()
        {
            var shape = new RectangleShape(new Vector2f(20, 20));
            shape.FillColor = Color.White;

            Objects = new List<Drawable>()
            {
                new RectangleShape(new Vector2f(20,20))
            };
        }

        public IEnumerable<Drawable> Objects;
    }
}
