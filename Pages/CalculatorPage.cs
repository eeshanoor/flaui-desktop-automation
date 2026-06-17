using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using System.Linq;

namespace EeshaNoor.FlaUI.Pages
{
    public class CalculatorPage
    {
        private readonly Application _app;
        private readonly UIA3Automation _automation;

        public CalculatorPage(Application app, UIA3Automation automation)
        {
            _app = app;
            _automation = automation;
        }

        private AutomationElement MainWindow => _app.GetMainWindow(_automation);

        private AutomationElement GetButton(string name) =>
            MainWindow.FindFirstDescendant(cf => cf.ByName(name).And(cf.ByControlType(ControlType.Button)));

        private AutomationElement ResultDisplay =>
            MainWindow.FindFirstDescendant(cf => cf.ByAutomationId("CalculatorResults"));

        public void ClickButton(string name) => GetButton(name)?.Click();

        public string GetResult()
        {
            var text = ResultDisplay?.Name ?? string.Empty;
            // Strip "Display is " prefix from Windows Calculator
            return text.Replace("Display is ", "").Trim();
        }

        public void Clear() => ClickButton("Clear");

        public void Calculate(string expression)
        {
            foreach (char c in expression)
            {
                var label = c switch
                {
                    '+' => "Plus",
                    '-' => "Minus",
                    '*' => "Multiply by",
                    '/' => "Divide by",
                    '=' => "Equals",
                    _   => c.ToString()
                };
                ClickButton(label);
            }
        }
    }
}