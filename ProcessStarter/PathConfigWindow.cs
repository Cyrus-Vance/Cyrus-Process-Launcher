using ProcessStarter;
using ProcessStarter.GlobalSets;
using ProcessStarter.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServerStarter
{
    public partial class PathConfigWindow : Form
    {
        public MainForm _MainForm;

        private string[] pathData = new string[GlobalVariable.MAX_PATH];
        private string[] cmdLineData = new string[GlobalVariable.MAX_PATH];
        private bool[] enableData = new bool[GlobalVariable.MAX_PATH];
        private bool[] hideData = new bool[GlobalVariable.MAX_PATH];


        public PathConfigWindow()
        {
            InitializeComponent();

        }

        public PathConfigWindow(MainForm form): this()
        {
            _MainForm = form;
        }

        private void PathConfigWindow_Load(object sender, EventArgs e)
        {
            if (File.Exists(GlobalVariable.PathDBPath))
            {
                string countText = @"SELECT * FROM path ORDER BY id ASC;";
                DataTable alldt = SQLiteHelper.ExecuteDataSet(countText).Tables[0];
                AmountNumLabel.Text = Convert.ToString(alldt.Rows.Count);
                for (int i = 1; i <= alldt.Rows.Count; i++)
                {
                    EditData(i, alldt.Rows[i - 1]["path"].ToString(),
                        alldt.Rows[i - 1]["cmdline"].ToString(),
                        Convert.ToBoolean(alldt.Rows[i - 1]["enable"]),
                        Convert.ToBoolean(alldt.Rows[i - 1]["hide"]));
                }
                //selectNumBox.Text = IniFile.IniReadValue(GlobalString.cfgPthGlobal, GlobalString.cfgPthAmount, GlobalVariable.PathDBPath);
                ProgramPathText.Text = pathData[0];
                ProgramCmdLineText.Text = cmdLineData[0];
                EnableBox.Checked = enableData[0];
                HideBox.Checked = hideData[0];
            }
            else
            {
                AmountNumLabel.Text = "1";
            }
            GlobalVariable.SelectPathNum = Convert.ToInt32(selectNumBox.Value);
            selectNumBox.Maximum = Convert.ToInt32(AmountNumLabel.Text);
        }

        private void PathConfigWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseThisWindow();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = false;

            //先将当前数据存入内存
            EditData(GlobalVariable.SelectPathNum, ProgramPathText.Text, ProgramCmdLineText.Text, EnableBox.Checked, HideBox.Checked);
            
            //进行路径空值检测
            for(int i = 0; i < Convert.ToInt32(AmountNumLabel.Text); i++)
            {
                if (pathData[i].Equals(""))
                {
                    MessageBox.Show("您的第" + (i + 1) + "个启动目标尚未设置启动路径！", "存在空路径",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    selectNumBox.Value = i + 1;
                    SaveButton.Enabled = true;
                    return;
                }
            }

            if (!Directory.Exists(GlobalVariable.ConfigPathData)) System.IO.Directory.CreateDirectory(GlobalVariable.ConfigPathData);
            SQLiteConnection cn = new SQLiteConnection("Data Source =" + GlobalVariable.PathDBPath + ";version=3;");
            cn.Open();

            SQLiteCommand createTableCmd = new SQLiteCommand(cn)
            {
                CommandText = "CREATE TABLE IF NOT EXISTS path(" +
                "id integer primary key, " +
                "path text, " +
                "cmdline text, " +
                "enable integer(2), " +
                "hide integer(2)" +
                ");"
            };
            createTableCmd.ExecuteNonQuery();

            for (int i = 1; i <= Convert.ToInt32(AmountNumLabel.Text); i++)
            {
                //查询数据是否存在
                string commandText = @"select * from path where id ='" + Convert.ToString(i) + "';";
                DataTable dt = SQLiteHelper.ExecuteDataSet(commandText).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    //插入数据
                    SQLiteCommand insertDataCmd = new SQLiteCommand(cn)
                    {
                        CommandText = @"INSERT INTO path VALUES(" +
                        i + ", '" +
                        pathData[i - 1] + "', '" +
                        cmdLineData[i - 1] + "'," +
                        Convert.ToInt32(enableData[i - 1]) + "," +
                        Convert.ToInt32(hideData[i - 1]) + ");"
                    };
                    insertDataCmd.ExecuteNonQuery();
                    Debug.WriteLine("路径不存在于数据库中！");
                }
                //string path = dt.Rows[0]["path"].ToString();
                //更新数据
                SQLiteCommand updateDataCmd = new SQLiteCommand(cn)
                {
                    CommandText = @"UPDATE path SET path='" +
                    pathData[i - 1] + "', cmdline='" +
                    cmdLineData[i - 1] + "', enable=" +
                    Convert.ToInt32(enableData[i - 1]) + ", hide=" +
                    Convert.ToInt32(hideData[i - 1]) + " WHERE id=" + i + ";"
                };
                updateDataCmd.ExecuteNonQuery();
            }

            //同步数量数据到变量中
            GlobalVariable.PathAmount = Convert.ToInt32(AmountNumLabel.Text);
                
            //检查是否有多余项，如存在就删除
            DataTable dtlast = SQLiteHelper.ExecuteDataSet(@"SELECT * FROM path ORDER BY id DESC;").Tables[0];
            Debug.WriteLine("第一个查询到的ID为："+dtlast.Rows[0]["id"]);
            if (Convert.ToInt32(dtlast.Rows[0]["id"]) > GlobalVariable.PathAmount)
            {
                Debug.WriteLine("数目不匹配！");
                //删除数据
                for (int i = 1; i <= dtlast.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtlast.Rows[i - 1]["id"]) == GlobalVariable.PathAmount) break;
                    SQLiteCommand deleteDataCmd = new SQLiteCommand(cn)
                    {
                        CommandText = @"DELETE FROM path WHERE ID = " + dtlast.Rows[i - 1]["id"] + ";"
                    };
                    deleteDataCmd.ExecuteNonQuery();
                    Debug.WriteLine("已经删除id为" + dtlast.Rows[i - 1]["id"] + "的项！");
                }                   

            }
            else
            {
                Debug.WriteLine("数目匹配！");
            }
            cn.Close();

            //IniFile.IniWriteValue("Program2", "Path", Program2Path.Text,GlobalVariable.ConfigPath );
            //IniFile.IniWriteValue("Program2", "CmdLine", Program2CmdLine.Text,GlobalVariable.ConfigPath );        
            _MainForm.Addlog("路径数据库已经更新！", Color.Blue);
            CloseThisWindow();
        }

        private void BrowsePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Multiselect = false,//该值确定是否可以选择多个文件
                Title = "请选择程序路径",
                Filter = "所有文件(*.*)|*.*"
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                ProgramPathText.Text = file;
            }
        }

        private void CloseThisWindow()
        {
            Invoke((EventHandler)delegate
            {
                _MainForm.Visible = true;
                Close();
            });
        }

        private void EditData(int OperateNumber, string PathData, string CmdLineData, bool EnableData, bool HideData)
        {
            pathData[OperateNumber - 1] = PathData;
            cmdLineData[OperateNumber - 1] = CmdLineData;
            enableData[OperateNumber - 1] = EnableData;
            hideData[OperateNumber - 1] = HideData;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(AmountNumLabel.Text) < GlobalVariable.MAX_PATH)
            {
                int newNumber = Convert.ToInt32(AmountNumLabel.Text) + 1;
                AmountNumLabel.Text = Convert.ToString(newNumber);
                //设置新值
                EditData(newNumber, null, null, true, true);
                selectNumBox.Maximum = newNumber;
                selectNumBox.Value = selectNumBox.Maximum;

                //SelectNumChanged();
            }
            else
            {
                MessageBox.Show("您的当前许可只能设置最多" + GlobalVariable.MAX_PATH + "个启动目标！","达到许可上限",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void SelectNumBox_ValueChanged(object sender, EventArgs e)
        {
            //先保存老数据到数组里
            EditData(GlobalVariable.SelectPathNum, ProgramPathText.Text, ProgramCmdLineText.Text, EnableBox.Checked, HideBox.Checked);

            SelectNumUpdated();
        }

        private void SelectNumUpdated()
        {
            if (selectNumBox.Value <= selectNumBox.Maximum || selectNumBox.Value >= selectNumBox.Minimum)
            {
                int CurrentSelection = Convert.ToInt32(selectNumBox.Value) - 1;
                ProgramPathText.Text = pathData[CurrentSelection];
                ProgramCmdLineText.Text = cmdLineData[CurrentSelection];
                EnableBox.Checked = enableData[CurrentSelection];
                HideBox.Checked = hideData[CurrentSelection];
                GlobalVariable.SelectPathNum = Convert.ToInt32(selectNumBox.Value);
                Debug.WriteLine("当前Currentselection为：" + CurrentSelection);
            }
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            int CurrentSelectNumber = Convert.ToInt32(selectNumBox.Value);
            int TotalAmountNumber = Convert.ToInt32(AmountNumLabel.Text);
            if (TotalAmountNumber > 1)
            {
                if (CurrentSelectNumber == TotalAmountNumber)
                {
                    //如果是最后一个，直接清零最后一个的数据并且将总上限-1
                    int newNumber = CurrentSelectNumber - 1;
                    AmountNumLabel.Text = Convert.ToString(newNumber);
                    selectNumBox.Value = selectNumBox.Maximum - 1;
                    selectNumBox.Maximum -= 1;

                    EditData(CurrentSelectNumber, null, null, true, true);

                    Debug.WriteLine("删除对象是最后一个");
                }
                else
                {
                    /* 如果不是最后一个，就先从当前项的下一项开始所有项往前移并且清空最后一项的数据然后上限-1。
                     * 最后更新当前显示和old_SelectNumber */
                    for (int i = CurrentSelectNumber; i <= TotalAmountNumber - 1; i++)
                    {
                        EditData(i, pathData[i], cmdLineData[i], enableData[i], hideData[i]);
                    }
                    //清空最后一项
                    EditData(TotalAmountNumber, null, null, true, true);
                    //上限-1
                    AmountNumLabel.Text = Convert.ToString(Convert.ToInt32(AmountNumLabel.Text) - 1);
                    selectNumBox.Maximum -= 1;

                    SelectNumUpdated();
                    GlobalVariable.SelectPathNum = CurrentSelectNumber;
                    Debug.WriteLine("删除对象是第" + CurrentSelectNumber + "个");
                }
            }
            else
            {
                EditData(CurrentSelectNumber, null, null, true, true);
                SelectNumUpdated();
            }
        }

 
    }
}
