using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Reflection;

namespace Course_Project.Utils
{
    public static class MacStyle
    {
        public static void Apply(Form form)
        {
            form.Font = new Font("Segoe UI", 10F);
            form.StartPosition = FormStartPosition.CenterScreen;

            SetDoubleBuffered(form, true);
            EnableUserPaint(form);

            form.Paint += (s, e) =>
            {
                var rect = form.ClientRectangle;
                using (var bgBrush = new LinearGradientBrush(
                    rect,
                    Color.FromArgb(245, 245, 245),
                    Color.FromArgb(200, 200, 200),
                    LinearGradientMode.Vertical)) e.Graphics.FillRectangle(bgBrush, rect);               
                using (var glassBrush = new SolidBrush( Color.FromArgb(45, Color.White))) e.Graphics.FillRectangle(glassBrush, rect);              
                using (var pen = new Pen(Color.FromArgb(180, 180, 180)))
                {
                    e.Graphics.DrawRectangle(
                        pen,
                        0,
                        0,
                        rect.Width - 1,
                        rect.Height - 1);
                }
            };

            MakeLabelsTransparent(form);
        }

        private static void EnableUserPaint(Control control)
        {
            typeof(Control)
                .GetMethod("SetStyle", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.Invoke(control, new object[]
                {
                    ControlStyles.UserPaint |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer,
                    true
                });
        }

        private static void SetDoubleBuffered(Control control, bool value)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(control, value, null);
        }

        public static void MakeLabelsTransparent(Form form)
        {
            foreach (Control c in form.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.BackColor = Color.Transparent;
                    lbl.Parent = form;
                }
            }
        }

        public static void ApplyToPanel(Panel panel)
        {
            SetDoubleBuffered(panel, true);
            EnableUserPaint(panel);

            panel.Paint += (s, e) =>
            {
                var rect = panel.ClientRectangle;

                using (var bgBrush = new LinearGradientBrush(
                    rect,
                    Color.FromArgb(245, 245, 245),
                    Color.FromArgb(210, 210, 210),
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(bgBrush, rect);
                }
                using (var glassBrush = new SolidBrush(
                    Color.FromArgb(30, Color.White)))
                {
                    e.Graphics.FillRectangle(glassBrush, rect);
                }
            };
        }

    }
}
