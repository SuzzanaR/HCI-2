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
using System;
using System.Windows.Threading;

namespace Asocijacije
{

    public partial class MainWindow : Window
    {
        private int points = 0;
        private int remainingTimeInSeconds = 150;
        private DispatcherTimer countdownTimer;

        public MainWindow()
        {
            InitializeComponent();
            UpdateScoreDisplay();
            InitializeTimer();
        }

        private void InitializeTimer()
        {

            countdownTimer = new DispatcherTimer();
            countdownTimer.Interval = TimeSpan.FromSeconds(1);
            countdownTimer.Tick += CountdownTimer_Tick;

            countdownTimer.Start();

            UpdateTimerDisplay();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            remainingTimeInSeconds--;

            UpdateTimerDisplay();


            if (remainingTimeInSeconds <= 0)
            {
                countdownTimer.Stop();
                MessageBox.Show("Vrijeme je isteklo!\n\nRješenja asocijacije:\nA: NAUČNIK\nB: AERODROM\nC: MAGNET\nD: POLJE\nKonačno: NIKOLA TESLA");
                EndGame();
            }
        }
        private void UpdateTimerDisplay()
        {
            timerTextBlock.Text = remainingTimeInSeconds.ToString();
        }

        private void EndGame()
        {
            buttona4.Visibility = Visibility.Collapsed;
            buttona3.Visibility = Visibility.Collapsed;
            buttona2.Visibility = Visibility.Collapsed;
            buttona1.Visibility = Visibility.Collapsed;
            myTextBoxA.Visibility = Visibility.Collapsed;

            buttonb4.Visibility = Visibility.Collapsed;
            buttonb3.Visibility = Visibility.Collapsed;
            buttonb2.Visibility = Visibility.Collapsed;
            buttonb1.Visibility = Visibility.Collapsed;
            myTextBoxB.Visibility = Visibility.Collapsed;

            buttonc4.Visibility = Visibility.Collapsed;
            buttonc3.Visibility = Visibility.Collapsed;
            buttonc2.Visibility = Visibility.Collapsed;
            buttonc1.Visibility = Visibility.Collapsed;
            myTextBoxC.Visibility = Visibility.Collapsed;

            buttond4.Visibility = Visibility.Collapsed;
            buttond3.Visibility = Visibility.Collapsed;
            buttond2.Visibility = Visibility.Collapsed;
            buttond1.Visibility = Visibility.Collapsed;
            myTextBoxD.Visibility = Visibility.Collapsed;

            myTextBoxK.Visibility = Visibility.Collapsed;
            ButtonOdustani.Visibility = Visibility.Collapsed;


        }


        //A
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            buttona1.Visibility = Visibility.Collapsed;

        }

        private void buttona2_Click(object sender, RoutedEventArgs e)
        {
            buttona2.Visibility = Visibility.Collapsed;

        }

        private void buttona3_Click(object sender, RoutedEventArgs e)
        {
            buttona3.Visibility = Visibility.Collapsed;
        }

        private void buttona4_Click(object sender, RoutedEventArgs e)
        {
            buttona4.Visibility = Visibility.Collapsed;
        }



        //B


        private void buttonb1_Click(object sender, RoutedEventArgs e)
        {
            buttonb1.Visibility = Visibility.Collapsed;

        }

        private void buttonb2_Click(object sender, RoutedEventArgs e)
        {
            buttonb2.Visibility = Visibility.Collapsed;


        }

        private void buttonb3_Click(object sender, RoutedEventArgs e)
        {
            buttonb3.Visibility = Visibility.Collapsed;


        }

        private void buttonb4_Click(object sender, RoutedEventArgs e)
        {
            buttonb4.Visibility = Visibility.Collapsed;


        }


        //C
        private void buttonc1_Click(object sender, RoutedEventArgs e)
        {
            buttonc1.Visibility = Visibility.Collapsed;
        }

        private void buttonc2_Click(object sender, RoutedEventArgs e)
        {
            buttonc2.Visibility = Visibility.Collapsed;
        }

        private void buttonc3_Click(object sender, RoutedEventArgs e)
        {
            buttonc3.Visibility = Visibility.Collapsed;
        }

        private void buttonc4_Click(object sender, RoutedEventArgs e)
        {
            buttonc4.Visibility = Visibility.Collapsed;
        }


        //D
        private void buttond1_Click(object sender, RoutedEventArgs e)
        {
            buttond1.Visibility = Visibility.Collapsed;
        }

        private void buttond2_Click(object sender, RoutedEventArgs e)
        {
            buttond2.Visibility = Visibility.Collapsed;
        }

        private void buttond3_Click(object sender, RoutedEventArgs e)
        {
            buttond3.Visibility = Visibility.Collapsed;
        }

        private void buttond4_Click(object sender, RoutedEventArgs e)
        {
            buttond4.Visibility = Visibility.Collapsed;
        }


    //KOLONA B UNOS RJESENJA


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (buttonb1.Visibility != Visibility.Visible ||
                   buttonb2.Visibility != Visibility.Visible ||
                   buttonb3.Visibility != Visibility.Visible ||
                   buttonb4.Visibility != Visibility.Visible)
            {

                if (e.Key == Key.Enter)
                {

                    string enteredText = myTextBoxB.Text;
                    if (enteredText.Equals("AERODROM") || enteredText.Equals("aerodrom"))
                    {
                        MessageBox.Show("TAČNO!");


                        points += (4 + GetRemainingButtonsPointsB());
                        buttonb4.Visibility = Visibility.Collapsed;
                        buttonb3.Visibility = Visibility.Collapsed;
                        buttonb2.Visibility = Visibility.Collapsed;
                        buttonb1.Visibility = Visibility.Collapsed;
                        myTextBoxB.Visibility = Visibility.Collapsed;

                        buttonB1P.Background = Brushes.LimeGreen;
                        buttonB2P.Background = Brushes.LimeGreen;
                        buttonB3P.Background = Brushes.LimeGreen;
                        buttonB4P.Background = Brushes.LimeGreen;
                        buttonBP.Background = Brushes.LimeGreen;


                    }
                    else
                    {

                        MessageBox.Show("NETAČNO");

                        myTextBoxB.Clear();
                    }
                    UpdateScoreDisplay();
                }
            }  else { MessageBox.Show("Otvorite neko polje da biste mogli da pogađate asocijaciju."); }


        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (myTextBoxB.Text == "B")
            {
                myTextBoxB.Clear();
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(myTextBoxB.Text))
            {
                myTextBoxB.Text = "B";
            }
            myTextBoxB.Text = "B";
        }

        private int GetRemainingButtonsPointsB()
        {
            int additionalPoints = 0;

            if (buttonb1.Visibility == Visibility.Visible) additionalPoints += 2;
            if (buttonb2.Visibility == Visibility.Visible) additionalPoints += 2;
            if (buttonb3.Visibility == Visibility.Visible) additionalPoints += 2;
            if (buttonb4.Visibility == Visibility.Visible) additionalPoints += 2;

            return additionalPoints;
        }

        private void UpdateScoreDisplay()
        {
            scoreTextBlock.Text = "Bodovi: " + points;
        }

    //KOLONA A UNOS RJESENJA


        void TextBox_KeyDownA(object sender, KeyEventArgs e)
        {
            if (buttona1.Visibility != Visibility.Visible ||
                   buttona2.Visibility != Visibility.Visible ||
                   buttona3.Visibility != Visibility.Visible ||
                   buttona4.Visibility != Visibility.Visible)
            {

                if (e.Key == Key.Enter)  
                {
                    

                        string enteredText = myTextBoxA.Text;
                        if (enteredText.Equals("NAUČNIK") || enteredText.Equals("naučnik") || enteredText.Equals("naucnik") || enteredText.Equals("NAUCNIK"))
                        {
                            MessageBox.Show("TAČNO!");
                            points += (4 + GetRemainingButtonsPointsA());
                            buttona4.Visibility = Visibility.Collapsed;
                            buttona3.Visibility = Visibility.Collapsed;
                            buttona2.Visibility = Visibility.Collapsed;
                            buttona1.Visibility = Visibility.Collapsed;
                            myTextBoxA.Visibility = Visibility.Collapsed;

                            buttonA1P.Background = Brushes.LimeGreen;
                            buttonA2P.Background = Brushes.LimeGreen;
                            buttonA3P.Background = Brushes.LimeGreen;
                            buttonA4P.Background = Brushes.LimeGreen;
                            buttonAP.Background = Brushes.LimeGreen;
                    
                        }
                        else
                        {

                            MessageBox.Show("NETAČNO");

                            myTextBoxA.Clear();
                        }
                        UpdateScoreDisplay();
                    }
            }
            else { MessageBox.Show("Otvorite neko polje da biste mogli da pogađate asocijaciju."); }


        }
    

            void TextBox_GotFocusa(object sender, RoutedEventArgs e)
            {
                if (myTextBoxA.Text == "A")
                {
                    myTextBoxA.Clear();
                }
            }

            void TextBox_LostFocusa(object sender, RoutedEventArgs e)
            {

                if (string.IsNullOrWhiteSpace(myTextBoxA.Text))
                {
                    myTextBoxA.Text = "A";
                }
                myTextBoxA.Text = "A";
            }

            int GetRemainingButtonsPointsA()
            {
                int additionalPoints = 0;
                if (buttona1.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttona2.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttona3.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttona4.Visibility == Visibility.Visible) additionalPoints += 2;

                return additionalPoints;
            }


      //KOLONA C UNOS RJESENJA


            void TextBox_KeyDownC(object sender, KeyEventArgs e)
            {
            if (buttonc1.Visibility != Visibility.Visible ||
                   buttonc2.Visibility != Visibility.Visible ||
                   buttonc3.Visibility != Visibility.Visible ||
                   buttonc4.Visibility != Visibility.Visible)
            {

                if (e.Key == Key.Enter)  
                    {

                        string enteredText = myTextBoxC.Text;
                        if (enteredText.Equals("MAGNET") || enteredText.Equals("magnet"))
                        {
                            MessageBox.Show("TAČNO!");
                            points += (4 + GetRemainingButtonsPointsC());
                            buttonc4.Visibility = Visibility.Collapsed;
                            buttonc3.Visibility = Visibility.Collapsed;
                            buttonc2.Visibility = Visibility.Collapsed;
                            buttonc1.Visibility = Visibility.Collapsed;
                            myTextBoxC.Visibility = Visibility.Collapsed;

                            buttonC1P.Background = Brushes.LimeGreen;
                            buttonC2P.Background = Brushes.LimeGreen;
                            buttonC3P.Background = Brushes.LimeGreen;
                            buttonC4P.Background = Brushes.LimeGreen;
                            buttonCP.Background = Brushes.LimeGreen;

                        }
                        else
                        {

                            MessageBox.Show("NETAČNO");

                            myTextBoxC.Clear();
                        }
                        UpdateScoreDisplay();
                    }
            }
            else { MessageBox.Show("Otvorite neko polje da biste mogli da pogađate asocijaciju."); }

            }

        void TextBox_GotFocusC(object sender, RoutedEventArgs e)
            {
                if (myTextBoxC.Text == "C")
                {
                    myTextBoxC.Clear();
                }
            }

            void TextBox_LostFocusC(object sender, RoutedEventArgs e)
            {

                if (string.IsNullOrWhiteSpace(myTextBoxC.Text))
                {
                    myTextBoxC.Text = "C";
                }
                myTextBoxC.Text = "C";
            }

            int GetRemainingButtonsPointsC()
            {
                int additionalPoints = 0;

                if (buttonc1.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttonc2.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttonc3.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttonc4.Visibility == Visibility.Visible) additionalPoints += 2;

                return additionalPoints;
            }


    //KOLONA D UNOS RJESENJA


            void TextBox_KeyDownD(object sender, KeyEventArgs e)
            {
            if (buttond1.Visibility != Visibility.Visible ||
                  buttond2.Visibility != Visibility.Visible ||
                  buttond3.Visibility != Visibility.Visible ||
                  buttond4.Visibility != Visibility.Visible)
            {

                if (e.Key == Key.Enter)  
                    {

                        string enteredText = myTextBoxD.Text;
                        if (enteredText.Equals("POLJE") || enteredText.Equals("polje"))
                        {
                            MessageBox.Show("TAČNO!");
                            points += (4 + GetRemainingButtonsPointsD());
                            buttond4.Visibility = Visibility.Collapsed;
                            buttond4.Visibility = Visibility.Collapsed;
                            buttond3.Visibility = Visibility.Collapsed;
                            buttond2.Visibility = Visibility.Collapsed;
                            buttond1.Visibility = Visibility.Collapsed;
                            myTextBoxD.Visibility = Visibility.Collapsed;

                            buttonD1P.Background = Brushes.LimeGreen;
                            buttonD2P.Background = Brushes.LimeGreen;
                            buttonD3P.Background = Brushes.LimeGreen;
                            buttonD4P.Background = Brushes.LimeGreen;
                            buttonDP.Background = Brushes.LimeGreen;

                        }
                        else
                        {

                            MessageBox.Show("NETAČNO");

                            myTextBoxD.Clear();
                        }
                        UpdateScoreDisplay();
                    }
            }
            else { MessageBox.Show("Otvorite neko polje da biste mogli da pogađate asocijaciju."); }


             }

        void TextBox_GotFocusD(object sender, RoutedEventArgs e)
            {
                if (myTextBoxD.Text == "D")
                {
                    myTextBoxD.Clear();
                }
            }

            void TextBox_LostFocusD(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(myTextBoxD.Text))
                {
                    myTextBoxD.Text = "D";
                }
            }


            int GetRemainingButtonsPointsD()
            {
                int additionalPoints = 0;


                if (buttond1.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttond2.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttond3.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttond4.Visibility == Visibility.Visible) additionalPoints += 2;

                return additionalPoints;
            }


     //KONACNO RJESENJE


            void TextBox_KeyDownK(object sender, KeyEventArgs e)
            {
                if (buttona1.Visibility != Visibility.Visible ||
                    buttona2.Visibility != Visibility.Visible ||
                    buttona3.Visibility != Visibility.Visible ||
                    buttona4.Visibility != Visibility.Visible ||

                    buttonb1.Visibility != Visibility.Visible ||
                    buttonb2.Visibility != Visibility.Visible ||
                    buttonb3.Visibility != Visibility.Visible ||
                    buttonb4.Visibility != Visibility.Visible ||

                    buttonc1.Visibility != Visibility.Visible ||
                    buttonc2.Visibility != Visibility.Visible ||
                    buttonc3.Visibility != Visibility.Visible ||
                    buttonc4.Visibility != Visibility.Visible ||

                    buttond1.Visibility != Visibility.Visible ||
                    buttond2.Visibility != Visibility.Visible ||
                    buttond3.Visibility != Visibility.Visible ||
                    buttond4.Visibility != Visibility.Visible)
                {
                    if (e.Key == Key.Enter)  
                    {

                        string enteredText = myTextBoxK.Text;
                        if (enteredText.Equals("NIKOLA TESLA") || enteredText.Equals("nikola tesla"))
                        {
                            MessageBox.Show("Čestitamo! Pogodili ste konačno rješenje!");
                            countdownTimer.Stop();

                            points += (8 + GetRemainingButtonsPointsK());

                            buttona4.Visibility = Visibility.Collapsed;
                            buttona3.Visibility = Visibility.Collapsed;
                            buttona2.Visibility = Visibility.Collapsed;
                            buttona1.Visibility = Visibility.Collapsed;
                            myTextBoxA.Visibility = Visibility.Collapsed;

                            buttonb4.Visibility = Visibility.Collapsed;
                            buttonb3.Visibility = Visibility.Collapsed;
                            buttonb2.Visibility = Visibility.Collapsed;
                            buttonb1.Visibility = Visibility.Collapsed;
                            myTextBoxB.Visibility = Visibility.Collapsed;

                            buttonc4.Visibility = Visibility.Collapsed;
                            buttonc3.Visibility = Visibility.Collapsed;
                            buttonc2.Visibility = Visibility.Collapsed;
                            buttonc1.Visibility = Visibility.Collapsed;
                            myTextBoxC.Visibility = Visibility.Collapsed;

                            buttond4.Visibility = Visibility.Collapsed;
                            buttond3.Visibility = Visibility.Collapsed;
                            buttond2.Visibility = Visibility.Collapsed;
                            buttond1.Visibility = Visibility.Collapsed;
                            myTextBoxD.Visibility = Visibility.Collapsed;

                            myTextBoxK.Visibility = Visibility.Collapsed;
                            ButtonOdustani.Visibility = Visibility.Collapsed;

                            buttonA1P.Background = Brushes.LimeGreen;
                            buttonA2P.Background = Brushes.LimeGreen;
                            buttonA3P.Background = Brushes.LimeGreen;
                            buttonA4P.Background = Brushes.LimeGreen;
                            buttonAP.Background = Brushes.LimeGreen;

                            buttonB1P.Background = Brushes.LimeGreen;
                            buttonB2P.Background = Brushes.LimeGreen;
                            buttonB3P.Background = Brushes.LimeGreen;
                            buttonB4P.Background = Brushes.LimeGreen;
                            buttonBP.Background = Brushes.LimeGreen;

                            buttonC1P.Background = Brushes.LimeGreen;
                            buttonC2P.Background = Brushes.LimeGreen;
                            buttonC3P.Background = Brushes.LimeGreen;
                            buttonC4P.Background = Brushes.LimeGreen;
                            buttonCP.Background = Brushes.LimeGreen;

                            buttonD1P.Background = Brushes.LimeGreen;
                            buttonD2P.Background = Brushes.LimeGreen;
                            buttonD3P.Background = Brushes.LimeGreen;
                            buttonD4P.Background = Brushes.LimeGreen;
                            buttonDP.Background = Brushes.LimeGreen;

                            Konacno.Background = Brushes.LimeGreen;

                        }
                        else
                        {

                            MessageBox.Show("NETAČNO");

                            myTextBoxK.Clear();
                        }
                        UpdateScoreDisplay();
                    }
                }
                else { MessageBox.Show("Otvorite neko polje da biste mogli da pogađate asocijaciju."); }

            }

            void TextBox_GotFocusK(object sender, RoutedEventArgs e)
            {
                if (myTextBoxK.Text == "???")
                {
                    myTextBoxK.Clear();
                }
            }

            void TextBox_LostFocusK(object sender, RoutedEventArgs e)
            {

                if (string.IsNullOrWhiteSpace(myTextBoxK.Text))
                {
                    myTextBoxK.Text = "???";
                }
                myTextBoxK.Text = "???";
            }


            int GetRemainingButtonsPointsK()
            {
                int additionalPoints = 0;

                if (buttona1.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttona2.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttona3.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttona4.Visibility == Visibility.Visible) additionalPoints += 2;
                if (myTextBoxA.Visibility == Visibility.Visible) additionalPoints += 4;

                if (buttonb1.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttonb2.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttonb3.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttonb4.Visibility == Visibility.Visible) additionalPoints += 2;
                if (myTextBoxB.Visibility == Visibility.Visible) additionalPoints += 4;

                if (buttonc1.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttonc2.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttonc3.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttonc4.Visibility == Visibility.Visible) additionalPoints += 2;
                if (myTextBoxC.Visibility == Visibility.Visible) additionalPoints += 4;

                if (buttond1.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttond2.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttond3.Visibility == Visibility.Visible) additionalPoints += 2;
                if (buttond4.Visibility == Visibility.Visible) additionalPoints += 2;
                if (myTextBoxD.Visibility == Visibility.Visible) additionalPoints += 4;

                return additionalPoints;
            }

        void Button_Odustani(object sender, RoutedEventArgs e)
        {
           
            DeleteConfirmationPopup.IsOpen = true;
        }


        void ConfirmDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            countdownTimer.Stop();

            MessageBox.Show("Odustali ste. Više sreće drugi put!\n\nRješenja asocijacije:\nA: NAUČNIK\nB: AERODROM\nC: MAGNET\nD: POLJE\nKonačno: NIKOLA TESLA", "Igra je završena", MessageBoxButton.OK, MessageBoxImage.Information);
            EndGame();

           
            DeleteConfirmationPopup.IsOpen = false;
        }

        void CancelDeleteButton_Click(object sender, RoutedEventArgs e)
        {

            DeleteConfirmationPopup.IsOpen = false;
        }




    }

}
