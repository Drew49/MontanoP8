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
       
        private int num;
        public int Num { get { return num; } }
        
        
        
        
        
        public MainWindow()
        {
            DBManager dbManager = new DBManager();
            InitializeComponent();
            btnRight.IsEnabled = false;
            btnWrong.IsEnabled = false;
            cards = dbManager.GetCards();
            lbCardlist.ItemsSource = cards;
            num = GetRandomCard();
            DisplayCardQuestion(num);

        }

        private void lbCardlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Card card = (Card)lbCardlist.SelectedItem;
            tbxManageID.Text = card.CardID.ToString();
            tbxManageAnswer.Text=card.Answer;
            tbxManageTitle.Text=card.Title;
            tbxManageQuestion.Text=card.Question;
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
            tbxCardID.Text = card.CardID.ToString();
            tbxCardTitle.Text = card.Title;
            tbxQuestion.Text = card.Question;
            tbxThink.Text = "Think about the answer and click Show Answer";
        }

        private void btnShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            Card card = cards[num];

            tbxAnswer.Text = card.Answer;
            btnShowAnswer.IsEnabled = false;
            btnRight.IsEnabled = true;
            btnWrong.IsEnabled = true;
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            Card card = cards[num];
            card.NumRight++;
            num = GetRandomCard();
            DisplayCardQuestion(num);
            btnRight.IsEnabled = false;
            btnWrong.IsEnabled= false;
            btnShowAnswer.IsEnabled = true;
            tbxAnswer.Clear();
        }

        private void btnWrong_Click(object sender, RoutedEventArgs e)
        {
            Card card = cards[num];
            card.NumWrong++;
            num = GetRandomCard();
            DisplayCardQuestion(num);
            btnRight.IsEnabled = false;
            btnWrong.IsEnabled = false;
            btnShowAnswer.IsEnabled = true;
            tbxAnswer.Clear();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Card card = new Card();
            DBManager dBManager = new DBManager();
            card.CardID = string.IsNullOrEmpty(tbxManageID.Text) ? 0 : int.Parse(tbxManageID.Text);
            card.Title = tbxManageTitle.Text;
            card.Question = tbxManageQuestion.Text;
            card.Answer = tbxManageAnswer.Text;
            card.NumRight = 0;
            card.NumWrong = 0;
            dBManager.AddCard(card);
            cards = dBManager.GetCards();
            lbCardlist.ItemsSource = cards;
            

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Card card = (Card)lbCardlist.SelectedItem;
            DBManager dBManager = new DBManager();
            card.CardID = int.Parse(tbxManageID.Text);
            dBManager.RemoveCard(card.CardID);
            cards = dBManager.GetCards();
            lbCardlist.ItemsSource = cards;
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Card card = new Card();
            DBManager dbManager = new DBManager();
            card.CardID = string.IsNullOrEmpty(tbxManageID.Text)?0:int.Parse(tbxManageID.Text);
            card.Title = tbxManageTitle.Text;
            card.Question = tbxManageQuestion.Text;
            card.Answer = tbxManageAnswer.Text;
            card.NumRight = 0;
            card.NumWrong = 0;
            dbManager.Update(card);
            cards= dbManager.GetCards();
            lbCardlist.ItemsSource=cards;
        }
    }
}
