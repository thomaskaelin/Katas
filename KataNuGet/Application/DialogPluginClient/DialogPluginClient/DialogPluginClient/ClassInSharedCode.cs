using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DialogPlugin.Core;

namespace DialogPluginClient
{
    public class ClassInSharedCode
    {
        private readonly IAlertDialog _alertDialog;

        public ClassInSharedCode(IAlertDialog alertDialog)
        {
            _alertDialog = alertDialog;
        }

        public void Show()
        {
            _alertDialog.Show("Cool", "Hallo Loana!");
        }
    }
}
