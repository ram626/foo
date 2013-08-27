using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Level1Map
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /* Array of cells. 1 is wall, 0 is no wall. It goes top, right, bottom, left.
        This order of walls seems natural to me, but to change it we would just change the mapCellArray values
        and the top, left, bottom, right indexes. This can be extended to be initiated from a text file. */
        static int[][] mapCellArray =
        new int[][] { new int[] { 1, 0, 0, 1 },
                      new int[] { 1, 0, 1, 0 },
                      new int[] { 1, 1, 0, 0 },
                      new int[] { 0, 0, 0, 1 },
                      new int[] { 1, 0, 0, 0 },
                      new int[] { 0, 1, 0, 0 },
                      new int[] { 0, 1, 1, 1 },
                      new int[] { 0, 0, 0, 1 },
                      new int[] { 0, 1, 0, 0 },
                      new int[] { 1, 0, 1, 1 }, 
                      new int[] { 0, 0, 1, 0 },
                      new int[] { 0, 1, 1, 0 } };

        /* Array of cell positions. This is always the same length as mapCellArray.
        This is indexed the same as mapCellArray, and cellPosition[i] refers to the position of mapCellArray[i].
        This could be added into the mapCellArray but if so, becomes a horribly nested array and very confusing. 
        This can be extended to be initiated from a text file. */
        static int[][] cellPosition =
        new int[][] { new int[] { 0, 0 }, 
                      new int[] { 1, 0 },
                      new int[] { 2, 0 },
                      new int[] { 0, 1 },
                      new int[] { 1, 1 },
                      new int[] { 2, 1 },
                      new int[] { 0, 2 },
                      new int[] { 1, 2 },
                      new int[] { 2, 2 },
                      new int[] { 0, 3 },
                      new int[] { 1, 3 },
                      new int[] { 2, 3 } };

        // Create a PictureBox to draw the map inside.
        private PictureBox pictureBox1 = new PictureBox();

        /// <summary>
        /// On form load, draw PictureBox, and set up the paint event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        public static int getDim()
        {
            int maximum = 0;
            for (int i = 0; i < cellPosition.Length; i += 1)
            {
                if (cellPosition[i][0] > maximum)
                {
                    maximum = cellPosition[i][0];
                }
                if (cellPosition[i][1] > maximum)
                {
                    maximum = cellPosition[i][1];
                }
            }
            return maximum;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Dock the PictureBox to the form and set its background to white.
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BackColor = Color.White;

            // Connect the Paint event of the PictureBox to the event handler method.
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

            // Add the PictureBox control to the Form. 
            this.Controls.Add(pictureBox1);
        }

        /// <summary>
        /// Get the dimensions of the map.
        /// </summary>
        /// <returns></returns>

        // An image could be used for each cell but is not implemented right now.
        public Image img;

        // X position of the board in the form.
        public int BOARDX = 50;

        // Y position of the board in the form.
        public int BOARDY = 50;

        // Square sizes
        public int SQUARESIZE = 100;

        /// <summary>
        /// This gets called when the paint event handler is called. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Create a local version of the graphics object for the PictureBox.
            Graphics g = e.Graphics;

            // These variables will be explained at definition time. 
            int[] position;
            int[] walls;
            int column;
            int row;
            int top;
            int right;
            int bottom;
            int left;



            // Loop through mapCellArray.
            for (int i = 0; i < mapCellArray.Length; i++)
            {
                // Define walls as one array within mapCellArray. 
                walls = mapCellArray[i];

                // Set position to coinciding cellPosition value.
                position = cellPosition[i];

                // Define column and row
                column = BOARDX + position[0] * SQUARESIZE;
                row = BOARDY + position[1] * SQUARESIZE;

                // Set the top, right, bottom, and left wall variables.
                top = walls[0];
                right = walls[1];
                bottom = walls[2];
                left = walls[3];

                // If there is a top wall, draw it.
                if (top == 1)
                {
                    g.DrawLine(System.Drawing.Pens.Red, column, row, column + SQUARESIZE, row);
                }
                else
                {
                    g.DrawLine(System.Drawing.Pens.LightBlue, column, row, column + SQUARESIZE, row);
                }
                // If there is a right wall, draw it. 
                if (right == 1)
                {
                    g.DrawLine(System.Drawing.Pens.Red, column + SQUARESIZE, row, column + SQUARESIZE, row + SQUARESIZE);
                }
                else
                {
                    g.DrawLine(System.Drawing.Pens.LightBlue, column + SQUARESIZE, row, column + SQUARESIZE, row + SQUARESIZE);
                }
                // If there is a bottom wall, draw it.
                if (bottom == 1)
                {
                    g.DrawLine(System.Drawing.Pens.Red, column + SQUARESIZE, row + SQUARESIZE, column, row + SQUARESIZE);
                }
                else
                {
                    g.DrawLine(System.Drawing.Pens.LightBlue, column + SQUARESIZE, row + SQUARESIZE, column, row + SQUARESIZE);
                }
                // If there is a left wall, draw it. 
                if (left == 1)
                {
                    g.DrawLine(System.Drawing.Pens.Red, column, row + SQUARESIZE, column, row);
                }
                else
                {
                    g.DrawLine(System.Drawing.Pens.LightBlue, column, row + SQUARESIZE, column, row);
                }

            }

        }
    }
}