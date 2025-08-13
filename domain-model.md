|    Classes   |                Methods/Properties                |                   Scenario                  |   Outputs  |
|:------------:|:------------------------------------------------:|:-------------------------------------------:|:----------:|
| Customer     | CreateAccount()                                  | Get a new account                           | Account ID |
| Customer     | CreateAccount(savings)                           | Get a new savings account                   | Account ID |
| Customer     | GetStatement(Account ID)                         | Get a statement of all transactions         | string     |
| Customer     | DepositFunds(Account ID, int)                    | Add money to account                        | Success    |
| Customer     | WithdrawFunds(Account ID, int)                   | Remove money from account                   | Success    |
| Customer     | RequestOverdraft(account ID)                     | Request an overdraft to a certain account   |            |
| Bank Manager | CreateAccount(branch) / ChangeBranch(new branch) | Assign a branch                             | Success    |
| Bank Manager | AssessOverdraft(Account ID)                      | Assess an overdraft request                 |            |
| Engineer     |                                                  | Dont  make a variable that contains balance |            |