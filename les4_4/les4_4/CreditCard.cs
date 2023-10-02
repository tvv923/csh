using System;

namespace les4_4
{
    public class CreditCard
    {
        public bool errorExists;
        public string errorText = "";
        public string CardNumber { get; set; }
        public string CvcCode { get; set; }
        private double balance;
        private double addBalance;
        public double Balance        
        {
            get => balance;
            set => balance = value >= 0 ? value : 0;
        }
        public double AddBalance
        {
            get => addBalance;
            set => addBalance = value <= 0 ? 0 : value;
        }
        public void SetBalance()
        {
            CheckInput(1);
        }
        public void AddMoney()
        {
            CheckInput(2);
        }
        public void CheckInput(int inputType)
        {
            string? a1;
            Console.WriteLine("Введіть ціле число: ");
            a1 = Console.ReadLine();
            errorExists = false;
            try
            {
                if (inputType == 1) Balance = Convert.ToDouble(a1);
                else addBalance = Convert.ToDouble(a1);
            }
            catch (Exception)
            {
                errorExists = true;
                errorText = "Помилка у числі.";
            }
            if (errorExists)
                Console.WriteLine(errorText);
        }
        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
        public CreditCard(string cardNumber, string cvcCode, double balance)
        {
            CardNumber = cardNumber;
            CvcCode = cvcCode;
            Balance = balance;
        }        
        public static CreditCard operator +(CreditCard card, double amount)
        {
            card.Balance += amount;
            return card;
        }        
        public static CreditCard operator -(CreditCard card, double amount)
        {
            card.Balance -= amount;
            return card;
        }        
        public static bool operator ==(CreditCard card1, CreditCard card2)
        {
            if (ReferenceEquals(card1, card2))
                return true;
            if (card1 is null || card2 is null)
                return false;
            return card1.CvcCode == card2.CvcCode;
        }        
        public static bool operator !=(CreditCard card1, CreditCard card2)
        {
            return !(card1 == card2);
        }        
        public static bool operator <(CreditCard card1, CreditCard card2)
        {
            return card1.Balance < card2.Balance;
        }       
        public static bool operator >(CreditCard card1, CreditCard card2)
        {
            return card1.Balance > card2.Balance;
        }        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return this == (CreditCard)obj;
        }        
        public override int GetHashCode()
        {
            return CvcCode.GetHashCode();
        }
        public override string ToString()
        {
            return $"Номер картки: {CardNumber}, CVC код: {CvcCode}, Баланс: {Balance}";
        }
    }
}
