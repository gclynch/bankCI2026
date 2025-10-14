using Bank;
using System;
using Reqnroll;

namespace BankAcceptanceTest.StepDefinitions
{
    [Binding]
    public class WithdrawFeatureStepDefinitions
    {
        private CurrentAccount? account;

        [Given("the balance on my account is {double}")]
        public void GivenTheBalanceOnMyAccountIs(double balance)
        {
            account = new CurrentAccount(balance);
        }

        [When("I withdraw {double}")]
        public void WhenIWithdraw(double amount)
        {
            account.Withdraw(amount);
        }

        [Then("the balance on the account should be {double}")]
        public void ThenTheBalanceOnTheAccountShouldBe(double newBalance)
        {
            Assert.AreEqual(account.Balance, newBalance);
        }

        [Given("there is an overdraft limit of {double} on the account")]
        public void GivenThereIsAnOverdraftLimitOfOnTheAccount(double overdraftlimit)
        {
            account.OverdraftLimit = overdraftlimit;
            // = 0 would cause test to fail
        }
    }
}
