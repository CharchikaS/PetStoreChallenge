# PetStoreChallenge
**Acceptance criteria file:**
.\Inputs\Acceptance Criterias.feature

**Framework used:**
Selenium + Specflow + C# (RestSharp for API automation)

**Base URL for the API**
https://petstore.swagger.io/v2/

**BDD structure:**
1. Folder Features - contains Test cases in gherkin (Note: Commented out test cases have not been automated due to being similar to already test cases for the purpose of this assignment)
2. Folder Models - contains object models
3. Folder StepDefinitions - contains code implementation of the test cases
4. Folder Extensions - contains supporting classes for feature wise implementation
5. Folder Helpers - contains commoon classes across features

**How to execute:**
1. Clone the repository (git clone https://github.com/CharchikaS/PetStoreChallenge.git)
2. Open the .sln file in Visual studio IDE
3. Go to Build Menu and Build the solution
4. After successful Build
5. Go to Menu "Test" --> Test Explorer and click
6. Navigate to Test Explorer window
7. select the PetStoreChallenge.Features node and right click --> Run
