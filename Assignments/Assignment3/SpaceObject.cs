using System;
/*
Use coordinates of circle to find out coordinates of planets and moons in orbit
*/

namespace SpaceSim
{
    public static int OSC = 365; // The Orbital speed calculator value to find out how fast an object is supposed to spin around it's "Parent"
    public class SpaceObject
    {
        protected String name { get; set; }// Name of object
        protected int radius { get; set; } // Radius of object
        protected int x { get; set; } // X coordinates
        protected int y { get; set; } // Y coordinates
        public SpaceObject(String _name, int _radius, int _x, int _y)
        {
            name = _name;
            radius = _radius;
            x = _x;
            y = _y;
        }
        public virtual void Draw()
        {
            Console.WriteLine(name);
        }
    }


    public class Star : SpaceObject
    {
        protected int rotPeriod { get; set; } // Rotational period (length of day)
        protected String color { get; set; } // Color of object
        protected List<SpaceObject> satellite { get; set; } // List of satellites, like comets, planets(Moons for planet) and so on
        public Star(String _name, int _radius, int _rotPeriod, String _color, List<SpaceObject> satellite) : base(_name, _radius)
        {
            radius = _radius;
            rotPeriod = _rotPeriod;
            color = _color;
            satellite = _satellite;
            x = 0;
            y = 0;
        }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
            Console.WriteLine("Planets: ");
            foreach (SpaceObject item in satellite)
            {
                Console.WriteLine("   *" + satellite.name);
            }
        }
    }

    public class Planet : Sun
    {
        protected SpaceObject orbiting { get; set; } // What object this object is orbiting
        protected int orbPeriod; // Orbital period (Length of year) TODO: Implement
        protected int orbRadius { get; set; } // Radius of orbit
        protected int orbSpeed { get; set; } // Speed of orbit

        public Planet(String _name, int _radius, int _rotPeriod, String _color, int _orbRadius, int _orbPeriod, SpaceObject _orbiting, List<SpaceObject> _satellite) : base(_name, _radius, _rotPeriod, _color, _satellite)
        {
            orbiting = _orbiting;
            orbRadius = _orbRadius;
            x = _orbRadius;
            orbiting = _orbiting;
            orbSpeed = OSC/orbPeriod;
        }

        public virtual void position(int time)
        {
            x = orbiting.x + orbRadius + (int)(Math.Cos(time * orbSpeed * 3.1416 / 180) * orbRadius);
            y = orbiting.y + orbRadius + (int)(Math.Sin(time * orbSpeed * 3.1416 / 180) * orbRadius);
        }
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
            Console.WriteLine("Moons: ");
            foreach (SpaceObject item in satellite)
            {
                Console.WriteLine("   *" + satellite.name);
            }
        }
    }

    public class Moon : Planet
    {
        public Moon(String _name, int _radius, int _rotPeriod, String _color, int _orbRadius, int _orbPeriod, SpaceObject _orbiting) : base(_name, _radius, _rotPeriod, _color, _satellite, _orbPeriod, _orbiting) { }
        public override void Draw()
        {
            Console.Write("Moon: ");
            base.Draw();
        }
    }

    public class Comet : SpaceObject
    {
        public Comet(String _name, int _radius, int _rotPeriod, String _color) : base(_name, _radius, _rotPeriod, _color) { }
        public override void Draw()
        {
            Console.Write("Comet: ");
            base.Draw();
        }
    }

    public class Asteroid : Planet
    {
        protected int number { get; set; } // Asteroids are identified with a number before their name
        public Asteroid(String _name, int _radius, int _rotPeriod, String _color, int _orbRadius, int _orbPeriod, SpaceObject _orbiting, int _number) : base(_name, _radius, _rotPeriod, _color, _satellite, _orbSpeed, _orbiting)
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

    public class AsteroidBelt : Sun
    {
        public AsteroidBelt(String _name, SpaceObject _orbiting) : base(_name, _orbiting) { }
        public override void Draw()
        {
            Console.Write("Asteroid belt: ");
            base.Draw();
        }
    }

    public class DwarfPlanet : Planet
    {
        public DwarfPlanet(String _name, int _radius, int _rotPeriod, String _color, int _orbRadius, int _orbSpeed, SpaceObject _orbiting) : base(_name, _radius, _rotPeriod, _color, _satellite, _orbSpeed, _orbiting) { }

        public override void Draw()
        {
            Console.Write("Dwarf planet: ");
            base.Draw();
        }
    }
}