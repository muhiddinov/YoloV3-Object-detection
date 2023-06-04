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
using Emgu.CV.CvEnum;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace YoloV3_Object_detection
{
    public partial class Form1 : Form
    {
        Net model = null;
        List<String> classLabels = null;
        VideoCapture capture = null;

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
                int imgDefaultSize = 416;
                Image<Bgr, byte> img = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image File(*.jpg;*.png;)|*.jpg;*.png;";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    img = new Image<Bgr, byte>(openFileDialog.FileName).Resize(imgDefaultSize, imgDefaultSize, Inter.Cubic);
                }
                pictureBox_View(img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void testModelFromWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int imgDefaultSize = 416;
                capture = new VideoCapture(0);
                capture.ImageGrabbed += Capture_ImageGrabbed;
                capture.Set(CapProp.FrameWidth, imgDefaultSize);
                capture.Set(CapProp.FrameHeight, imgDefaultSize);
                capture.Grab();
                capture.Start();
            }
            catch (Exception ex)
            {
                capture.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            try
            {
                Mat img = new Mat();
                capture.Retrieve(img);
                if (img.IsEmpty == false)
                {
                    pictureBox_View(img.ToImage<Bgr, byte>());
                } else
                {
                    throw new Exception("WebCam source not found!");
                }
            }
            catch (Exception ex)
            {
                capture.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox_View (Image<Bgr, byte> img)
        {
            try
            {
                float confThreshold = 0.8f;
                float nmsThreshold = 0.4f;
                var input = DnnInvoke.BlobFromImage(img, 1 / 255.0, swapRB: true);
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
                    var data = HelperClass.Arrayto2DList(mat.GetData());

                    for (int i = 0; i < data.Count; i++)
                    {
                        var row = data[i];
                        var rowscores = row.Skip(5).ToArray();
                        var classId = rowscores.ToList().IndexOf(rowscores.Max());
                        var confidence = rowscores[classId];

                        if (confidence >= confThreshold)
                        {
                            var center_x = row[0] * img.Width;
                            var center_y = row[1] * img.Height;

                            var width = (int)(row[2] * img.Width);
                            var height = (int)(row[3] * img.Height);

                            var x = (int)(center_x - (width / 2));
                            var y = (int)(center_y - (height / 2));
                            bboxes.Push(new Rectangle[] { new Rectangle(x, y, width, height) });
                            indices.Push(new int[] { classId });
                            scores.Push(new float[] { confidence });
                        }
                    }
                }
                var idx = DnnInvoke.NMSBoxes(bboxes.ToArray(), scores.ToArray(), confThreshold, nmsThreshold);
                for (int i = 0; i < idx.Length; i++)
                {
                    int index = idx[i];
                    var bbox = bboxes[index];
                    img.Draw(bbox, new Bgr(0, 0, 255), 2);
                    CvInvoke.PutText(img, classLabels[indices[index]], new Point(bbox.X, bbox.Y + 20),
                        FontFace.HersheySimplex, 1.0, new MCvScalar(0, 0, 255), 2);
                }
                byte[] bytes = img.ToJpegData();
                Image image = (Bitmap)(new ImageConverter().ConvertFrom(bytes));
                pictureBox_image.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
