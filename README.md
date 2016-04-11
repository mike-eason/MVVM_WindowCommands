# Open Windows and Dialogs in MVVM
Open Windows and Dialogs using an `ICommand`. This repository uses the MVVM pattern in order to separate the View and the View Model, but maintaining the ability to open Windows.

For examples, check out the `WindowCommands.Demo` project in this repository.

## Getting Started

1) Download and extract the solution.
2) Build the solution.
3) Add/Reference the `WindowCommands` project in your solution.

Start coding.

### Open a Window
Firstly, create an `OpenWindowCommand` property in your view model:

```
public class MyViewModel
{
    public OpenWindowCommand OpenWindowCommand { get; private set; }

    public MyViewModel()
    {
        OpenWindowCommand = new OpenWindowCommand();
    }

    ...
}
```

Then, bind the `OpenWindowCommand` to a `Button` in your View:

```
<Button Content="Open Window"
        Command="{Binding OpenWindowCommand}"
        CommandParameter="{x:Type local:MyNewWindow}"/>
```

The `CommandParamter` is the `Type` of the `Window` you want to open.

### Show a Dialog
A dialog is slightly different to a `Window` as a dialog will return a `bool?` result. The `OpenDialogCommand` requires an `Action<bool?>` callback method, here's an example:

```
public class MyViewModel
{
    public ShowDialogCommand ShowDialogCommand { get; private set; }

    public MyViewModel()
    {
        ShowDialogCommand = new ShowDialogCommand(PostOpenDialog);
    }

    /// <summary>
    /// This executes after the dialog is opened.
    /// </summary>
    public void PostOpenDialog(bool? dialogResult)
    {
        //TODO
    }
    
    ...
}
```

Once the dialog has been closed, the `PostOpenDialog` callback method will be called and the dialog result will be passed into the paramters.

Just like before, you can bind a `Button` to the command like so:

```
<Button Content="Show Dialog"
        Command="{Binding ShowDialogCommand}"
        CommandParameter="{x:Type local:MyDialogWindow}"/>
```

##### The `PreOpenDialog` overload
You may want to call a method **before** a dialog is displayed, in this case you can simply use the overload on the `ShowDialogCommand` constructor:

```
public class MyViewModel
{
    public ShowDialogCommand ShowDialogCommand { get; private set; }

    public MyViewModel()
    {
        ShowDialogCommand = new ShowDialogCommand(PostOpenDialog, PreOpenDialog);
    }

    /// <summary>
    /// This executes just before the dialog is opened.
    /// </summary>
    public void PreOpenDialog()
    {
        //TODO
    }
    
    /// <summary>
    /// This executes after the dialog is opened.
    /// </summary>
    public void PostOpenDialog(bool? dialogResult)
    {
        //TODO
    }
    
    ...
}
```

## License

This project is under the MIT license.