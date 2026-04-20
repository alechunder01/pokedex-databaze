using System.Collections.ObjectModel;
using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pokedex_databaze
{
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Pokemon> pokemons = new ObservableCollection<Pokemon>
        {
            new Pokemon("Bulbasaur", "Grass/Poison", 45, 49, 49, 45),
            new Pokemon("Charmander", "Fire", 39, 52, 43, 65),
            new Pokemon("Squirtle", "Water", 44, 48, 65, 43)
        };
        public Pokemon activePokemon;

        public MainWindow()
        {
            InitializeComponent();
            dgPokedex.ItemsSource = pokemons;
        }

        private void loadObject(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = activePokemon.Name;
            typeTextBox.Text = activePokemon.Type;
            HPTextBox.Text = activePokemon.HP.ToString();
            ATKTextBox.Text = activePokemon.Attack.ToString();
            DEFTextBox.Text = activePokemon.Defense.ToString();
            SPEEDTextBox.Text = activePokemon.Speed.ToString();
        }

        private void saveObject(object sender, RoutedEventArgs e)
        {
            int number;
            dgPokedex.ItemsSource = null;
            activePokemon.Name = nameTextBox.Text;
            activePokemon.Type = typeTextBox.Text;
            if (int.TryParse(HPTextBox.Text, out number))
            {
                activePokemon.HP = number;
            }
            else
            {
                MessageBox.Show(
                    "Invalid format!\nPlease enter a valid number.",
                    "Format Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }

            if (int.TryParse(ATKTextBox.Text, out number))
            {
                activePokemon.Attack = number;
            }
            else
            {
                MessageBox.Show(
                    "Invalid format!\nPlease enter a valid number.",
                    "Format Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }

            if (int.TryParse(DEFTextBox.Text, out number))
            {
                activePokemon.Defense = number;
            }
            else
            {
                MessageBox.Show(
                    "Invalid format!\nPlease enter a valid number.",
                    "Format Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }

            if (int.TryParse(SPEEDTextBox.Text, out number))
            {
                activePokemon.Speed = number;
            }
            else
            {
                MessageBox.Show(
                    "Invalid format!\nPlease enter a valid number.",
                    "Format Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }

            if (DiscoveredCheckBox.IsChecked == true)
            {
                activePokemon.Discovered = true;
            }
            else
            {
                activePokemon.Discovered = false;
            }

            dgPokedex.ItemsSource = pokemons;
            clear(sender, e);
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = null;
            typeTextBox.Text = null;
            HPTextBox.Text = null;
            ATKTextBox.Text = null;
            DEFTextBox.Text = null;
            SPEEDTextBox.Text = null;
        }

        private void changePokemon(object sender, SelectionChangedEventArgs e)
        {
            if (dgPokedex.SelectedItem is Pokemon pokemon)
            {
                activePokemon = pokemon;
                loadObject(sender, e);
                heading.Text = $"{activePokemon.Name} details";
            }
        }

        private void addPokemon(object sender, RoutedEventArgs e)
        {
            Pokemon newPokemon = new Pokemon("New Pokemon", "Type", 0, 0, 0, 0);
            pokemons.Add(newPokemon);
            dgPokedex.SelectedItem = newPokemon;
        }

        private void removePokemon(object sender, RoutedEventArgs e)
        {
            if (dgPokedex.SelectedItem is Pokemon pokemon)
            {
                pokemons.Remove(pokemon);
                clear(sender, e);
            }
        }

        private void loadPokemonList(object sender, RoutedEventArgs e)
        {
            dgPokedex.ItemsSource = null;
            pokemons = new ObservableCollection<Pokemon>
            {
                new Pokemon("Bulbasaur",    "Grass/Poison",  45, 49, 49, 45),
                new Pokemon("Ivysaur",      "Grass/Poison",  60, 62, 63, 60),
                new Pokemon("Venusaur",     "Grass/Poison",  80, 82, 83, 80),
                new Pokemon("Charmander",   "Fire",          39, 52, 43, 65),
                new Pokemon("Charmeleon",   "Fire",          58, 64, 58, 80),
                new Pokemon("Charizard",    "Fire/Flying",   78, 84, 78,100),
                new Pokemon("Squirtle",     "Water",         44, 48, 65, 43),
                new Pokemon("Wartortle",    "Water",         59, 63, 80, 58),
                new Pokemon("Blastoise",    "Water",         79, 83,100, 78),
                new Pokemon("Caterpie",     "Bug",           45, 30, 35, 45),
                new Pokemon("Metapod",      "Bug",           50, 20, 55, 30),
                new Pokemon("Butterfree",   "Bug/Flying",    60, 45, 50, 70),
                new Pokemon("Weedle",       "Bug/Poison",    40, 35, 30, 50),
                new Pokemon("Kakuna",       "Bug/Poison",    45, 25, 50, 35),
                new Pokemon("Beedrill",     "Bug/Poison",    65, 90, 40, 75),
                new Pokemon("Pidgey",       "Normal/Flying", 40, 45, 40, 56),
                new Pokemon("Pidgeotto",    "Normal/Flying", 63, 60, 55, 71),
                new Pokemon("Pidgeot",      "Normal/Flying", 83, 80, 75,101),
                new Pokemon("Rattata",      "Normal",        30, 56, 35, 72),
                new Pokemon("Raticate",     "Normal",        55, 81, 60, 97),
                new Pokemon("Spearow",      "Normal/Flying", 40, 60, 30, 70),
                new Pokemon("Fearow",       "Normal/Flying", 65, 90, 65,100),
                new Pokemon("Ekans",        "Poison",        35, 60, 44, 55),
                new Pokemon("Arbok",        "Poison",        60, 95, 69, 80),
                new Pokemon("Pikachu",      "Electric",      35, 55, 40, 90),
                new Pokemon("Raichu",       "Electric",      60, 90, 55,110),
                new Pokemon("Sandshrew",    "Ground",        50, 75, 85, 40),
                new Pokemon("Sandslash",    "Ground",        75,100,110, 65),
                new Pokemon("Nidoran♀",     "Poison",        55, 47, 52, 41),
                new Pokemon("Nidorina",     "Poison",        70, 62, 67, 56),
                new Pokemon("Nidoqueen",    "Poison/Ground", 90, 92, 87, 76),
                new Pokemon("Nidoran♂",     "Poison",        46, 57, 40, 50),
                new Pokemon("Nidorino",     "Poison",        61, 72, 57, 65),
                new Pokemon("Nidoking",     "Poison/Ground", 81,102, 77, 85),
                new Pokemon("Clefairy",     "Fairy",         70, 45, 48, 60),
                new Pokemon("Clefable",     "Fairy",         95, 70, 73, 90),
                new Pokemon("Vulpix",       "Fire",          38, 41, 40, 65),
                new Pokemon("Ninetales",    "Fire",          73, 76, 75,100),
                new Pokemon("Jigglypuff",   "Normal/Fairy", 115, 45, 20, 20),
                new Pokemon("Wigglytuff",   "Normal/Fairy", 140, 70, 45, 45),
                new Pokemon("Zubat",        "Poison/Flying", 40, 45, 35, 55),
                new Pokemon("Golbat",       "Poison/Flying", 75, 80, 70, 90),
                new Pokemon("Oddish",       "Grass/Poison",  45, 50, 55, 30),
                new Pokemon("Gloom",        "Grass/Poison",  60, 65, 70, 40),
                new Pokemon("Vileplume",    "Grass/Poison",  75, 80, 85, 50),
                new Pokemon("Paras",        "Bug/Grass",     35, 70, 55, 25),
                new Pokemon("Parasect",     "Bug/Grass",     60, 95, 80, 30),
                new Pokemon("Venonat",      "Bug/Poison",    60, 55, 50, 45),
                new Pokemon("Venomoth",     "Bug/Poison",    70, 65, 60, 90),
                new Pokemon("Diglett",      "Ground",        10, 55, 25, 95),
                new Pokemon("Dugtrio",      "Ground",        35, 80, 50,120),
                new Pokemon("Meowth",       "Normal",        40, 45, 35, 90),
                new Pokemon("Persian",      "Normal",        65, 70, 60,115),
                new Pokemon("Psyduck",      "Water",         50, 52, 48, 55),
                new Pokemon("Golduck",      "Water",         80, 82, 78, 85),
                new Pokemon("Mankey",       "Fighting",      40, 80, 35, 70),
                new Pokemon("Primeape",     "Fighting",      65,105, 60, 95),
                new Pokemon("Growlithe",    "Fire",          55, 70, 45, 60),
                new Pokemon("Arcanine",     "Fire",          90,110, 80, 95),
                new Pokemon("Poliwag",      "Water",         40, 50, 40, 90),
                new Pokemon("Poliwhirl",    "Water",         65, 65, 65, 90),
                new Pokemon("Poliwrath",    "Water/Fighting",90, 95, 95, 70),
                new Pokemon("Abra",         "Psychic",       25, 20, 15, 90),
                new Pokemon("Kadabra",      "Psychic",       40, 35, 30,105),
                new Pokemon("Alakazam",     "Psychic",       55, 50, 45,120),
                new Pokemon("Machop",       "Fighting",      70, 80, 50, 35),
                new Pokemon("Machoke",      "Fighting",      80,100, 70, 45),
                new Pokemon("Machamp",      "Fighting",      90,130, 80, 55),
                new Pokemon("Bellsprout",   "Grass/Poison",  50, 75, 35, 40),
                new Pokemon("Weepinbell",   "Grass/Poison",  65, 90, 50, 55),
                new Pokemon("Victreebel",   "Grass/Poison",  80,105, 65, 70),
                new Pokemon("Tentacool",    "Water/Poison",  40, 40, 35, 70),
                new Pokemon("Tentacruel",   "Water/Poison",  80, 70, 65,100),
                new Pokemon("Geodude",      "Rock/Ground",   40, 80,100, 20),
                new Pokemon("Graveler",     "Rock/Ground",   55, 95,115, 35),
                new Pokemon("Golem",        "Rock/Ground",   80,120,130, 45),
                new Pokemon("Ponyta",       "Fire",          50, 85, 55, 90),
                new Pokemon("Rapidash",     "Fire",          65,100, 70,105),
                new Pokemon("Slowpoke",     "Water/Psychic", 90, 65, 65, 15),
                new Pokemon("Slowbro",      "Water/Psychic", 95, 75,110, 30),
                new Pokemon("Magnemite",    "Electric/Steel",25, 35, 70, 45),
                new Pokemon("Magneton",     "Electric/Steel",50, 60, 95, 70),
                new Pokemon("Farfetch'd",   "Normal/Flying", 52, 65, 55, 60),
                new Pokemon("Doduo",        "Normal/Flying", 35, 85, 45, 75),
                new Pokemon("Dodrio",       "Normal/Flying", 60,110, 70,100),
                new Pokemon("Seel",         "Water",         65, 45, 55, 45),
                new Pokemon("Dewgong",      "Water/Ice",     90, 70, 80, 70),
                new Pokemon("Grimer",       "Poison",        80, 80, 50, 25),
                new Pokemon("Muk",          "Poison",       105,105, 75, 50),
                new Pokemon("Shellder",     "Water",         30, 65,100, 40),
                new Pokemon("Cloyster",     "Water/Ice",     50, 95,180, 70),
                new Pokemon("Gastly",       "Ghost/Poison",  30, 35, 30, 80),
                new Pokemon("Haunter",      "Ghost/Poison",  45, 50, 45, 95),
                new Pokemon("Gengar",       "Ghost/Poison",  60, 65, 60,110),
                new Pokemon("Onix",         "Rock/Ground",   35, 45,160, 70),
                new Pokemon("Drowzee",      "Psychic",       60, 48, 45, 42),
                new Pokemon("Hypno",        "Psychic",       85, 73, 70, 67),
                new Pokemon("Krabby",       "Water",         30,105, 90, 50),
                new Pokemon("Kingler",      "Water",         55,130,115, 75),
                new Pokemon("Voltorb",      "Electric",      40, 30, 50,100),
                new Pokemon("Electrode",    "Electric",      60, 50, 70,140),
                new Pokemon("Exeggcute",    "Grass/Psychic", 60, 40, 80, 40),
                new Pokemon("Exeggutor",    "Grass/Psychic", 95, 95, 85, 55),
                new Pokemon("Cubone",       "Ground",        50, 50, 95, 35),
                new Pokemon("Marowak",      "Ground",        60, 80,110, 45)
            };
            dgPokedex.ItemsSource = pokemons;
        }
    }
}