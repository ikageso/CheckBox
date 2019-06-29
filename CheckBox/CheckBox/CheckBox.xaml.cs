using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckBox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBox : ContentView
    {
        #region BindableProperty
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(propertyName: nameof(IsChecked), returnType: typeof(bool), declaringType: typeof(CheckBox), defaultValue:false,
            propertyChanged: (bindable, oldValue, newValue) => { ((CheckBox)bindable).OnChecked((bool)newValue); });

        private void OnChecked(bool newValue)
        {
            this.checkOn.IsVisible = IsChecked;
            this.checkOff.IsVisible = !IsChecked;
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        #endregion

        public CheckBox()
        {
            InitializeComponent();

            this.checkOn.IsVisible = IsChecked;
            this.checkOff.IsVisible = !IsChecked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }
    }
}