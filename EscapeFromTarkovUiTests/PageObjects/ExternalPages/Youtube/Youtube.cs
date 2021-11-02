using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace EscapeFromTarkovUiTests.PageObjects.ExternalPages
{
    public class Youtube : ExternalPages
    {
        public Youtube(IWebDriver driver) : base(driver)
        {
            _driver.SwitchTo().DefaultContent();
            _driver.SwitchTo().Frame(_driver.FindElement(By.XPath("//iframe[@id='VideoPlayer_39']")));
        }

        private BaseElement playButton => new BaseElement(By.XPath("//button[@title='Play (k)']"), "Play Button", _driver);

        private BaseElement playingVideo => new BaseElement(By.XPath("//*[@class='html5-video-player ytp-exp-bottom-control-flexbox ytp-title-enable-channel-logo ytp-embed ytp-embed-playlist ytp-large-width-mode playing-mode']"), "Play Button", _driver);

        //*[@class='html5-video-player ytp-exp-bottom-control-flexbox ytp-title-enable-channel-logo ytp-embed ytp-embed-playlist ytp-heat-map playing-mode']

        
        public void ClickPlayButton()
        {
            playButton.Click();
        }
        public bool IsVideoPlaying()
        {
           return playingVideo.IsPresent(30000);
            //Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='html5-video-player ytp-transparent ytp-exp-bottom-control-flexbox ytp-exp-bigger-button-like-mobile ytp-exp-ppp-update ytp-hide-info-bar ytp-large-width-mode ytp-autonav-endscreen-cancelled-state playing-mode ytp-autohide']")));
          //  return IsElementDisplayed(By.XPath("//*[@class='html5-video-player ytp-exp-bottom-control-flexbox ytp-title-enable-channel-logo ytp-embed ytp-embed-playlist ytp-large-width-mode playing-mode ytp-autohide']"), "Youtube playing mode");
        }

    }
}
