using System;
using System.Windows;

namespace WindowCommands
{
    public class ShowDialogCommand : OpenWindowCommand
    {
        private Action _PreOpenDialogAction;
        private Action<bool?> _PostOpenDialogAction;

        public ShowDialogCommand(Action<bool?> postDialogAction)
        {
            if (postDialogAction == null)
                throw new ArgumentNullException("postDialogAction");

            _PostOpenDialogAction = postDialogAction;
        }

        public ShowDialogCommand(Action<bool?> postDialogAction, Action preDialogAction)
            : this(postDialogAction)
        {
            if (preDialogAction == null)
                throw new ArgumentNullException("preDialogAction");

            _PreOpenDialogAction = preDialogAction;
        }

        protected override void OpenWindow(Window wnd)
        {
            //If there is a pre dialog action then invoke that.
            if (_PreOpenDialogAction != null)
                _PreOpenDialogAction();

            //Show the dialog
            bool? result = wnd.ShowDialog();

            //Invoke the post open dialog action.
            _PostOpenDialogAction(result);
        }
    }
}