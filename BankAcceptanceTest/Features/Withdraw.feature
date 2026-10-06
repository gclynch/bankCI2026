# Gherkin DSL

Feature: Withdraw Feature
	Withdraw money from a bank account

# scenario 1
Scenario: Withdraw money when there is no overdraft facility
	Given the balance on my account is <balance>
	When I withdraw <amount>
	Then the balance on the account should be <new_balance>

Examples:
	| balance | amount | new_balance |
	|     200 |    100 |         100 |
	|     400 |    300 |        100 |

# scenario 2
Scenario: Withdraw money when there is there is an overdraft facility
	Given the balance on my account is <balance>
	And there is an overdraft limit of <overdraft_limit> on the account
	When I withdraw <amount>
	Then the balance on the account should be <new_balance>

Examples:
	| balance | overdraft_limit | amount | new_balance |
	|     200 |             500 |    300 |        -100 |
	|     400 |             500 |    300 |         100 |


# text needs to match exactly step defintion 
# text in italics are parameters