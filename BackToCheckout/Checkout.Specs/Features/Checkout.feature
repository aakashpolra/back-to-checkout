Feature: Checkout With Single Special Price

Background: 
	Given The following pricing rules:
	| Item | Unit Price | Special Price |
	| A    | 50         | 3 for 130     |
	| B    | 30         | 2 for 45      |
	| C    | 20         |               |
	| D    | 15         |               |
	
Scenario: No items in cart
	Then The total price should be: 0

Scenario: Mixed items in cart - None qualifying for a special price
	When The following items are scanned out: <Items>
	Then The total price should be: <Total Price>
Examples:
	| Items | Total Price |
	|       | 0           |
	| A     | 50          |
	| AB    | 80          |
	| CDBA  | 115         |

Scenario: Single item with varying quantities
	When The following items are scanned out: <Items>
	Then The total price should be: <Total Price>
Examples:
	| Items  | Total Price |
	| A      | 50          |
	| AA     | 100         |
	| AAA    | 130         |
	| AAAA   | 180         |
	| AAAAA  | 230         |
	| AAAAAA | 260         |

Scenario: Multiple items with varying quantities
	When The following items are scanned out: <Items>
	Then The total price should be: <Total Price>
Examples:
	| Items  | Total Price |
	| AAAB   | 160         |
	| AAABB  | 175         |
	| AAABBD | 190         |
	| DABABA | 190         |
