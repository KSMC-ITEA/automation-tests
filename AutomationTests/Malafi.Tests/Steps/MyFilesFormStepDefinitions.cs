﻿using Malafi.Tests.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Malafi.Tests.Steps
{
    [Binding]
    public class MyFilesFormStepDefinitions
    {

        private ScenarioContext scenarioContext;
        private IWebDriver driver;
        private DocumentsGroup documentsGroupPage;
        private MyFiles MyFiles;
        private MyFilesData testData;



        public MyFilesFormStepDefinitions(ScenarioContext context)

        {
            scenarioContext = context;

            driver = scenarioContext["WebDriver"] as IWebDriver ?? throw new NullReferenceException("Web Driver");
        }



        [When(@"I click any file My files")]
        public void WhenIClickAnyFileMyFiles()
        {

            var malafiHome = scenarioContext["MalafiHome"] as MalafiHome;
            Assert.IsNotNull(malafiHome);
            MyFiles = malafiHome.ClickOnMyFiles();
            MyFiles.Wait.Until(ExpectedConditions.ElementToBeClickable(MyFiles.FileVLD));
            Thread.Sleep(1000);
            MyFiles.FileVLD.Click(); Thread.Sleep(1000);
        }

        [When(@"Click on view documents  My files")]
        public void WhenClickOnViewDocumentsMyFiles()
        {
            Thread.Sleep(1000);
            MyFiles.buttonVLD.Click();
            Thread.Sleep(1000);

        }


        [When(@"I upload File")]
        public void WhenIUploadFile(Table table)
        {
            MyFilesData data = table.CreateInstance<MyFilesData>();

            testData = data;

        }

        [Then(@"cilck on Save button")]
        public void ThenCilckOnSaveButton()
        {
            MyFiles.MyFilesUpload(testData);
        }

    }
}
