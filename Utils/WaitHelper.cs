using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using System;
using System.Threading;

namespace EeshaNoor.FlaUI.Utils
{
    public static class WaitHelper
    {
        public static AutomationElement? WaitForElement(
            AutomationElement parent,
            Func<ConditionFactory, ConditionBase> conditionFunc,
            int timeoutSeconds = 10)
        {
            var automation = parent.FrameworkAutomationElement.Automation;
            var cf = new ConditionFactory(automation.PropertyLibrary);
            var deadline = DateTime.Now.AddSeconds(timeoutSeconds);

            while (DateTime.Now < deadline)
            {
                var element = parent.FindFirstDescendant(conditionFunc(cf));
                if (element != null) return element;
                Thread.Sleep(500);
            }
            return null;
        }

        public static void WaitForMilliseconds(int ms) => Thread.Sleep(ms);
    }
}