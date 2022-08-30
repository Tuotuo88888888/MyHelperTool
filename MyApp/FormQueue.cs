using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    public class FormStack
    {
        private static readonly object _lock = new object();
        private static readonly object _stackLook = new object();
        private static FormStack formStack;

        private Stack<Form> values;
        private Dictionary<string,Form> keyValuePairs=new Dictionary<string,Form>();

        private FormStack()
        {
            this.values = new Stack<Form>();
        }

        public static FormStack Instance()
        {
            if (formStack == null)
            {
                lock (_lock)
                {
                    if (formStack == null)
                    {
                        formStack = new FormStack();
                    }
                }
            }
            return formStack;
        }

        public void fallbackForm()
        {
            lock (_stackLook)
            {
                if (values.Count > 0)
                {
                    values.Pop().Close();
                    if (values.Count > 0)
                    {
                        values.Peek().Show();
                    }
                }
            }
        }

        public void forwardForm(Form form)
        {
            lock (_stackLook)
            {
                form.Show();
                if (values.Count > 0)
                {
                    values.Peek().Hide();
                }
                values.Push(form);
            }
        }

    }
}
