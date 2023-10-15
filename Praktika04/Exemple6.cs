using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika04
{
    internal class Exemple6
    {
        class Client
        {
            public string Name { get; set; }
            // Другие свойства для клиента.

            public BankAccount BankAccount { get; set; }
            public CreditCard CreditCard { get; set; }

            public void MakePayment(decimal amount)
            {
                // Оплата счета.
            }

            public void TransferMoney(BankAccount targetAccount, decimal amount)
            {
                // Перевод денег на другой счет.
            }

            public void BlockCreditCard()
            {
                // Блокировка кредитной карты.
            }
            public void CancelPayment(decimal amount)
            {
                // Аннулирование счета.
            }
        }

        class BankAccount
        {
            public string AccountNumber { get; set; }
            public decimal Balance { get; set; }
            // Другие свойства и методы для банковского счета.
        }

        class CreditCard
        {
            public string CardNumber { get; set; }
            public decimal CreditLimit { get; set; }
            public bool IsBlocked { get; set; }
            // Другие свойства и методы для кредитной карты.
        }

        class Administrator
        {
            public void BlockCreditCard(CreditCard creditCard)
            {
                creditCard.IsBlocked = true;
            }
            // Другие методы администратора.
        }

        class Program
        {
            static void Main()
            {
                // Создаем клиента, банковский счет и кредитную карту
                Client client1 = new Client { Name = "Клиент 1" };
                BankAccount bankAccount1 = new BankAccount { AccountNumber = "123456", Balance = 1000.00M };
                CreditCard creditCard1 = new CreditCard { CardNumber = "1111-2222-3333-4444", CreditLimit = 5000.00M, IsBlocked = false };

                client1.BankAccount = bankAccount1;
                client1.CreditCard = creditCard1;

                // Клиент проводит платеж и переводит деньги на другой счет
                client1.MakePayment(200.00M);
                client1.TransferMoney(bankAccount1, 300.00M);

                // Создаем администратора
                Administrator administrator = new Administrator();

                // Администратор блокирует кредитную карту
                administrator.BlockCreditCard(creditCard1);

                // Клиент аннулирует счет
                client1.CancelPayment(50.00M);

                // Выводим информацию о клиенте, банковском счете и кредитной карте
                Console.WriteLine($"Имя клиента: {client1.Name}");
                Console.WriteLine($"Баланс банковского счета: {bankAccount1.Balance}");
                Console.WriteLine($"Лимит кредитной карты: {creditCard1.CreditLimit}");
                Console.WriteLine($"Кредитная карта заблокирована: {creditCard1.IsBlocked}");

            }
        }
    }
}
