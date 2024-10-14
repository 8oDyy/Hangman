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

namespace Hanman
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            starGame();
        }

        int vie;
        string GuessWord;
        char[] HiddenTab;
        string MotIntern;


        public void starGame()
        {
            List<string> listMot = new List<string> { "garage" }; //, "portail", "ordinateur", "voiture", "maison", };
            Random rand = new Random();
            int i = rand.Next(listMot.Count);
            GuessWord = listMot[i].ToUpper();

            MotIntern = new string('*', GuessWord.Length);
            TB_Display.Text = MotIntern;
            vie = 5;
        }

        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string lett = btn.Content.ToString();
            btn.IsEnabled = false;
            int index = 0;

            if (GuessWord.Contains(lett))
            {
                foreach (var l in GuessWord)
                {
                    if (l.ToString() == lett)
                    {
                        MotIntern = MotIntern.Remove(index, 1).Insert(index, lett);
                        TB_Display.Text = MotIntern;    
                    }
                    index++;
                }
            }
            else
            {
                vie--;
            }
        }
    }
}
