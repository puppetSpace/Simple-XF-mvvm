[![Build Status](https://sebastianschoof.visualstudio.com/SimpleMvvm/_apis/build/status/SimpleMvvm-CI?branchName=master)](https://sebastianschoof.visualstudio.com/SimpleMvvm/_build/latest?definitionId=1?branchName=master)
# Simple-XF-mvvm
Simple-XF-mvvm is, as the name states, a simple mvvm framework for Xamarin.Forms. 
The project depends on Xamarin.Forms so it can only be used with Xamarin.Forms.
## Getting started
The project contains the class **ViewModelBase** that can be used as a base class
for your viewmodels. **ViewModelBase** contains methods to notify property changes, 
to do navigation, respond on navigation events.
### Navigation
To be able to respond on navigation events and use navigation, certain actions need to be taken.

In the **App.xaml.cs** class of your shared project, you have to configure to which pages you can navigate to 
using the Navigator class.
```
public App()
{
	InitializeComponent();

	Pi.Xf.SimpleMvvm.Navigator.Instance.Configure(nameof(MainPage),typeof(MainPage));
	Pi.Xf.SimpleMvvm.Navigator.Instance.Configure(nameof(Page1),typeof(Page1));
	Pi.Xf.SimpleMvvm.Navigator.Instance.Configure(nameof(Page2),typeof(Page2));
	
	...
}
```
The name you specify, is the name you have to use when you want to navigate to that page from within your viewmodel.
#### Navigating
**ViewModelBase** has 2 methods to navigate:
* NavigateTo
* NavigateBack

**NavigateTo** is used to navigate to a page. You pass in the pagename,you configured with the navigator, as argument. 
You can also pass in an object you want to use in the navigated page's viewmodel.

**NavigateBack** is used to navigate to the previous page. Here you can also pass back an object as argument.

### Navigating notification

To receive notification of navigation, you have to use the **PiNavigationPage**. This navigationpage inherits from the
Xamarin.Forms navigation and has handlers on the Pushed and Popped event.

```
public App()
{
	InitializeComponent();

	...
	
	MainPage = new Pi.Xf.SimpleMvvm.NavigationPage(new MainPage());
}
```

**ViewModelBase** has 3 overridable methods that gets called when a page is pushed on or popped off the navigationstack

* **OnNavigatedFrom(object param)**: Gets called on the page's viewmodel that's been pushed on the stack. 
The argument is the object you pass when calling **NavigateTo**.
* **OnNavigatedTo()**: Gets called on the page's viewmodel that initiated the navigation to another page.
* **OnNavigatedBack(object param)**: gets called on the page's viewmodel that has been popped.
The argument is the object you pass when calling **NavigateBack**.

### Property Changed Notification
**ViewModelBase** inherits from **ObservableObject** which has a method **`Set<T>()`**. This method is used to notify propertychanges on your bindable properties
in the viewmodel.

**ObservableObject** can be inherited if you want to notify property changes without having to implement INotifyPropertyChanged yourself.

e.g.
```
private string _title;
public string Title
{
	get{return _title;}
	set{Set(ref _title,value);}
}
```
**Set()** will check if the equality between the old and new value. If they are not the same, the old value gets 
overriden with the new value and the PropertyChangedEvent is called.

The **[CalledMemberName]** attribute is used in **Set()** to retrieve the name of the property who's value has changed.

