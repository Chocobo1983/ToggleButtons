﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MyButton
{
    public class MyButton : Button
    {
        public static readonly DependencyProperty IsOnProperty = DependencyProperty.Register("IsOn", typeof(bool), typeof(MyButton), new PropertyMetadata(default));
        protected async override void OnClick()
        {
            base.OnClick();            
            //timer.Stop();
            if (IsOn) SetCurrentValue(IsOnProperty, false);
            else
            {
                SetCurrentValue(IsOnProperty, true);
                await Task.Delay(3000);
                SetCurrentValue(IsOnProperty, false);
            }            
        }
        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }
        //DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(3) };       
        static MyButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyButton), new FrameworkPropertyMetadata(typeof(MyButton)));
        }
        public MyButton()
        {
            IsEnabledChanged += async (s, e) => 
            {
                //timer.Stop();
                if(IsOn)
                {
                    SetCurrentValue(IsOnProperty, true);
                    await Task.Delay(3000);
                    SetCurrentValue(IsOnProperty, false);
                }               
            };            
        }
    }
}
