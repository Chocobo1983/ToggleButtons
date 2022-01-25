using System.Windows;
using System.Windows.Controls;

namespace Decorators
{
    /// <summary>
    /// Decorator, which displaces its child by a given offset.
    /// </summary>
    public class TranslateDecorator : Decorator
    {
        static TranslateDecorator()
        {
            ClipToBoundsProperty.OverrideMetadata(typeof(TranslateDecorator), new FrameworkPropertyMetadata(true));
        }


        /// <summary>
        /// Horizontal Offset. 1 unit = 1 width of the child control.
        /// </summary>
        public double TranslateXChild
        {
            get { return (double)GetValue(TranslateXChildProperty); }
            set { SetValue(TranslateXChildProperty, value); }
        }
        public static readonly DependencyProperty TranslateXChildProperty = DependencyProperty.Register(
            "TranslateXChild", typeof(double), typeof(TranslateDecorator), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsArrange));

        /// <summary>
        /// Vertical Offset. 1 unit = 1 height of the child control.
        /// </summary>
        public double TranslateYChild
        {
            get { return (double)GetValue(TranslateYChildProperty); }
            set { SetValue(TranslateYChildProperty, value); }
        }
        public static readonly DependencyProperty TranslateYChildProperty = DependencyProperty.Register(
            "TranslateYChild", typeof(double), typeof(TranslateDecorator), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsArrange));


        /// <summary>
        /// Horizontal Offset. 1 unit = 1 width of this control.
        /// </summary>
        public double TranslateXParent
        {
            get { return (double)GetValue(TranslateXParentProperty); }
            set { SetValue(TranslateXParentProperty, value); }
        }
        public static readonly DependencyProperty TranslateXParentProperty = DependencyProperty.Register(
            "TranslateXParent", typeof(double), typeof(TranslateDecorator), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsArrange));

        /// <summary>
        /// Vertical Offset. 1 unit = 1 height of this control.
        /// </summary>
        public double TranslateYParent
        {
            get { return (double)GetValue(TranslateYParentProperty); }
            set { SetValue(TranslateYParentProperty, value); }
        }
        public static readonly DependencyProperty TranslateYParentProperty = DependencyProperty.Register(
            "TranslateYParent", typeof(double), typeof(TranslateDecorator), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsArrange));


        /// <summary>
        /// Horizontal Offset. 1 unit = 1 dip.
        /// </summary>
        public double TranslateXPoints
        {
            get { return (double)GetValue(TranslateXPointsProperty); }
            set { SetValue(TranslateXPointsProperty, value); }
        }
        public static readonly DependencyProperty TranslateXPointsProperty = DependencyProperty.Register(
            "TranslateXPoints", typeof(double), typeof(TranslateDecorator), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsArrange));


        /// <summary>
        /// Vertical Offset. 1 unit = 1 dip.
        /// </summary>
        public double TranslateYPoints
        {
            get { return (double)GetValue(TranslateYPointsProperty); }
            set { SetValue(TranslateYPointsProperty, value); }
        }
        public static readonly DependencyProperty TranslateYPointsProperty = DependencyProperty.Register(
            "TranslateYPoints", typeof(double), typeof(TranslateDecorator), new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.AffectsArrange));


        protected override Size ArrangeOverride(Size arrangeSize)
        {
            UIElement child = Child;
            if (child != null)
            {
                double x = arrangeSize.Width * TranslateXParent + child.DesiredSize.Width * TranslateXChild + TranslateXPoints;
                double y = arrangeSize.Height * TranslateYParent + child.DesiredSize.Height * TranslateYChild + TranslateYPoints;

                child.Arrange(new Rect(new Point(x, y), arrangeSize));
            }
            return arrangeSize;
        }
    }
}
