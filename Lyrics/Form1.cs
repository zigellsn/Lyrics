using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lyrics
{
    public partial class Form1 : Form
    {
        private LineDiscr ld;

        private int GetRtfRow(RichTextBox rtfb)
        {
            return rtfb.GetLineFromCharIndex(rtfb.SelectionStart);
        }

        private int GetRtfCol(RichTextBox rtfb)
        {
            rtfb.GetCharIndexFromPosition(rtfb.GetPositionFromCharIndex(rtfb.SelectionStart));
            return rtfb.SelectionStart - Win32.SendMessage(rtfb.Handle, Win32.EM_LINEINDEX, -1, 0);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ld = LineDiscr.getInstance();
            dataGridView1.Columns[0].Width = dataGridView1.Width - 3;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                dataGridView1.Rows[e.RowIndex].Cells[0].Value = 
                    ld.Analyze(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), e.RowIndex);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.ControlKey)
            {
                MessageBox.Show("Jetzt 2");
                e.Handled = true;
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
                MessageBox.Show("Jetzt");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Lines[GetRtfRow(richTextBox1)] != null)
                richTextBox1.Lines[GetRtfRow(richTextBox1)] =
                    ld.Analyze(richTextBox1.Lines[GetRtfRow(richTextBox1)], GetRtfRow(richTextBox1));
        }
    }
}
