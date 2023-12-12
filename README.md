# Live Nation Interview
This project is part of LiveNation interview process. The goal is to develop a .NET Web API that accepts a number range, applies a set of rules to each number in the range.

## Requirements
* Develop a .NET Web API that accepts a number range, applies a set of rules to each number in the range
* Returns the result as json
* Rules must be configurable and new rules easy to add
* Produce a summary showing how many times the following were output
  * Live
  * Nation
  * LiveNation
  * A number

## Rules
* If no rule matches, then output the input number
* If the input number is a multiple of 3 then output “Live”
* If the input number is a multiple of 5 then output “Nation”
* If the input number is a multiple of 3 and 5 then output “LiveNation”

## Solution Expectation
* TDD
* SOLID
* Clean code
* Clean maintainable code
* Caching, multiple requests to the same endpoint produce a cached response

## Sample Test

#### Input
> * the-domain/api/LiveNation?From=1&To=20

#### Expected Json Result
```
{
    "result": "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation",
    "summary":
    {
      "Live": "4",
      "Nation": "2",
      "LiveNation": "1",
      "Integer": "8"
    }
}
```

### How to run this program
* Clone and open it in Visual Studio or VS Code (ensure you have C# extension and .NET SDK)
  * https://code.visualstudio.com/docs/csharp/get-started
  * https://visualstudio.microsoft.com/vs/
* Build all project files
* Run the API 

### How to run the tests
* The tests should automatically appear in the project test runner window. 
* Run each individual test or all.
* All tests have been confirmed as passing.