# Rental example

## Description
This is a simple rental company who have differents options rent. For example:

1 hour rent --> $5
1 day rent --> $20
1 week rent --> $5

Also have one promotion

Family Rental --> 3 to 5 rental (of any type) have a 30% discount of the total price.

## Assumptions
- This solutions assumes that the customer comes to the copmany rent and has the only three options and promo. 
So the customer purchase an option and the program calculate the start and the finish rent, the quantity bicycle, the options type, the cost per customer and the total.
- The program only gives the contract, no the paymnet ticket.
- For the Family promo, the logic only check if the request comes with, at least, 3 bicycle request the apply it. If come
- The logic assumes that other class gives the requests
- The logic assumes that if a customer returns the bike before his contract says no money is reimbursed
- This logic assumes that there is no need to contemplate surcharges if a customer returns the bicycle after what his contract says

## Design
- The solution have a solution with differentes projects.
- The "Models" project contains the main classes for share information between them.
- The "ViewModels" project contains only the response classes for the client who will use this.
- The "Domain" project contains all the bussiness logic.
- The "Common" project contains classes that are cross project.
- The "Tests" project, only contains the unit test

## Development practices
I try to use the best practices that I know.
For the options rent, I think in a strategy pattern with the differents options and each one knows how to respond.

## Tests
To run the tests you will need to open the IntiveFDV.sln in the IntiveFDV folder (root folder) with a Visual Studio IDE 2017 or higher.
Once open, you need to build the solution (right click on the solution > Build). 
Then go to the toolbar and make click on Test > Windows > Test Explorer this will open the Test Explorer window.
Once open you have to make click on "Run All".
If all the tests are green, GREAT! if not, :(

For code coverage purpose, I used the Visual Studio Enterprise IDE. It have the option to see it on Test > Analyze Code Coverage > All Test (in the toolbar)