Feature: Checkout With Single Special Price

Scenario: Sample Scenario given in the problem
	Given The following pricing rules:
	| Item | Unit Price | Special Price |
	| A    | 50         | 3 for 130     |
	| B    | 30         | 2 for 45      |
	| C    | 20         |               |
	| D    | 15         |               |
	When The following items are scanned out: <Items>
	Then The total price should be: <Total Price>
Examples:
	| Items | Total Price |
	| A     | 50          |
	| AA    | 100         |
	| AAA   | 130         |
	| AAAA  | 180         |
	| B     | 30          |
	| BB    | 45          |
	| BBB   | 85          |
	| AB    | 80          |
	| AAABB | 175         |
	| ABCD  | 115         |
