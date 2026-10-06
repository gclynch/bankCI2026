using System;
using Reqnroll;
using Bank; 

namespace BankAcceptanceTest.StepDefinitions
{
    [Binding]
    public class WithdrawFeatureStepDefinitions
    {
        CurrentAccount account;

        [Given("the balance on my account is {double}")]
        public void GivenTheBalanceOnMyAccountIsBalance(double balance)
        {
            account = new CurrentAccount(balance);
        }

        [Given("there is an overdraft limit of {double} on the account")]
        public void GivenThereIsAnOverdraftLimitOfOverdraft_LimitOnTheAccount(double overdraftLimit)
        {
            account.OverdraftLimit = overdraftLimit;
        }

        [When("I withdraw {double}")]
        public void WhenIWithdrawAmount(double amount)
        {
            account.Withdraw(amount);
        }

        [Then("the balance on the account should be {double}")]
        public void ThenTheBalanceOnTheAccountShouldBeNew_Balance(double newBalance)
        {
            Assert.AreEqual(account.Balance, newBalance);
        } 

    }
}
