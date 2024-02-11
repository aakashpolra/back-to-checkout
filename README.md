# Back To The Checkout

C# Implementation of [kata09-back-to-the-checkout](http://codekata.com/kata/kata09-back-to-the-checkout/) along with SpecFlow tests for tests scenarios given in the kata.

## Run tests

You can execute SpecFlow tests by executing `dotnet test` command in the solution folder.
SpecFlow tests are located in `Checkout.Specs` project.

## Discussion

`SpecialPrice` represents only Quantity based special prices. This should be extended in the future so that a variety of special pricing strategies can be defined.

`ICheckoutScanner` provides a generic and extensible interface that allows for a number of sophesticated future implementation. I am pondering whether Scanning and calculating total are two responsibilities or one. Settling for a simple design for now.

`SimpleCheckoutScanner` implements a crude solution to the given problem while keeping things simple.

Please feel free to share your comments or thoughts by raising Issues.
