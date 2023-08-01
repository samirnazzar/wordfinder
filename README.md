# WordFinder Solution Overview
- This solution was implemented using .NET 6 and C#.
- The software development process used was TDD.

# Architecture
- **WordFinder.Business**: Contains the business logic for the application and core abstractions.
- **WordFinder.Console**: Contains the code for the console application and has a source code dependency on WordFinder.Business.
- **WordFinder.Business.Tests**: Contains the code with unit tests for WordFinder.Business.

# Steps to Execute
1. Clone the repo on your local or download the zip containing the source code
2. Create WordFinderMatrix.txt and WordFinderWordStream.txt files inside the folder WordFinder.Console
3. Open a command prompt in the folder WordFinder.Console and run the "dotnet run" command

**Note**: In order to run the applitacion you need to install the .NET 6 SDK
