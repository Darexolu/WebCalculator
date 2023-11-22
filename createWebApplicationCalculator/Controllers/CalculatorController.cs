using createWebApplicationCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace createWebApplicationCalculator.Controllers
{
    public class CalculatorController: Controller
    {
        public IActionResult CalculatorView() { 
             return View(new CalculatorModel());
        }
      

        [HttpPost]
        public IActionResult Calculate(CalculatorModel model)
        {
            CalculatorModel result = new CalculatorModel
            {
                Expression = model.Expression,
                Result = "Invalid Expression"
            };

            string[] expressionParts = model.Expression.Split(new[] { "+", "-", "*", "/", "%"}, StringSplitOptions.RemoveEmptyEntries);
            if (expressionParts.Length == 1 &&
    double.TryParse(expressionParts[0], out double number1))
            {
                result.Result = (number1 / 100).ToString();
            }
           else if (expressionParts.Length == 2 &&
                float.TryParse(expressionParts[0], out float number1a) &&
               float.TryParse(expressionParts[1], out float number2))
            {
                char op = model.Expression.FirstOrDefault(c => c == '+' || c == '-' || c == '*' || c == '/'|| c == '%');

                switch (op)
                {
                    case '+':
                        result.Result = (number1a + number2).ToString();
                        break;
                    case '-':
                        result.Result = (number1a - number2).ToString();
                        break;
                    case '*':
                        result.Result = (number1a * number2).ToString();
                        break;
                    case '/':
                        if (number2 != 0)
                        {
                            result.Result = (number1a / number2).ToString();
                        }
                        else
                        {
                            result.Result = "Error: Division by zero";

                        }
                        break;
                    case '%':
                        result.Result = (number1a *(number2 / 100)).ToString();
                        break;
                    default:
                        result.Result = "Invalid operator";
                        break;
                }
            }
            else
            {
                result.Result = "Invalid expression";
            }
          
            return Json(result);
        }
    }
}
