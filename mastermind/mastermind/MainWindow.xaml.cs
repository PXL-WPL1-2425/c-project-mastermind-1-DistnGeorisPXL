using System.Reflection.Emit;
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

        // Beschikbare kleuren
        List<string> kleuren = new List<string> { "Rood", "Geel", "Oranje", "Wit", "Groen", "Blauw" };

        // Lijst voor de gegenereerde code
        List<string> secretCode = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            VulComboBoxen(); // Vul de comboboxen met de kleuren
            GenerateRandomCode(); // Genereer en toon de random code in de titel
        }


        // Methode om de willekeurige code te genereren
        private void GenerateRandomCode()
        {

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
        private void VulComboBoxen()
        {
            comboBox1.ItemsSource = kleuren;
            comboBox2.ItemsSource = kleuren;
            comboBox3.ItemsSource = kleuren;
            comboBox4.ItemsSource = kleuren;
        }











        // Event handler voor de selectie van een kleur in de ComboBox
        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Controleer welke ComboBox is geselecteerd en werk het juiste Label bij
            if (sender == comboBox1)
            {
                UpdateLabelColor(label1, comboBox1.SelectedItem.ToString());
            }
            else if (sender == comboBox2)
            {
                UpdateLabelColor(label2, comboBox2.SelectedItem.ToString());
            }
            else if (sender == comboBox3)
            {
                UpdateLabelColor(label3, comboBox3.SelectedItem.ToString());
            }
            else if (sender == comboBox4)
            {
                UpdateLabelColor(label4, comboBox4.SelectedItem.ToString());
            }
        }

        // Methode om de achtergrondkleur van een label bij te werken
        private void UpdateLabelColor(System.Windows.Controls.Label label, string colorName)
        {
            // Zet de achtergrondkleur van het label op basis van de geselecteerde kleur
            switch (colorName)
            {
                case "Rood":
                    label.Background = System.Windows.Media.Brushes.Red;
                    break;
                case "Geel":
                    label.Background = System.Windows.Media.Brushes.Yellow;
                    break;
                case "Oranje":
                    label.Background = System.Windows.Media.Brushes.Orange;
                    break;
                case "Wit":
                    label.Background = System.Windows.Media.Brushes.White;
                    break;
                case "Groen":
                    label.Background = System.Windows.Media.Brushes.Green;
                    break;
                case "Blauw":
                    label.Background = System.Windows.Media.Brushes.Blue;
                    break;
                default:
                    label.Background = System.Windows.Media.Brushes.Transparent; // Als er geen kleur is geselecteerd
                    break;
            }
        }





















        // Event handler voor het klikken op de Check Code knop
        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            // Haal de ingevoerde kleuren uit de ComboBoxen
            List<string> userInput = new List<string>
            {
                comboBox1.SelectedItem?.ToString(),
                comboBox2.SelectedItem?.ToString(),
                comboBox3.SelectedItem?.ToString(),
                comboBox4.SelectedItem?.ToString()
            };

            // Controleer of de gebruiker een waarde heeft geselecteerd in elke ComboBox
            if (userInput.Contains(null))
            {
                MessageBox.Show("Please select a color for all boxes.");
                return;
            }

            // Vergelijk de ingevoerde code met de geheime code
            for (int i = 0; i < 4; i++)
            {
                // Als de kleur op de juiste plaats staat (Rood)
                if (userInput[i] == secretCode[i])
                {
                    SetLabelBorder(i, Colors.DarkRed); // Rode rand voor correcte positie
                }
                else if (secretCode.Contains(userInput[i]))
                {
                    SetLabelBorder(i, Colors.Wheat); // Witte rand voor correcte kleur maar verkeerde positie
                }
                else
                {
                    SetLabelBorder(i, Colors.Transparent); // Geen rand als de kleur niet in de code zit
                }
            }
        }

        // Methode om de rand van het label in te stellen
        private void SetLabelBorder(int index, Color borderColor)
        {
            switch (index)
            {
                case 0:
                    label1.BorderBrush = new SolidColorBrush(borderColor);
                    label1.BorderThickness = new Thickness(2);
                    break;
                case 1:
                    label2.BorderBrush = new SolidColorBrush(borderColor);
                    label2.BorderThickness = new Thickness(2);
                    break;
                case 2:
                    label3.BorderBrush = new SolidColorBrush(borderColor);
                    label3.BorderThickness = new Thickness(2);
                    break;
                case 3:
                    label4.BorderBrush = new SolidColorBrush(borderColor);
                    label4.BorderThickness = new Thickness(2);
                    break;
            }
        }


    }
}