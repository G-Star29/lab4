using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using lab4.Models;
namespace lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string second_number;
        private RomanNumberExtend result_of_calc;
        private RomanNumberExtend second_value;
        string operation_calc = " ";
        public MainWindowViewModel()
        {
            AddNum = ReactiveCommand.Create<string, string>(AddNumberToString);
            ExecuteOperationCommand = ReactiveCommand.Create<string>(ExecuteOperation);
        }
        public string ShowValue
        {
            set
            {
                this.RaiseAndSetIfChanged(ref second_number, value);
            }
            get
            {
                return second_number;
            }
        }
        public ReactiveCommand<string, string> AddNum { get; }
        public ReactiveCommand<string, Unit> ExecuteOperationCommand { get; }

        private string AddNumberToString(string str)
        {
            if (operation_calc == "n")
            {
                ShowValue = str;
                operation_calc = " ";
            }
            else
            {
                ShowValue += str;
            }
            return ShowValue;
        }
        private void ExecuteOperation(string operation)
        {
            if (RomanNumberExtend.ToRoman(second_number) > 0)
                second_value = new RomanNumberExtend(second_number);
            RomanNumber temp;
            try
            {
                switch (operation_calc[0])
                {
                    case '+':
                        {
                            temp = result_of_calc + second_value;
                            result_of_calc = new RomanNumberExtend(temp.ToString());
                            break;
                        }
                    case '*':
                        {
                            temp = result_of_calc * second_value;
                            result_of_calc = new RomanNumberExtend(temp.ToString());
                            break;
                        }
                    case '/':
                        {
                            temp = result_of_calc / second_value;
                            result_of_calc = new RomanNumberExtend(temp.ToString());
                            break;
                        }
                    case '-':
                        {
                            temp = result_of_calc - second_value;
                            result_of_calc = new RomanNumberExtend(temp.ToString());
                            break;
                        }
                    case ' ':
                        {
                            if (RomanNumberExtend.ToRoman(second_number) > 0)
                                result_of_calc = new RomanNumberExtend(second_number);
                            break;
                        }
                    case 'n':
                        {
                            if (RomanNumberExtend.ToRoman(second_number) > 0)
                                result_of_calc = new RomanNumberExtend(second_number);
                            break;
                        }
                    default:
                        break;
                }
                if (operation == "=")
                {
                    if (result_of_calc != null)
                        ShowValue = result_of_calc.ToString();
                    operation_calc = "n";
                    result_of_calc = null;
                }
                else
                {
                    operation_calc = operation;
                    ShowValue = "";
                }
            }
            catch (RomanNumberException ex)
            {
                ShowValue = $"Ошибка: {ex.Message}";
            }
        }
    }
}
