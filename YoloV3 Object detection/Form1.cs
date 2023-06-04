using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace YoloV3_Object_detection
{
    public partial class Form1 : Form
    {
        Net model = null;
        List<String> classLabels = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var pathWeights = openFileDialog.FileNames.Where(x => x.ToLower().EndsWith(".weights")).First();
                    var pathConfig = openFileDialog.FileNames.Where(x => x.ToLower().EndsWith(".cfg")).First();
                    var pathClasses = openFileDialog.FileNames.Where(x => x.ToLower().EndsWith(".names")).First();

                    model = DnnInvoke.ReadNetFromDarknet(pathConfig, pathWeights);
                    classLabels = File.ReadAllLines(pathClasses).ToList();
                    toolStripLabel_status.Text = "Loaded weights";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void testModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (model == null)
                {
                    throw new Exception("Files not selected!");
                }
                float confThreshold = 0.8f;
                float nmsThreshold = 0.4f;
                int imgDefaultSize = 416;

                Image<Bgr, byte> img = null;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image File(*.jpg;*.png;)|*.jpg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    img = new Image<Bgr, byte>(openFileDialog.FileName).Resize(imgDefaultSize, imgDefaultSize, Emgu.CV.CvEnum.Inter.Cubic);
                }
                var input = DnnInvoke.BlobFromImage(img, 1/255.0, swapRB: true);
                model.SetInput(input);
                model.SetPreferableBackend(Emgu.CV.Dnn.Backend.Cuda);
                model.SetPreferableTarget(Target.Cuda);

                VectorOfMat vectorOfMat = new VectorOfMat();
                model.Forward(vectorOfMat, model.UnconnectedOutLayersNames);
                VectorOfRect bboxes = new VectorOfRect();
                VectorOfFloat scores = new VectorOfFloat();
                VectorOfInt indices = new VectorOfInt();

                for (int k = 0; k < vectorOfMat.Size; k++)
                {
                    var mat = vectorOfMat[k];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
