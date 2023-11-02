using System.Drawing.Imaging;

namespace LZW
{
    public partial class Form1 : Form
    {
        private Encoder encoder;
        private Decoder decoder;
        private string encoderInputFilePath;
        private string encoderOutputFilePath;
        private string decoderInputFilePath;
        private string decoderOutputFilePath;


        public Form1()
        {
            InitializeComponent();
        }

        private void loadOriginalFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"D:\School\CIM\LZW\Files";
            openFileDialog.ShowDialog();
            encoderInputFilePath = openFileDialog.FileName;
            encoderOutputFilePath = encoderInputFilePath;

            //display the file path

            encoder = new Encoder();
        }

        private void encodeFileBtn_Click(object sender, EventArgs e)
        {
            encoderOutputFilePath += ".";
            if (chooseDictionaryTypeCb.Text == "Freeze")
            {
                encoderOutputFilePath += "f";
            }
            else
            {
                encoderOutputFilePath += "e";
            }

            encoderOutputFilePath += chooseNumberOfBitsCb.Text;

            encoderOutputFilePath += ".lzw";

            encoder.InitialiseEncoder(encoderInputFilePath, encoderOutputFilePath);
            encoder.SetIndicesSize(Convert.ToInt32(chooseNumberOfBitsCb.Text));
            encoder.EncodeFile();

        }

        private void loadEncodedFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"D:\School\CIM\LZW\Files";
            openFileDialog.Filter = "Text Files|*.lzw|All Files|*.*";
            openFileDialog.ShowDialog();
            decoderInputFilePath = openFileDialog.FileName;

            string[] parts = decoderInputFilePath.Split('.');
            string extension = parts[parts.Length - 2];

            decoderOutputFilePath = decoderInputFilePath + "." + extension;

            decoder = new Decoder();
        }

        private void decodeFileBtn_Click(object sender, EventArgs e)
        {


        }
    }
}