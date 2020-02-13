using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
There's alot of code commented out, this is due to me losing control of what inherited from what and so on during stages where things changed every 10 minutes. 
If these outcommented parts are necessary I will reimplement them.
*/

namespace SpaceSim
{

    public class SpaceObject
    {
        public static int OSC = 365; // The Orbital speed calculator value to find out how fast an object is supposed to spin around it's "Parent"
        public String name { get; protected set; }// Name of object
        public int radius { get; protected set; } // Radius of object
        public int x { get; protected set; } // X coordinates
        public int y { get; protected set; } // Y coordinates
        public SpaceObject(String _name, int _radius)
        {
            name = _name;
            radius = _radius;
            x = 0;
            y = 0;
        }
        public virtual void Draw()
        {
            Console.WriteLine(name);
        }
    }


    public class Star : SpaceObject
    {
        public int rotPeriod { get; protected set; } // Rotational period (length of day)
        public String color { get; protected set; } // Color of object
        public List<SpaceObject> satellite { get; set; } // List of satellites, like comets, planets(Moons for planet) and so on
        public Star(String _name, int _radius, int _rotPeriod, String _color) : base(_name, _radius)
        {
            radius = _radius;
            rotPeriod = _rotPeriod;
            color = _color;
            x = 0;
            y = 0;
            satellite = new List<SpaceObject>();

        }
        public override void Draw()
        {
            String obj = this.GetType().ToString().Replace("SpaceSim.", "");
            Console.Write(obj + ": ");
            base.Draw();
            if (satellite.Any())
            {
                String sat = satellite[0].GetType().ToString().Replace("SpaceSim.", "");
                Console.WriteLine(sat + ": ");
                foreach (var item in satellite)
                {
                    Console.WriteLine("   *" + item.name);
                }
            }
        }
    }

    public class Planet : Star
    {
        public SpaceObject orbiting { get; protected set; } // What object this object is orbiting
        public int orbPeriod; // Orbital period (Length of year) TODO: Implement
        public int orbRadius { get; protected set; } // Radius of orbit
        public int orbSpeed { get; protected set; } // Speed of orbit

        public Planet(String _name, int _radius, int _rotPeriod, String _color, int _orbRadius, int _orbPeriod, SpaceObject _orbiting) : base(_name, _radius, _rotPeriod, _color)
        {
            orbiting = _orbiting;
            orbRadius = _orbRadius;
            orbPeriod = _orbPeriod;
            x = _orbRadius;
            y = 0;
            orbSpeed = OSC / orbPeriod;
            satellite = new List<SpaceObject>();

        }

        public virtual void position(int time)
        {
            x = orbiting.x + orbRadius + (int)(Math.Cos(time * orbSpeed * 3.1416 / 180) * orbRadius);
            y = orbiting.y + orbRadius + (int)(Math.Sin(time * orbSpeed * 3.1416 / 180) * orbRadius);
        }
        public override void Draw()
        {
            base.Draw();
            /*
            Console.Write("Planet: ");
            base.Draw();
            Console.WriteLine("Moons: ");
            foreach (Moon item in satellite)
            {
                Console.WriteLine("   *" + item.name);
            }
            */
        }
    }

    public class Moon : Planet
    {
        
        public Moon(String _name,
        int _radius,
        int _rotPeriod,
        String _color,
        int _orbRadius,
        int _orbPeriod,
        SpaceObject _orbiting)
        : base(_name,
        _radius,
        _rotPeriod,
        _color,
        _orbRadius,
        _orbPeriod,
        _orbiting)
        {
        }
        public override void Draw()
        {
            Console.Write("Moon: " + name);
            satellite = new List<SpaceObject>();
        }
    }
    /*
        public class Comet : SpaceObject
        {
            public Comet(String _name,
            int _radius,
            int _rotPeriod,
            String _color,
            int _orbRadius,
            int _orbPeriod,
            SpaceObject _orbiting) 
            : base(_name, 
            _radius, 
            _rotPeriod, 
            _color, 
            _orbRadius,
            _orbPeriod,
            _orbiting) { }
            public override void Draw()
            {
                Console.Write("Comet: ");
                base.Draw();
            }
        }
    */
    public class Asteroid : Planet
    {
        protected int number { get; set; } // Asteroids are identified with a number before their name
        public Asteroid(String _name, int _radius, int _rotPeriod, String _color, int _orbRadius, int _orbPeriod, SpaceObject _orbiting, int _number) : base(_name, _radius, _rotPeriod, _color, _orbRadius, _orbPeriod, _orbiting)
        {
            number = _number;
        }
        public override void Draw()
        {
            Console.Write("Asteroid: ");
            base.Draw();
            Console.Write(number);
        }
    }

    /*
    public class AsteroidBelt : Planet
    {
        public AsteroidBelt(String _name, SpaceObject _orbiting) : base(_name, _radius, _rotPeriod, _color, _orbiting) { }
        public override void Draw()
        {
            Console.Write("Asteroid belt: ");
            base.Draw();
        }
    }
    */
    public class DwarfPlanet : Planet
    {
        public DwarfPlanet(String _name,
        int _radius,
        int _rotPeriod,
        String _color,
        int _orbRadius,
        int _orbPeriod,
        SpaceObject _orbiting)
        : base(_name,
        _radius,
        _rotPeriod,
        _color,
        _orbRadius,
        _orbPeriod,
        _orbiting)
        {
            satellite = new List<SpaceObject>();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}