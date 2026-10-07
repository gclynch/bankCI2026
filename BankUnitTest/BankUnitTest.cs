// MSTest unit tests

using Bank;

namespace BankUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]                                            // a unit test
        public void TestDeposit1()
        {
            // 0 balance
            CurrentAccount acc = new CurrentAccount();
            acc.Deposit(100);
            acc.Deposit(200);
            Assert.AreEqual(300, acc.Balance);
        }

        [TestMethod]
        public void CreateAccountWithInvalidOverdraftLimit()
        {
            Assert.ThrowsException<ArgumentException>(() => new CurrentAccount(-5000));
        }

        [DataTestMethod]
        [DataRow(1000, 100, 50, 50)]
        [DataRow(0, 100, 50, 50)]
        [DataRow(1000, 100, 1000, -900)]
        [TestMethod]
        public void TestDepositAndWithdrawal1(double overdraftLimit, double deposit, double withdrawal, double balance)
        {
            CurrentAccount acc = new CurrentAccount();
            acc.OverdraftLimit = overdraftLimit;
            acc.Deposit(deposit);
            acc.Withdraw(withdrawal);
            Assert.AreEqual(balance, acc.Balance);
        }

        [TestMethod]
        public void TestDepositAndWithdrawal3()
        {
            CurrentAccount acc = new CurrentAccount();
            Assert.ThrowsException<ArgumentException>(() => acc.Deposit(-100));     // must be positive
        }

        [TestMethod]
        public void TestDepositAndWithdrawal4()
        {
            CurrentAccount acc = new CurrentAccount();
            acc.Deposit(100);
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(0));     // must be positive
        }
    }
}
