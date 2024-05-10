using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM_LumaStore_Demo.Pages.Interfaces
{
    internal interface IQuantity
    {
        int Quantity { get; }

        void ClearQuantity();

        void InputQuantity(int i);


    }
}
