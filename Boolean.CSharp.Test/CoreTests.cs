using Boolean.CSharp.Main;
using NUnit.Framework;
using System.ComponentModel;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        [Test]
        public void TestCreateCheckingsAccount()
        {
            CheckingAccount account = new CheckingAccount(Branches.Oslo);

            Assert.IsNotNull(account);
            Assert.That(account.GetAccountId(), Is.TypeOf<Guid>());
            Assert.That(account.GetOverdraft(), Is.Null);
        }

        [Test]
        public void TestCreateSavingsAccount()
        {
            SavingsAccount account = new SavingsAccount(Branches.Tokyo);

            Assert.IsNotNull(account);
            Assert.That(account.GetAccountId(), Is.TypeOf<Guid>());
        }


        [Test]
        public void TestDepositFunds() {
            CheckingAccount account = new CheckingAccount(Branches.Jakarta);

            account.Deposit(50.3m);
            List<Transaction> transactions = account.GetTransactions();
            Assert.That(transactions.Count, Is.EqualTo(1));
        }

        public void TestWithdrawFunds()
        {
            CheckingAccount account = new CheckingAccount(Branches.Oslo);

            account.Deposit(50.3m);
            
            bool success = account.Withdraw(25m);
            List<Transaction> transactions = account.GetTransactions();
            Assert.That(transactions.Count, Is.EqualTo(2));
            Assert.IsTrue(success);
        }

        public void TestWithdrawFundsFail()
        {
            CheckingAccount account = new CheckingAccount(Branches.New_York);

            account.Deposit(50.3m);

            bool success = account.Withdraw(55m);
            Assert.IsFalse(success);
        }


        [Test]
        public void GetBankStatement()
        {
            CheckingAccount account = new CheckingAccount(Branches.Oslo);
            account.Deposit(500);
            account.Deposit(500);
            account.Withdraw(250);
            string statement = account.GetStatements();
            string[] statements = statement.Split('\n');
            Assert.That(statements.Count(), Is.EqualTo(5)); // first index is the columns
            Assert.IsTrue(statements[1].Contains("500"));
            Assert.IsTrue(statements[2].Contains("500"));
            Assert.IsTrue(statements[2].Contains("1000"));
            Assert.IsTrue(statements[3].Contains("250"));
            Assert.IsTrue(statements[3].Contains("750"));
        }

        [Test]
        public void RequestOverdraft()
        {
            CheckingAccount account = new CheckingAccount(Branches.Oslo);
            OverdraftRequest request = account.RequestOverdraft(200);

            Assert.IsNull(request.GetStatus());
        }

        [Test]
        public void ApproveOverdraft()
        {
            CheckingAccount account = new CheckingAccount(Branches.Oslo);
            OverdraftRequest request = account.RequestOverdraft(200);

            request.Approve();

            Assert.IsTrue(account.GetOverdraft().GetStatus());
            Assert.That(account.GetOverdraft().Allowance, Is.EqualTo(200));
        }

        [Test]
        public void RejectOverdraft()
        {
            CheckingAccount account = new CheckingAccount(Branches.Oslo);
            OverdraftRequest request = account.RequestOverdraft(200);

            request.Reject();
            Assert.IsFalse(account.GetOverdraft().GetStatus());
        }

        [Test]
        public void StatementToPhone()
        {
            CheckingAccount account = new CheckingAccount(Branches.Oslo);
            account.Deposit(500);
            account.Deposit(500);
            account.Withdraw(250);
            string statement = account.GetStatements();
            string[] statements = statement.Split('\n');
        }
    }
}