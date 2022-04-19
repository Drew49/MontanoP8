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

namespace MontanoP8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Card> cards;
        
        
        
        
        
        public MainWindow()
        {
            DBManager dbManager = new DBManager();
            InitializeComponent();
            cards = dbManager.GetCards();
            lbCardlist.ItemsSource = cards;
            DisplayCardQuestion(GetRandomCard());
             
            
            

        }

        private void lbCardlist_MouseDoubleClick(object sender, SelectionChangedEventArgs e)
        {

        }

        private int GetRandomCard()
        {
            Random rnd = new Random();
            int r = rnd.Next(cards.Count);
            return r;

        }
        private void DisplayCardQuestion(int k)
        {
            Card card = cards[k];
            int id = k + 1;
            tbxCardID.Text = card.CardID.ToString();
            tbxCardTitle.Text = card.Title;
            tbxQuestion.Text = card.Question;
            tbxThink.Text = "Think about the answer and click Show Answer";
        }
    }
}
