
namespace Gui_roulette
{
    public partial class Form1 : Form
    {
        private decimal playerBalance = 100;
        private string selectedBetType = null; // "Red", "Black", "Even", "Odd" eller null
        private readonly HashSet<int> redNumbers = new HashSet<int> { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        private readonly Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            UpdateBalanceDisplay();

            // Koppla eventhanterare
            betred.Click += (s, e) => { selectedBetType = "Red"; resultat.Text = "Vald: Rött"; UpdateButtonColors(); };
            betblack.Click += (s, e) => { selectedBetType = "Black"; resultat.Text = "Vald: Svart"; UpdateButtonColors(); };
            beteven.Click += (s, e) => { selectedBetType = "Even"; resultat.Text = "Vald: Jämnt"; UpdateButtonColors(); };
            betodd.Click += (s, e) => { selectedBetType = "Odd"; resultat.Text = "Vald: Udda"; UpdateButtonColors(); };
            betbtn.Click += BetBtn_Click;
            reset.Click += Reset_Click;

            // Endast siffror i textfält
            betamount.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; };
            nrbtn.KeyPress += (s, e) => { if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; };
        }

        private void UpdateBalanceDisplay()
        {
            balance.Text = $"Balance: ${playerBalance}";
        }

        private void UpdateButtonColors()
        {
            betred.BackColor = selectedBetType == "Red" ? Color.DarkRed : Color.Red;
            betblack.BackColor = selectedBetType == "Black" ? Color.DarkGray : Color.Black;
            beteven.BackColor = selectedBetType == "Even" ? Color.BurlyWood : Color.SandyBrown;
            betodd.BackColor = selectedBetType == "Odd" ? Color.DimGray : Color.Gray;
        }

        private void BetBtn_Click(object sender, EventArgs e)
        {
            // 1. Validera insats
            if (string.IsNullOrWhiteSpace(betamount.Text))
            {
                resultat.Text = " Ange insatsbelopp!";
                return;
            }

            if (!decimal.TryParse(betamount.Text, out decimal betAmount) || betAmount <= 0)
            {
                resultat.Text = " Ogiltig insats!";
                return;
            }

            if (betAmount > playerBalance)
            {
                resultat.Text = $" Du har bara ${playerBalance} kvar!";
                return;
            }

            // 2. Hämta valt nummer (om angivet)
            bool hasNumber = !string.IsNullOrWhiteSpace(nrbtn.Text);
            int selectedNumber = -1;

            if (hasNumber)
            {
                if (!int.TryParse(nrbtn.Text, out selectedNumber) || selectedNumber < 0 || selectedNumber > 36)
                {
                    resultat.Text = " Ogiltigt nummer (0-36)!";
                    return;
                }
            }

            // 3. Validera kombination om både bettyp och nummer är valda
            if (!string.IsNullOrEmpty(selectedBetType) && hasNumber)
            {
                if (selectedNumber == 0)
                {
                    resultat.Text = " 0 är GRÖNT! Kan ej kombineras med Rött/Svart/Jämnt/Udda.";
                    return;
                }

                if (selectedBetType == "Red" && !redNumbers.Contains(selectedNumber))
                {
                    resultat.Text = $" {selectedNumber} är SVART, inte rött!";
                    return;
                }

                if (selectedBetType == "Black" && redNumbers.Contains(selectedNumber))
                {
                    resultat.Text = $" {selectedNumber} är RÖTT, inte svart!";
                    return;
                }

                if (selectedBetType == "Even" && selectedNumber % 2 != 0)
                {
                    resultat.Text = $" {selectedNumber} är UDDA, inte jämnt!";
                    return;
                }

                if (selectedBetType == "Odd" && selectedNumber % 2 == 0)
                {
                    resultat.Text = $" {selectedNumber} är JÄMNT, inte udda!";
                    return;
                }
            }

            // 4. Generera slumpresultat (0-36)
            int resultNumber = random.Next(0, 37);
            string resultColor = GetColor(resultNumber);
            bool isEven = (resultNumber != 0 && resultNumber % 2 == 0);

            // 5. Beräkna vinst/förlust
            bool win = false;
            decimal payout = 0;

            // FALL 1: Satsa enbart på nummer (ingen färg/typ vald)
            if (string.IsNullOrEmpty(selectedBetType) && hasNumber)
            {
                if (resultNumber == selectedNumber)
                {
                    win = true;
                    payout = selectedNumber == 0 ? betAmount * 100 : betAmount * 2; // 100x för 0, 2x för andra nummer
                }
                // Annars förlust (win = false)
            }
            // FALL 2: Satsa på färg/typ + nummer
            else if (!string.IsNullOrEmpty(selectedBetType) && hasNumber)
            {
                if (resultNumber == 0)
                {
                    // 0 = alltid förlust för färg/typ-satsningar
                    win = false;
                }
                else if (selectedBetType == "Red" && resultColor == "Red")
                {
                    if (resultNumber == selectedNumber)
                        payout = betAmount * 4; // Både färg och nummer rätt
                    else
                        payout = betAmount * 2; // Endast färg rätt
                    win = true;
                }
                else if (selectedBetType == "Black" && resultColor == "Black")
                {
                    if (resultNumber == selectedNumber)
                        payout = betAmount * 4;
                    else
                        payout = betAmount * 2;
                    win = true;
                }
                else if (selectedBetType == "Even" && isEven)
                {
                    if (resultNumber == selectedNumber)
                        payout = betAmount * 4;
                    else
                        payout = betAmount * 2;
                    win = true;
                }
                else if (selectedBetType == "Odd" && !isEven)
                {
                    if (resultNumber == selectedNumber)
                        payout = betAmount * 4;
                    else
                        payout = betAmount * 2;
                    win = true;
                }
                // Annars förlust
            }
            // FALL 3: Satsa enbart på färg/typ (inget nummer)
            else if (!string.IsNullOrEmpty(selectedBetType) && !hasNumber)
            {
                if (resultNumber == 0)
                {
                    // 0 = alltid förlust för färg/typ-satsningar
                    win = false;
                }
                else if (selectedBetType == "Red" && resultColor == "Red")
                {
                    win = true;
                    payout = betAmount * 2;
                }
                else if (selectedBetType == "Black" && resultColor == "Black")
                {
                    win = true;
                    payout = betAmount * 2;
                }
                else if (selectedBetType == "Even" && isEven)
                {
                    win = true;
                    payout = betAmount * 2;
                }
                else if (selectedBetType == "Odd" && !isEven)
                {
                    win = true;
                    payout = betAmount * 2;
                }
                // Annars förlust
            }
            // FALL 4: Ingen satsning gjord
            else
            {
                resultat.Text = " Välj antingen en färg/typ ELLER ett nummer att satsa på!";
                return;
            }

            // 6. Visa resultat och uppdatera saldo
            if (win)
            {
                playerBalance += payout - betAmount;
                resultat.Text = $" VINST! +${payout} | Resultat: {resultNumber} ({resultColor})";
            }
            else
            {
                playerBalance -= betAmount;
                resultat.Text = $" FÖRLUST -${betAmount} | Resultat: {resultNumber} ({resultColor})" +
                               (resultNumber == 0 ? " - 0 är GRÖNT!" : "");
            }

            UpdateBalanceDisplay();
            selectedBetType = null;
            UpdateButtonColors();

            // 7. Game over?
            if (playerBalance <= 0)
            {
                resultat.Text = " GAME OVER! Tryck på Reset för att börja om.";
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            playerBalance = 100;
            selectedBetType = null;
            betamount.Text = "";
            nrbtn.Text = "";
            resultat.Text = " Spelet återställt - du har $100 att spela med!";
            UpdateBalanceDisplay();
            UpdateButtonColors();
        }

        private string GetColor(int number)
        {
            if (number == 0) return "Green";
            return redNumbers.Contains(number) ? "Red" : "Black";
        }
    }
}