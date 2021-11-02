using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using EscapeFromTarkovUiTests.Common.Logging;
using EscapeFromTarkovUiTests.Common;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Threading;

namespace EscapeFromTarkovUiTests.PageObjects
{
   public class BaseElement
	{
		private readonly By _locator;
		private readonly string _name;

		private readonly IWebElement _element;
		
		protected readonly int DefaultTimeout = GlobalRunSettings.TimeoutSeconds;

		private static readonly Logger Logger = Logger.Instance;

		private readonly IWebDriver _driver;

		private IWebElement Element => _element ?? _driver.FindElements(_locator).FirstOrDefault();


		public BaseElement(By locator, string name, IWebDriver driver )
		{
			_name = name;
			_locator = locator;
			_driver = driver;
		}



		/// <summary>
		/// Determines whether element is clickable.
		/// </summary>
		/// <returns>System.Boolean.</returns>
		public bool IsClickable() => GetElement().Enabled;

		/// <summary>
		/// Waits for element exists in DOM.
		/// </summary>
		public void WaitForElementIsPresent() => WaitForElementExistence();

		/// <summary>
		/// Waits for element exists in DOM.
		/// </summary>
		/// <param name="timeout">Timeout of wait.</param>
		public void WaitForElementIsPresent(int timeout) => WaitForElementExistence(timeout);

		/// <summary>
		/// Waits for element exists in DOM.
		/// </summary>
		/// <param name="timeout">Timeout of wait.</param>
		/// <param name="count">Count of elements to wait.</param>
		/// <param name="pollingInterval">Polling interval.</param>
		public void WaitForElementIsPresent(int timeout, int count, int? pollingInterval = null)
			=> WaitForElementExistence(timeout, pollingInterval, count);

		/// <summary>
		/// Waits for element disappear from DOM.
		/// </summary>
		public void WaitForElementDisappear()
			=> WaitForElementExistence(isPresent: false);

		/// <summary>
		/// Waits for element disappear from DOM.
		/// </summary>
		/// <param name="timeout">Timeout of wait.</param>
		/// /// <param name="pollingInterval">Polling interval.</param>
		public void WaitForElementDisappear(int timeout, int? pollingInterval = null)
			=> WaitForElementExistence(isPresent: false, timeout: timeout, pollingInterval: pollingInterval);

		/// <summary>
		///     Waits for element is visible.
		/// </summary>
		/// <param name="timeout">Milliseconds until timeout.</param>
		public void WaitForElementIsVisible(int? timeout = null) => _driver.GetWait(TimeSpan.FromMilliseconds(timeout ?? DefaultTimeout))
			.Until(waiting => IsPresent() && Element.Displayed);

		/// <summary>
		/// Waits for element is invisible.
		/// </summary>
		/// <param name="timeout">Milliseconds until timeout.</param>
		public void WaitForElementIsInvisible(int? timeout = null) => _driver.GetWait(TimeSpan.FromMilliseconds(timeout ?? DefaultTimeout))
			.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(_locator));

		/// <summary>
		/// Waits for element is clickable.
		/// </summary>
		public void WaitForElementIsClickable(int? timeout = null) => _driver.GetWait(TimeSpan.FromMilliseconds(timeout ?? DefaultTimeout)).Until(waiting => IsPresent() && Element.Enabled);

		/// <summary>
		/// Gets element`s InnerText.
		/// </summary>
		/// <param name="acceptEmptyText">Will wait for not empty InnerText.</param>
		/// <returns>System.String.</returns>
		public string GetText(bool acceptEmptyText = true)
		{
			if (!acceptEmptyText)
			{
				WaitForTextIsNotEmpty();
			}

			return GetElement().Text.Trim();
		}

		/// <summary>
		/// Finds element on the current page or returns _element value.
		/// </summary>
		/// <returns>Element on the current page/_element/null.</returns>
		public IWebElement GetElement()
		{
			WaitForElementIsPresent();

			return Element;
		}

		/// <summary>
		/// Waits for enabled/displayed, hovers over element to avoid tooltip overlaying and clicks.
		/// </summary>
		public void Click()
		{
			_driver.GetWait(TimeSpan.FromMilliseconds(DefaultTimeout)).Until(waiting =>
			{
				try
				{
					WaitForElementAvailable();
					Element.Click();
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			});
		}

		/// <summary>
		/// Waits for enabled/displayed and hovers over element.
		/// </summary>
		public void HoverOver()
		{
			WaitForElementAvailable();
			Hover();
		}

		/// <summary>
		/// Waits for present in DOM and hovers over element.
		/// </summary>
		public void HoverOverInvisibleElement()
		{
			WaitForElementIsPresent();
			Hover();
		}

		/// <summary>
		/// Gets the attribute value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>System.String.</returns>
		public string GetAttributeValue(string value)
		{
			var result = GetElement()
				.GetAttribute(value);

			return result?.Trim() ?? string.Empty;
		}

		/// <summary>
		/// Determines whether element is displayed.
		/// </summary>
		/// <returns>System.Boolean.</returns>
		public bool IsDisplayed(int timeout = 0)
		{
			if (timeout == 0)
			{
				return IsPresent() && Element.Displayed;
			}

			try
			{
				WaitForElementIsVisible(timeout);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Check if element.
		/// </summary>
		/// <param name="timeout">Milliseconds until timeout.</param>
		/// <returns></returns>
		public bool IsPresent(int? timeout = null)
		{
			if (timeout == null)
			{
				return Element != null;
			}

			try
			{
				_driver.GetWait(TimeSpan.FromMilliseconds(timeout ?? DefaultTimeout))
					.Until(drv => drv.FindElements(_locator).Count > 0);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		/// <summary>
		/// Waits for element animation is completed and it`s location is static.
		/// </summary>
		public void WaitForAnimationIsCompleted()
		{
			_driver.GetWait(TimeSpan.FromMilliseconds(DefaultTimeout))
				.Until(waiting =>
				{
					var previousPosition = GetElement()?.Location;
					Thread.Sleep(100);
					var currentPosition = GetElement()?.Location;

					return currentPosition != null && previousPosition.Equals(currentPosition);
				});
		}

		protected string GetName() => _name;

		protected By GetLocator() => _locator;

		protected void WaitForTextIsNotEmpty() => _driver.GetWait(TimeSpan.FromMilliseconds(DefaultTimeout)).Until(brw => GetElement().Text != string.Empty);

		protected void WaitForElementAvailable()
		{
			WaitForElementIsPresent();
			WaitForElementIsVisible();
			WaitForElementIsClickable();
		}

		private void WaitForElementExistence(int? timeout = null, int? pollingInterval = null, int? count = null, bool isPresent = true)
		{
			timeout = timeout ?? DefaultTimeout;

			if (_locator == null)
			{
				return;
			}

			_driver.GetWait(TimeSpan.FromMilliseconds(DefaultTimeout)).Until(drv =>
			{
				var webElements = drv.FindElements(_locator);

				if (!isPresent)
				{
					return webElements.Count == 0;
				}

				if (count != null)
				{
					return webElements.Count == count;
				}

				return webElements.Count != 0;
			});
		}

		private void Hover()
		{
			new Actions(_driver)
				.MoveToElement(GetElement())
				.Build()
				.Perform();
			Logger.Info($"Mouse pointer hover over '{GetName()}'");
		}
	}
}
