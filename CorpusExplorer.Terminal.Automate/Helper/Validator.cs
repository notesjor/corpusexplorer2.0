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

  public class Validator<T> : AbstractValidator where T : Control
  {
    public class ValidatorRule<T> where T : Control
    {
      public T Control { get; set; }
      public Function<T, bool> ValidationFunction { get; set; }
      public string ErrorMessage { get; set; }

      internal bool Validate() => ValidationFunction(Control);
    }

    public List<ValidatorRule<T>> Rules { get; set; } = new List<ValidatorRule<T>>();

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
