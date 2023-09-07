using System;
using CodeBase.UI.Factories;

namespace CodeBase.Services.WindowsService
{
    public class WindowService
    {
        private IUIFactory uiFactory;

        public WindowService(IUIFactory uiFactory)
        {
            this.uiFactory = uiFactory;
        }

        public void Open(WindowId window)
        {
            switch (window)
            {
                case WindowId.None:
                    break;
                case WindowId.PrivatePolicyAccept:
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(window), window, null);
            }
        }
    }
}