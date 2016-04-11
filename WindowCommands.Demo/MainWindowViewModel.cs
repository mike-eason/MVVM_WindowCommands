using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowCommands.Demo
{
    public class MainWindowViewModel
    {
        public OpenWindowCommand OpenWindowCommand { get; private set; }
        public ShowDialogCommand ShowDialogCommand { get; private set; }

        public MainWindowViewModel()
        {
            OpenWindowCommand = new OpenWindowCommand();
            ShowDialogCommand = new ShowDialogCommand(PostOpenDialog, PreOpenDialog);
        }

        /// <summary>
        /// This executes just before the dialog is opened.
        /// </summary>
        public void PreOpenDialog()
        {
            Console.WriteLine("The dialog is about to be opened");
        }

        /// <summary>
        /// This executes after the dialog is opened.
        /// </summary>
        public void PostOpenDialog(bool? dialogResult)
        {
            Console.WriteLine(string.Format("The dialog has been closed and the result was {0}", dialogResult));
        }
    }
}
