using System;
using System.Collections.Generic;
using System.Linq;
using SpaceSim;

class Astronomy
{
    public static void Main()
    {

        Star Sun = new Star("Sun", 50, 0, "RED");

        Planet mercury = new Planet("Mercury", 3, 2, "ORANGE", 57910, 87, Sun);
        Planet venus = new Planet("Venus", 3, 2, "BROWN", 108200, 224, Sun);
        Planet earth = new Planet("Earth", 3, 2, "BLUE", 149600, 365, Sun);
        Planet mars = new Planet("Mars", 4, 24, "RED", 227940, 686, Sun);
        Planet jupiter = new Planet("Jupiter", 10, 500, "BEIGE", 778330, 4332, Sun);
        Planet saturn = new Planet("Saturn", 10, 500, "BROWN", 1429400, 10759, Sun);
        Planet uranus = new Planet("Uranus", 10, 500, "GREEN", 2870990, 30685, Sun);
        Planet neptune = new Planet("Neptune", 10, 500, "BLUE", 4504300, 60190, Sun);
        DwarfPlanet pluto = new DwarfPlanet("Pluto", 10, 500, "GREY", 5913520, 90550, Sun);


        Moon moon = new Moon("Moon", 1, 0, "GREY", 384, 27, earth);

        Moon phobis = new Moon("Phobos", 1, 0, "GREY", 9, 1, mars);
        Moon Deimos = new Moon("Deimos", 1, 0, "GREY", 23, 46023, mars);

        Moon metis = new Moon("Metis", 1, 0, "GREY", 128, 1, jupiter);
        Moon adrastea = new Moon("Adrastea", 1, 0, "GREY", 129, 1, jupiter);
        Moon amalthea = new Moon("Amalthea", 1, 0, "GREY", 181, 1, jupiter);
        Moon thebe = new Moon("Thebe", 1, 0, "GREY", 222, 1, jupiter);
        Moon Io = new Moon("Io", 1, 0, "GREY", 422, 28126, jupiter);
        Moon Europa = new Moon("Europa", 1, 0, "GREY", 671, 20149, jupiter);
        Moon Ganymede = new Moon("Ganymede", 1, 0, "GREY", 1070, 42186, jupiter);
        Moon Callisto = new Moon("Callisto", 1, 0, "GREY", 1883, 16, jupiter);
        Moon Leda = new Moon("Leda", 1, 0, "GREY", 11094, 238, jupiter);
        Moon Himalia = new Moon("Himalia", 1, 0, "GREY", 11480, 250, jupiter);
        Moon Lysithea = new Moon("Lysithea", 1, 0, "GREY", 11720, 259, jupiter);
        Moon Elara = new Moon("Elara", 1, 0, "GREY", 11737, 259, jupiter);
        Moon Ananke = new Moon("Ananke", 1, 0, "GREY", 21200, -631, jupiter);
        Moon Carme = new Moon("Carme", 1, 0, "GREY", 22600, -692, jupiter);
        Moon Pasiphae = new Moon("Pasiphae", 1, 0, "GREY", 23500, -735, jupiter);
        Moon Sinope = new Moon("Sinope", 1, 0, "GREY", 23700, -758, jupiter);

        Moon Pan = new Moon("Pan", 1, 0, "GREY", 134, 1, saturn);
        Moon Atlas = new Moon("Atlas", 1, 0, "GREY", 138, 1, saturn);
        Moon Prometheus = new Moon("Prometheus", 1, 0, "GREY", 139, 1, saturn);
        Moon Pandora = new Moon("Pandora", 1, 0, "GREY", 142, 1, saturn);
        Moon Epimetheus = new Moon("Epimetheus", 1, 0, "GREY", 151, 1, saturn);
        Moon Janus = new Moon("Janus", 1, 0, "GREY", 151, 1, saturn);
        Moon Mimas = new Moon("Mimas", 1, 0, "GREY", 186, 1, saturn);
        Moon Enceladus = new Moon("Enceladus", 1, 0, "GREY", 238, 13516, saturn);
        Moon Tethys = new Moon("Moon", 1, 0, "GREY", 295, 32509, saturn);
        Moon Telesto = new Moon("Telesto", 1, 0, "GREY", 295, 32509, saturn);
        Moon Calypso = new Moon("Calypso", 1, 0, "GREY", 295, 32509, saturn);
        Moon Dione = new Moon("Dione", 1, 0, "GREY", 377, 27061, saturn);
        Moon Helene = new Moon("Helene", 1, 0, "GREY", 377, 27061, saturn);
        Moon Rhea = new Moon("Rhea", 1, 0, "GREY", 527, 19085, saturn);
        Moon Titan = new Moon("Titan", 1, 0, "GREY", 1222, 15, saturn);
        Moon Hyperion = new Moon("Hyperion", 1, 0, "GREY", 1481, 21, saturn);
        Moon Iapetus = new Moon("Iapetus", 1, 0, "GREY", 3561, 79, saturn);
        Moon Phoebe = new Moon("Phoebe", 1, 0, "GREY", 12952, -550, saturn);

        Moon Cordelia = new Moon("Cordelia", 1, 0, "GREY", 50, 1, uranus);
        Moon Ophelia = new Moon("Ophelia", 1, 0, "GREY", 54, 1, uranus);
        Moon Bianca = new Moon("Bianca", 1, 0, "GREY", 59, 1, uranus);
        Moon Cressida = new Moon("Cressida", 1, 0, "GREY", 62, 1, uranus);
        Moon Desdemona = new Moon("Desdemona", 1, 0, "GREY", 63, 1, uranus);
        Moon Juliet = new Moon("Juliet", 1, 0, "GREY", 64, 1, uranus);
        Moon Portia = new Moon("Portia", 1, 0, "GREY", 66, 1, uranus);
        Moon Rosalind = new Moon("Rosalind", 1, 0, "GREY", 70, 1, uranus);
        Moon Belinda = new Moon("Belinda", 1, 0, "GREY", 75, 1, uranus);
        Moon Puck = new Moon("Puck", 1, 0, "GREY", 86, 1, uranus);
        Moon Miranda = new Moon("Miranda", 1, 0, "GREY", 130, 14977, uranus);
        Moon Ariel = new Moon("Ariel", 1, 0, "GREY", 191, 19025, uranus);
        Moon Umbriel = new Moon("Umbriel", 1, 0, "GREY", 266, 41730, uranus);
        Moon Titania = new Moon("Titania", 1, 0, "GREY", 436, 26146, uranus);
        Moon Oberon = new Moon("Oberon", 1, 0, "GREY", 583, 13, uranus);
        Moon Caliban = new Moon("Caliban", 1, 0, "GREY", 7169, -580, uranus);
        Moon Stephano = new Moon("Stephano", 1, 0, "GREY", 7948, -674, uranus);
        Moon Sycorax = new Moon("Sycorax", 1, 0, "GREY", 12213, -1289, uranus);
        Moon Prospero = new Moon("Prospero", 1, 0, "GREY", 16568, -2019, uranus);
        Moon Setebos = new Moon("Setebos", 1, 0, "GREY", 17681, -2239, uranus);

        Moon Naiad = new Moon("Naiad", 1, 0, "GREY", 48, 1, neptune);
        Moon Thalassa = new Moon("Thalassa", 1, 0, "GREY", 50, 1, neptune);
        Moon Despina = new Moon("Despina", 1, 0, "GREY", 53, 1, neptune);
        Moon Galatea = new Moon("Galatea", 1, 0, "GREY", 62, 1, neptune);
        Moon Larissa = new Moon("Larissa", 1, 0, "GREY", 74, 1, neptune);
        Moon Triton = new Moon("Triton", 1, 0, "GREY", 355, -5, neptune);
        Moon Nereid = new Moon("Nereid", 1, 0, "GREY", 5513, 360, neptune);

        Moon Charon = new Moon("Charon", 1, 0, "GREY", 20, 14397, pluto);
        Moon Nix = new Moon("Nix", 1, 0, "GREY", 49, 24, pluto);
        Moon Hydra = new Moon("Hydra", 1, 0, "GREY", 65, 38, pluto);

        List<SpaceObject> allPlanets = new List<SpaceObject> { mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, pluto };
        List<Moon> allMoons = new List<Moon> { moon, phobis, Deimos, metis, adrastea, amalthea, thebe, Io, Europa, Ganymede, Callisto, Leda, Himalia, Lysithea, Elara, Ananke, Carme, Pasiphae, Sinope, Pan, Atlas, Prometheus, Pandora, Epimetheus, Janus, Mimas, Enceladus, Tethys, Telesto, Calypso, Dione, Helene, Rhea, Titan, Hyperion, Iapetus, Phoebe, Cordelia, Bianca, Cressida, Desdemona, Juliet, Portia, Rosalind, Belinda, Puck, Miranda, Ariel, Umbriel, Titania, Oberon, Caliban, Stephano, Sycorax, Prospero, Setebos, Naiad, Thalassa, Despina, Galatea, Larissa, Triton, Nereid, Charon, Nix, Hydra };


        Sun.satellite = allPlanets;
        /*
        foreach (Planet p in allPlanets)
        {
            foreach (Moon m in allMoons)
            {
                if (m.orbiting == p)
                {
                    p.satellite.Add(m);
                }
                else if (m.orbiting == pluto)
                {
                    pluto.satellite.Add(m);
                }
            }
        }
        */
        foreach (Moon m in allMoons)
        {
            foreach (Planet s in allPlanets)
            {
                if (m.orbiting.name == s.name)
                {
                    s.satellite.Add(m);
                }
            }
        }

        //jupiter.Draw();

        String planet = Console.ReadLine();
        int simple = 0;
        
        foreach(SpaceObject o in allPlanets)
        {
            if(o.name == planet){
                o.Draw();
                simple++;
            }
        }

        if(simple == 0){
            Sun.Draw();
        }
        /*
        foreach (SpaceObject obj in solarSystem)
        {
            obj.Draw();
        }
        */
        Console.ReadLine();
    }
}