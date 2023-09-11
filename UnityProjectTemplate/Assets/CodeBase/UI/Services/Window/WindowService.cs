﻿using System;
using CodeBase.UI.Services.Factories;

namespace CodeBase.UI.Services.Window
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
                    uiFactory.CreatePrivatePolicyPopup();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(window), window, null);
            }
        }
    }
}