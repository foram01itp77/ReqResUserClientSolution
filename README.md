# ReqResUserClientSolution
Req Res User Test Assignment 
# Project Title
Req Res User Test Assignment
Installation
To run this project locally, follow these steps:
Prerequisites
Ensure you have the following installed:
.NET SDK 6.0 or higher
Visual Studio 2022 or VS Code
Steps
1.	1. Clone the repository:
      git clone https://github.com/foram01itp77/ReqResUserClientSolution
       (this is public repository)
2. Navigate to the project directory:
3. Restore dependencies:
4. Build the solution:

Usage

This class library can be used to retrieve users from the ReqRes API.

Example:

var users = await _reqResApiClient.GetUsersByPageAsync(1);
var user = await _reqResApiClient.GetUserByIdAsync(2);

Run via a Console App or unit tests.

Deploy

This is a class library and not directly deployable. To integrate:
- Add the project to your solution.
- Register dependencies in Program.cs or Startup.cs.
- Configure base URL in appsettings.json:

"ReqRes": {
  "BaseUrl": "https://reqres.in/api"
}

Technologies

•	.NET Core - Backend Framework
•	ReqRes API - Public API for testing
•	Polly - Retry logic for transient HTTP errors








