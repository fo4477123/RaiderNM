using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSubstitute;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form,ICalculator
    {
        private ICalculator _calculator;
        public Form1()
        {
            InitializeComponent();
            _calculator = Substitute.For<ICalculator>();
        }

        string ICalculator.Mode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action PoweringUp;

        event Action ICalculator.PoweringUp
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public int Add(int a,int b)
        {
            return a + b;
        }


        [TestMethod]
        public void Test_GetStarted_ReturnSpecifiedValue()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);

            int actual = calculator.Add(1, 2);
            Assert.AreEqual<int>(3, actual);
        }

        int ICalculator.Add(int a, int b)
        {
            return a + b;
        }
    }


    public interface ICalculator
    {
        int Add(int a, int b);
        string Mode { get; set; }
        event Action PoweringUp;
    }
}
