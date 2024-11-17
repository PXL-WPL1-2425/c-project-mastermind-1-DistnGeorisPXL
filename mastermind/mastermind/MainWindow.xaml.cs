using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateRandomCode(); // Genereer en toon de random code in de titel
        }


        // Methode om de willekeurige code te genereren
        private void GenerateRandomCode()
        {
            // Beschikbare kleuren
            List<string> kleuren = new List<string> { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };

            // Lijst voor de gegenereerde code
            List<string> secretCode = new List<string>();

            // Random object voor willekeurige getallen
            Random random = new Random();

            // Genereer een willekeurige code van 4 kleuren
            for (int i = 0; i < 4; i++)
            {
                secretCode.Add(kleuren[random.Next(kleuren.Count)]);
            }

            // Zet de code in de titel van het window voor testdoeleinden
            this.Title = "Mastermind - Secret Code: " + string.Join(", ", secretCode);
        }

    }
}