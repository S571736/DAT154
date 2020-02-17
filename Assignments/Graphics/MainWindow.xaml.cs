using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SpaceSim;

namespace Graphics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void delg(int time);
        private DispatcherTimer t;
        int time = 0;
        public event delg moveIt;
        private Star Sun;
        public MainWindow()
        {
            InitializeComponent();

            Width = SystemParameters.PrimaryScreenWidth;
            Height = SystemParameters.PrimaryScreenHeight;

            Sun = createSolarSystem();
            t = new DispatcherTimer();
            t.Interval = new TimeSpan(2000);
            t.Tick += t_Tick;
            t.Start();
            moveIt += run;



        }
        void t_Tick(object sender, EventArgs e)
        {
            moveIt(time++);
        }

        (List<SpaceObject>, List<Moon>) makePlanets(Star Sun)
        {

            Planet mercury = new Planet("Mercury", 10, 2, "Orange", 57910, 87, Sun);
            Planet venus = new Planet("Venus", 10, 2, "Brown", 108200, 224, Sun);
            Planet earth = new Planet("Earth", 10, 2, "Blue", 149600, 365, Sun);
            Planet mars = new Planet("Mars", 10, 24, "Red", 227940, 686, Sun);
            Planet jupiter = new Planet("Jupiter", 10, 500, "Bisque", 778330, 4332, Sun);
            Planet saturn = new Planet("Saturn", 10, 500, "Brown", 1429400, 10759, Sun);
            Planet uranus = new Planet("Uranus", 10, 500, "Green", 2870990, 30685, Sun);
            Planet neptune = new Planet("Neptune", 10, 500, "Blue", 4504300, 60190, Sun);
            DwarfPlanet pluto = new DwarfPlanet("Pluto", 10, 500, "Gray", 5913520, 90550, Sun);

            List<SpaceObject> allPlanets = new List<SpaceObject> { mercury, venus, earth, mars, jupiter, saturn, uranus, neptune, pluto };

            Moon moon = new Moon("Moon", 1, 0, "Gray", 384, 27, earth);

            Moon phobis = new Moon("Phobos", 1, 0, "Gray", 9, 1, mars);
            Moon Deimos = new Moon("Deimos", 1, 0, "Gray", 23, 46023, mars);

            Moon metis = new Moon("Metis", 1, 0, "Gray", 128, 1, jupiter);
            Moon adrastea = new Moon("Adrastea", 1, 0, "Gray", 129, 1, jupiter);
            Moon amalthea = new Moon("Amalthea", 1, 0, "Gray", 181, 1, jupiter);
            Moon thebe = new Moon("Thebe", 1, 0, "Gray", 222, 1, jupiter);
            Moon Io = new Moon("Io", 1, 0, "Gray", 422, 28126, jupiter);
            Moon Europa = new Moon("Europa", 1, 0, "Gray", 671, 20149, jupiter);
            Moon Ganymede = new Moon("Ganymede", 1, 0, "Gray", 1070, 42186, jupiter);
            Moon Callisto = new Moon("Callisto", 1, 0, "Gray", 1883, 16, jupiter);
            Moon Leda = new Moon("Leda", 1, 0, "Gray", 11094, 238, jupiter);
            Moon Himalia = new Moon("Himalia", 1, 0, "Gray", 11480, 250, jupiter);
            Moon Lysithea = new Moon("Lysithea", 1, 0, "Gray", 11720, 259, jupiter);
            Moon Elara = new Moon("Elara", 1, 0, "Gray", 11737, 259, jupiter);
            Moon Ananke = new Moon("Ananke", 1, 0, "Gray", 21200, -631, jupiter);
            Moon Carme = new Moon("Carme", 1, 0, "Gray", 22600, -692, jupiter);
            Moon Pasiphae = new Moon("Pasiphae", 1, 0, "Gray", 23500, -735, jupiter);
            Moon Sinope = new Moon("Sinope", 1, 0, "Gray", 23700, -758, jupiter);

            Moon Pan = new Moon("Pan", 1, 0, "Gray", 134, 1, saturn);
            Moon Atlas = new Moon("Atlas", 1, 0, "Gray", 138, 1, saturn);
            Moon Prometheus = new Moon("Prometheus", 1, 0, "Gray", 139, 1, saturn);
            Moon Pandora = new Moon("Pandora", 1, 0, "Gray", 142, 1, saturn);
            Moon Epimetheus = new Moon("Epimetheus", 1, 0, "Gray", 151, 1, saturn);
            Moon Janus = new Moon("Janus", 1, 0, "Gray", 151, 1, saturn);
            Moon Mimas = new Moon("Mimas", 1, 0, "Gray", 186, 1, saturn);
            Moon Enceladus = new Moon("Enceladus", 1, 0, "Gray", 238, 13516, saturn);
            Moon Tethys = new Moon("Moon", 1, 0, "Gray", 295, 32509, saturn);
            Moon Telesto = new Moon("Telesto", 1, 0, "Gray", 295, 32509, saturn);
            Moon Calypso = new Moon("Calypso", 1, 0, "Gray", 295, 32509, saturn);
            Moon Dione = new Moon("Dione", 1, 0, "Gray", 377, 27061, saturn);
            Moon Helene = new Moon("Helene", 1, 0, "Gray", 377, 27061, saturn);
            Moon Rhea = new Moon("Rhea", 1, 0, "Gray", 527, 19085, saturn);
            Moon Titan = new Moon("Titan", 1, 0, "Gray", 1222, 15, saturn);
            Moon Hyperion = new Moon("Hyperion", 1, 0, "Gray", 1481, 21, saturn);
            Moon Iapetus = new Moon("Iapetus", 1, 0, "Gray", 3561, 79, saturn);
            Moon Phoebe = new Moon("Phoebe", 1, 0, "Gray", 12952, -550, saturn);

            Moon Cordelia = new Moon("Cordelia", 1, 0, "Gray", 50, 1, uranus);
            Moon Ophelia = new Moon("Ophelia", 1, 0, "Gray", 54, 1, uranus);
            Moon Bianca = new Moon("Bianca", 1, 0, "Gray", 59, 1, uranus);
            Moon Cressida = new Moon("Cressida", 1, 0, "Gray", 62, 1, uranus);
            Moon Desdemona = new Moon("Desdemona", 1, 0, "Gray", 63, 1, uranus);
            Moon Juliet = new Moon("Juliet", 1, 0, "Gray", 64, 1, uranus);
            Moon Portia = new Moon("Portia", 1, 0, "Gray", 66, 1, uranus);
            Moon Rosalind = new Moon("Rosalind", 1, 0, "Gray", 70, 1, uranus);
            Moon Belinda = new Moon("Belinda", 1, 0, "Gray", 75, 1, uranus);
            Moon Puck = new Moon("Puck", 1, 0, "Gray", 86, 1, uranus);
            Moon Miranda = new Moon("Miranda", 1, 0, "Gray", 130, 14977, uranus);
            Moon Ariel = new Moon("Ariel", 1, 0, "Gray", 191, 19025, uranus);
            Moon Umbriel = new Moon("Umbriel", 1, 0, "Gray", 266, 41730, uranus);
            Moon Titania = new Moon("Titania", 1, 0, "Gray", 436, 26146, uranus);
            Moon Oberon = new Moon("Oberon", 1, 0, "Gray", 583, 13, uranus);
            Moon Caliban = new Moon("Caliban", 1, 0, "Gray", 7169, -580, uranus);
            Moon Stephano = new Moon("Stephano", 1, 0, "Gray", 7948, -674, uranus);
            Moon Sycorax = new Moon("Sycorax", 1, 0, "Gray", 12213, -1289, uranus);
            Moon Prospero = new Moon("Prospero", 1, 0, "Gray", 16568, -2019, uranus);
            Moon Setebos = new Moon("Setebos", 1, 0, "Gray", 17681, -2239, uranus);

            Moon Naiad = new Moon("Naiad", 1, 0, "Gray", 48, 1, neptune);
            Moon Thalassa = new Moon("Thalassa", 1, 0, "Gray", 50, 1, neptune);
            Moon Despina = new Moon("Despina", 1, 0, "Gray", 53, 1, neptune);
            Moon Galatea = new Moon("Galatea", 1, 0, "Gray", 62, 1, neptune);
            Moon Larissa = new Moon("Larissa", 1, 0, "Gray", 74, 1, neptune);
            Moon Triton = new Moon("Triton", 1, 0, "Gray", 355, -5, neptune);
            Moon Nereid = new Moon("Nereid", 1, 0, "Gray", 5513, 360, neptune);

            Moon Charon = new Moon("Charon", 1, 0, "Gray", 20, 14397, pluto);
            Moon Nix = new Moon("Nix", 1, 0, "Gray", 49, 24, pluto);
            Moon Hydra = new Moon("Hydra", 1, 0, "Gray", 65, 38, pluto);

            List<Moon> allMoons = new List<Moon> { moon, phobis, Deimos, metis, adrastea, amalthea, thebe, Io, Europa, Ganymede, Callisto, Leda, Himalia, Lysithea, Elara, Ananke, Carme, Pasiphae, Sinope, Pan, Atlas, Prometheus, Pandora, Epimetheus, Janus, Mimas, Enceladus, Tethys, Telesto, Calypso, Dione, Helene, Rhea, Titan, Hyperion, Iapetus, Phoebe, Cordelia, Bianca, Cressida, Desdemona, Juliet, Portia, Rosalind, Belinda, Puck, Miranda, Ariel, Umbriel, Titania, Oberon, Caliban, Stephano, Sycorax, Prospero, Setebos, Naiad, Thalassa, Despina, Galatea, Larissa, Triton, Nereid, Charon, Nix, Hydra };

            return (allPlanets, allMoons);
        }

        void run(int time)
        {
            //ClearCanvasInfo();


            Ellipse sol = new Ellipse();
            SolidColorBrush scb = (SolidColorBrush)new BrushConverter().ConvertFromString(Sun.color);
            sol.Fill = scb;
            sol.Width = Sun.radius * 2;
            sol.Height = Sun.radius * 2;
            double nullW = Sun.x + (Width / 2) - Sun.radius;
            double nullH = Sun.y + (Height / 2) - Sun.radius;

            Canvas.SetLeft(sol, nullW - Sun.radius);
            Canvas.SetTop(sol, nullH - Sun.radius);

            myCanvas.Children.Clear();
            myCanvas.Children.Add(sol);

            double mX = (myCanvas.RenderSize.Width / 2);
            double mY = (myCanvas.RenderSize.Height / 2);
            foreach (Planet p in Sun.satellite)
            {
                Ellipse s = new Ellipse();
                scb = (SolidColorBrush)new BrushConverter().ConvertFromString(p.color);
                s.Fill = scb;
                s.Width = p.radius * 2;
                s.Height = p.radius * 2;

                int tempCount = 1;


                double currentx = nullW + p.x / (400 * (Math.Pow(tempCount, 2)));
                double currenty = nullH + p.y / (400 * (Math.Pow(tempCount, 2)));

                tempCount++;

                Canvas.SetLeft(s, currentx);
                Canvas.SetTop(s, currenty);

                myCanvas.Children.Add(s);

                foreach (Moon m in p.satellite)
                {
                    Ellipse em = new Ellipse();
                    scb = new SolidColorBrush();
                    var c = (Color)ColorConverter.ConvertFromString(m.color);
                    scb.Color = c;
                    em.Fill = scb;
                    em.Width = m.radius * 2;
                    em.Height = m.radius * 2;

                    Canvas.SetLeft(em, m.x / (400 * (Math.Pow(tempCount, 2))) + currentx);
                    Canvas.SetTop(em, m.y / (400 * (Math.Pow(tempCount, 2))) + currenty);

                    myCanvas.Children.Add(em);


                }


            }

            foreach (Planet sObj in Sun.satellite)
            {
                moveIt += sObj.position;

                foreach (Moon moon in sObj.satellite)
                {
                    moveIt += moon.position;
                }
            }


        }

        void ClearCanvasInfo()
        {
            for (int i = myCanvas.Children.Count - 1; i >= 0; i += -1)
            {
                UIElement Child = myCanvas.Children[i];
                if (Child is Ellipse)
                    myCanvas.Children.Remove(Child);
            }
        }

        Star createSolarSystem()
        {
            var Sun = new Star("Sun", 50, 0, "Red");

            var (allPlanets, allMoons) = makePlanets(Sun);

            Sun.satellite = allPlanets;


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

            return Sun;
        }
    }
}
