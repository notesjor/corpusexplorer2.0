using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace CorpusExplorer.Terminal.Automate.Helper
{
  public abstract class AbstractValidator
  {
    public string[] ErrorMessages { get; protected set; }
    public abstract bool Validate(AbstractValidator additionalValidator = null);
  }

  public class Validator : AbstractValidator
  {
    public class Rule
    {
      public Control Control { get; set; }
      public Func<Control, bool> ValidationFunction { get; set; }
      public string ErrorMessage { get; set; }

      internal bool Validate()
      {
        try
        {
          // ReSharper disable once ConvertIfStatementToReturnStatement
          if (ValidationFunction == null)
            return true;

          return ValidationFunction(Control);
        }
        catch (InvalidCastException)
        {
          return true;
        }
        catch
        {
          return false;
        }
      }
    }

    public List<Rule> Rules { get; set; } = new List<Rule>();

    public override bool Validate(AbstractValidator additionalValidator = null)
    {
      var res = (from rule in Rules where !rule.Validate() select rule.ErrorMessage).ToArray();

      if (additionalValidator != null)
      {
        additionalValidator.Validate();

        var tmp = new List<string>();
        tmp.AddRange(res);
        tmp.AddRange(additionalValidator.ErrorMessages);
        res = tmp.ToArray();
      }

      ErrorMessages = res;
      return res.Length == 0;
    }

    public string SimpleErrorMessage()
    {
      var res = new List<string> { "Bitte nehmen Sie folgende Eingaben/Änderungen vor:" };
      res.AddRange(ErrorMessages);

      return string.Join("\n", res);
    }
  }
}
