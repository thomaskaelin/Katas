using System.ComponentModel;
using Android.Widget;

namespace MVVM.Android
{
    public class EditTextBinding
    {
        public EditTextBinding(INotifyPropertyChanged vm, string vmPropertyName, EditText widget, string widgetPropertyName)
        {
            // ViewModel to View
            vm.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == vmPropertyName)
                {
                    var vmType = vm.GetType();
                    var vmProperty = vmType.GetProperty(vmPropertyName);
                    var vmPropertyValue = vmProperty.GetValue(vm).ToString();

                    var widgetType = widget.GetType();
                    var widgetProperty = widgetType.GetProperty(widgetPropertyName);
                    widgetProperty.SetValue(widget, vmPropertyValue);
                }
            };

            // View to ViewModel
            widget.TextChanged += (sender, args) =>
            {
                var widgetType = widget.GetType();
                var widgetProperty = widgetType.GetProperty(widgetPropertyName);
                var widgetPropertyValue = widgetProperty.GetValue(widget);

                var vmType = vm.GetType();
                var vmProperty = vmType.GetProperty(vmPropertyName);
                vmProperty.SetValue(vm, widgetPropertyValue);
            };
        }
    }
}