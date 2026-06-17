using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using NUnit.Framework;

namespace EeshaNoor.FlaUI.Base
{
    public abstract class BaseTest
    {
        protected Application? App;
        protected UIA3Automation? Automation;
        protected AutomationElement? Desktop;

        protected abstract string AppPath { get; }

        [SetUp]
        public virtual void SetUp()
        {
            Automation = new UIA3Automation();
            App = Application.Launch(AppPath);
            App.WaitWhileMainHandleIsMissing(TimeSpan.FromSeconds(10));
            Desktop = Automation.GetDesktop();
        }

        [TearDown]
        public virtual void TearDown()
        {
            App?.Close();
            Automation?.Dispose();
        }
    }
}