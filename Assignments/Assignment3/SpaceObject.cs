using System;
/*
Use coordinates of circle to find out coordinates of planets and moons in orbit
*/
namespace SpaceSim
{
    public class SpaceObject
    {
        protected String name; // Name of object
        protected int radius; // Radius of object
        public SpaceObject(String _name, int _radius)
        {
            name = _name;
            radius = _radius;
        }
        public virtual void Draw()
        {
            Console.WriteLine(name);
        }
    }


    public class Star : SpaceObject
    {
        protected int rotPeriod; // Rotational period (length of day)
        protected String color; // Color of object
        protected List<SpaceObject> satellite;
        public Star(String _name, int _radius, int _rotPeriod, String _color, List<SpaceObject> _satellite) : base(_name, _radius)
        {
            radius = _radius;
            rotPeriod = _rotPeriod;
            color = _color;
            satellite = _satellite;
        }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }

    public class Planet : Sun
    {
        protected SpaceObject orbiting; // What object this object is orbiting
        protected int orbPeriod; // Orbital period (Length of year)
        public Planet(String _name, int _radius, int _rotPeriod, String _color, SpaceObject _orbiting, int _orbPeriod, List<SpaceObject> _satellite) : base(_name, _radius, _rotPeriod, _color, _satellite)
        {
            orbiting = _orbiting;
            orbPeriod = _orbPeriod;
        }
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }

    public class Moon : Planet
    {
        public Moon(String _name, int _radius, int _rotPeriod, String _color, SpaceObject _orbiting, int _orbPeriod, List<SpaceObject> _satellite) : base(_name, _radius, _rotPeriod, _color, _orbiting, _orbPeriod, _satellite) { }
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
        protected int number; // Asteroids are identified with a number before their name
        public Asteroid(String _name, int _radius, int _rotPeriod, String _color, SpaceObject _orbiting, int _orbPeriod, int _number, List<SpaceObject> _satellite) : base(_name, _radius, _rotPeriod, _color, _orbiting, _orbPeriod, _satellite)
        {
            number = _number;
        }
        public override void Draw()
        {
            Console.Write("Asteroid: ");
            base.Draw();
        }
    }

    public class AsteroidBelt : Sun
    {
        public AsteroidBelt(String _name, List<SpaceObject> _satellite) : base(_name, _satellite) { }
        public override void Draw()
        {
            Console.Write("Asteroid belt: ");
            base.Draw();
        }
    }

    public class DwarfPlanet : Planet
    {
        public DwarfPlanet(String _name, int _radius, int _rotPeriod, String _color, SpaceObject _orbiting, int _orbPeriod, List<SpaceObject> _satellite) : base(_name, _radius, _rotPeriod, _color, _orbiting, _orbPeriod, _satellite) { }

        public override void Draw()
        {
            Console.Write("Dwarf planet: ");
            base.Draw();
        }
    }
}