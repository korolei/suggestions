using TechTalk.SpecFlow;

namespace SuggestionBox.Tests
{
    [Binding]
    public class ESBRegularUserScenariosSteps
    {
        [Given(@"I can see '(.*)' button on the ESB page")]
        public void GivenICanSeeButtonOnTheESBPage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I entered minimum (.*) and maximum (.*) characters in the text box")]
        public void GivenIEnteredMinimumAndMaximumCharactersInTheTextBox(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I can see text box and two buttons '(.*)' and '(.*)'")]
        public void GivenICanSeeTextBoxAndTwoButtonsAnd(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click '(.*)' button")]
        public void WhenIClickButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I can see all posted and answered suggestions")]
        public void ThenICanSeeAllPostedAndAnsweredSuggestions()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"text box with two buttons '(.*)' and '(.*)' will be shown")]
        public void ThenTextBoxWithTwoButtonsAndWillBeShown(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"'(.*)' button get enabled")]
        public void ThenButtonGetEnabled(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I can submit my suggestion")]
        public void ThenICanSubmitMySuggestion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"confirmation message will be shown")]
        public void ThenConfirmationMessageWillBeShown()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"my suggestion will not be visible")]
        public void ThenMySuggestionWillNotBeVisible()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"text box and two buttons will disappear")]
        public void ThenTextBoxAndTwoButtonsWillDisappear()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Admin Group will receive email notification")]
        public void ThenAdminGroupWillReceiveEmailNotification()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
