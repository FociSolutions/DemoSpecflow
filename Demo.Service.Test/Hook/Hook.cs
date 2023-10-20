using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Demo.Service.Test.Hook
{
    [Binding]
    public class Hook
    {

        readonly ScenarioContext _scenarioContext;
        readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public Hook(ScenarioContext scenarioContext, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _scenarioContext = scenarioContext;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _specFlowOutputHelper.WriteLine("Before Scenario " + _scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _specFlowOutputHelper.WriteLine("After Scenario " + _scenarioContext.ScenarioInfo.Title);
        }

    }
}
