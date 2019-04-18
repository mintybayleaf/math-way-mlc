using System.Drawing;
using System.Windows.Forms;

namespace MathLogCenter
{
    class Utility
    {
        public static int FONTSIZE = 12;
        public static Color FONTCOLOR = Color.White;
        public static Color DEFAULTBACKCOLOR = Color.FromArgb(20, 40, 60);
        
        /// <summary>
        /// Sets the width of the control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="width"></param>
        public static void SetWidth(Control control, int width)
        {
            control.Width = width;
        }

        /// <summary>
        /// Sets the height of the contrl                                                                                           
        /// </summary>
        /// <param name="control"></param>
        /// <param name="height"></param>
        public static void SetHeight(Control control, int height)
        {
            control.Height = height;
        }

        /// <summary>
        /// Sets the distance from the left edge of the control to the parent control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="left"></param>
        public static void SetLeft(Control control, int left)
        {
            control.Left = left;
        }

        /// <summary>
        /// Sets the distance from the top of the parent control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="top"></param>
        public static void SetTop(Control control, int top)
        {
            control.Top = top;
        }

        /// <summary>
        /// Sets the control postition with the new point
        /// </summary>
        /// <param name="control"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void SetPos(Control control, int x, int y)
        {
            control.Location = new Point(x, y);
        }

        /// <summary>
        /// Set the back color of the control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="color"></param>
        public static void SetBackColor(Control control, Color color)
        {
            control.BackColor = color;
        }

        /// <summary>
        /// Sets the fore color of the control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="color"></param>
        public static void SetForeColor(Control control, Color color)
        {
            control.ForeColor = color;
        }

        /// <summary>
        /// Sets the font size of the specified text box
        /// </summary>
        /// <param name="box"></param>
        /// <param name="size"></param>
        /// <param name="fontstyle"></param>
        public static void SetFontSize(TextBox box, float size, FontStyle fontstyle = FontStyle.Regular)
        {
            Font font = new Font("Microsoft Sans Serif", size, fontstyle);
            box.Font = font;
        }

        /// <summary>
        /// Sets the anchor of the control with a default of no anchor
        /// </summary>
        /// <param name="control"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="top"></param>
        /// <param name="bottom"></param>
        public static void SetAnchor(Control control, AnchorStyles left = 0, AnchorStyles right = 0, AnchorStyles top = 0, AnchorStyles bottom = 0)
        {
            AnchorStyles l = left == 0 ? 0 : AnchorStyles.Left;
            AnchorStyles r = right == 0 ? 0 : AnchorStyles.Right;
            AnchorStyles t = top == 0 ? 0 : AnchorStyles.Top;
            AnchorStyles b = bottom == 0 ? 0 : AnchorStyles.Bottom;

            control.Anchor = (l | r | t | b);
        }

        /// <summary>
        /// Set the size of the control
        /// </summary>
        /// <param name="control"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void SetSize(Control control, int width, int height)
        {
            control.Size = new Size(width, height);
        }

        /// <summary>
        /// Center the control horizontally to the parent
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
       public static void CenterHorizontal(Control parent, Control child)
        {
            SetLeft(child, (parent.Width - child.Width) / 2);
        }

        /// <summary>
        /// Center the control vertically to the parent
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        public static void CenterVertical(Control parent, Control child)
        {
            SetTop(child, (parent.Height - child.Height) / 2);
        }

        /// <summary>
        /// Contruct the default MathWayLog Lablels
        /// </summary>
        /// <param name="label"></param>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public static void ConstructLabel(Label label, string name, string text)
        {
            label.Name = name;
            label.Text = text;
            label.Font = new Font("Microsoft Sans Serif", 12);
            SetForeColor(label, Color.White);
        }

        /// <summary>
        /// Construct the default MathWayLogs text boxes
        /// </summary>
        /// <param name="box"></param>
        /// <param name="name"></param>
        /// <param name="text"></param>
        public static void ConstructTextBox(TextBox box, string name, string text)
        {
            box.Name = name;
            box.Text = text;
            SetFontSize(box, 12F);
            SetForeColor(box, Color.White);
        }

        public static void ConstructButton(Button but, string name, string text, Bitmap bm)
        {
            but.Name = name;
            but.Text = text;
            but.FlatStyle = FlatStyle.Flat;
            but.FlatAppearance.BorderSize = 0;
            but.Image = bm;
        }

       public static string[] ComboList()
        {
            return new string[] { "MTH", "STAT", "OTH" };
        }

        public static string WordFromBool(bool m = false, bool s = false, bool o = false)
        {
            string temp = "";
            if(m == true)
                temp = "MTH";
            if (s == true)
                temp = "STAT";
            if (o == true)
                temp = "OTH";

            return temp;
        }
    }
}
