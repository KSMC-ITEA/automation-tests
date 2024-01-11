using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Compensation.Tests
{
    [Binding]
    public class StepsDefinition
    {
        [Given(@"Hello")]
        public void GivenHello()
        {
            throw new PendingStepException();
        }

        [When(@"I want to \.\.\.")]
        public void WhenIWantTo_()
        {
            throw new PendingStepException();
        }

    }
}
