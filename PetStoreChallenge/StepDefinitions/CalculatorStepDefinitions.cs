//using PetStoreChallenge.Extensions;

//namespace PetStoreChallenge.StepDefinitions
//{
//    [Binding]
//    public class CalculatorStepDefinitions
//    {
//        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

//        private readonly ScenarioContext _scenarioContext;
//        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
//        {
//            _scenarioContext = scenarioContext;
//        }


//        [Given("the first number is (.*)")]
//        public void GivenTheFirstNumberIs(int number)
//        {
//            _scenarioContext.SetFirstNumber(number);
//        }

//        [Given("the second number is (.*)")]
//        public void GivenTheSecondNumberIs(int number)
//        {
//            _scenarioContext.SetSecondNumber(number);
//        }

//        [When("the two numbers are added")]
//        public void WhenTheTwoNumbersAreAdded()
//        {
//            _scenarioContext.SetSum(_scenarioContext.GetFirstNumber() + _scenarioContext.GetSecondNumber());
//        }

//        [Then("the result should be (.*)")]
//        public void ThenTheResultShouldBe(int result)
//        {
//            var sum = _scenarioContext.GetSum();
//            sum.Should().Be(result);
//        }
//    }
//}
