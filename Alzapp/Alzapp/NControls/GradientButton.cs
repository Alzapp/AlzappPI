using MagicGradients;
using NControl.Abstractions;
using NGraphics;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.NControls
{
    public class GradientButton : NControlView
    {
        private Frame _frame;
        private Label _label;
        private GradientView _gradientView;

        public float BorderRadius
        {
            get => (float)GetValue(BorderRadiusProperty);
            set
            {
                SetValue(BorderRadiusProperty, value);
                Invalidate();
            }
        }
        static float initialRadius = 15;

        public static BindableProperty BorderRadiusProperty =
            BindableProperty.Create(nameof(BorderRadius),
                typeof(float),
                typeof(GradientButton),
                initialRadius,
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.BorderRadius = (float)n;
                });


        public string Text
        {
            get => (string)GetValue(TextProperty);
            set
            {
                SetValue(TextProperty, value);
                Invalidate();
            }
        }

        public static BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text),
                typeof(string),
                typeof(GradientButton),
                "",
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.Text = (string)n;
                });


        public string GradientStyle
        {
            get => (string)GetValue(GradientStyleProperty);
            set
            {
                SetValue(GradientStyleProperty, value);
                Invalidate();
            }
        }

        public static BindableProperty GradientStyleProperty =
            BindableProperty.Create(nameof(GradientStyle),
                typeof(string),
                typeof(GradientButton),
                "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(0,0,0),rgb(0,0,0))",
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.GradientStyle = (string)n;
                });
        public string GradientStyle2
        {
            get => (string)GetValue(GradientStyle2Property);
            set
            {
                SetValue(GradientStyle2Property, value);
                Invalidate();
            }
        }

        public static BindableProperty GradientStyle2Property =
            BindableProperty.Create(nameof(GradientStyle2),
                typeof(string),
                typeof(GradientButton),
                "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(0,0,0),rgb(0,0,0))",
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.GradientStyle2 = (string)n;
                });


        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set
            {
                SetValue(CommandProperty, value);
                Invalidate();
            }
        }

        public static BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command),
                typeof(ICommand),
                typeof(GradientButton),
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.Command = (ICommand)n;
                });


        public GradientButton()
        {
            _label = new Label
            {
                Text = "Test 1",
                TextColor = Xamarin.Forms.Color.White,
                VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center
            };
            _gradientView = new GradientView
            {
                GradientSource = new CssGradientSource
                {
                    Stylesheet = "linear-gradient(316deg, rgba(234, 234, 234, 0.02) 0%, rgba(234, 234, 234, 0.02) 16.667%,rgba(128, 128, 128, 0.02) 16.667%, rgba(128, 128, 128, 0.02) 33.334%,rgba(161, 161, 161, 0.02) 33.334%, rgba(161, 161, 161, 0.02) 50.001000000000005%,rgba(154, 154, 154, 0.02) 50.001%, rgba(154, 154, 154, 0.02) 66.668%,rgba(77, 77, 77, 0.02) 66.668%, rgba(77, 77, 77, 0.02) 83.33500000000001%,rgba(10, 10, 10, 0.02) 83.335%, rgba(10, 10, 10, 0.02) 100.002%),linear-gradient(75deg, rgba(39, 39, 39, 0.03) 0%, rgba(39, 39, 39, 0.03) 20%,rgba(232, 232, 232, 0.03) 20%, rgba(232, 232, 232, 0.03) 40%,rgba(33, 33, 33, 0.03) 40%, rgba(33, 33, 33, 0.03) 60%,rgba(84, 84, 84, 0.03) 60%, rgba(84, 84, 84, 0.03) 80%,rgba(112, 112, 112, 0.03) 80%, rgba(112, 112, 112, 0.03) 100%),linear-gradient(103deg, rgba(174, 174, 174, 0.03) 0%, rgba(174, 174, 174, 0.03) 12.5%,rgba(190, 190, 190, 0.03) 12.5%, rgba(190, 190, 190, 0.03) 25%,rgba(191, 191, 191, 0.03) 25%, rgba(191, 191, 191, 0.03) 37.5%,rgba(23, 23, 23, 0.03) 37.5%, rgba(23, 23, 23, 0.03) 50%,rgba(227, 227, 227, 0.03) 50%, rgba(227, 227, 227, 0.03) 62.5%,rgba(71, 71, 71, 0.03) 62.5%, rgba(71, 71, 71, 0.03) 75%,rgba(162, 162, 162, 0.03) 75%, rgba(162, 162, 162, 0.03) 87.5%,rgba(85, 85, 85, 0.03) 87.5%, rgba(85, 85, 85, 0.03) 100%),linear-gradient(355deg, rgba(38, 38, 38, 0.02) 0%, rgba(38, 38, 38, 0.02) 25%,rgba(106, 106, 106, 0.02) 25%, rgba(106, 106, 106, 0.02) 50%,rgba(28, 28, 28, 0.02) 50%, rgba(28, 28, 28, 0.02) 75%,rgba(66, 66, 66, 0.02) 75%, rgba(66, 66, 66, 0.02) 100%),linear-gradient(137deg, rgba(38, 38, 38, 0.03) 0%, rgba(38, 38, 38, 0.03) 25%,rgba(211, 211, 211, 0.03) 25%, rgba(211, 211, 211, 0.03) 50%,rgba(4, 4, 4, 0.03) 50%, rgba(4, 4, 4, 0.03) 75%,rgba(24, 24, 24, 0.03) 75%, rgba(24, 24, 24, 0.03) 100%),linear-gradient(51deg, rgba(253, 253, 253, 0.03) 0%, rgba(253, 253, 253, 0.03) 14.286%,rgba(103, 103, 103, 0.03) 14.286%, rgba(103, 103, 103, 0.03) 28.572%,rgba(46, 46, 46, 0.03) 28.572%, rgba(46, 46, 46, 0.03) 42.858%,rgba(68, 68, 68, 0.03) 42.858%, rgba(68, 68, 68, 0.03) 57.144%,rgba(116, 116, 116, 0.03) 57.144%, rgba(116, 116, 116, 0.03) 71.42999999999999%,rgba(248, 248, 248, 0.03) 71.43%, rgba(248, 248, 248, 0.03) 85.71600000000001%,rgba(174, 174, 174, 0.03) 85.716%, rgba(174, 174, 174, 0.03) 100.002%),linear-gradient(283deg, rgba(20, 20, 20, 0.01) 0%, rgba(20, 20, 20, 0.01) 14.286%,rgba(23, 23, 23, 0.01) 14.286%, rgba(23, 23, 23, 0.01) 28.572%,rgba(19, 19, 19, 0.01) 28.572%, rgba(19, 19, 19, 0.01) 42.858%,rgba(134, 134, 134, 0.01) 42.858%, rgba(134, 134, 134, 0.01) 57.144%,rgba(4, 4, 4, 0.01) 57.144%, rgba(4, 4, 4, 0.01) 71.42999999999999%,rgba(254, 254, 254, 0.01) 71.43%, rgba(254, 254, 254, 0.01) 85.71600000000001%,rgba(87, 87, 87, 0.01) 85.716%, rgba(87, 87, 87, 0.01) 100.002%),linear-gradient(90deg, rgb(168, 1, 206),rgb(20, 120, 203))"
                }
            };


            _frame = new Frame
            {
                Content = new Grid
                {
                    Children =
                    {
                        _gradientView,
                        _label
                    }
                },
                Padding = 0,
                CornerRadius = 15f
            };

            Content = _frame;
        }
        public override bool TouchesBegan(IEnumerable<NGraphics.Point> points)
        {
            this.ScaleTo(0.96, 65, Easing.CubicInOut);
            return true;
        }

        public override bool TouchesCancelled(IEnumerable<NGraphics.Point> points)
        {
            this.ScaleTo(1, 65, Easing.CubicInOut);
            return true;
        }

        public override bool TouchesEnded(IEnumerable<NGraphics.Point> points)
        {
            this.ScaleTo(1, 65, Easing.CubicInOut);

            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(null);
            }

            return true;
        }
        public override void Draw(ICanvas canvas, NGraphics.Rect rect)
        {
            //canvas.DrawLine(rect.Left, rect.Top, rect.Width, rect.Height,
            //    NGraphics.Colors.Red);
            //canvas.DrawLine(rect.Width, rect.Top, rect.Left, rect.Height,
            //    NGraphics.Colors.Green);

            _frame.CornerRadius = BorderRadius;
            _label.Text = Text;

            _gradientView.GradientSource =
                new CssGradientSource
                {
                    Stylesheet = this.GradientStyle
                };
        }
    }
}
