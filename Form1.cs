using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string fileName = string.Empty;

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fileName = string.Empty;
            richTextBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            var textFile = richTextBox1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Create a stream using the filename
                FileStream fs = new(saveFileDialog1.FileName, FileMode.Create);

                // Create a script that will write to the stream
                StreamWriter writer = new StreamWriter(fs);

                // Writes the content of the textbox to the stream
                writer.Write(textFile.Text);

                // Close the write and stream
                writer.Close();
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file
                filePath = openFileDialog.FileName;

                // Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using StreamReader reader = new StreamReader(fileStream);
                fileContent = reader.ReadToEnd();

                richTextBox1.Text = fileContent;
            }
        }

        private void fontSToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using FontDialog fontDialog1 = new FontDialog();

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
                richTextBox1.Font = fontDialog1.Font; //apply new font to all text
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
                richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void textAlignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
    }
}