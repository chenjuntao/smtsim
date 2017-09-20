using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using System.Xml;
using Microsoft.Win32;

namespace SmtSim
{
    /// <summary>
    /// uc3d.xaml 的交互逻辑
    /// </summary>
    public partial class ucPCB3d : UserControl
    {
        private Transform3DGroup _transform;
        private ScaleTransform3D _scale = new ScaleTransform3D();
        private AxisAngleRotation3D _rotation = new AxisAngleRotation3D();
        private TranslateTransform3D _translate = new TranslateTransform3D();

        public ucPCB3d()
        {
            InitializeComponent();

            CreatePcbBoard();

            CreateComponents("Data\\demo1.eda");

            _transform = new Transform3DGroup();
            _transform.Children.Add(_scale);
            _transform.Children.Add(new RotateTransform3D(_rotation));
            _transform.Children.Add(_translate);
            PCBContainer.Transform = _transform;
        }

        #region BoardPnts

        //创建pcb板
        private void CreatePcbBoard()
        {
            GeometryModel3D geoModel3d = new GeometryModel3D();

            //创建pcb板子几何形状
            MeshGeometry3D mesh3d = new MeshGeometry3D();
            mesh3d.Positions = CreatePcbBoardPoints3D(30, 20, 1);
            mesh3d.TriangleIndices = CreatePcbBoardPointsIndices();
            geoModel3d.Geometry = mesh3d;

            //PCB表面材质
            MaterialGroup frontMaterialGroup = new MaterialGroup();          
            DiffuseMaterial material1 = new DiffuseMaterial(Brushes.DarkGreen);
            SpecularMaterial material2 = new SpecularMaterial(Brushes.Green,100);
            frontMaterialGroup.Children.Add(material1);
            frontMaterialGroup.Children.Add(material2);
            geoModel3d.Material = frontMaterialGroup;

            // //PCB背面材质
            DiffuseMaterial backMaterial = new DiffuseMaterial(Brushes.Gray);
            geoModel3d.BackMaterial = backMaterial;

            ModelUIElement3D pcbUIEle3d = new ModelUIElement3D();
            pcbUIEle3d.Model = geoModel3d;

            PCBContainer.Children.Add(pcbUIEle3d);
        }

        private Point3DCollection CreatePcbBoardPoints3D(double length, double width,double depth)
        {
            Point3DCollection pcbBoardPoints3D = new Point3DCollection(20);
            Point3D point;
            //top of the pcbBoard
            point = new Point3D(-length, 0, width);// pcbBoard Index - 0
            pcbBoardPoints3D.Add(point);
            point = new Point3D(length, 0, width);// pcbBoard Index - 1
            pcbBoardPoints3D.Add(point);
            point = new Point3D(length, 0, -width);// pcbBoard Index - 2
            pcbBoardPoints3D.Add(point);
            point = new Point3D(-length, 0, -width);// pcbBoard Index - 3
            pcbBoardPoints3D.Add(point);
            //front side
            point = new Point3D(-length, 0, width);// pcbBoard Index - 4
            pcbBoardPoints3D.Add(point);
            point = new Point3D(-length, -depth, width);// pcbBoard Index - 5
            pcbBoardPoints3D.Add(point);
            point = new Point3D(length, -depth, width);// pcbBoard Index - 6
            pcbBoardPoints3D.Add(point);
            point = new Point3D(length, 0, width);// pcbBoard Index - 7
            pcbBoardPoints3D.Add(point);
            //right side
            point = new Point3D(length, 0, width);// pcbBoard Index - 8
            pcbBoardPoints3D.Add(point);
            point = new Point3D(length, -depth, width);// pcbBoard Index - 9
            pcbBoardPoints3D.Add(point);
            point = new Point3D(length, -depth, -width);// pcbBoard Index - 10
            pcbBoardPoints3D.Add(point);
            point = new Point3D(length, 0, -width);// pcbBoard Index - 11
            pcbBoardPoints3D.Add(point);
            //back side
            point = new Point3D(length, 0, -width);// pcbBoard Index - 12
            pcbBoardPoints3D.Add(point);
            point = new Point3D(length, -depth, -width);// pcbBoard Index - 13
            pcbBoardPoints3D.Add(point);
            point = new Point3D(-length, -depth, -width);// pcbBoard Index - 14
            pcbBoardPoints3D.Add(point);
            point = new Point3D(-length, 0, -width);// pcbBoard Index - 15
            pcbBoardPoints3D.Add(point);
            //left side
            point = new Point3D(-length, 0, -width);// pcbBoard Index - 16
            pcbBoardPoints3D.Add(point);
            point = new Point3D(-length, -depth, -width);// pcbBoard Index - 17
            pcbBoardPoints3D.Add(point);
            point = new Point3D(-length, -depth, width);// pcbBoard Index - 18
            pcbBoardPoints3D.Add(point);
            point = new Point3D(-length, 0, width);// pcbBoard Index - 19
            pcbBoardPoints3D.Add(point);

            return pcbBoardPoints3D;
        }

        private Int32Collection CreatePcbBoardPointsIndices()
        {
            int[] indices = new int[] { 0, 1, 2, 0, 2, 3, 4, 5, 7, 5, 6, 7, 8, 9, 11, 9, 10, 11, 12, 13, 15, 13, 14, 15, 16, 17, 19, 17, 18, 19 };
            Int32Collection pcbBoardPointsIndices = new Int32Collection(indices);
            return pcbBoardPointsIndices;
        }

        #endregion

        //创建元器件
        private void CreateComponents(string filePath)
        {
            XmlDocument pcbXml = new XmlDocument();
            if (System.IO.File.Exists(filePath))
            {
                pcbXml.Load(filePath);
                for (int i = 0; i < pcbXml.DocumentElement.ChildNodes.Count; i++)
                {
                    XmlNode node = pcbXml.DocumentElement.ChildNodes[i];
                    string type = node.Attributes["type"].Value;
                    double x = double.Parse(node.Attributes["x"].Value);
                    double y = double.Parse(node.Attributes["y"].Value);
                    double z = double.Parse(node.Attributes["z"].Value);
                    double angle = double.Parse(node.Attributes["angle"].Value);
                    ModelBase modelbase = new ModelBase(type);
                    this.PCBContainer.Children.Add(modelbase);
                    modelbase.Move(x, y, z, angle);
                    modelbase.MouseDown += pcbComponent_MouseDown;
                }
            }
        }

        #region 平移
        private void moveUp_Click(object sender, RoutedEventArgs e)
        {
            _translate.OffsetZ -= 2;
        }

        private void moveDown_Click(object sender, RoutedEventArgs e)
        {
            _translate.OffsetZ += 2;
        }

        private void moveLeft_Click(object sender, RoutedEventArgs e)
        {
            _translate.OffsetX -= 2;
        }

        private void moveRight_Click(object sender, RoutedEventArgs e)
        {
            _translate.OffsetX += 2;
        }

        #endregion

        #region 缩放
        private void scaleInc_Click(object sender, RoutedEventArgs e)
        {
            _scale.ScaleX *= 1.1;
            _scale.ScaleY *= 1.1;
            _scale.ScaleZ *= 1.1;
        }

        private void scaleDesc_Click(object sender, RoutedEventArgs e)
        {
            _scale.ScaleX *= 0.9;
            _scale.ScaleY *= 0.9;
            _scale.ScaleZ *= 0.9;
        }

        #endregion

        //恢复到默认视角
        private void defaultView_Click(object sender, RoutedEventArgs e)
        {
            _translate.OffsetX = 0;
            _translate.OffsetZ = 0;
            _scale.ScaleX = 1;
            _scale.ScaleY = 1;
            _scale.ScaleZ = 1;

            trackballDecorator1.Reset();
        }

        //打开EDA文件
        private void openEDA_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "打开EDA文件";
            openFileDialog.Filter = "EDA文件|*.eda";
            openFileDialog.InitialDirectory = "Data\\Save_EDA";
            if ((bool)openFileDialog.ShowDialog())
            {
                PCBContainer.Children.Clear();
                CreatePcbBoard();
                CreateComponents(openFileDialog.FileName);
            }
        }

        //打开EDA文件
        private void clearData_Click(object sender, RoutedEventArgs e)
        {
            PCBContainer.Children.Clear();
            CreatePcbBoard();
        }

        //鼠标点击显示信息
        private void pcbComponent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Released && e.LeftButton == MouseButtonState.Pressed)
            {
                Point location = e.GetPosition(myViewport);

                ModelBase model = sender as ModelBase;
                TranslateTransform3D translateTrans = new TranslateTransform3D(0, 0, 0);
                (model.Transform as Transform3DGroup).Children.Add(translateTrans);

                DoubleAnimation animation = new DoubleAnimation();
                animation.To = 5;
                animation.DecelerationRatio = 1;
                animation.Duration = TimeSpan.FromSeconds(1);
                animation.AutoReverse = true;
                translateTrans.BeginAnimation(TranslateTransform3D.OffsetYProperty, animation);
            }
        }

        //模拟贴片过程
        private void mounter_Click(object sender, RoutedEventArgs e)
        {
            Storyboard stroy = new Storyboard();
        }
    }
}
